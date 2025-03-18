using System;
using System.Data;
using System.Windows;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Win32;
using ClosedXML.Excel;

namespace GSCOMD_2._0
{
    public partial class ReporteVentas : Window
    {
        private ReportDocument reporte;

        public ReporteVentas(DataView datos)
        {
            InitializeComponent();
            dgLista.ItemsSource = datos;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            reporte = new ReporteVentas();
        }

        private void ExportarExcel_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Excel Files|*.xlsx", Title = "Guardar como" };
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    DataTable dt = ((DataView)dgLista.ItemsSource).ToTable();
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "ReporteVentas");
                        wb.SaveAs(saveFileDialog.FileName);
                    }
                    MessageBox.Show("Datos exportados con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ImprimirReporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                reporte.PrintToPrinter(1, false, 0, 0);
                MessageBox.Show("Reporte enviado a la impresora.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
