// Add class when input field is focused
$("#searchInput").focus(function () {
    $('body').addClass("focused");
});

// Remove class when input field loses focus
$("#searchInput").blur(function () {
    $('body').removeClass("focused");
});

var map = L.map("map").setView([27.7765405,85.3463452], 13);

L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    maxZoom: 19,
    attribution: "© OpenStreetMap"
}).addTo(map);

function updateLocation(dummyLocations, radius) {
    var lat = 27.7765405;
    var lon = 85.3463452;

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

    var totalQuantity = 0; 
    var price= 0;
    var avgPrice = 0;
    var location = 0;
    $.each(dummyLocations, function (index, location) {
        location++;
        var distance = map.distance([lat, lon], [location.latitude, location.longitude]);
        if (distance <= radius * 1000) {
            var dummyMarker = L.marker([location.latitude, location.longitude])
                .addTo(map)
                .bindPopup(
                    "<div class='product_image--small'><img src='https://images.unsplash.com/photo-1573196444577-af471298e034'></div>" +
                    "Within " + radius + " km radius" +
                    "<br>Product: " + location.product +
                    "<br>Quantity: " + location.quantity + location.unit +
                    "<br>Price: " + location.price +
                    "<br><br><a href='/'>Connect</a>"
                )
                .openPopup();
                var lq = location.quantity;
                totalQuantity += lq;
                console.log(dummyLocations.length);
                //avg price
                price += location.price;
                console.log(price);
                avgPrice = price/dummyLocations.length;
                
        }
    });
    console.log(totalQuantity);
    $(".suggestion-box").html("Total Quantity: " + totalQuantity + "<br>Avg Price: " + dummyLocations.length);
}

$(document).ready(function () {
    $("#searchForm").submit(function (event) {
        event.preventDefault(); // Prevent the default form submission

        var searchTerm = $("#searchInput").val();
        var selectedRadius = $("#radiusSelect").val(); // Get the selected radius

        if (searchTerm.trim() !== "") {
            $.ajax({
                url: "https://blueprintapp.azurewebsites.net/api/Search?searchItem=" + searchTerm,
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