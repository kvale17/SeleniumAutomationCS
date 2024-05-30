Feature: User

  Background:
    * def userData = 
    """
    {
      "firstName": "Kevin",
      "lastName": "Valencia",
      "id": "1"
    }
    """
    * def baseUrl = 'https://6595c1f104335332df833e0a.mockapi.io/test/Users'

  Scenario: Add User
    Given url baseUrl
    And request { "firstName": #(userData.firstName), "lastName": #(userData.lastName) }
    When method post
    Then status 201
    And match response == userData

  Scenario: Get User
    Given url baseUrl + '/' + userData.id
    When method get
    Then status 200
    And match response == userData

  Scenario: Delete User
    Given url baseUrl + '/' + userData.id
    When method delete
    Then status 200
    And match response == userData