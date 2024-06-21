//geo.test.js
/// <reference types="cypress" />
function mockLocation(latitude, longitude) {
  return {
    onBeforeLoad(win) {
      cy.stub(win.navigator.geolocation, "getCurrentPosition").callsFake(
        (cb, err) => {
          if (latitude && longitude) {
            return cb({ coords: { latitude, longitude } });
          }

          throw err({ code: 1 });
        }
      );
    },
  };
}

describe("Mock Geo Location", () => {
  it.only("Geo ßßßLocation Test", () => {
    // cy.visit("https://whatmylocation.com/", mockLocation(27.769532, 85.362510));
    cy.visit("http://localhost:5077/");
    cy.get('[title="Zoom out"]').should("exist").should("be.visible");
    cy.get("#searchInput")
      .should("exist")
      .should("be.visible")
      .type("Potato", {});
    cy.get("#radiusSelect").select("9999");
    cy.intercept("Search?searchItem=Potato").as("searchPotato");
    cy.get("button[type=submit]").should("be.visible").click();
    cy.wait("@searchPotato").its("response.statusCode").should("eq", 200);
    cy.get('[title="Zoom out"]')
      .click()
      .click()
      .click()
      .click()
      .click()
      .click();
    cy.wait(2000);
    cy.get("img.leaflet-marker-icon")
      .should("be.visible")
      .first()
      .click({ force: true });

    cy.get("div.leaflet-popup div.leaflet-popup-content")
      .should("be.visible")
      .then(($div) => {
        cy.wrap($div).should("include.text", "Product: Potato");
        cy.wrap($div)
          .find("a:contains(Connect):visible")
          .should("exist")
          .click();
      });
  });
});

describe("template spec", () => {
  it("passes", () => {
    cy.visit("http://localhost:5077/");
  });
});
