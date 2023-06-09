Feature: Use a background
    
    Background: System preparation steps (background)
        Given browser is opened
        * the login page is opened
        
    Scenario: Test something positive
        When user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        Then the title is "All Projects - TestRail"
        
    Scenario: Test something negative
        When user "atrostyanko@gmail.com" with password "Qwertyu_2" logged in
        Then the title is "Login - TestRail"
