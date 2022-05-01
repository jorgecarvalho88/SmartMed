Feature: Delete medication

@delete
Scenario: Successfully delete medication
	When  I submit a DELETE request /Medications
	Then I receive a response
	And the http response status is OK
	And the response content is valid
