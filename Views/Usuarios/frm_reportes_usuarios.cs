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

namespace Login.Views.Usuarios
{
    public partial class frm_reportes_usuarios : Form
    {
        UsuariosController _usuariosController = new UsuariosController();
        public frm_reportes_usuarios()
        {
            InitializeComponent();
        }

        private void frm_reportes_usuarios_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Login.Reportes.Usuarios.rdlc";

            List<UsuariosModel> usuariosModel = _usuariosController.ObtenerTodosLosUsuarios();
            ReportDataSource fuentedatos = new ReportDataSource("DataSet2", usuariosModel);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(fuentedatos);

            reportViewer1.RefreshReport();
        }
    }
}
