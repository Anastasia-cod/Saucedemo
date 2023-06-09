Feature: Problems
    
    @GUI @GeneralUser
    Scenario: Using different defs classes 1
        Given new browser is opened
        * a login page is displayed
        * the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        Then settings page is opened
        
   @GeneralUser
    Scenario: Using different defs classes 2
        Given new browser is opened
        * a login page is displayed
        * the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        Then settings page is opened