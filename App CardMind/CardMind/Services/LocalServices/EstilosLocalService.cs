using CardMind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Services.LocalServices
{
    public class EstilosLocalService
    {
        public List<EstiloBaralho> estiloBaralhos = new();
        public List<EstiloBaralho> estilosUsuario = new();
        public EstilosLocalService()
        {
            estiloBaralhos.Add(new EstiloBaralho
            {
                CodEstilo = 1,
                NomeEstilo = "Estrela",
                Valor = 10,
                Img = "estilo_estrela.png",
                BackgroundImg = "fundo_estrela.png"
            });
            estiloBaralhos.Add(new EstiloBaralho
            {
                CodEstilo = 2,
                NomeEstilo = "Rosas",
                Valor = 20,
                Img = "estilo_rosas.png",
                BackgroundImg = "fundo_rosas.png"
            });
            estiloBaralhos.Add(new EstiloBaralho
            {
                CodEstilo = 3,
                NomeEstilo = "Gato",
                Valor = 10,
                Img = "estilo_gato.png",
                BackgroundImg = "fundo_gatos.png"
            });
        }
    }
}
