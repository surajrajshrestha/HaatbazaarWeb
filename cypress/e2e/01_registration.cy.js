/// <reference types="cypress" />
describe("Registration Page", () => {
  it("should successfully register a new member", () => {
    // Generate unique email based on timestamp
    const timestamp = new Date().getTime();
    const email = `cypress-tester-${timestamp}@test.com`;

    // Visit the registration page and assert the page content is loaded successfully.
    cy.visit("http://localhost:5077/login/register");
    cy.contains("h4", "Register a new membership")
      .should("exist")
      .and("be.visible");
     
    // Fill out the registration form and submit
    cy.get("#FirstName")
      .should("exist")
      .should("be.visible")
      .type("CY First Name");
    cy.get("#LastName")
      .should("exist")
      .should("be.visible")
      .type("CY Last Name");
    cy.get("#PhoneNumber")
      .should("exist")
      .should("be.visible")
      .type("9860106879");
    cy.get("#Email").should("exist").should("be.visible").type(email);
    cy.get("#Password").should("exist").should("be.visible").type("CyTest123!");
    cy.get("#flexCheckDefault").should("exist").should("be.visible").check();
    cy.get("button[type=submit]").should("be.visible").click();
  });

  it("should check for the validation message if any", () => {
    // Visit the registration page and assert the page content is loaded successfully.
    cy.visit("http://localhost:5077/login/register");
    cy.contains("h4", "Register a new membership")
      .should("exist")
      .and("be.visible");
     
    // Fill out the the first name and leave the phone number field empty
    cy.get("#FirstName")
      .should("exist")
      .should("be.visible")
      .type("CY First Name");
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
