using CardMind.Services.Navigation;
using CardMind.Views;

namespace CardMind
{
    public partial class AppShell : Shell
    {
        private INavigationService _navigationService;
        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Routing.RegisterRoute("Baralho", typeof(BaralhoView));
            Routing.RegisterRoute("CartaTexto", typeof(CartaTextoView));
            Routing.RegisterRoute("CartaPergunta",typeof(CartaPerguntaView));
            Routing.RegisterRoute("CartaResposta", typeof(CartaResposta));
            Routing.RegisterRoute("EscolhaDificuldade",typeof(EscolhaDificuldadeView));
            InitializeComponent();
        }
        protected override async void OnParentSet()
        {
            base.OnParentSet();
            if (Parent is not null)
            {
                await _navigationService.InitializeAsync();
            }
        }
    }
}
