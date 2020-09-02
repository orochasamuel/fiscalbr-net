using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped
{
    public class RegistroBaseSped
    {
        [SpedCampos(1, "REG", "C", 4, 0, true)]
        public string Reg { get; set; }

        public static object GetPropValue(object src, string propName)
        {
            var property = src.GetType().GetProperty(propName);
            var propertyType = property.PropertyType;

            var propertyValue = property.GetValue(src, null);

            if (propertyType.IsEnum)
                propertyValue = IdentifyEnumValueByType(propertyType, propertyValue);

            return propertyValue;
        }

        public static string IdentifyEnumValueByType(Type type, object valueOfType)
        {
            if (type == typeof(SimOuNao))
                return ((SimOuNao)valueOfType).ToDefaultValue();

            if (type == typeof(IndMovimento))
                return ((IndMovimento)valueOfType).ToDefaultValue();

            if (type == typeof(IndCodFinalidadeArquivo))
                return ((IndCodFinalidadeArquivo)valueOfType).ToDefaultValue();

            if (type == typeof(IndPerfilArquivo))
                return ((IndPerfilArquivo)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoAtividade))
                return ((IndTipoAtividade)valueOfType).ToDefaultValue();

            if (type == typeof(ClassEstabIndustrial))
                return ((ClassEstabIndustrial)valueOfType).ToDefaultValue();

            if (type == typeof(IndCodMod))
                return ((IndCodMod)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoItem))
                return ((IndTipoItem)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoMercadoria))
                return ((IndTipoMercadoria)valueOfType).ToDefaultValue();

            if (type == typeof(IndNaturezaConta))
                return ((IndNaturezaConta)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoConta))
                return ((IndTipoConta)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoOperacaoProduto))
                return ((IndTipoOperacaoProduto)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoOperacaoServico))
                return ((IndTipoOperacaoServico)valueOfType).ToDefaultValue();

            if (type == typeof(IndEmitente))
                return ((IndEmitente)valueOfType).ToDefaultValue();

            if (type == typeof(IndCodSitDoc))
                return ((IndCodSitDoc)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoPagamento))
                return ((IndTipoPagamento)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoFrete))
                return ((IndTipoFrete)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoOperacaoStUfDiversa))
                return ((IndTipoOperacaoStUfDiversa)valueOfType).ToDefaultValue();

            if (type == typeof(IndOrigemProcesso))
                return ((IndOrigemProcesso)valueOfType).ToDefaultValue();

            if (type == typeof(IndCodModDocArrecadacao))
                return ((IndCodModDocArrecadacao)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoTransporte))
                return ((IndTipoTransporte)valueOfType).ToDefaultValue();

            if (type == typeof(IndDocumentoImportacao))
                return ((IndDocumentoImportacao)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoTituloCred))
                return ((IndTipoTituloCred)valueOfType).ToDefaultValue();

            if (type == typeof(IndPeriodoApuracaoIpi))
                return ((IndPeriodoApuracaoIpi)valueOfType).ToDefaultValue();

            if (type == typeof(IndMovFisicaItem))
                return ((IndMovFisicaItem)valueOfType).ToDefaultValue();

            if (type == typeof(IndBaseProdFarmaceutico))
                return ((IndBaseProdFarmaceutico)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoProdFarmaceutico))
                return ((IndTipoProdFarmaceutico)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoArmaFogo))
                return ((IndTipoArmaFogo)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoOperacaoVeiculo))
                return ((IndTipoOperacaoVeiculo)valueOfType).ToDefaultValue();

            if (type == typeof(IndClasseConsumoEnergia))
                return ((IndClasseConsumoEnergia)valueOfType).ToDefaultValue();

            if (type == typeof(IndClasseConsumoAgua))
                return ((IndClasseConsumoAgua)valueOfType).ToDefaultValue();

            if (type == typeof(IndClasseConsumoGas))
                return ((IndClasseConsumoGas)valueOfType).ToDefaultValue();

            if (type == typeof(IndCodTipoLigacao))
                return ((IndCodTipoLigacao)valueOfType).ToDefaultValue();

            if (type == typeof(IndCodGrupoTensao))
                return ((IndCodGrupoTensao)valueOfType).ToDefaultValue();

            if (type == typeof(IndTipoAjuste))
                return ((IndTipoAjuste)valueOfType).ToDefaultValue();

            return string.Empty;
        }
    }
}
