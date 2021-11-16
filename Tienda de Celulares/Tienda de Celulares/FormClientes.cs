using POS.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.BL
{
    public partial class FormClientes : Form
    {
        Contexto _contexto;

        public FormClientes()
        {
            InitializeComponent();

            // READ o SELECT
            _contexto = new Contexto();

            dataGridView1.DataSource = _contexto.Clientes.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Clientes nuevoCliente = new Clientes();
            nuevoCliente.Nombre = textBox1.Text;

            //CREATE
            _contexto.Clientes.Add(nuevoCliente);
            _contexto.SaveChanges();

            MessageBox.Show("Cliente Creado");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                {
                    if (dataGridView1.SelectedRows[0].Cells[2].Value != null)
                    {
                        textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                int Id = int.Parse(textBox3.Text);
                string nombre = textBox1.Text;
                string telefono = textBox2.Text;

                Clientes cliente = _contexto.Clientes.Find(Id);

                if (cliente != null)
                {
                    cliente.Nombre = nombre;
                    cliente.Telefono = telefono;

                    //UPDATE
                    _contexto.SaveChanges();


                    dataGridView1.DataSource = null;
                    //READ OR SELECT
                    dataGridView1.DataSource = _contexto.Clientes.ToList();

                    MessageBox.Show("Cliente Actualizado");

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                int Id = int.Parse(textBox3.Text);

                Clientes cliente = _contexto.Clientes.Find(Id);

                if (cliente != null)
                {

                    //DELETE
                    _contexto.Clientes.Remove(cliente);
                    _contexto.SaveChanges();


                    dataGridView1.DataSource = null;
                    //READ OR SELECT
                    dataGridView1.DataSource = _contexto.Clientes.ToList();

                    MessageBox.Show("Cliente eliminado");

                }
            }
        }
    }
}
