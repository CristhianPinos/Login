using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Controllers
{
    internal class ProveedoresController
    {
        ProveedoresModel _proveedoresModel = new ProveedoresModel();

        public List<ProveedoresModel> todos()
        {
            return _proveedoresModel.todos();
        }
    }
}
