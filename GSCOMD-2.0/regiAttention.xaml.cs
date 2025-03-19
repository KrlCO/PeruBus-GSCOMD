using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace GSCOMD_2._0
{
    public partial class regiAttention : Page
    {
        private string meConectSql;
        public ObservableCollection<feeding> feedings { get; set; }

        public regiAttention()
        {
            InitializeComponent();
            meConectSql = ConfigurationManager.ConnectionStrings["GSCOMD_2._0.Properties.Settings.GSCOMDConnectionString"]?.ConnectionString;

            //InitializeComponent();
            //meConectSql = ConfigurationManager.ConnectionStrings["gscomd_2._0.properties.settings.gscomdconnectionstring1"]?.ConnectionString;

            CargarCategorias(); 
            CargarComidas();

            feedings = new ObservableCollection<feeding>();
            dgComidas.ItemsSource = feedings;
            
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedTipo = CboTipoComida.SelectedItem as DataRowView;
            DataRowView selectedCate = CboCategoria.SelectedItem as DataRowView;

            
            if(selectedTipo == null || selectedCate == null)
            {
                MessageBox.Show("Por favor, seleccione un Tipo de Comida y una Categoría.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string codeTipo = selectedTipo["CO_TIPO_COMI"].ToString();
            string codeCate = selectedCate["CO_CATE"].ToString();

            MessageBox.Show($"Tipo: {codeTipo}, Categoría: {codeCate}", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            //var selectedV1 = CboTipoComida.SelectedValue.ToString();
            //var selectedV2 = CboCategoria.SelectedValue.ToString();
            //MessageBox.Show($"{selectedV2},{selectedV1}");
            ListSelectedFoods(codeTipo, codeCate, "01", "401");
        }

        private void ListSelectedFoods(string tipo, string cate, string come, string codTrab)
        {
            try
            {
                using(SqlConnection cnx = new SqlConnection(meConectSql))
                {
                    cnx.Open();
                    using(SqlCommand cmd = new SqlCommand("SP_TRCOMI_CATE_NQ01", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CO_TIPO_COMI", tipo);
                        cmd.Parameters.AddWithValue("@CO_CATE", cate);
                        cmd.Parameters.AddWithValue("@CO_COME", come);
                        cmd.Parameters.AddWithValue("@CO_TRAB", codTrab);

                        //feedings.Clear();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                feedings.Add(new feeding
                                {
                                    Description = reader["DE_COMI"].ToString(),
                                    Quantity = Convert.ToInt32(reader["NU_CANT"]),
                                    Grant = Convert.ToDecimal(reader["IM_SUBV"]),
                                    Cash = Convert.ToDecimal(reader["IM_TOTA"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CargarCategorias()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(meConectSql))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_TMCATE_LIST", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            CboCategoria.ItemsSource = dt.DefaultView;
                            CboCategoria.DisplayMemberPath = "NO_CATE";  
                            CboCategoria.SelectedValuePath = "CO_CATE"; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CboCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CboCategoria.SelectedItem != null)
            {
                DataRowView row = (DataRowView)CboCategoria.SelectedItem;
                string categoriaSeleccion = row["NO_CATE"].ToString();

                MessageBox.Show("Seleccionaste: " + categoriaSeleccion);
            }
        }

        private void CargarComidas()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(meConectSql))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_TMTIP_COMID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            CboTipoComida.ItemsSource = dt.DefaultView;
                            CboTipoComida.DisplayMemberPath = "NO_TIPO_COMI";
                            CboTipoComida.SelectedValuePath = "CO_TIPO_COMI";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CargarCategoriasPorComida(string codigoComida)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(meConectSql))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_CATEGORIAS_POR_COMIDA", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CO_TIPO_COMI", codigoComida);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            CboCategoria.ItemsSource = dt.DefaultView;
                            CboCategoria.DisplayMemberPath = "NO_CATE";
                            CboCategoria.SelectedValuePath = "CO_CATE";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // cuando el usuario cambia el tipo de comida
        private void CboTipoComida_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CboTipoComida.SelectedItem != null)
            {
                DataRowView row = (DataRowView)CboTipoComida.SelectedItem;
                string codigoComida = row["CO_TIPO_COMI"].ToString();
                CargarCategoriasPorComida(codigoComida);
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void dgComidas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
