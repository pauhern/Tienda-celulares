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
using static BL.Seguridad.ProductosBL;

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

            if (resultado.Exitoso == true)
            {
                productoBindingSource1.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);

            }

            else
            {
                MessageBox.Show(resultado.Mensaje);
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            productoBindingSource1.MoveLast();

            DeshabilitarHabilitarBotones(false);


        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            {


                bindingNavigatorMoveFirstItem.Enabled = valor;
                bindingNavigatorMoveLastItem.Enabled = valor;
                bindingNavigatorMovePreviousItem.Enabled = valor;
                bindingNavigatorMoveNextItem.Enabled = valor;

                bindingNavigatorAddNewItem.Enabled = valor;
                bindingNavigatorDeleteItem.Enabled = valor;
                Cancelar.Visible = !valor;

            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

            if (idTextBox.Text != "")
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

            if (resultado == true)
            {
                productoBindingSource1.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error eliminando el producto");
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }
    }
}
        

        
    


    

    









