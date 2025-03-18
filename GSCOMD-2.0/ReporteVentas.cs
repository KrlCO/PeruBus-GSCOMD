using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ClosedXML.Excel;
using Microsoft.Win32;

namespace GSCOMD_2._0
{
    public partial class ReporteVentas : Window
    {
        public ReporteVentas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Guardar como"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    if (dgLista.ItemsSource is DataView dataView)
                    {
                        DataTable dt = dataView.ToTable();

                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "ReporteVentas");
                            wb.SaveAs(saveFileDialog.FileName);
                        }

                        MessageBox.Show("Datos exportados con éxito a Excel", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public static implicit operator ReportDocument(ReporteVentas v)
        {
            throw new NotImplementedException();
        }
    }
}
