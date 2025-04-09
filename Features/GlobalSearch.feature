Feature: EPAM website Search Functionality
 As an EPAM website user
 I want to perform a search on the main page 

Scenario Outline: Perform a search on the Epam website
	Given I navigate to the EPAM website
	And I accept cookies
	When I search for "<searchText>"
    Then all search results should contain "<searchText>"

Examples:
	| searchText |
	| Automation |
	| Cloud      |
