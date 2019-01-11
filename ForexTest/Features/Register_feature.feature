Feature: Register_feature
	In order to register
	As a new trader
	I want to be register into the website

@mytag
Scenario: Succesful Register
	Given User is at home page
	And user click signup button 
	When user enter email'test7@yopmail.com' and password '123456'
	And Click on the checkbox button
	And Click on the register button
	Then Succesful register message should display

Scenario: Register for existing user
	Given User is at home page
	And user click signup button 
	When user enter email'test1@yopmail.com' and password '123456'
	And Click on the checkbox button
	And Click on the register button
	Then user should see an error message




