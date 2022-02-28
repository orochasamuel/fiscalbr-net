using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped
{
    public class RegistroBaseSped
    {
        [SpedCampos(1, "REG", "C", 4, 0, true, 2)]
        public string Reg { get; set; }

        public static object GetPropValue(object src, string propName)
        {
            var property = src.GetType().GetProperty(propName);
            var propertyType = property.PropertyType;

            var propertyValue = property.GetValue(src, null);

            if (propertyType.IsEnum)
                propertyValue = GetEnumDefaultValueByType(propertyType, propertyValue);

            return propertyValue;
        }

        public static string GetEnumDefaultValueByType(Type type, object value)
        {
            /*
             * https://stackoverflow.com/questions/50604295/how-to-get-default-value-of-an-enum-from-a-type-variable
             */
            var enumObj = Enum.ToObject(type, value) as Enum;

            return enumObj.ToDefaultValue();

            #region OLD ENUM CHECK

            if (type == typeof(CodigoVersaoLeiaute))
                return ((CodigoVersaoLeiaute)value).ToDefaultValue();

            if (type == typeof(SimOuNao))
                return ((SimOuNao)value).ToDefaultValue();

            if (type == typeof(IndMovimento))
                return ((IndMovimento)value).ToDefaultValue();

            if (type == typeof(IndCodFinalidadeArquivo))
                return ((IndCodFinalidadeArquivo)value).ToDefaultValue();

            if (type == typeof(IndPerfilArquivo))
                return ((IndPerfilArquivo)value).ToDefaultValue();

            if (type == typeof(IndTipoAtividade))
                return ((IndTipoAtividade)value).ToDefaultValue();

            if (type == typeof(ClassEstabIndustrial))
                return ((ClassEstabIndustrial)value).ToDefaultValue();

            if (type == typeof(IndCodMod))
                return ((IndCodMod)value).ToDefaultValue();

            if (type == typeof(IndTipoItem))
                return ((IndTipoItem)value).ToDefaultValue();

            if (type == typeof(IndTipoMercadoria))
                return ((IndTipoMercadoria)value).ToDefaultValue();

            if (type == typeof(IndNaturezaConta))
                return ((IndNaturezaConta)value).ToDefaultValue();

            if (type == typeof(IndTipoConta))
                return ((IndTipoConta)value).ToDefaultValue();

            if (type == typeof(IndTipoOperacaoProduto))
                return ((IndTipoOperacaoProduto)value).ToDefaultValue();

            if (type == typeof(IndTipoOperacaoServico))
                return ((IndTipoOperacaoServico)value).ToDefaultValue();

            if (type == typeof(IndEmitente))
                return ((IndEmitente)value).ToDefaultValue();

            if (type == typeof(IndCodSitDoc))
                return ((IndCodSitDoc)value).ToDefaultValue();

            if (type == typeof(IndTipoPagamento))
                return ((IndTipoPagamento)value).ToDefaultValue();

            if (type == typeof(IndTipoFrete))
                return ((IndTipoFrete)value).ToDefaultValue();

            if (type == typeof(IndTipoOperacaoStUfDiversa))
                return ((IndTipoOperacaoStUfDiversa)value).ToDefaultValue();

            if (type == typeof(IndOrigemProcesso))
                return ((IndOrigemProcesso)value).ToDefaultValue();

            if (type == typeof(IndCodModDocArrecadacao))
                return ((IndCodModDocArrecadacao)value).ToDefaultValue();

            if (type == typeof(IndTipoTransporte))
                return ((IndTipoTransporte)value).ToDefaultValue();

            if (type == typeof(IndDocumentoImportacao))
                return ((IndDocumentoImportacao)value).ToDefaultValue();

            if (type == typeof(IndTipoTituloCred))
                return ((IndTipoTituloCred)value).ToDefaultValue();

            if (type == typeof(IndPeriodoApuracaoIpi))
                return ((IndPeriodoApuracaoIpi)value).ToDefaultValue();

            if (type == typeof(IndMovFisicaItem))
                return ((IndMovFisicaItem)value).ToDefaultValue();

            if (type == typeof(IndBaseProdFarmaceutico))
                return ((IndBaseProdFarmaceutico)value).ToDefaultValue();

            if (type == typeof(IndTipoProdFarmaceutico))
                return ((IndTipoProdFarmaceutico)value).ToDefaultValue();

            if (type == typeof(IndTipoArmaFogo))
                return ((IndTipoArmaFogo)value).ToDefaultValue();

            if (type == typeof(IndTipoOperacaoVeiculo))
                return ((IndTipoOperacaoVeiculo)value).ToDefaultValue();

            if (type == typeof(IndClasseConsumoEnergiaOuGas))
                return ((IndClasseConsumoEnergiaOuGas)value).ToDefaultValue();

            if (type == typeof(IndClasseConsumoAgua))
                return ((IndClasseConsumoAgua)value).ToDefaultValue();

            if (type == typeof(IndClasseConsumoGas))
                return ((IndClasseConsumoGas)value).ToDefaultValue();

            if (type == typeof(IndCodTipoLigacao))
                return ((IndCodTipoLigacao)value).ToDefaultValue();

            if (type == typeof(IndCodGrupoTensao))
                return ((IndCodGrupoTensao)value).ToDefaultValue();

            if (type == typeof(IndTipoAjuste))
                return ((IndTipoAjuste)value).ToDefaultValue();

            return string.Empty;

            #endregion OLD ENUM CHECK
        }
    }
}