using Robo.Domain.Entities;
using Robo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Infra.Extension
{
    public static class RoboRotacaoExtension
    {
        private static CotoveloEnum estadoCotovelo = CotoveloEnum.EmRepouso;
        public  static Dictionary<bool, PulsoEnum> MovimentoPulsoValido(CotoveloEnum cotovelo, PulsoEnum newState)
        {
            var result = new Dictionary<bool, PulsoEnum>();
            if (cotovelo != CotoveloEnum.FortementeContraido && newState != PulsoEnum.EmRepouso)
            {
                result.Add(false, newState);
                return result;
            }
            result.Add(true, newState);
            return result;
        }

        public static bool RotacaoCabecaValida(Cabeca cabeca, Rotacao newState)
        {
            if (cabeca.Inclinacao == Inclinacao.ParaBaixo)
            {
                return false;
            }
            return true;
        }
        public static Dictionary<bool,CotoveloEnum> MoveCotoveloParaProximoEstado(CotoveloEnum rotacao)
        {
           var estado = new Dictionary<bool, CotoveloEnum>();
            
            if (rotacao != CotoveloEnum.EmRepouso)
            {
                estadoCotovelo++;
                estado.Add(true, estadoCotovelo);
                return estado;
            }
            else
            {
                estado.Add(false,estadoCotovelo);
                return estado ;
            }
        }


    }
}
