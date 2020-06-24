# FiscalBr.NET
###### SITE OFICIAL DO SPED: http://sped.rfb.gov.br/
Biblioteca gratuita  - desenvolvida com Visual Studio Community 2017 - para gera��o dos arquivos SPED e demais declara��es necess�rias no cen�rio cont�bil/fiscal brasileiro.

## Doa��es [![Donate](https://img.shields.io/badge/Doa��es-Doare-ff69b4.svg)](http://doa.re/k3jpt)

Se o projeto lhe ajudou ou contribuiu de alguma forma, fa�a uma doa��o. :D Ajude a dar continuidade nesse projeto.

## TODO

- [ ] Implementar Factory Pattern para facilitar uso da biblioteca.
- [ ] Mapear enums restantes do SPED e implementar leitura dos layouts.
- [ ] Mapear registros restantes da EFD Contribui��es. [#28](https://github.com/samuelrochaoliveira/SPEDBr/issues/28)
- [ ] Melhorar performance na gera��o das linhas, monitorar tempo da gera��o.

## Sum�rio

- [Declara��es](#declaracoes)
- [Outros](#outros)
- [Exemplos](#exemplos)
- [D�vidas?](#d�vidas)
- [Colaboradores](#colaboradores)

## Declara��es

###### Projeto SPED

- [x] EFD ICMS/IPI
- [x] EFD Contribui��es
- [ ] Escritura��o Cont�bil Fiscal (ECF)
- [ ] Escritura��o Cont�bil Digital (ECD)

###### Outras

- [x] DIMOB (Conclu�do em 02/05/2016)

## Outros
- [x] [SINTEGRABr](https://github.com/samuelroliveira/SINTEGRABr)
- [ ] [FISCALBr](https://github.com/samuelroliveira/FiscalBr)

## Exemplos

###### EFD Contribui��es

- Exemplo de Preenchimento do Bloco F - Registro 200

```cs
var listaLinhasArquivo = new List<string>();

var competencia = new DateTime(dataInicial.Year, dataInicial.Month, 1);

var listaContratos = ObtemListaContratosNoPeriodo(dataInicial, dataFinal);

var totalLinhasF200 = 0;

/* Cada contrato imobili�rio gera um registro F200 */
foreach (var objContrato in listaContratos) {
  var registroF200 = new BlocoF.EfdContribRegF200 {
    // Preenche informa��es
  };

  /* adiciona nas linhas do arquivo */
  listaLinhasArquivo.Add(registroF200.EscreverCampos(competencia));
  totalLinhasF200++;
}
```

## D�vidas?

Abra um issue na p�gina do projeto no GitHub ou [clique aqui](https://github.com/osamueloliveira/FiscalBr.NET/issues).

## Colaboradores

AutoCom - Microplan Automa��o Comercial Ltda - MG
- Eduardo Moreira
- Bruno Novaes - (33) 3331-5808
- Whashington Reis