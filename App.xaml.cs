using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GestionVuelos.View;

namespace GestionVuelos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var Login = new Login();
            Login.Show();
            Login.IsVisibleChanged+=(s, ev)=>{
                if(Login.IsVisible==false && Login.IsLoaded)
                {
                    var Main = new Main();  
                    Main.Show();
                    Login.Close();  
                }
            };
        }
    }
}
