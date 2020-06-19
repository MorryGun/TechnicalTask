Feature: Provider Creator
	As an automation quality assurancу engineer
	I want to complete the technical task
	So I get the job

Background: 
	Given the user logged into the system
	And the user navigated to the Provider Creation form

@HappyPath
Scenario: Check that country name picked is shown on Medical license country drop-down
	Given the user clicks on Add License button
	And the user clicks on Medical license country drop-down
	When the user picks Austria from Medical license country drop-down
	Then Austria is displayed on Medical license country drop-down

@NegativeScenario
Scenario: Check that no country name is shown on Medical license country drop-down if no country is chosen
	Given the user clicks on Add License button
	And the user clicks on Medical license country drop-down
	When the user picks Medical School field
	Then no country name is displayed on Medical license country drop-down
