Feature: Busca CEP
Scenario: Fluxo Correios
Given que acesso o portal dos Correios
When pesquiso o CEP "80700000"
Then deve apresentar mensagem que o CEP não existe
