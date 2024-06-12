// Add class when input field is focused
$("#searchInput").focus(function () {
    $('body').addClass("focused");
});

// Remove class when input field loses focus
$("#searchInput").blur(function () {
    $('body').removeClass("focused");
});

var map = L.map("map").setView([27.6928855, 85.3192919], 13);

L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    maxZoom: 19,
    attribution: "© OpenStreetMap"
}).addTo(map);

function updateLocation(dummyLocations, radius) {
    var lat = 27.6928855;
    var lon = 85.3192919;

    map.eachLayer(function (layer) {
        if (layer instanceof L.Marker || layer instanceof L.Circle) {
            map.removeLayer(layer);
        }
    });

    // Set the map view to the custom location
    map.setView([lat, lon], 15);

    var marker = L.circleMarker([lat, lon], {
        color: "red",
        fillColor: "#f03",
        fillOpacity: 1,
        radius: 10
    }).addTo(map);

    var circle = L.circle([lat, lon], {
        color: "red",
        fillColor: "transparent",
        fillOpacity: 0.2,
        radius: radius * 1000
    }).addTo(map);

    $.each(dummyLocations, function (index, location) {
        var distance = map.distance([lat, lon], [location.latitude, location.longitude]);
        if (distance <= radius * 1000) {
            var dummyMarker = L.marker([location.latitude, location.longitude])
                .addTo(map)
                .bindPopup(
                    "<div class='product_image--small'><img src='https://images.unsplash.com/photo-1573196444577-af471298e034'></div>" +
                    "Within " + radius + " km radius" +
                    "<br>Product: " + location.product +
                    "<br>Quantity: " + location.quantity +
                    "<br>Price: " + location.price +
                    "<br><br><a href='/'>Connect</a>"
                )
                .openPopup();
        }
    });
}

$(document).ready(function () {
    $("#searchForm").submit(function (event) {
        event.preventDefault(); // Prevent the default form submission

        var searchTerm = $("#searchInput").val();
        var selectedRadius = $("#radiusSelect").val(); // Get the selected radius

        if (searchTerm.trim() !== "") {
            $.ajax({
                url: "https://localhost:7048/api/Search?searchItem=" + searchTerm,
                method: "GET",
                contentType: "application/json",
                success: function (data) {
                    console.log(data);
                    if (data.length > 0) {
                        updateLocation(data, selectedRadius); // Pass the selected radius
                    } else {
                        alert("No results found for the search term.");
                    }
                },
                error: function (err) {
                    console.error("Error fetching data: ", err);
                }
            });
        } else {
            alert("Please enter a search term.");
        }
    });
});