using System;
using System.Windows.Forms;
using Tp5Prueba.DataAccess;
using Tp5Prueba.Model;

namespace Tp5Prueba
{
    public partial class VistaProducto : Form
    {
        public Action Aceptar;
        public Producto Producto { get; set; }
        public IProductService Servicio { get; set; }
        public VistaPrincipal VistaPadre { get; set; }
        public VistaProducto()
        {
            InitializeComponent();
            Servicio = new ProductService();
            Producto = new Producto();
            cbEstado.DataSource = Enum.GetValues(typeof(Estado));
            InicializarCampos(Producto);
        }

        private void InicializarCampos(Producto producto)
        {
            tbCodigo.DataBindings.Add(new Binding("Text", producto, "Codigo"));
            tbDescripcion.DataBindings.Add(new Binding("Text", producto, "Descripcion"));
            tbCostoSinIva.DataBindings.Add(new Binding("Text", producto, "CostoSinIva"));
            tbPorcentajeIva.DataBindings.Add(new Binding("Text", producto, "PorcentajeIva"));
            tbCostoConIva.DataBindings.Add(new Binding("Text", producto, "CostoConIva"));
            tbMargenGanancia.DataBindings.Add(new Binding("Text", producto, "MargenGanancia"));
            tbPrecioFinal.DataBindings.Add(new Binding("Text", producto, "PrecioFinal"));
            tbExistencias.DataBindings.Add(new Binding("Text", producto, "Existencias"));
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        internal void Crear(VistaPrincipal vista)
        {
            VistaPadre = vista;
            btConfirmar.Text = "Crear";
            Producto.Codigo = Servicio.GetNextId();
            Show();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            Producto.Estado = (Estado)cbEstado.SelectedItem;
            if (Producto.Validar())
            {
                VistaPadre.Agregar(Producto);
                Close();
                OnAceptar();
                Dispose();
            }
            else
            {
                MessageBox.Show("se olvido de cargar un dato");
            }
            
        }

        public void OnAceptar()
        {
            Aceptar.Invoke();
        }
    }
}
