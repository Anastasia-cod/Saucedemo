Feature: Create Project
    
    @GUI   
    Scenario: Creating project in TestRail
        Given new browser is opened
        * a login page is displayed
        When the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        * dashboard page is opened 
        * the current user switched to add project page
        * entered in the name field "Anastasiya Project Test 2 - bdd"
        * clicked the add project button
        Then the new project is displayed

          