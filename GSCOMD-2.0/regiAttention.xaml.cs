using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace GSCOMD_2._0
{
    public partial class regiAttention : Page
    {
        private string meConectSql;



        public regiAttention()
        {
            InitializeComponent();
            meConectSql = ConfigurationManager.ConnectionStrings["GSCOMD_2._0.Properties.Settings.GSCOMDConnectionString"]?.ConnectionString;
            
            CargarCategorias(); 
            CargarComidas();
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
