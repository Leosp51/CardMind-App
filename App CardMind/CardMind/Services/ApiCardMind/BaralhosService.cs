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
    public class BaralhosService
    {


        private HttpClient client;
        private JsonSerializerOptions options;
        private ObservableCollection<Baralho> baralhos = new ObservableCollection<Baralho>();

        public BaralhosService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Baralho>> GetBaralhosUsuario(int idUser)
        {

            Uri uri = new Uri("https://localhost:8080/baralhos/" + idUser.ToString());
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    baralhos = JsonSerializer.Deserialize<ObservableCollection<Baralho>>(content, options);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return baralhos;
        }


    }
}

