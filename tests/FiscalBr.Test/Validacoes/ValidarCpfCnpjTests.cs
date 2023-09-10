using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalBr.Test.Validacoes
{
    public class ValidarCpfCnpjTests
    {
        [Theory]
        [InlineData("")]
        public void ValidarCpfTest(string cpf) {

            FiscalBr.Common.Tipos.Cpf cpfAtual = cpf;

            Assert.False(cpfAtual.EhValido);
        }

        [Theory]
        [InlineData("00000000000191")]
        public void ValidarCnpjTest(string cnpj)
        {

            FiscalBr.Common.Tipos.Cnpj cnpjAtual = cnpj;

            Assert.True(cnpjAtual.EhValido);
        }
    }
}
