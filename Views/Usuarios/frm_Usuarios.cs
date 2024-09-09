using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Login.Controllers;
using Login.Models;
using Login.Config;
using Login.config;

namespace Login.Views.Usuarios
{
    public partial class frm_Usuarios : Form
    {
        SerialPort _arduino;

        UsuariosController _usuariosController = new UsuariosController();
        UsuariosModel usuariosModel = new UsuariosModel();
        int id = 0;

        public frm_Usuarios()
        {
            InitializeComponent();
            /* _arduino = new SerialPort();
             _arduino.PortName = "COM4";
             _arduino.BaudRate = 9600;
             _arduino.Open();*/


        }

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {
            cargalista();
            cmb_roles.SelectedIndex = 0;
        
        }

        private void cargalista()
        {

            var listausuarios = _usuariosController.ObtenerTodosLosUsuarios();
            lst_usuarios.DataSource = null;
            lst_usuarios.DataSource = listausuarios;
            lst_usuarios.DisplayMember = "NombreUsuario";
            lst_usuarios.ValueMember = "ID";



        }

        /*private void frm_Usuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_arduino.IsOpen)
            {
                _arduino.Close();
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            //_arduino.Write("E");

            // txt_nombre.Text = _arduino.Read().ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            _arduino.Write("F");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            if (txt_contrasenia.Text == txt_repita.Text)  // Verifica si las contraseñas coinciden
            {
                // Encripta la contraseña antes de guardarla
                string passwordEncriptado = Encriptacion.Encripta(txt_contrasenia.Text, "Esta es la clave secreta");

                usuariosModel = new UsuariosModel
                {
                    NombreUsuario = txt_nombre.Text,
                    Password = passwordEncriptado,
                    Roles = cmb_roles.SelectedItem.ToString()
                };

                if (id == 0)
                {
                    _usuariosController.InsertarUsuario(usuariosModel);
                }
                else
                {
                    usuariosModel.ID = id;
                    _usuariosController.ActualizarUsuario(usuariosModel);
                }

                MessageBox.Show("Usuario guardado correctamente.");
                txt_nombre.Text = "";
                txt_contrasenia.Text = "";
                txt_repita.Text = "";
                cmb_roles.SelectedIndex = 0;
                id = 0;
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden.");
            }
        }

        public bool comprobar()
        {

            //txt_nombre.Text.Trim() == "" ? MessageBox.Show("Ingrese el nombres") : "" 
            if (string.IsNullOrWhiteSpace(txt_nombre.Text) || string.IsNullOrWhiteSpace(txt_contrasenia.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return false;
            }

            if (txt_contrasenia.Text != txt_repita.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return false;
            }

            return true;

        }

        private void lst_usuarios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lst_usuarios.SelectedValue != null)
            {
                var usuario = _usuariosController.ObtenerUsuarioPorId((int)lst_usuarios.SelectedValue);
                this.id = (int)usuario.ID;
                txt_nombre.Text = usuario.NombreUsuario;
                txt_contrasenia.Text = usuario.Password;
                txt_repita.Text = usuario.Password;
                if (usuario.Roles == "Admin") cmb_roles.SelectedIndex = 1;
                if (usuario.Roles == "Guardia") cmb_roles.SelectedIndex = 2;
                if (usuario.Roles == "Financiero") cmb_roles.SelectedIndex = 3;
                if (usuario.Roles == "Bodega") cmb_roles.SelectedIndex = 4;



            }
            else
            {
                ErrorHandler.ManejarErrorGeneral(null, "Seleccione un usuario de la lista");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (lst_usuarios.SelectedItem != null)
            {
                int idUsuario = Convert.ToInt32(lst_usuarios.SelectedValue);
                var resultado = _usuariosController.EliminarUsuario(idUsuario);

                if (resultado == "OK")
                {
                    MessageBox.Show("Usuario eliminado correctamente");
                    cargalista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para eliminar");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_nombre.Text = "";
            txt_contrasenia.Text = "";
            txt_repita.Text = "";
            cmb_roles.SelectedIndex = 0;
            id = 0;
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}