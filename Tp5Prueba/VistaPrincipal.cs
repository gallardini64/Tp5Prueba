using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tp5Prueba.DataAccess;
using Tp5Prueba.Model;

namespace Tp5Prueba
{
    public partial class VistaPrincipal : Form
    {
        public List<Producto> Productos { get; set; }
        public IProductService Service { get; set; }
        public VistaProducto VistaProducto { get; set; }
        public VistaPrincipal()
        {
            InitializeComponent();
            InicializarServicios();
            RecargarTabla();
        }

        private void InicializarServicios()
        {
            Service = new ProductService();
            Productos = Service.GetFiltered(x => x.Existencias > 0);
        }

        public void RecargarTabla()
        {
            dataGridProductos.DataSource = Productos;
            dataGridProductos.Update();
            dataGridProductos.Refresh();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscar();
            }
        }

        private void Buscar()
        {
            int codigo;
            if (int.TryParse(textBox1.Text, out codigo))
            {
                dataGridProductos.DataSource = Productos.Where(x => x.Codigo == codigo).ToList();
                dataGridProductos.Refresh();
            }
            else
            {
                RecargarTabla();
            }
            
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaProducto = new VistaProducto();
            VistaProducto.Crear(this);
        }

        internal void Agregar(Producto producto)
        {
            Productos.Add(producto);
        }
    }
}
