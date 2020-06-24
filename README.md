# FiscalBr.NET
###### SITE OFICIAL DO SPED: http://sped.rfb.gov.br/
Biblioteca gratuita  - desenvolvida com Visual Studio Community 2017 - para geração dos arquivos SPED e demais declarações necessárias no cenário contábil/fiscal brasileiro.

## Doações [![Donate](https://img.shields.io/badge/Doações-Doare-ff69b4.svg)](http://doa.re/k3jpt)

Se o projeto lhe ajudou ou contribuiu de alguma forma, faça uma doação. :D Ajude a dar continuidade nesse projeto.

## TODO

- [ ] Implementar Factory Pattern para facilitar uso da biblioteca.
- [ ] Mapear enums restantes do SPED e implementar leitura dos layouts.
- [ ] Mapear registros restantes da EFD Contribuições. [#28](https://github.com/samuelrochaoliveira/SPEDBr/issues/28)
- [ ] Melhorar performance na geração das linhas, monitorar tempo da geração.

## Sumário

- [Declarações](#declaracoes)
- [Outros](#outros)
- [Exemplos](#exemplos)
- [Dúvidas?](#dúvidas)
- [Colaboradores](#colaboradores)

## Declarações

###### Projeto SPED

- [x] EFD ICMS/IPI
- [x] EFD Contribuições
- [ ] Escrituração Contábil Fiscal (ECF)
- [ ] Escrituração Contábil Digital (ECD)

###### Outras

- [x] DIMOB (Concluído em 02/05/2016)

## Outros
- [x] [SINTEGRABr](https://github.com/samuelroliveira/SINTEGRABr)
- [ ] [FISCALBr](https://github.com/samuelroliveira/FiscalBr)

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

## Colaboradores

AutoCom - Microplan Automação Comercial Ltda - MG
- Eduardo Moreira
- Bruno Novaes - (33) 3331-5808
- Whashington Reis