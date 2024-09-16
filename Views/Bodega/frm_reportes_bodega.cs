using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.Controllers;
using Login.Models;
using Microsoft.Reporting.WinForms;

namespace Login.Views.Bodega
{
    public partial class frm_reportes_bodega : Form
    {
        ProductosController _productosController = new ProductosController();
        public frm_reportes_bodega()
        {
            InitializeComponent();
        }

        private void frm_reportes_bodega_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Login.Reportes.Productos.rdlc";

            List<ProductosModel> productosModel = _productosController.todos();
            ReportDataSource fuentedaots = new ReportDataSource("DataSet1", productosModel);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(fuentedaots);

            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
