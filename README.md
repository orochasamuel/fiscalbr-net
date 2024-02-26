<div align="center">

# <a id="title" /> FiscalBr.NET
[![Build Status](https://img.shields.io/github/actions/workflow/status/orochasamuel/fiscalbr-net/build-and-test)](https://github.com/orochasamuel/fiscalbr-net/actions/workflows/build-and-test.yml) [![GitHub issues](https://img.shields.io/github/issues/orochasamuel/fiscalbr-net)](https://github.com/orochasamuel/fiscalbr-net/issues) [![GitHub](https://img.shields.io/github/license/orochasamuel/fiscalbr-net)](https://github.com/orochasamuel/fiscalbr-net/blob/master/LICENSE)

###### http://sped.rfb.gov.br/
Biblioteca gratuita para geração dos arquivos SPED e demais declarações necessárias no cenário contábil/fiscal brasileiro.

###### Precisa de ajuda para começar? Então [clique aqui](https://github.com/orochasamuel/fiscalbr-net/issues/115).

</div>

## <a id="brother-project" /> Conheça também o FiscalBrJS

[FiscalBrJS](https://github.com/orochasamuel/fiscalbr-js) é uma biblioteca feita em TypeScript para auxiliar na escrita e leitura dos arquivos SPED.

## <a id="table-of-contents" /> 📖 Conteúdo

- [SPED](#sped)
- [Instalação](#instalacao)
  - [EFD Contribuições](#sped-efd-contribuicoes)
    - [Instalação](#sped-efd-contribuicoes-instalacao)
    - [Modo de usar](#sped-efd-contribuicoes-modo-de-usar)
  - [EFD Fiscal](#sped-efd-fiscal)
    - [Instalação](#sped-efd-fiscal-instalacao)
    - [Modo de usar](#sped-efd-fiscal-modo-de-usar)
- [Apoie :D](#buy-me-a-coffee)
- [Dúvidas](#need-help)
- [Licença](#license)

## <a id="sped" /> SPED

O Sistema Público de Escrituração Digital (SPED), é o sistema criado pelo governo federal para o recebimento de informações fiscais e contábeis das empresas.

## <a id="instalacao" /> 💿 Instalação

O pacote `FiscalBr.Common` é o core do projeto, todos os outros pacotes dependem deste. Veja a lista de pacotes disponíveis abaixo: 

<div align="center">
  
| Pacote | Nuget | Downloads |
|--------|-------|-----------|
| [FiscalBr.Common](https://www.nuget.org/packages/FiscalBr.Common/)<br><small>É o Core do projeto</small> | [![FiscalBr.Common](https://img.shields.io/nuget/v/FiscalBr.Common?color=red&label=Common)](https://www.nuget.org/packages/FiscalBr.Common/) | [![NuGet](https://img.shields.io/nuget/dt/FiscalBr.Common.svg)](https://www.nuget.org/packages/FiscalBr.Common/) |
| [FiscalBr.Dimob](https://www.nuget.org/packages/FiscalBr.Dimob/)<br><small>Registros da DIMOB</small> | [![FiscalBr.Dimob](https://img.shields.io/nuget/v/FiscalBr.Dimob?color=green&label=Dimob)](https://www.nuget.org/packages/FiscalBr.Dimob/) | [![NuGet](https://img.shields.io/nuget/dt/FiscalBr.Dimob.svg)](https://www.nuget.org/packages/FiscalBr.Dimob/) |
| [FiscalBr.ECF](https://www.nuget.org/packages/FiscalBr.ECF/)<br><small>Blocos e Registros da ECF (Escrituração Contábil Fiscal)</small> | [![FiscalBr.ECF](https://img.shields.io/nuget/v/FiscalBr.ECF?color=blue&label=ECF)](https://www.nuget.org/packages/FiscalBr.ECF/) | [![NuGet](https://img.shields.io/nuget/dt/FiscalBr.ECF.svg)](https://www.nuget.org/packages/FiscalBr.ECF/) |
| [FiscalBr.EFDContribuicoes](https://www.nuget.org/packages/FiscalBr.Contribuicoes/)<br><small>Blocos e Registros da EFD Contribuições (antigo SPED Pis/Cofins)</small> | [![FiscalBr.EFDContribuicoes](https://img.shields.io/nuget/v/FiscalBr.EFDContribuicoes?color=orange&label=EFDContribuicoes)](https://www.nuget.org/packages/FiscalBr.EFDContribuicoes/) | [![NuGet](https://img.shields.io/nuget/dt/FiscalBr.EFDContribuicoes.svg)](https://www.nuget.org/packages/FiscalBr.EFDContribuicoes/) |
| [FiscalBr.EFDFiscal](https://www.nuget.org/packages/FiscalBr.EFDFiscal/)<br><small>Blocos e Registros da EFD Fiscal (SPED ICMS/IPI)</small> | [![FiscalBr.EFDFiscal](https://img.shields.io/nuget/v/FiscalBr.EFDFiscal?color=orange&label=EFDFiscal)](https://www.nuget.org/packages/FiscalBr.EFDFiscal/) | [![NuGet](https://img.shields.io/nuget/dt/FiscalBr.EFDFiscal.svg)](https://www.nuget.org/packages/FiscalBr.EFDFiscal/) |
| [FiscalBr.Sintegra](https://www.nuget.org/packages/FiscalBr.Sintegra/)<br><small>Registros do Sintegra</small> | [![FiscalBr.Sintegra](https://img.shields.io/nuget/v/FiscalBr.Sintegra?color=yellow&label=Sintegra)](https://www.nuget.org/packages/FiscalBr.Sintegra/) | [![NuGet](https://img.shields.io/nuget/dt/FiscalBr.Sintegra.svg)](https://www.nuget.org/packages/FiscalBr.Sintegra/) |

</div>

<p align="right">(<a href="#title">voltar para o topo</a>)</p>

## <a id="sped-efd-contribuicoes" /> EFD Contribuições [![FiscalBr.EFDContribuicoes](https://img.shields.io/nuget/v/FiscalBr.EFDContribuicoes?color=orange&label=EFDContribuicoes)](https://www.nuget.org/packages/FiscalBr.EFDContribuicoes/)

### <a id="sped-efd-contribuicoes-instalacao" /> Instalação
```sh
 dotnet add package FiscalBr.EFDContribuicoes --version 6.1.0
```
OU
```sh
 NuGet\Install-Package FiscalBr.EFDContribuicoes -Version 6.1.0
```

<p align="right">(<a href="#title">voltar para o topo</a>)</p>

### <a id="sped-efd-contribuicoes-modo-de-usar" /> Modo de usar
```cs
public class MeuGeradorSped
{
    public void GerarArquivo()
    {
        var efdContribuicoes = new ArquivoEFDContribuicoes();

        // Preencher arquivo...
        if (efdContribuicoes.Bloco0 is null)
            efdContribuicoes.Bloco0 = new FiscalBr.EFDContribuicoes.Bloco0();

        if (efdContribuicoes.Bloco0.Reg0000 is null)
            efdContribuicoes.Bloco0.Reg0000 = new FiscalBr.EFDContribuicoes.Bloco0.Registro0000();

        efdContribuicoes.Bloco0.Reg0000.Nome = "EMPRESA ABC";

        // Gerar linhas 1 única vez, após preencher as informações
        efdContribuicoes.GerarLinhas();

        // Acesse os erros em
        var errosGerados = efdContribuicoes.Erros;

        // Acesse as linhas geradas em
        var linhasGeradas = efdContribuicoes.Linhas;

        // Enjoy \o/
    }
}
```

<p align="right">(<a href="#title">voltar para o topo</a>)</p>

## <a id="sped-efd-fiscal" /> EFD Fiscal [![FiscalBr.EFDFiscal](https://img.shields.io/nuget/v/FiscalBr.EFDFiscal?color=orange&label=EFDFiscal)](https://www.nuget.org/packages/FiscalBr.EFDFiscal/)

### <a id="sped-efd-fiscal-instalacao" /> Instalação
```sh
 dotnet add package FiscalBr.EFDFiscal --version 17.1.0
```
OU
```sh
 NuGet\Install-Package FiscalBr.EFDFiscal -Version 17.1.0
```

<p align="right">(<a href="#title">voltar para o topo</a>)</p>

### <a id="sped-efd-fiscal-modo-de-usar" /> Modo de usar
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

<p align="right">(<a href="#title">voltar para o topo</a>)</p>

## <a id="buy-me-a-coffee" /> Gostou? Me paga um café :D

Se as bibliotecas lhe ajudaram ou contribuiram de alguma forma, apoie. :D Ajude a dar continuidade nesse projeto.

<div align="center">
  
<a href="https://nubank.com.br/pagar/4jklf/N5Nz6ZCJ6d">
  <img src="https://github.com/orochasamuel/fiscalbr-net/assets/15462690/a951abc7-a7ac-4e7d-86fb-68c63017c2e7" width="400" height="400">
</a>

</div>

<p align="right">(<a href="#title">voltar para o topo</a>)</p>

## <a id="need-help" /> Dúvidas? [![GitHub issues](https://img.shields.io/github/issues/orochasamuel/fiscalbr-net)](https://github.com/orochasamuel/fiscalbr-net/issues)

Abra um issue na página do projeto no GitHub ou [clique aqui](https://github.com/orochasamuel/fiscalbr-net/issues).

<p align="right">(<a href="#title">voltar para o topo</a>)</p>

## <a id="license" /> Licença [![GitHub](https://img.shields.io/github/license/orochasamuel/fiscalbr-net)](https://github.com/orochasamuel/fiscalbr-net/blob/master/LICENSE)

[MIT](https://github.com/orochasamuel/fiscalbr-net/blob/master/LICENSE)

<p align="right">(<a href="#title">voltar para o topo</a>)</p>
