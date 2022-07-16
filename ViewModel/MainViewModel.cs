using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GestionVuelos.Model;
using GestionVuelos.Repositories;

namespace GestionVuelos.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //VARIABLES
        private DatosUsuario _currentUserAccount;
        private IUsuarioRepository usuarioRepository;
        private IEnumerable<VuelosModel> _vuelosModel;
        private VuelosModel _vuelos;
        private IVuelosRepository vuelosRepository;

        //VARIABLES DE TEXTBOX
        private string _ciudadOrigen;
        private string _ciudadDestino;
        private string _fecha;
        private string _horaSalida;
        private string _horaLlegada;
        private int _numeroVuelo;
        private string _aerolinea;
        private string _estadoVuelo;

        //geters y seters
        public DatosUsuario CurrentUserAccount { get { return _currentUserAccount; } set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); } }
        public IEnumerable<VuelosModel> VuelosModel { get { return _vuelosModel; } set { _vuelosModel = value; OnPropertyChanged(nameof(VuelosModel)); } }
        public VuelosModel Vuelos { get { return _vuelos; } set { _vuelos = value; OnPropertyChanged(nameof(Vuelos)); } }
        public string CiudadOrigen { get { return _ciudadOrigen; } set { _ciudadOrigen = value; OnPropertyChanged(nameof(CiudadOrigen)); } }
        public string CiudadDestino { get { return _ciudadDestino; } set { _ciudadDestino = value; OnPropertyChanged(nameof(CiudadDestino)); } }
        public string Fecha { get { return _fecha;} set { _fecha = value; OnPropertyChanged(nameof(Fecha));} }
        public string HoraSalida { get { return _horaSalida; } set { _horaSalida = value; OnPropertyChanged(nameof(HoraSalida));} }
        public string HoraLlegada { get { return _horaLlegada;} set { _horaLlegada = value; OnPropertyChanged(nameof(HoraLlegada));} }
        public int NumeroVuelo { get { return _numeroVuelo;} set { _numeroVuelo = value; OnPropertyChanged(nameof(NumeroVuelo));} }
        public string Aerolinea { get { return _aerolinea;} set { _aerolinea = value; OnPropertyChanged(nameof(Aerolinea)); } }
        public string EstadoVuelo { get { return _estadoVuelo;} set { _estadoVuelo = value; OnPropertyChanged(nameof(EstadoVuelo));} }


        //COMANDOS
        public ICommand CrearVueloCommand { get; }

        public MainViewModel()
        {
            usuarioRepository = new UsuarioRepository();
            CurrentUserAccount = new DatosUsuario();
            vuelosRepository = new VuelosRepository();
            CrearVueloCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            LoadCurrentUserData();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            VuelosModel vuelosModels = new VuelosModel();
            vuelosModels.ciudadOrigen = CiudadOrigen;
            vuelosModels.ciudadDestino = CiudadDestino;
            vuelosModels.fecha =  Fecha;
            vuelosModels.horaSalida = HoraSalida;
            vuelosModels.horaLlegada = HoraLlegada;
            vuelosModels.numeroVuelo = NumeroVuelo;
            vuelosModels.aerolinea = Aerolinea;
            vuelosModels.estadoVuelo = EstadoVuelo;
            
            var isAdd = vuelosRepository.Add(vuelosModels);
            if (isAdd)
            {
                LimpiarFormulario();
                TraerVuelos();
            }
        }

        private void LoadCurrentUserData()
        {
            var user = usuarioRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.userName = user.userName;
                CurrentUserAccount.displayName = $"Bienvenido {user.name} {user.lastName} ;)";
                CurrentUserAccount.profilePicture = null;
                TraerVuelos();
            }
            else
            {
                CurrentUserAccount.displayName = "Usuario no loggeado";
                
            }
        }

        private void TraerVuelos()
        {
            var vuelos = vuelosRepository.GetByAll();
            if(vuelos != null)
            {
                VuelosModel = vuelos;
            }
        }
    
        private void LimpiarFormulario()
        {
            CiudadOrigen = string.Empty;
            CiudadDestino=string.Empty;
            Fecha=string.Empty;
            HoraSalida=string.Empty;
            HoraLlegada=string.Empty;
            NumeroVuelo=0;
            Aerolinea=string.Empty;
            EstadoVuelo=string.Empty;
        }
    }
}
