Feature: Параметризированные тесты
    
    Scenario: Параметризация шагов
        Given browser is opened
        * the login page is opened
        When user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        Then the title is "All Projects - TestRail"
        * project ID is 123
        
    Scenario Outline: Parametrizazia with table of values
        Given browser is opened
        * the login page is opened
        When user "<username>" with password "<password>" logged in
        Then the title is "All Projects - TestRail"
        * project ID is <id>
        
        Examples:
        | username              | password  | id  |
        | atrostyanko@gmail.com | Qwertyu_1 | 123 |
        | atrostyanko@gmail.com | Qwertyu_1 | 456 |
        
    Scenario Template: Parametrizazia with table of values Template
        Given browser is opened
        * the login page is opened
        When user "<username>" with password "<password>" logged in
        Then the title is "All Projects - TestRail"
        * project ID is <id>
        
        Examples:
          | username              | password  | id  |
          | atrostyanko@gmail.com | Qwertyu_1 | 123 |
          | atrostyanko@gmail.com | Qwertyu_1 | 456 |
        
    Scenario Outline: Parametrizazia with table of values 3
        Given browser is opened
        * the login page is opened
        When user "<username>" with password "<password>" logged in
        Then the title is "All Projects - TestRail"
        * project ID is <id>
        
        Examples:
          | username              | password  | id  |
          | atrostyanko@gmail.com | Qwertyu_1 | 123 |
          | atrostyanko@gmail.com | Qwertyu_1 | 456 |