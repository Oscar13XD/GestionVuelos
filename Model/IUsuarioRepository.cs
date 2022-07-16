using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GestionVuelos.Model
{
    public interface IUsuarioRepository
    {
        bool AutenticateUser(NetworkCredential credential);
        void Add(UsuarioModel usuarioModel);
        void Edit(UsuarioModel usuarioModel);
        void Remove(int id);
        UsuarioModel GetById(int id);
        UsuarioModel GetByUserName(string userName);
        IEnumerable<UsuarioModel> GetByAll();
    }
}
