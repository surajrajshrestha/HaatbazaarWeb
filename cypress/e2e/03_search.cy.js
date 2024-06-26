/// <reference types="cypress" />
describe("Search Page", () => {
  it("should allow the Buyer to search for 'Potato', handle results, navigate links in the pop-up, and place an order", () => {
    // login with valid user credentials
    login("9860106879", "test1234");

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
    // cy.get('[data-id="seller-section"]')
    cy.get("span:contains(Seller Detail)")
      .should("be.visible")
      .and("include.text", "Seller Detail");

    // Proceed to the Buy the given product
    // cy.get('[data-id="buy-now"]').should("be.visible").click();
    cy.get("button", "Buy").should("be.visible").click();
    cy.url().should("include", "/connection?connectionId=");
    // Use cy.location() to get the current URL
    cy.location().then((location) => {
      const searchParams = new URLSearchParams(location.search);
      const connectionId = searchParams.get("connectionId");

      // Log the connectionId to the console
      cy.log(connectionId).as("connectionID");
    });
  });

  it("should allow the Seller to view available orders placed by the User and approve them", () => {
    // login with valid user credentials
    login("9860106879", "test1234");
    // Visit the Search page and assert the page content is loaded success full.
    cy.visit("/");
    cy.get('[title="Zoom out"]').should("exist").should("be.visible");
    cy.contains("button", "Login").should("not.exist");

    cy.get("@connectionID").then((connID) => {
      // go to the order item
      cy.visit(`/connection?connectionID=${connID}`);
    });
    cy.contains("div", "Potato").should("exist").and("be.visible");
    cy.contains("span", "Buyer Detail").should("exist").and("be.visible");
    // cy.get('[data-id="seller-section"]')
    cy.get("span:contains(Seller Detail)")
      .should("be.visible")
      .and("include.text", "Seller Detail");

    // clicks on approve button
    cy.get("button:contains(Approve)").should("be.visible").click();
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
