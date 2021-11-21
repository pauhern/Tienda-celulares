using System;
using System.Windows.Forms;

namespace Tienda_de_Celulares
{
    public partial class FormReporteFactura : Form
    {

        public FormReporteFactura()
        {
            InitializeComponent();

            var _facturaBL = new FacturaBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _facturaBL.ObtenerFacturas();

            var reporte = new ReporteFactura();
            reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }

    internal class FacturaBL
    {
        public FacturaBL()
        {
        }

        internal object ObtenerFacturas()
        {
            throw new NotImplementedException();
        }
    }
}
