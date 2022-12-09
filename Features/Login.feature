Feature: Login
	Verify the login is working for correct credentials

Scenario Outline: Verify user can successfully login to the system
	Given user in the login page
	When user enter '<UserName>', '<Password>' and clicks on the login button
	Then user navigate to home page
Examples:
	| UserName            | Password   |
	| ta3862989@gmail.com | !QAZ2wsx!@ |
	| abcd@gmail.com      | 123456789  |