namespace FiscalBr.Common.ModeloAuxiliar
{
    public class ErroLinha
    {
        public int Numero { get; private set; }
        public string Conteudo { get; private set; }
        public string MensagemExcecao { get; private set; }

        public ErroLinha(int numero, string conteudo, string mensagemExcecao)
        {
            Numero = numero;
            Conteudo = conteudo;
            MensagemExcecao = mensagemExcecao;
        }
    }
}
