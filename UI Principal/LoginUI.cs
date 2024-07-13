using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TP5
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar login
            if (ValidarLogin(UserText.Text, PasswordText.Text, DBBox.Text))
            {                       
                LogInActual.Usuario = UserText.Text;
                LogInActual.Contraseña = PasswordText.Text;
                LogInActual.DB = DBBox.Text;

                // Establecer el resultado del formulario como OK
                this.DialogResult = DialogResult.OK;
                this.Close();

                
                /*MainUI mainUI = new MainUI(UserText.Text, PasswordText.Text, DBBox.Text);
                mainUI.Show();
                this.Hide();*/
            }
            else
            {
                MessageBox.Show("Credenciales invalidas");
            }
        }

        private bool ValidarLogin(string User, string Pass, string DB)
        {
            try
            {
                // Conexion SQL Server
                var LocalCNX = new SqlConnection($"Data Source=DESKTOP-UJR9NPC\\SQLEXPRESS;Initial Catalog={DB};Integrated Security=False;packet size=4096;UID={User};PWD={Pass}"); // Usando "$" se permite la interpolación de cadenas

                LocalCNX.Open();
                LocalCNX.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}


/* 

        
    }
}
*/