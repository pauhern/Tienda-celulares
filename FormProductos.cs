using System;
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
            productoBindingSource1.EndEdit();
            var producto = (Producto)productoBindingSource1.Current;
            var resultado = _productos.GuardarProducto(producto);
            

//            if (resultado.Exitoso == true)
  //          {
    //            productoBindingSource1.ResetBindings(false);
                

      //      }

        //    else
            {
                MessageBox.Show("resultado.Mensaje");
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            productoBindingSource1.MoveLast();

            
        }

       
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

            
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }


            }
        }

        private void Eliminar(int id)
        {

            var resultado = _productos.EliminarProducto(id);

          //  if (resultado == true)
            //{
                productoBindingSource1.ResetBindings(false);
            //}
            //else
            {
                MessageBox.Show("Ocurrio un error eliminando el producto");
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            
            Eliminar(0);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }
    }

    internal class Producto
    {
    }
}