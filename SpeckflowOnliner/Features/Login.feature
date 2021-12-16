Feature: Authorization

Scenario: Proceed the login functionality successfully
	Given The login page is opened
	When Valid credentials are entered 
	And The enter button is pushed
	Then User's profile is appeared

Scenario: Logout of the system successully
	Given A user logs in with valid credentials 
	When The user attempts to logout 
	Then User's profile is disappeared