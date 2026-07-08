Feature: Search CEP
  As a user of the Correios system
  I want to search for a CEP
  So that I can get the corresponding address

Scenario: Full Correios E2E Flow
  Given I access the CEP search service
  When I search for the CEP "80700000"
  Then I should confirm the CEP does not exist
  And I return to the start page
  When I search for the CEP "01013-001"
  Then the address should contain "Rua Quinze de Novembro, São Paulo/SP"
  And I return to the start page
  When I go to the tracking page
  And I search for the tracking code "SS987654321BR"
  Then I should confirm the tracking code is invalid
  Then I close the browser