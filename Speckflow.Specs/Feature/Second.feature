Feature: Параметризированные тесты

    Scenario: Параметризация шагов
        Given browser is opened
        * the login page is opened
        When user ""atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        Then the title is "All Projects - TestRail"