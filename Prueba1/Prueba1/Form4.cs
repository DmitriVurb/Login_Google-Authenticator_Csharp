using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtpNet;

namespace Prueba1
{
    public partial class VentanaPrueba : Form
    {
        private ConexionDB dbConexion;

        public VentanaPrueba()
        {
            InitializeComponent();

            dbConexion = new ConexionDB();
        }

        private void VentanaPrueba_Load(object sender, EventArgs e)
        {

        }

        private void buttonPrueba_Click(object sender, EventArgs e)
        {
            dbConexion.AbrirConexion();

            string query = "SELECT claveAuthenticator FROM usuarios WHERE usuario = @nombreUsuario";
            using (var comando = new SQLiteCommand(query, dbConexion.conexion))
            {
                comando.Parameters.AddWithValue("@nombreUsuario", "prueba");

                try
                {
                    var resultado = comando.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        MessageBox.Show($"El código TOTP es: {resultado.ToString()}", "Código TOTP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado o no tiene un código TOTP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el código TOTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dbConexion.CerrarConexion();
        }

        private void buttonTOTP_Click(object sender, EventArgs e)
        {
            string codigoUsuario = textBox1.Text;

            dbConexion.AbrirConexion();

            string query = "SELECT claveAuthenticator FROM usuarios WHERE usuario = @nombreUsuario";
            using (var comando = new SQLiteCommand(query, dbConexion.conexion))
            {
                comando.Parameters.AddWithValue("@nombreUsuario", "prueba");

                try
                {
                    var resultado = comando.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        var claveSecreta = resultado.ToString();
                        var totp = new Totp(Base32Encoding.ToBytes(claveSecreta));
                        if (totp.VerifyTotp(codigoUsuario, out _, new VerificationWindow(1, 1)))
                        {
                            MessageBox.Show("La verificación TOTP es correcta.", "Verificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("La verificación TOTP es incorrecta.", "Verificación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado o clave TOTP no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al verificar el código TOTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dbConexion.CerrarConexion();
        }
    }
}
