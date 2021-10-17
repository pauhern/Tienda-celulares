using BL.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.TiendaCelulares
{
    public partial class FormProductos : Form
    {
        
        ProductosBL _productos;

        public FormProductos()
        {
            InitializeComponent();

            _productos = new ProductosBL();
            productoBindingSource1.DataSource = _productos.ObtenerProductos();
        }

        private void productoBindingSource1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            var producto = (Producto)productoBindingSource1.Current;
            var resultado = _productos.GuardarProducto(producto);

            if (resultado == true)
            {
                productoBindingSource1.ResetBindings(false);
            }

            else
            {
                MessageBox.Show("Ocurrio un error guardando el producto");
            }

        }
    }
}
