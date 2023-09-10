using FiscalBr.Common.ValueObjects;
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
        [InlineData("123")]
        [InlineData("123456")]
        [InlineData("123456789")]
        [InlineData("12345678900")]
        public void ValidarCpfInvalidoTest(string cpf)
        {
            FiscalBr.Common.Tipos.Cpf cpfAtual = cpf;

            Assert.False(cpfAtual.EhValido);
        }

        [Theory]
        [InlineData("68486046076")] // https://www.4devs.com.br/gerador_de_cpf
        public void ValidarCpfValidoTest(string cpf)
        {
            FiscalBr.Common.Tipos.Cpf cpfAtual = cpf;

            Assert.True(cpfAtual.EhValido);
        }

        [Theory]
        [InlineData("")]
        [InlineData("01234567000899")]
        public void ValidarCnpjInvalidoTest(string cnpj)
        {
            FiscalBr.Common.Tipos.Cnpj cnpjAtual = cnpj;

            Assert.False(cnpjAtual.EhValido);
        }

        [Theory]
        [InlineData("00000000000191")]
        public void ValidarCnpjValidoTest(string cnpj)
        {
            FiscalBr.Common.Tipos.Cnpj cnpjAtual = cnpj;

            Assert.True(cnpjAtual.EhValido);
        }

        [Theory]
        [InlineData("68486046076")] // https://www.4devs.com.br/gerador_de_cpf
        [InlineData("00000000000191")]
        public void ValidarCpfCnpjTest(string cpfCnpj)
        {
            FiscalBr.Common.ValueObjects.CpfCnpj cpfCnpjAtual = cpfCnpj;

            Assert.True(cpfCnpjAtual.EhValido);
        }

        [Fact]
        public void ValidarIgualdadeCpfValidoTest()
        {
            CpfCnpj one = "68486046076";
            CpfCnpj two = "68486046076";

            Assert.True(EqualityComparer<CpfCnpj>.Default.Equals(one, two)); // True
            Assert.True(object.Equals(one, two)); // True
            Assert.True(one.Equals(two)); // True
            Assert.True(one == two); // True
        }

        [Fact]
        public void ValidarIgualdadeCpfInvalidoTest()
        {
            CpfCnpj one = "12345678900";
            CpfCnpj two = "12345678900";

            Assert.True(EqualityComparer<CpfCnpj>.Default.Equals(one, two)); // True
            Assert.True(object.Equals(one, two)); // True
            Assert.True(one.Equals(two)); // True
            Assert.True(one == two); // True
        }

        [Fact]
        public void ValidarIgualdadeCnpjValidoTest()
        {
            CpfCnpj one = "00000000000191";
            CpfCnpj two = "00000000000191";

            Assert.True(EqualityComparer<CpfCnpj>.Default.Equals(one, two)); // True
            Assert.True(object.Equals(one, two)); // True
            Assert.True(one.Equals(two)); // True
            Assert.True(one == two); // True
        }

        [Fact]
        public void ValidarIgualdadeCnpjInvalidoTest()
        {
            CpfCnpj one = "01234567000899";
            CpfCnpj two = "01234567000899";

            Assert.True(EqualityComparer<CpfCnpj>.Default.Equals(one, two)); // True
            Assert.True(object.Equals(one, two)); // True
            Assert.True(one.Equals(two)); // True
            Assert.True(one == two); // True
        }
    }
}
