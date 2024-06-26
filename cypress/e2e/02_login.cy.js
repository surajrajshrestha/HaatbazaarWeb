/// <reference types="cypress" />
describe("Login Page", () => {
  it("should successfully allow user to login in the system", () => {
    // Visit the login page and assert the page content is loaded successfully.
    cy.visit("/login/login");
    cy.contains("h3", "Login").should("exist").and("be.visible");

    // Fill out the Login form and submit
    cy.get("#PhoneNumber")
      .should("exist")
      .should("be.visible")
      .type("9860106879");
    cy.get("#Password").should("exist").should("be.visible").type("CyTest123!");
    cy.get("button[type=submit]").should("be.visible").click();
  });

  it("should throw an validation error for empty phone number", () => {
    // Visit the login page and assert the page content is loaded successfully.
    cy.visit("/login/login");
    cy.contains("h3", "Login").should("exist").and("be.visible");

    // Leave the Phone number field empty and submit
    cy.get("#PhoneNumber")
      .should("exist")
      .should("be.visible")
    cy.get("#Password").should("exist").should("be.visible").type("CyTest123!");
    cy.get("button[type=submit]").should("be.visible").click();

    // Assert that the validation message is shown for the phone field
    cy.get("#PhoneNumber").then(($el) => {
      if ($el[0].validationMessage) {
        cy.wrap($el[0].validationMessage).should(
          "equal",
          "Please fill out this field."
        );
      }
    });
  });
});
