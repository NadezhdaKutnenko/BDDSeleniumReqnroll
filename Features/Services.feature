Feature: EPAM website Services functionality
 As an EPAM website user
 I want to navigate to a specific Core Service from the Services page 
 and verify each page contains the section ‘Our Related Expertise’.

  Scenario Outline: Check navigation and the section existence for a specific service
	Given I navigate to the EPAM website
	And I accept cookies
    When I navigate to the Services page
    And I select the "<service>" from the "Our Core Services" section
    Then the page title should display the "<service>" service
    And the "Our Related Expertise" section should be displayed

  Examples:
    | service         |
    | Strategy        |
    | Cybersecurity   |
