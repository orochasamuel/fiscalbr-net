[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/orochasamuel/fiscalbr-net/dotnet.yml)](https://github.com/orochasamuel/fiscalbr-net/actions/workflows/dotnet.yml)
# FiscalBr.NET [![Build Status](https://github.com/orochasamuel/fiscalbr-net/actions/workflows/dotnet.yml/badge.svg)](https://github.com/orochasamuel/fiscalbr-net/actions/workflows/dotnet.yml) [![GitHub issues](https://img.shields.io/github/issues/orochasamuel/fiscalbr.net)](https://github.com/orochasamuel/FiscalBr.NET/issues) [![TODOs](https://badgen.net/https/api.tickgit.com/badgen/github.com/orochasamuel/fiscalbr-net)](https://www.tickgit.com/browse?repo=github.com/orochasamuel/fiscalbr-net) [![GitHub](https://img.shields.io/github/license/orochasamuel/fiscalbr.net)](https://github.com/orochasamuel/FiscalBr.NET/blob/master/LICENSE)
[![Nuget](https://img.shields.io/nuget/v/FiscalBr.Common?color=red&label=Common)](https://www.nuget.org/packages/FiscalBr.Common/) [![Nuget](https://img.shields.io/nuget/v/FiscalBr.Dimob?label=Dimob)](https://www.nuget.org/packages/FiscalBr.Dimob/) [![Nuget](https://img.shields.io/nuget/v/FiscalBr.ECF?label=ECF)](https://www.nuget.org/packages/FiscalBr.ECF/) [![Nuget](https://img.shields.io/nuget/v/FiscalBr.EFDContribuicoes?label=EFD%20Contribuições)](https://www.nuget.org/packages/FiscalBr.EFDContribuicoes/) [![Nuget](https://img.shields.io/nuget/v/FiscalBr.EFDFiscal?label=EFD%20Fiscal)](https://www.nuget.org/packages/FiscalBr.EFDFiscal/)  [![Nuget](https://img.shields.io/nuget/v/FiscalBr.Sintegra?label=Sintegra)](https://www.nuget.org/packages/FiscalBr.Sintegra/)

###### SITE OFICIAL DO SPED: http://sped.rfb.gov.br/
Biblioteca gratuita  - desenvolvida com Visual Studio Community 2022 - para geração dos arquivos SPED e demais declarações necessárias no cenário contábil/fiscal brasileiro.

## EFD Fiscal [![Nuget](https://img.shields.io/nuget/v/FiscalBr.EFDFiscal?label=EFD%20Fiscal)](https://www.nuget.org/packages/FiscalBr.EFDFiscal/)

### Instalação
```bash
$ dotnet add package FiscalBr.EFDFiscal --version 17.0.1
```
OU
```bash
$ NuGet\Install-Package FiscalBr.EFDFiscal -Version 17.0.1
```

### Modo de usar
```cs
public class MeuGeradorSped
{
    public void GerarArquivo()
    {
        var efdFiscal = new ArquivoEFDFiscal();

        // Preencher arquivo...
        if (efdFiscal.Bloco0 is null)
            efdFiscal.Bloco0 = new FiscalBr.EFDFiscal.Bloco0();

        if (efdFiscal.Bloco0.Reg0000 is null)
            efdFiscal.Bloco0.Reg0000 = new FiscalBr.EFDFiscal.Bloco0.Registro0000();

        efdFiscal.Bloco0.Reg0000.Nome = "EMPRESA ABC";

        // Gerar linhas 1 única vez, após preencher as informações
        efdFiscal.GerarLinhas();

        // Acesse os erros em
        var errosGerados = efdFiscal.Erros;

        // Acesse as linhas geradas em
        var linhasGeradas = efdFiscal.Linhas;

        // Enjoy \o/
    }
}
```

## Gostou? Me paga um café :D [![Coffee](https://img.shields.io/badge/buy%20me%20a-coffee-yellow)](https://www.buymeacoffee.com/orochasamuel)

Se as bibliotecas lhe ajudaram ou contribuiram de alguma forma, apoie. :D Ajude a dar continuidade nesse projeto.

## Dúvidas? [![GitHub issues](https://img.shields.io/github/issues/orochasamuel/fiscalbr-net)](https://github.com/orochasamuel/fiscalbr-net/issues)

Abra um issue na página do projeto no GitHub ou [clique aqui](https://github.com/orochasamuel/fiscalbr-net/issues).

## Licença [![GitHub](https://img.shields.io/github/license/orochasamuel/fiscalbr-net)](https://github.com/orochasamuel/fiscalbr-net/blob/master/LICENSE)

[MIT](https://github.com/orochasamuel/fiscalbr-net/blob/master/LICENSE)
