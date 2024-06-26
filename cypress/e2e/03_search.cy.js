/// <reference types="cypress" />
describe("Search Page", () => {
  it("Should successfully search for 'Potato', handle results, and navigate using links in pop-up", () => {
    // Visit the Search page and assert the page content is loaded success full. 
    cy.visit("http://localhost:5077/");
    cy.get('[title="Zoom out"]').should("exist").should("be.visible");

    // Type Potato in the search box and select the radius
    cy.get("#searchInput")
      .should("exist")
      .should("be.visible")
      .type("Potato", {});
    cy.get("#radiusSelect").select("9999");

    // Intecept the API Call to wait unit is comes back with result
    cy.intercept("Search?searchItem=Potato").as("searchPotato");
    // Submit the button.
    cy.get("button[type=submit]").should("be.visible").click();
    // Assert the API call comes back with 200 statusCode. 
    cy.wait("@searchPotato").its("response.statusCode").should("eq", 200);

    // Click on the Zoom out button and wait for pin points to appear.
    cy.get('[title="Zoom out"]')
      .click()
      .click()
      .click()
      .click()
      .click()
      .click();
    cy.wait(2000);
    
    // Click on the first pin point and make sure the Content on the popup is visible
    cy.get("img.leaflet-marker-icon")
      .should("be.visible")
      .first()
      .click({ force: true });
    cy.get("div.leaflet-popup div.leaflet-popup-content")
      .should("be.visible")
      .then(($div) => {
        cy.wrap($div).should("include.text", "Product: Potato");

        // click on the Connect button
        cy.wrap($div)
          .find("a:contains(Connect):visible")
          .should("exist")
          .click();
      });
  });
});
