using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_de_Celulares
{
    public partial class FormFactura : Form
    {
        Contexto _contexto;

        public FormFactura()
        {
            InitializeComponent();
            _contexto = new Contexto();

            CargarDatos();

        }
        private void CargarDatos()
        {
            Button btn = new Button();
            btn.Text = "Presioname";
            groupBox1.Controls.Add(btn); 
            //item.Subitems.Add("60");
            //listView1.Items.Add(item);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem Item = new ListViewItem();
            Item.Text = "iPhone X";
            Item.SubItems.Add("20,000");

            listView1.Items.Add(Item);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    internal class Contexto
    {
    }
}
