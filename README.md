# Correios Automation

## Descrição

Projeto de automação de testes desenvolvido em **C#**, **.NET 8**,
**SpecFlow**, **NUnit** e **Selenium WebDriver** para validar
funcionalidades do portal dos Correios.

## Objetivo

Automatizar os seguintes cenários:

-   Buscar um CEP inexistente (`80700000`) e validar a mensagem de erro.
-   Buscar um CEP válido (`01013-001`) e validar o endereço **Rua Quinze
    de Novembro, São Paulo/SP**.
-   Validar um código de rastreamento inválido (`SS987654321BR`).

## Tecnologias

-   .NET 8
-   C#
-   Selenium WebDriver
-   SpecFlow (BDD)
-   NUnit
-   ChromeDriver

## Estrutura

    CorreiosAutomation/
    ├── Features/
    ├── StepDefinitions/
    ├── Pages/
    ├── Drivers/
    ├── Hooks/
    ├── Helpers/
    ├── TestData/
    ├── appsettings.json
    └── CorreiosAutomation.csproj

## Padrão de Projeto

O projeto utiliza: - Page Object Model (POM) - BDD com SpecFlow - Hooks
para inicialização e encerramento do navegador - Separação entre
Features, Steps e Pages

## Cenários Automatizados

### Busca de CEP inexistente

1.  Acessar o portal dos Correios.
2.  Informar o CEP `80700000`.
3.  Validar a mensagem de CEP não encontrado.

### Busca de CEP válido

1.  Retornar à tela inicial.
2.  Informar o CEP `01013-001`.
3.  Validar o endereço retornado.

### Rastreamento

1.  Acessar a área de rastreamento.
2.  Informar `SS987654321BR`.
3.  Validar a mensagem de código inválido.

## Localizadores utilizados

-   ID
-   CSS Selector
-   XPath

## Executando o projeto

### Restaurar dependências

``` bash
dotnet restore
```

### Executar testes

``` bash
dotnet test
```

## Boas práticas

-   Centralização dos seletores nas Pages.
-   Reutilização de componentes.
-   Esperas explícitas.
-   Captura de evidências em falhas.
-   Código organizado para integração com Azure DevOps, GitHub Actions
    ou Jenkins.

## Autor - MAURICIO MONTEIRO

Projeto desenvolvido como avaliação técnica de automação de testes
utilizando C# + SpecFlow + NUnit.
