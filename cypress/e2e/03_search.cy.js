/// <reference types="cypress" />
describe("Search Page", () => {
  it("should allow Buyer to successfully search for 'Potato', handle results, and navigate using links in pop-up", () => {
    // login with valid user credentials
    login("9860106879", "test1234")

    // Visit the Search page and assert the page content is loaded success full.
    cy.visit("/");
    cy.get('[title="Zoom out"]').should("exist").should("be.visible");
    cy.contains("button", "Login").should("not.exist");

    // Type Potato in the search box and select the radius
    cy.get("#searchInput")
      .should("exist")
      .should("be.visible")
      .type("Potato", {});
    cy.get("#radiusSelect").select("20");

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

    // Assert that the user is on the Connection Page.
    cy.url().should("include", "/connection");
    cy.contains("div", "Potato").should("exist").and("be.visible");
    cy.contains("span", "Buyer Detail").should("exist").and("be.visible");
    cy.get('[data-id="seller-section"]')
      .should("be.visible")
      .and("include.text", "Seller Details");

    // Proceed to the Buy the given product
    cy.get('[data-id="buy-now"]').should("be.visible").click();
  });

  it("should allow Seller to look into the avaible orders placed by User. ", () => {
    // login with valid user credentials
    login("9860106879", "test1234")

    // Visit the Search page and assert the page content is loaded success full.
    cy.visit("/");
    cy.get('[title="Zoom out"]').should("exist").should("be.visible");
    cy.contains("button", "Login").should("not.exist");

    // Type Potato in the search box and select the radius
    cy.get("#searchInput")
      .should("exist")
      .should("be.visible")
      .type("Potato", {});
    cy.get("#radiusSelect").select("20");

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

    // Assert that the user is on the Connection Page.
    cy.url().should("include", "/connection");
    cy.contains("div", "Potato").should("exist").and("be.visible");
    cy.contains("span", "Buyer Detail").should("exist").and("be.visible");
    cy.get('[data-id="seller-section"]')
      .should("be.visible")
      .and("include.text", "Seller Details");

    // Proceed to the Buy the given product
    cy.get('[data-id="buy-now"]').should("be.visible").click();
  });
});

const login = (phone, password) => {
  // Visit the login page and assert the page content is loaded successfully.
  cy.visit("/login/login");
  cy.contains("h3", "Login").should("exist").and("be.visible");
  cy.contains("button", "Login").should("exist");
  // Fill out the Login form and submit
  cy.get("#PhoneNumber").should("exist").should("be.visible").type(phone);
  cy.get("#Password").should("exist").should("be.visible").type(password);
  cy.get("button[type=submit]").should("be.visible").click();
};
