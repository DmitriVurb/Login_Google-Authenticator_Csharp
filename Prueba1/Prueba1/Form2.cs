using OtpNet;
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

namespace Prueba1
{
    public partial class VentanaInicio : Form
    {
        private ConexionDB dbConexion;

        public VentanaInicio()
        {
            InitializeComponent();

            dbConexion = new ConexionDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBox1.Text;
            string contraseñaIngresada = textBox3.Text;
            string codigoTOTPIngresado = textBox2.Text;

            dbConexion.AbrirConexion();

            string query = "SELECT contrasena, claveAuthenticator FROM usuarios WHERE usuario = @nombreUsuario";
            using (var comando = new SQLiteCommand(query, dbConexion.conexion))
            {
                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string contraseñaDb = reader["contrasena"].ToString();
                        string claveAuthenticatorDb = reader["claveAuthenticator"].ToString();
                        
                        if (contraseñaIngresada == contraseñaDb)
                        {
                            var totp = new Totp(Base32Encoding.ToBytes(claveAuthenticatorDb));
                            if (totp.VerifyTotp(codigoTOTPIngresado, out long timeStepMatched, new VerificationWindow(2, 2)))
                            {
                                MessageBox.Show("La verificación TOTP es correcta.", "Verificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Código TOTP incorrecto.", "Verificación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Contraseña incorrecta.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            dbConexion.CerrarConexion();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void VentanaInicio_Load(object sender, EventArgs e)
        {

        }
    }
}
