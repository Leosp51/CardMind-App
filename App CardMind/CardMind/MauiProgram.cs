using CardMind.Controls;
using CardMind.Popups;
using CardMind.Services.ApiCardMind;
using CardMind.Services.LocalServices;
using CardMind.Services.Navigation;
using CardMind.ViewModels;
using CardMind.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace CardMind
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegistrarAppServices()
                .RegistrarViewModels()
                .RegistrarViews();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static MauiAppBuilder RegistrarAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
            mauiAppBuilder.Services.AddSingleton<SistemaRecompensa>();
            //API CardMind

            mauiAppBuilder.Services.AddSingleton<UsuarioService>();
            mauiAppBuilder.Services.AddSingleton<BaralhosService>();
            mauiAppBuilder.Services.AddSingleton<ConquistasService>();
            mauiAppBuilder.Services.AddSingleton<BaralhosService>();
            mauiAppBuilder.Services.AddSingleton<SistemaRecompensa>();
            mauiAppBuilder.Services.AddSingleton<AutenticationService>();
            mauiAppBuilder.Services.AddSingleton<EstilosLocalService>();

            mauiAppBuilder.Services.AddSingleton<BaralhosLocalService>();

            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegistrarViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoginViewModel>();
            mauiAppBuilder.Services.AddSingleton<BaralhosViewModel>();
            mauiAppBuilder.Services.AddSingleton<BaralhoViewModel>();
            mauiAppBuilder.Services.AddSingleton<CadastroViewModel>();
            mauiAppBuilder.Services.AddSingleton<ConquistasViewModel>();
            mauiAppBuilder.Services.AddSingleton<LojaViewModel>();
            mauiAppBuilder.Services.AddSingleton<PerfilViewModel>();
            mauiAppBuilder.Services.AddSingleton<ComunidadeViewModel>();


            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegistrarViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<Login>();
            mauiAppBuilder.Services.AddTransient<HomeView>();
            mauiAppBuilder.Services.AddTransient<LojaView>();
            mauiAppBuilder.Services.AddTransient<ConquistasView>();
            mauiAppBuilder.Services.AddTransient<Testes>();
            mauiAppBuilder.Services.AddTransient<BaralhoView>();
            mauiAppBuilder.Services.AddTransient<CartaTextoView>();
            mauiAppBuilder.Services.AddTransient<CartaPerguntaView>();
            mauiAppBuilder.Services.AddTransient<CadastroView>();
            mauiAppBuilder.Services.AddTransient<ComunidadeView>();
            //popups
            mauiAppBuilder.Services.AddTransientPopup<RealizarCompra, LojaViewModel>();
            

            mauiAppBuilder.Services.AddSingleton<BaralhosView>();
            mauiAppBuilder.Services.AddSingleton<PerfilView>();
            return mauiAppBuilder;
        }
    }
}
