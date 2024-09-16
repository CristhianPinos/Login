using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.config;
using Login.Controllers;
using Login.Models;
using Login.Views.Bodega;

namespace Login.Views.Usuarios
{
    public partial class frm_Usuarios_Principal : Form
    {
        UsuariosController _usuariosController = new UsuariosController();
        List<UsuariosModel> _listaUsuarios = new List<UsuariosModel>();
        public frm_Usuarios_Principal()
        {
            InitializeComponent();
        }

        private void frm_Usuarios_Principal_Load(object sender, EventArgs e)
        {
            cargaDataGridView();
        }
        public void cargaDataGridView()
        {
            dataGridView1.DataSource = null;
            _listaUsuarios = _usuariosController.ObtenerTodosLosUsuarios();
            dataGridView1.DataSource = _listaUsuarios;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Usuarios _frm_Usuarios = new frm_Usuarios();
            _frm_Usuarios.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_reportes_usuarios _Reportes_Usuarios = new frm_reportes_usuarios();
            _Reportes_Usuarios.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
