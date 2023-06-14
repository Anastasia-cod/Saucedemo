Feature: Login
    
    @GUI
    Scenario: Login to the TestRail with valid credentials
        Given new browser is opened
        * a login page is displayed
        When the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        Then dashboard page is opened        