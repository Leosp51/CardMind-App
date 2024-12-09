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
        public EstilosLocalService()
        {
            estiloBaralhos.Add(new EstiloBaralho
            {
                CodEstilo = 1,
                NomeEstilo = "Cósmico",
                Valor = 10,
                Img = "estilo_estrela.png",
                BackgroundImg = "fundo_estrela.png",
                TextColor = "White"
            });
            estiloBaralhos.Add(new EstiloBaralho
            {
                CodEstilo = 2,
                NomeEstilo = "Primavera",
                Valor = 20,
                Img = "estilo_rosas.png",
                BackgroundImg = "fundo_rosas.png",
                TextColor = "White"
            });
            estiloBaralhos.Add(new EstiloBaralho
            {
                CodEstilo = 3,
                NomeEstilo = "Felinos",
                Valor = 10,
                Img = "estilo_gato.png",
                BackgroundImg = "fundo_gatos.png",
                TextColor = "White"
            });
        }
    }
}
