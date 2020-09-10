# FiscalBr.NET [![Travis (.com) branch](https://img.shields.io/travis/com/osamueloliveira/fiscalbr.net/master)](https://travis-ci.com/github/osamueloliveira/FiscalBr.NET) [![GitHub issues](https://img.shields.io/github/issues/osamueloliveira/fiscalbr.net)](https://github.com/osamueloliveira/FiscalBr.NET/issues) [![GitHub](https://img.shields.io/github/license/osamueloliveira/fiscalbr.net)](https://github.com/osamueloliveira/FiscalBr.NET/blob/master/LICENSE)
[![Nuget](https://img.shields.io/nuget/v/FiscalBr.Common?color=red&label=Common)](https://www.nuget.org/packages/FiscalBr.Common/) [![Nuget](https://img.shields.io/nuget/v/FiscalBr.Dimob?label=Dimob)](https://www.nuget.org/packages/FiscalBr.Dimob/) [![Nuget](https://img.shields.io/nuget/v/FiscalBr.Sintegra?label=Sintegra)](https://www.nuget.org/packages/FiscalBr.Sintegra/) [![Nuget](https://img.shields.io/nuget/v/FiscalBr.EFDContribuicoes?label=EFDContribuicoes)](https://www.nuget.org/packages/FiscalBr.EFDContribuicoes/) [![Nuget](https://img.shields.io/nuget/v/FiscalBr.EFDFiscal?label=EFDFiscal)](https://www.nuget.org/packages/FiscalBr.EFDFiscal/) [![Nuget](https://img.shields.io/nuget/v/FiscalBr.ECF?label=ECF)](https://www.nuget.org/packages/FiscalBr.ECF/)

###### SITE OFICIAL DO SPED: http://sped.rfb.gov.br/
Biblioteca gratuita  - desenvolvida com Visual Studio Community 2019 - para geração dos arquivos SPED e demais declarações necessárias no cenário contábil/fiscal brasileiro.

## TODO

- [ ] Implementar Factory Pattern.
- [ ] Mapear enums restantes do SPED.
- [ ] Implementar leitura dos layouts.
- [ ] Melhorar performance na geração das linhas.

## Apoiadores [![Donate](https://img.shields.io/badge/apoia.se-FiscalBr-green)](https://apoia.se/fiscalbr)

Se as bibliotecas lhe ajudaram ou contribuiram de alguma forma, apoie. :D Ajude a dar continuidade nesse projeto.

###### Últimos Apoios

[@rodrigofornasier](https://github.com/rodrigofornasier)

## Declarações

###### Projeto SPED

- [x] EFD Fiscal (ICMS/IPI)
- [x] EFD Contribuições (PIS/COFINS)
- [x] Escrituração Contábil Fiscal (ECF)
- [ ] Escrituração Contábil Digital (ECD)

###### Outras

- [x] DIMOB
- [x] SINTEGRA

## Exemplos

###### EFD Contribuições

- Exemplo de Preenchimento do Bloco F - Registro 200

```cs
var listaLinhasArquivo = new List<string>();

var competencia = new DateTime(dataInicial.Year, dataInicial.Month, 1);

var listaContratos = ObtemListaContratosNoPeriodo(dataInicial, dataFinal);

var totalLinhasF200 = 0;

/* Cada contrato imobiliário gera um registro F200 */
foreach (var objContrato in listaContratos) {
  var registroF200 = new BlocoF.EfdContribRegF200 {
    // Preenche informações
  };

  /* adiciona nas linhas do arquivo */
  listaLinhasArquivo.Add(registroF200.EscreverCampos(competencia));
  totalLinhasF200++;
}
```

## Dúvidas?

Abra um issue na página do projeto no GitHub ou [clique aqui](https://github.com/osamueloliveira/FiscalBr.NET/issues).

## Licença

[MIT](https://github.com/osamueloliveira/FiscalBr.NET/blob/master/LICENSE)
