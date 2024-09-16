using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Controllers
{
    internal class StockController
    {
        StockModel _stockModel = new StockModel();

        public StockModel insertar(StockModel stock)
        {
            return _stockModel.inserat(stock);
        }
    }
}
