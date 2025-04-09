Feature: EPAM website Carousel Article functionality
  As an EPAM website user
 I want to verify that the article displayed on the Insights carousel matches the article page 
 after clicking "Read More".

  Scenario: Check carousel article title against article page title
	Given I navigate to the EPAM website
	And I accept cookies
    When I navigate to the Insights page
    And I swipe the carousel to the next item
    And I get the carousel article title
    And I click the "Read More" button
	And I get the article page title
    Then the carousel article title should match the article page title
