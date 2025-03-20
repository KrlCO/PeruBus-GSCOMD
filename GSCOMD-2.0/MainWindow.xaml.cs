using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace GSCOMD_2._0
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string iscoTrab { get; private set; } 
        private string meConectSql;
        private int validation = 0;

        public MainWindow()
        {
            InitializeComponent();
            meConectSql = ConfigurationManager.ConnectionStrings["GSCOMD_2._0.Properties.Settings.GSCOMDConnectionString"]?.ConnectionString;

            //InitializeComponent();
            //meConectSql = ConfigurationManager.ConnectionStrings["gscomd_2._0.properties.settings.gscomdconnectionstring1"]?.ConnectionString;
            frmAtte.NavigationService.Navigate(new regiAttention());
        }

        private void limpiarCampos()
        {
            txtCodeTrab.Text = "";
            txtNombTrab.Text = "";
            lblAsig.Content = "";
            imgTrab.Source = null;
            return;
        }

        private void txtCodeTrab_validacion(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (int.TryParse(txtCodeTrab.Text, out int codigo))
                {
                    bool valor = consultaAtencion(codigo);

                    if (valor == true)
                    {
                        limpiarCampos();
                        MessageBox.Show("TRABAJADOR ATENDIDO");
                        return;
                    }
                    consultaTrabajador(codigo);
                    txtCodeTrab.IsEnabled = false;
                }
            }
        }


        private void consultaTrabajador(int codigo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(meConectSql))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_TCASIG_Q02", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ISCO_TRAB", codigo);

                        // Asignar el valor correcto a @ISCO_COME según el usuario logueado
                        string iscoCome = (Login.UsuarioLogueado == "COMELIMA") ? "01" : "02";
                        cmd.Parameters.AddWithValue("@ISCO_COME", iscoCome);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Usuario tiene asignación
                                iscoTrab = reader["CO_TRAB"].ToString(); 
                                txtCodeTrab.Text = iscoTrab.ToString();
                                txtNombTrab.Text = reader["NO_PERS"].ToString();
                                string code = codigo.ToString();
                                

                                validation = 1; // Se asigna el valor de validación
                                lblAsig.Content = "CON ASIGNACION";
                                consultarImagen(code);

                                // Desbloquear la vista
                                DesbloquearVista();
                            }
                            else
                            {
                                // Usuario NO tiene asignación
                                limpiarCampos();
                                MessageBox.Show("NO TIENE ASIGNACION", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

                                validation = 0; // Mantener bloqueado
                                BloquearVista();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Función para desbloquear la vista cuando el usuario tiene asignación
        private void DesbloquearVista()
        {
            if (frmAtte.Content is regiAttention regiAtte)
            {
                frmAtte.IsEnabled = true;
                regiAtte.IsEnabled = true;
                regiAtte.grdAtte.IsEnabled = true;
            }
        }

        // Función para bloquear la vista cuando el usuario NO tiene asignación
        private void BloquearVista()
        {
            if (frmAtte.Content is regiAttention regiAtte)
            {
                frmAtte.IsEnabled = false;
                regiAtte.IsEnabled = false;
                regiAtte.grdAtte.IsEnabled = false;
            }
        }

        // Se ajusta frame_attention() para bloquear/desbloquear según el estado de validation
        private void frame_attention(object sender, EventArgs e)
        {
            if (validation == 1)
            {
                DesbloquearVista(); // Si tiene asignación, desbloquear
            }
            else
            {
                BloquearVista(); // Si no tiene asignación, mantener bloqueado
            }
        }


        //private void frmActivation (int valor)
        //{
        //    if(validation != 0)
        //    {
        //        regiAttention frmRegi = new regiAttention();
        //        frmAtte.IsEnabled = false;
        //        frmRegi.IsEnabled = false;
        //        frmRegi.grdAtte.IsEnabled = false;
        //    }
        //}

        private bool consultaAtencion(int codigo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(meConectSql))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_TCDOCU_ATEN_Q02", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ISCO_TRAB", codigo);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }

        private void consultarImagen(string codigo)
        {
            string networkPath = @"\\10.10.10.99\gssist\FOTO";
            string user = "compartido";
            string pass = "P3ruBu$2024";
            string comand = $"net use {networkPath} /user:{user} {pass}";

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/C " + comand)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = new Process { StartInfo = psi };
                process.Start();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    string nombreImagen = "T" + codigo.PadLeft(11, '0') + ".jpg";
                    string rutaImagen = Path.Combine(networkPath, nombreImagen);
                    string rutaDefault = @"\\10.10.10.99\gssist\usuario.png";

                    string imgFinal = File.Exists(rutaImagen) ? rutaImagen : rutaDefault;

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imgFinal);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                    imgTrab.Source = bitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void btnReporte_Click(object sender, RoutedEventArgs e)
        {
            new ListaReports().Show();
            btnReporte.IsEnabled = false;
        }
    }
}
