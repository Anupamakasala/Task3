Feature: TestCases

A short summary of the feature

@tag1
Scenario: 01) Registration for the Portal
	Given I entered the required credentials to join the LocalHost 
	When I clicked on the Join Button
	Then It Navigates me to the LocalHost HomePage 
	And I Successfully Registered as a new User
	
Scenario: 02) Login into the Portal
    Given I entered my credentials for Login 
    When  I clicked on the Login Button
    Then  It Navigates me to the Profile page
	And  I Successfully Logged into the Portal

Scenario: 03) Load More Notifications under the Notification Menu
    Given  I Logged into the LocalHost successfully
    When  I clicked on the Notification dropdown menu
    And  I clicked on the See All Button 
    Then  It navigates me to the notification page
    When  I clicked on the LoadMore button at the bottom
    Then  All the Notifications displayed on the page

Scenario: 04) Show Less Notifications under the Notification Menu
    Given I Logged into the LocalHost successfully
    When I clicked on the Notification dropdown menu
    And I clicked on the See All Button
    When I clicked on the ShowLess button at the bottom
    Then Only Few Latest notifications displayed on the page