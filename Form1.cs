﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.Controllers;
using Login.Views.Acesos;
using Login.Views.Bodega;
using Login.Views.Financiero;
using Login.Views;
using Login.Config;

namespace Login
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_contrasenia.Text = "";
            txt_usuario.Text = "";
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string usuario = txt_usuario.Text.Trim();
            string contrasenia = txt_contrasenia.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia))
            {
                MessageBox.Show("Por favor, rellene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(usuario);

            string contraseniaEncriptada = Encriptacion.Encripta(contrasenia, "Esta es la clave secreta");
            MessageBox.Show("Contraseña encriptada: " + contraseniaEncriptada);

            string contraseniaMD5 = Encriptacion.MD5Encripter(contrasenia);
            MessageBox.Show("Contraseña en MD5: " + contraseniaMD5);

            try
            {
                UsuariosController _usuariosController = new UsuariosController();
                var usuariomodel = _usuariosController.AutenticarUsuario(usuario, contrasenia);

                if (usuariomodel != null)
                {
                    lbl_mensaje.Text = "Ingreso exitoso";
                    this.Hide();

                    ConfiguracionProyecto.IDusuario = (int)usuariomodel.ID;
                    ConfiguracionProyecto.usuario = usuariomodel.NombreUsuario;
                    ConfiguracionProyecto.rol = usuariomodel.Roles;

                    Dashboard _dashboard = new Dashboard();
                    _dashboard.Show();
                }
                else
                {
                    lbl_mensaje.Text = "El usuario o la contraseña no son validos";
                    txt_contrasenia.Text = "";
                    txt_usuario.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            /*
            if (usuariomodel.Roles == "Admin")
            {
                Dashboard _dashboard = new Dashboard();
                this.Hide();
                _dashboard.Show();
            }
            else if (usuariomodel.Roles == "Guardia")
            {
                var _accesos = new frm_Accesos_Principal();
                _accesos.Show();
            }
            else if (usuariomodel.Roles == "Financiero")
            {
                //financiero
                var _fiananciero = new frm_Financiero_Principal();
                _fiananciero.Show();
            }
            else if (usuariomodel.Roles == "Bodega")
            {
                var _bodega = new frm_Bodega_Principal();
                _bodega.Show();
            }
            else {
                lbl_mensaje.Text = "Usted no posee el nivel de acceso necesario";
            }
        }
        else
        {
            lbl_mensaje.Text = "El usuario o la contraseña son incorrectos";
            txt_contrasenia.Text = "";
            txt_usuario.Text = "";
        }*/
        }
    }
}
