using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CardMind.Models;
using CardMind.Services;
using CardMind.Services.ApiCardMind;
using CardMind.Services.Navigation;
using System.Text.RegularExpressions;
using CommunityToolkit.Maui.Views;
using CardMind.Popups;

namespace CardMind.ViewModels
{
    public partial class CadastroViewModel : ObservableObject
    {
        private INavigationService _navigationService;
        private AutenticationService autenticationService;

        [ObservableProperty]
        public Usuario usuario = new();
        [ObservableProperty]
        public string confirmarSenha = "";
        [ObservableProperty]
        public string message = "";
        [ObservableProperty]
        public string cor = "White";
        [ObservableProperty]
        public bool isChecked = false;

        private UsuarioService usuarioService;

        public CadastroViewModel(UsuarioService usuarioService,INavigationService navigationService, AutenticationService autenticationService)
        {
            this.usuarioService = usuarioService;
            this._navigationService = navigationService;
            this.autenticationService = autenticationService;
            
        }
        //[RelayCommand]
        public void Adicionar(Usuario user)
        {
            //Aplicação de serviço de bd
        }
        [RelayCommand]
        public async Task Validar()
        {
            Message = string.Empty;
            if (string.IsNullOrWhiteSpace(Usuario.Email)  || string.IsNullOrWhiteSpace(Usuario.Senha) || string.IsNullOrWhiteSpace(ConfirmarSenha) || string.IsNullOrWhiteSpace(Usuario.NomeUsuario))
            {
                Message += "Preencha todos os campos!\n";
            }
            if (string.IsNullOrWhiteSpace(Message))
            {
                Message += ValidarEmail(Usuario.Email);
                Message += ValidarSenha(Usuario.Senha);
            }
            if (string.IsNullOrWhiteSpace(Message))
            {
                 if (Usuario.Senha != ConfirmarSenha)
                {

                    Message += "Senhas diferentes!\n";
                    Cor = "Red";
                }
                if (!IsChecked) {
                    Message += "É necessário concordar com os termos e nossa política";
                }
            }
            
            if (string.IsNullOrEmpty(Message))
            {

                //verificar se o post ocorreu como esperado; trocar depois código abaixo
                autenticationService.InserirUsuario(Usuario.NomeUsuario, Usuario.Email, Usuario.Senha);

                await _navigationService.NavigateToAsync("//Menu/Home");
            }
        }

        public static string ValidarEmail(string email)
        {

            // Expressão regular para validar um formato de e-mail básico
            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            // Verifica se o e-mail corresponde ao padrão
            if (regex.IsMatch(email))
            {
                return string.Empty; // E-mail válido
            }
            else
            {
                return "Email inválido \n"; // E-mail inválido
            }
        }
        public string ValidarSenha(string senha)
        {
            // Verifica se a senha possui pelo menos 5 caracteres
            if (senha.Length < 5)
            {
                return "A senha deve ter pelo menos 5 caracteres. \n";
            }

            // Verifica se a senha contém pelo menos um número
            if (!senha.Any(char.IsDigit))
            {
                return "A senha deve conter pelo menos um número.\n";
            }

            // Verifica se a senha contém pelo menos uma letra maiúscula
            if (!senha.Any(char.IsUpper))
            {
                return "A senha deve conter pelo menos uma letra maiúscula. \n";
            }

            // Se todas as condições foram atendidas, retorna uma string vazia (senha válida)
            return string.Empty;

        }
        [RelayCommand]
        public async Task VerTermos()
        {
            var popup = new TermosPopup();
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);

        }
    }
}
