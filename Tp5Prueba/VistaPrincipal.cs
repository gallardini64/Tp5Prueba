using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp5Prueba.DataAccess;
using Tp5Prueba.Model;

namespace Tp5Prueba
{
    public partial class VistaPrincipal : Form
    {
        public List<Producto> Productos { get; set; }
        public IProductService Service { get; set; }
        public VistaPrincipal()
        {
            InitializeComponent();
            InicializarServicios();
            InicializarTabla();
        }

        private void InicializarServicios()
        {
            Service = new ProductService();
            Productos = Service.GetFiltered(x => x.Existencias > 0);
        }

        private void InicializarTabla()
        {
            dataGridProductos.DataSource = Productos;
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
                InicializarTabla();
            }
            
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
