using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Prueba1

{
    public class ConexionDB
    {
        public SQLiteConnection conexion;

        public ConexionDB()
        {
            string cadenaConexion = @"Data Source=C:\Personal\Estudios\Login con Google Authenticator\GUI Python\Usuarios.db;Version=3;";
            conexion = new SQLiteConnection(cadenaConexion);
        }

        public void AbrirConexion()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CerrarConexion()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }


    }
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void Form_FormClosed(object? sender, FormClosedEventArgs e)
        {
            this.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            VentanaInicio ventanaInicio = new VentanaInicio();

            ventanaInicio.FormClosed += Form_FormClosed;

            this.Hide();

            ventanaInicio.Show();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            VentanaRegistro ventanaRegistro = new VentanaRegistro();

            ventanaRegistro.FormClosed += Form_FormClosed;

            this.Hide();

            ventanaRegistro.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VentanaPrueba ventanaPrueba = new VentanaPrueba();

            ventanaPrueba.FormClosed += Form_FormClosed;

            this.Hide();

            ventanaPrueba.Show();
        }

 
    }
}
