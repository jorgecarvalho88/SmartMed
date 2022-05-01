Feature: Get list of medications 

@getAll
Scenario: Successfully Get list of medications
	When  I submit a GET request /Medications
	Then I receive a response
	And the http response status is OK