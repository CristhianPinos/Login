using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Controllers
{
    internal class ProductosController
    {
        ProductosModel _productosModel = new ProductosModel();
        public List<ProductosModel> todos()
        {

            return _productosModel.todos();
        }
        public ProductosModel insertar(ProductosModel productosModel)
        {

            return _productosModel.inserat(productosModel);

        }
    }
}
