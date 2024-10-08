﻿using System;
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

namespace Login.Views.Bodega
{
    public partial class frm_Bodega_Principal : Form
    {
        ProductosController _productosController = new ProductosController();
        List<ProductosModel> _listaProductos = new List<ProductosModel>();
        public frm_Bodega_Principal()
        {
            InitializeComponent();
        }

        private void frm_Bodega_Principal_Load(object sender, EventArgs e)
        {
            cargaDataGridView();
        }

        public void cargaDataGridView()
        {
            dataGridView1.DataSource = null;
            _listaProductos = _productosController.todos();
            dataGridView1.DataSource = _listaProductos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_nuevo_producto _frm_nuevo_producto = new frm_nuevo_producto();
            _frm_nuevo_producto.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_reportes_bodega _Reportes_Bodega = new frm_reportes_bodega();
            _Reportes_Bodega.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
