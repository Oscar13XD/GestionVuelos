using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVuelos.Model
{
    public interface IVuelosRepository
    {
        bool Add(VuelosModel vuelosModel);
        bool Edit(VuelosModel vuelosModel);
        bool Remove(int id);
        VuelosModel GetById(int id);
        IEnumerable<VuelosModel> GetByAll();
    }
}
