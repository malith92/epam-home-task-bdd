Feature: Email Operations

User can draft and send emails

Background: 
	Given user logged into the home page

Scenario: Draft and send emails
	When user creates a draft email
	Then drafted email is present in the drafts
	Then drafted email should have the correct receiver, subject, body
	When user sends the email
	Then email should dissapear from drafts
	Then sent email is present in the sent section
