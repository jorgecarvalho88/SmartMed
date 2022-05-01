Feature: Create new medication

@create
Scenario: Successfully Create medication
	When  I submit a POST request /Medications
	| Name     | Quantity |
	| Vigantol | 5        |
	Then I receive a response
	And the http response status is OK
	And the response content is valid
