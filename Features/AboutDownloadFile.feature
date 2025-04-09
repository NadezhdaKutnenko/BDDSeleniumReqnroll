Feature: EPAM website File download functionality
  As an EPAM website user
 I want to download a file on the About page

Scenario: Download a file on the About page
	Given I navigate to the EPAM website
	And I accept cookies
	When I navigate to the About page
	And I download the "<fileName>" file
	Then the file "<fileName>" is downloaded successfully
    
Examples:
	| fileName                              |
	| EPAM_Corporate_Overview_Q4FY-2024.pdf |
