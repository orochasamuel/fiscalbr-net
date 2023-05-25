# Como usar a DLL de validação da IE?

- Copie a DLL "DllInscE32.dll" para o diretório "Windows/System".
- Crie a chamada do método no seu sistema.
- Enjoy o/

```cs

    public static class Utils
    {
        /// <summary>
        /// Verifica a consistência da inscrição estadual
        /// </summary>
        /// <param name="vInsc">Número da I.E.</param>
        /// <param name="vUF">UF da I.E.</param>
        /// <returns>0 - Válido; 1 - Inválido</returns>
        [DllImport("DllInscE32.dll")]
        public static extern int ConsisteInscricaoEstadual(string vInsc, string vUF);
    }

    // Chamada do método
    var result = Utils.ConsisteInscricaoEstadual(inscricaoEstadual, uf);
    // 0 - Inscrição é válida
    // 1 - Inscrinção inválida

```

Fonte: acesse o site do [Sintegra](http://www.sintegra.gov.br/) na seção Downloads.
