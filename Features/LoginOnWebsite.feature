Feature: Login on website

A short summary of the feature

@basiclogin
Scenario: Step 1
	Given I have navigated to the website
	When I input my username and password
	And I press login
	Then I end up on the IdentityNow dashboard
@basicviewpossiblerequest
Scenario: Step 2
	Given I am logged in on the website
	When I press request center
	Then I can request accesses
@requestaccessprofile
Scenario: Step 3
	Given User is logged in and on the request center
	When User request the VPN Consultant access profile
	Then User sends request to manager
@approverequest
Scenario: Step 4
	Given Manager is logged in
	When Manager sees that user has requested access
	Then Manager approves the access request

@adminapproval
Scenario: Step 5
	Given Admin is logged in
	Then Admin approves the access request

@request
Scenario: Step 6
	Given Manager is logged in
	When Manager access her team
	And Manager goes to user
	Then Manager request the removal of VPN Consultant from user
