Feature: Начальный тест для изучения SpecFlow
    
    Scenario: Простой тест без тела
        
    Scenario: Простой тест с Given
        Given открыт браузер
        
    Scenario: Простой тест с Given и When
        Given открыт браузер
        When страница логина открыта
        
    Scenario: Простой тест со всеми ключевыми словами 1
        Given открыт браузер
        When страница логина открыта
        Then поле username отображается
        
    Scenario: Простой тест со всеми ключевыми словами 2
        When страница логина открыта
        Then поле username отображается
        
    Scenario: Использование And
        Given открыт браузер
        And страница логина открыта
        Then поле username отображается
        * поле password отображается
        

    
    

