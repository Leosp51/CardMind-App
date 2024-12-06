using CardMind.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CardMind.Services.ApiCardMind
{
    public class ConquistasService
    {



        private HttpClient client;
        private JsonSerializerOptions options;
        private ObservableCollection<Conquista> conquistas = new ObservableCollection<Conquista>();

        public ConquistasService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Conquista>> GetConquistas()
        {

            Uri uri = new Uri("https://localhost:8080/conquistas/");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    conquistas = JsonSerializer.Deserialize<ObservableCollection<Conquista>>(content, options);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return conquistas;
        }

    }
}
