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
    public class EstilosServico
    {
        private HttpClient client;
        private JsonSerializerOptions options;
        private ObservableCollection<EstiloBaralho> estilos = new ObservableCollection<EstiloBaralho>();

        public EstilosServico()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<ObservableCollection<EstiloBaralho>> GetEstilos()
        {
            Uri uri = new Uri("http://localhost:8080/estilos");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode) {
                    string content = await response.Content.ReadAsStringAsync();
                    estilos = JsonSerializer.Deserialize<ObservableCollection<EstiloBaralho>>(content, options);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return estilos;
        }
    }
}
