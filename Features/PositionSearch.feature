Feature: EPAM website Position Search Functionality
 As an EPAM website user
 I want to perform a search on the Careers page based on keywords and locations

Scenario Outline: Perform Position search and check that the job description contains the keyword
	Given I navigate to the EPAM website
	And I accept cookies
    When I navigate to the Careers page
    And I search for positions with "<keyword>" in "<location>"
    Then the job description of the last search result should contain "<keyword>"

  Examples:
    | keyword  | location       |
    | Java     | All Locations  |
    | Python   | All Locations  |
