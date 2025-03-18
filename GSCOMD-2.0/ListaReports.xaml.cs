using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using ClosedXML.Excel;
using Microsoft.Win32;
using System.IO;


namespace GSCOMD_2._0
{
    public partial class ListaReports : Window
    {
        private string connectionString = "Server=10.10.10.58;Database=GSCOMD;User Id=cn;Password=cnn2k7;";

        public ListaReports()
        {
            InitializeComponent();
            CargarDatos(); // Cargar datos iniciales al abrir la ventana
            //Agregar datos del Crystal Reports
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (Login.UsuarioLogueado == "COMELIMA")
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_REPORTE_VENTAS_LIM", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgLista.ItemsSource = dt.DefaultView;

                        }
                    }
                    else if (Login.UsuarioLogueado == "COMEICA")
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_REPORTE_VENTAS_ICA", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgLista.ItemsSource = dt.DefaultView;

                        }
                    }

                    else
                    {
                        MessageBox.Show("Error al cargar datos");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void CargarDatosFiltrados()
        {
            if (FechIni.SelectedDate.HasValue && FechFin.SelectedDate.HasValue)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        if (Login.UsuarioLogueado == "COMELIMA")
                        {
                            using (SqlCommand cmd = new SqlCommand("SP_TDDOCU_ATEN_LIM", conn))
                            {
                                //Recibe los campos
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@IDFE_INIC", FechIni.SelectedDate.Value.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@IDFE_FINA", FechFin.SelectedDate.Value.ToString("yyyy-MM-dd"));

                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dgLista.ItemsSource = dt.DefaultView;
                            }
                        }
                        else if (Login.UsuarioLogueado == "COMEICA")
                        {
                            using (SqlCommand cmd = new SqlCommand("SP_TDDOCU_ATEN_ICA", conn))
                            {
                                //Recibe los campos
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@IDFE_INIC", FechIni.SelectedDate.Value.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@IDFE_FINA", FechFin.SelectedDate.Value.ToString("yyyy-MM-dd"));

                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dgLista.ItemsSource = dt.DefaultView;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error al cargar datos");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al filtrar datos: " + ex.Message);
                }
            }
            else
            {
                CargarDatos(); // Si no hay fechas seleccionadas, vuelve a cargar los datos originales
            }
        }

        private void MyDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CargarDatosFiltrados();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Manejo de selección si es necesario aunque no creo xd
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
                    DataTable dt = ((DataView)dgLista.ItemsSource).ToTable();

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "ReporteVentas");
                        wb.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Datos exportados con éxito a Excel", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
