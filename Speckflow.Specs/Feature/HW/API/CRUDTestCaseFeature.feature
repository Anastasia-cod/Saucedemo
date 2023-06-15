Feature: Create TestCase
    
    @API
    Scenario Outline: Add Case Test
        Given the API client is initialized
        When a new case is added with title "BDD New Test Case Anastasiya was created as part of API Test in bdd behaviour" sectionId "1" templateId "1" typeId "8" priorityId "3" and estimate "2d"
        Then the added case should match the expected details
    
    @API    
#        Why I get here Request failed with status code BadRequest (0,4s)?
    Scenario: Update Case Test
        Given the API client is initialized
        And a new case is added with title "Add Case For Update" sectionId "1" templateId "1" typeId "6" priorityId "2" and estimate "1h"
        When the case is updated with new details
        Then the updated case should match the expected details
        
    @API
    Scenario: Delete Case Test
        Given the API client is initialized
        And a new case is added with title "Add Case For Delete" sectionId "1" templateId "1" typeId "5" priorityId "1" and estimate "2h"
        When the case is deleted
        Then the case should be deleted 