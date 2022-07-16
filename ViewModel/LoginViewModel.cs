using GestionVuelos.Model;
using GestionVuelos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionVuelos.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        //VARIABLES
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible=true;

        private IUsuarioRepository usuarioRepository;

        //PROPIEDADES
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public SecureString Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get { return _errorMessage; } set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get { return _isViewVisible;} set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        //COMANDOS
        public ICommand LoginCommand { get; }

        //CONSTRUCTOR
        public LoginViewModel()
        {
            usuarioRepository = new UsuarioRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = usuarioRepository.AutenticateUser(new NetworkCredential(Username,Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username),null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "No se puso Iniciar Sesion";
            }
        }
    }
}
