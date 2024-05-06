using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QRCoder;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SQLite;

namespace Prueba1
{
    public partial class VentanaRegistro : Form
    {
        private ConexionDB dbConexion;
        private GeneradorClave generadorClave; // Asumiendo que tu clase GeneradorClave tiene la lógica para generar la clave

        public VentanaRegistro()
        {
            InitializeComponent();

            dbConexion = new ConexionDB();

            generadorClave = new GeneradorClave();

            generadorClave.GenerarAuthenticator();
        }




        private void VentanaRegistro_Load(object sender, EventArgs e)
        {

        }

        private void buttonClave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tu código autenticador es: " + generadorClave.ClaveAuthenticator, "Código Autenticador", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonMostrarQR_Click(object sender, EventArgs e)
        {
            dbConexion.AbrirConexion();

            string clave = generadorClave.ClaveAuthenticator;
            string mitad2 = textBox1.Text;
            string mitad1;

            string query = "SELECT id FROM usuarios ORDER BY id DESC LIMIT 1";
            using (var comando = new SQLiteCommand(query, dbConexion.conexion))
            {
                var resultado = comando.ExecuteScalar();
                if (resultado != null)
                {
                    int lastID = Convert.ToInt32(resultado);
                    lastID++;
                    mitad1 = lastID.ToString();
                }
                else
                {
                    mitad1 = "XXXXX";
                }
            }

            dbConexion.CerrarConexion();

            string nombre = mitad1 + "°" + mitad2.ToUpper();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            string qrContent = $"otpauth://totp/ExperimentoCsharp:{nombre}?secret={clave}&issuer=ExperimentoCsharp";

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCodeGenerator.ECCLevel.Q))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(20);

                        Form qrForm = new Form
                        {
                            Text = "Código QR",
                            Size = new Size(300, 300)
                        };

                        PictureBox pictureBox = new PictureBox
                        {
                            Image = qrCodeImage,
                            Dock = DockStyle.Fill,
                            SizeMode = PictureBoxSizeMode.Zoom
                        };

                        qrForm.Controls.Add(pictureBox);
                        qrForm.ShowDialog();
                    }
                }
            }
        }

        private void buttonREGISTRO_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string contra = textBox2.Text;
            string secreto = generadorClave.ClaveAuthenticator;

            dbConexion.AbrirConexion();

            string queryVerificacion = "SELECT COUNT(*) FROM usuarios WHERE usuario = @user";
            using (var comandoVerificacion = new SQLiteCommand(queryVerificacion, dbConexion.conexion))
            {
                comandoVerificacion.Parameters.AddWithValue("@user", user);
                int userExists = Convert.ToInt32(comandoVerificacion.ExecuteScalar());

                if (userExists > 0)
                {
                    MessageBox.Show("El nombre de usuario ya está en uso. Por favor, elige otro.", "Usuario Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string queryInsercion = "INSERT INTO usuarios (usuario, contrasena, claveAuthenticator) VALUES (@user, @contra, @secreto)";
                    using (var comandoInsercion = new SQLiteCommand(queryInsercion, dbConexion.conexion))
                    {
                        comandoInsercion.Parameters.AddWithValue("@user", user);
                        comandoInsercion.Parameters.AddWithValue("@contra", contra);
                        comandoInsercion.Parameters.AddWithValue("@secreto", secreto);

                        comandoInsercion.ExecuteNonQuery();

                        MessageBox.Show($"Usuario: {user} - registrado correctamente", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            dbConexion.CerrarConexion();
        }

    }

    public class GeneradorClave
    {
        public string ClaveAuthenticator { get; private set; }

        public void GenerarAuthenticator()
        {
            byte[] buffer = new byte[20];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buffer);
            }
            ClaveAuthenticator =  ConvertToBase32(buffer);
        }

        private static string ConvertToBase32(byte[] data)
        {
            const string base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
            StringBuilder result = new StringBuilder(data.Length * 8 / 5);

            int bitBuffer = 0;
            int currentBits = 0;
            foreach (byte b in data)
            {
                bitBuffer = (bitBuffer << 8) | b;
                currentBits += 8;

                while (currentBits >= 5)
                {
                    int index = (bitBuffer >> (currentBits - 5)) & 0x1F;
                    result.Append(base32Chars[index]);
                    currentBits -= 5;
                }
            }

            // Bits restantes
            if (currentBits > 0)
            {
                int index = (bitBuffer << (5 - currentBits)) & 0x1F;
                result.Append(base32Chars[index]);
            }

            return result.ToString();

        }

    }

}
