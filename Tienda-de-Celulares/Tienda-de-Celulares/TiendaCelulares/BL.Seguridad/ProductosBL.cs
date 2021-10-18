﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Seguridad
{ // Creamos la Clase Producto:
    public class ProductosBL
    {
        public BindingList<Producto> ListaProducto { get; set; }

        public ProductosBL()
        { //declaramos la lista de tipo producto
            ListaProducto = new BindingList<Producto>();
            //Declaramos productos prueba:
            var producto1 = new Producto();
            producto1.Id = 1;
            producto1.Descripcion = "Iphone SE 2020 64 GB";
            producto1.Precio = 14350;
            producto1.Existencia = 5;
            producto1.Activo = true;

            ListaProducto.Add(producto1);

            var producto2 = new Producto();
            producto2.Id = 2;
            producto2.Descripcion = "Iphone 11Pro 64 GB";
            producto2.Precio = 14500;
            producto2.Existencia = 15;
            producto2.Activo = true;

            ListaProducto.Add(producto2);

            var producto3 = new Producto();
            producto1.Id = 3;
            producto3.Descripcion = "Samsung S10 128 GB";
            producto3.Precio = 5500;
            producto3.Existencia = 20;
            producto3.Activo = true;

            ListaProducto.Add(producto3);

            var producto4 = new Producto();
            producto4.Id = 4;
            producto4.Descripcion = "LG Velvet 128 GB";
            producto4.Precio = 5000;
            producto4.Existencia = 10;
            producto4.Activo = true;

            ListaProducto.Add(producto4);

            var producto5 = new Producto();
            producto5.Id = 5;
            producto5.Descripcion = "Motorola G Power 64 GB";
            producto5.Precio = 3000;
            producto5.Existencia = 5;
            producto5.Activo = true;

            ListaProducto.Add(producto5);
        }

        public BindingList<Producto> ObtenerProductos()
        {
            return ListaProducto;
        }

        public Resultado GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }
            if (producto.Id == 0)
            { 
                producto.Id = ListaProducto.Max(item => item.Id) + 1;
            }

            resultado.Exitoso = true;
            return resultado;

        }

        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();
            ListaProducto.Add(nuevoProducto);
        }


        public bool EliminarProducto(int id)
        {
            foreach (var producto in ListaProducto)
            {
                if (producto.Id == id)
                {
                    ListaProducto.Remove(producto);
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;
            
            

            if (string.IsNullOrEmpty(producto.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripción";
                resultado.Exitoso = false;
            }
            if (producto.Existencia < 0)
            {
                resultado.Mensaje = "La existencia debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            if (producto.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            return resultado;
        }
    }

    public class Producto

    //aqui declaramos las propiedades de la clase producto

    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
  



