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
            if (type == typeof(Constantes.SimOuNao))
                return ((Constantes.SimOuNao)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndMovimento))
                return ((Constantes.IndMovimento)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndCodFinalidadeArquivo))
                return ((Constantes.IndCodFinalidadeArquivo)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndPerfilArquivo))
                return ((Constantes.IndPerfilArquivo)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoAtividade))
                return ((Constantes.IndTipoAtividade)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.ClassEstabIndustrial))
                return ((Constantes.ClassEstabIndustrial)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndCodMod))
                return ((Constantes.IndCodMod)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoItem))
                return ((Constantes.IndTipoItem)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoMercadoria))
                return ((Constantes.IndTipoMercadoria)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndNaturezaConta))
                return ((Constantes.IndNaturezaConta)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoConta))
                return ((Constantes.IndTipoConta)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoOperacaoProduto))
                return ((Constantes.IndTipoOperacaoProduto)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoOperacaoServico))
                return ((Constantes.IndTipoOperacaoServico)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndEmitente))
                return ((Constantes.IndEmitente)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndCodSitDoc))
                return ((Constantes.IndCodSitDoc)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoPagamento))
                return ((Constantes.IndTipoPagamento)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoFrete))
                return ((Constantes.IndTipoFrete)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoOperacaoStUfDiversa))
                return ((Constantes.IndTipoOperacaoStUfDiversa)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndOrigemProcesso))
                return ((Constantes.IndOrigemProcesso)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndCodModDocArrecadacao))
                return ((Constantes.IndCodModDocArrecadacao)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoTransporte))
                return ((Constantes.IndTipoTransporte)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndDocumentoImportacao))
                return ((Constantes.IndDocumentoImportacao)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoTituloCred))
                return ((Constantes.IndTipoTituloCred)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndPeriodoApuracaoIpi))
                return ((Constantes.IndPeriodoApuracaoIpi)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndMovFisicaItem))
                return ((Constantes.IndMovFisicaItem)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndBaseProdFarmaceutico))
                return ((Constantes.IndBaseProdFarmaceutico)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoProdFarmaceutico))
                return ((Constantes.IndTipoProdFarmaceutico)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoArmaFogo))
                return ((Constantes.IndTipoArmaFogo)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoOperacaoVeiculo))
                return ((Constantes.IndTipoOperacaoVeiculo)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndClasseConsumoEnergia))
                return ((Constantes.IndClasseConsumoEnergia)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndClasseConsumoAgua))
                return ((Constantes.IndClasseConsumoAgua)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndClasseConsumoGas))
                return ((Constantes.IndClasseConsumoGas)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndCodTipoLigacao))
                return ((Constantes.IndCodTipoLigacao)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndCodGrupoTensao))
                return ((Constantes.IndCodGrupoTensao)valueOfType).ToDefaultValue();

            if (type == typeof(Constantes.IndTipoAjuste))
                return ((Constantes.IndTipoAjuste)valueOfType).ToDefaultValue();

            return string.Empty;
        }
    }
}
