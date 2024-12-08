using CardMind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Services.LocalServices
{
    public class UsuarioLocalService
    {
        private Usuario usuario;
        public UsuarioLocalService()
        {
            usuario = new Usuario();
            UsuarioCarregar();
        }

        public void AdicionarBaralho(Baralho baralho)
        {
            usuario.Baralhos.Add(baralho);
        }
        public void UsuarioCarregar() {

            //recuperar infos locais do dispositivo
            //guardar essas e novas infos no back quando o app estiver pronto
        }
        public void AdicionarEstilo(EstiloBaralho estiloBaralho)
        {
            usuario.EstilosUsuario.Add(estiloBaralho);
        }
        public List<EstiloBaralho> PegarEstilos()
        {
            return usuario.EstilosUsuario;
        }
        public List<Baralho> PegarBaralhos()
        {
            return usuario.Baralhos;
        }
    }
}
