using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMind.Services.Navigation
{
    public class MauiNavigationService : INavigationService
    {
        public async Task<Task> InitializeAsync()
        {
            string status = Preferences.Default.Get<string>("statusUsuario", "primeiraVez");
            if (status == "primeiraVez")
                return NavigateToAsync("//Cadastro");
            else if (status == "cadastrado" || status == "logado")
                return NavigateToAsync("//Menu/Home");
            else
                return NavigateToAsync("//Login");

        }

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            return routeParameters != null
                ? Shell.Current.GoToAsync(route, routeParameters)
                : Shell.Current.GoToAsync(route);
        }

        public Task PopAsync()
        {
            return Shell.Current.CurrentPage.Navigation.PopToRootAsync();
        }
        
    }
}
