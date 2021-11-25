using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaBL
{
    public class FacturaBL //Creamos la Factura BL
    {
        Contexto _contexto;

        public BindingList<Factura> ListaFacturas { get; set; }

        public FacturaBL()
        {
            _contexto = new Contexto();
        }

        public BindingList<Factura> ObtenerFacturas()
        {
            _contexto.Facturas.Include("FacturaDetalle").Load();
            ListaFacturas = _contexto.Facturas.Local.ToBindingList();

            return ListaFacturas;
        }

        public void AgregarFactura()
        {
            var nuevaFactura = new Factura();
            _contexto.Facturas.Add(nuevaFactura);
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;//Revisar
                item.Reload();
            }
        }

        public Resultado GuardarFactura(Factura factura)
        {
            var resultado = Validar(factura);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.Save.Changes();
            resultado.Exitoso = true;
            return resultado;
        }

        private Resultado Validar(Factura factura)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            return resultado;
        }
    }

    internal class EntityState
    {
        public static object Unchanged { get; internal set; }
    }

    public class Factura //Creamos la Clase Factura y le agregamos una propiedad:
    {//Propiedades del encabezado
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }//Llave foranea ClienteId
        public Cliente Cliente { get; set; }
        public BindingList<FacturaDetalle> FacturaDetalle { get; set; }
        public double Sutotal { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        public Factura() //Declaramos un Constructor
        {
            Fecha = DateTime.Now; //Declaramos esta funcion para que carge la fecha actual cuando se inicialice
            FacturaDetalle = new BindingList<FacturaDetalle>();
            Activo = true;
        }
    }//Mantenimiento de Factura Listo. (Maestro de Detalle)

    public class Cliente
    {
    }

    public class FacturaDetalle //Declaramos la nueva clase para el maestro detalle, 
    {//Propiedades del detalle
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }

        public FacturaDetalle()
        {
            Cantidad = 1;
        }

    }
}
