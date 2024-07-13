using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP5
{
    public partial class CRUD_Sucursales : Form
    {
        private readonly string SQLString;

        public CRUD_Sucursales(string SQLStringConnection) // Recibe la str de conexion mediante el constructor
        {
            InitializeComponent();
            SQLString = SQLStringConnection;
        }

        private void BackBtn_Click(object sender, EventArgs e) // Cierra la pestaña
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e) // Guarda un nuevo registro o modifica uno existente
        {
            // Valido los ingresos
            if (!ValidarIngresos())
            {
                return;
            }

            // Convertir los textos a mayúsculas
            TxtBoxLocalidad.Text = TxtBoxLocalidad.Text.ToUpper();
            TxtBoxPartido.Text = TxtBoxPartido.Text.ToUpper();
            TxtBoxDomicilio.Text = TxtBoxDomicilio.Text.ToUpper();

            // Validar valores numéricos (CP) 
            if (!Funciones.EsNúmeroValido(TxtBoxCP.Text))
            {
                MessageBox.Show("El Código Postal debe ser un número.");
                return;
            }

            string operacion;

            // Valido si existe el CP
            if (ExisteClave(int.Parse(TxtBoxCP.Text)) == 0)
            {
                operacion = "INSERT INTO dbo.SUCURSALES (CP, LOCALIDAD, PARTIDO, PROVINCIA, DOMICILIO) VALUES (@CP, @LOCALIDAD, @PARTIDO, @PROVINCIA, @DOMICILIO)";
            }
            else
            {
                operacion = "UPDATE dbo.SUCURSALES SET LOCALIDAD = @LOCALIDAD, PARTIDO = @PARTIDO, PROVINCIA = @PROVINCIA, DOMICILIO = @DOMICILIO WHERE CP = @CP";
            }

            // Ejecuto el comando correspondiente
            using (var LocalCNX = new SqlConnection(SQLString))
            {
                LocalCNX.Open();

                using (var LocalCMD = new SqlCommand(operacion, LocalCNX))
                {
                    // Agregar parámetros
                    LocalCMD.Parameters.AddWithValue("@CP", int.Parse(TxtBoxCP.Text));
                    LocalCMD.Parameters.AddWithValue("@Localidad", TxtBoxLocalidad.Text);
                    LocalCMD.Parameters.AddWithValue("@Partido", TxtBoxPartido.Text);
                    LocalCMD.Parameters.AddWithValue("@Provincia", comboBox1.SelectedItem.ToString());
                    LocalCMD.Parameters.AddWithValue("@Domicilio", TxtBoxDomicilio.Text);

                    try
                    {
                        MessageBox.Show("Operación realizada con exito <Filas Afectadas>: " + LocalCMD.ExecuteNonQuery());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

                LocalCNX.Close();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e) // Borra un registro
        {
            // Validar si hay un CP
            if (string.IsNullOrEmpty(TxtBoxCP.Text))
            {
                MessageBox.Show("Debe ingresar un Código Postal.");
                return;
            }

            // Validar el tipo de dato
            if (!Funciones.EsNúmeroValido(TxtBoxCP.Text))
            {
                MessageBox.Show("El Código Postal debe ser un número.");
                return;
            }

            // Mostrar mensaje de confirmación
            if (!MostrarMensajeConfirmacion("¿Está seguro de realizar la operación?"))
            {
                return;
            }
 
            // Ejecutar el comando correspondiente
            using (var LocalCNX = new SqlConnection(SQLString))
            {
                LocalCNX.Open();

                using (var LocalCMD = new SqlCommand("DELETE FROM dbo.SUCURSALES WHERE CP = @CP", LocalCNX))
                {
                    // Agregar parámetro
                    LocalCMD.Parameters.AddWithValue("@CP", int.Parse(TxtBoxCP.Text));

                    try
                    {
                        MessageBox.Show("Se eliminó el registro correctamente <Filas Afectadas>: " + LocalCMD.ExecuteNonQuery());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al intentar eliminar el registro: " + ex.Message);
                    }
                }

                LocalCNX.Close();
            }   
        }

        private bool ValidarIngresos() // Valida que no falte ingresar campos
        {
            if (!Funciones.ValidezTextBox(TxtBoxCP, "El Codigo Postal no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezTextBox(TxtBoxLocalidad, "La Localidad no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezTextBox(TxtBoxPartido, "El Partido no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezComboBox(comboBox1, "Debe seleccionar una Provincia."))
                return false;

            if (!Funciones.ValidezTextBox(TxtBoxDomicilio, "El Domicilio no puede ser <NULO>"))
                return false;

            return true;
        }

        private int ExisteClave(int CP) // Valida si existe un registro
        {
            // Conectar a la BD
            var LocalCNX = new SqlConnection(SQLString);
            LocalCNX.Open();

            var LocalCMD = new SqlCommand("SELECT COUNT(*) FROM dbo.SUCURSALES WHERE CP = " + CP.ToString(), LocalCNX);

            var LocalDA = new SqlDataAdapter(LocalCMD);

            var LocalDT = new DataTable();

            LocalDA.Fill(LocalDT);

            return int.Parse(LocalDT.Rows[0][0].ToString()); // Convierte el resultado a entero
            // LocalDT.Rows[0] accede a la primera Fila y el segundo [0] a la columna
        }

        private bool MostrarMensajeConfirmacion(string mensaje) // Mensaje de confimación para el usuario
        {
            DialogResult resultado = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (resultado == DialogResult.Yes);
        }

        // Clase para almacenar los datos del registro
        private class DatosRegistro
        {
            public string Localidad { get; set; }
            public string Partido { get; set; }
            public string Provincia { get; set; }
            public string Domicilio { get; set; }
        }

        private DatosRegistro ObtenerDatosRegistro(int cp)
        {
            string query = "SELECT * FROM dbo.SUCURSALES WHERE CP = @CP";

            using (var LocalCNX = new SqlConnection(SQLString))
            {
                LocalCNX.Open();

                using (var LocalCMD = new SqlCommand(query, LocalCNX))
                {
                    LocalCMD.Parameters.AddWithValue("@CP", cp);

                    using (var registro = LocalCMD.ExecuteReader())
                    {
                        // Verificar si se encontraron resultados
                        if (registro.Read())
                        {
                            // Crear un nuevo objeto 'DatosRegistro' con los datos obtenidos
                            return new DatosRegistro
                            {
                                Localidad = registro["LOCALIDAD"].ToString(),
                                Partido = registro["PARTIDO"].ToString(),
                                Provincia = registro["PROVINCIA"].ToString(),
                                Domicilio = registro["DOMICILIO"].ToString()
                            };
                        }
                    }
                }

                LocalCNX.Close();
            }

            return null; // Retorna null si no se encontraron datos para el CP dado
        }

        private void TxtBoxCP_TextChanged(object sender, EventArgs e)
        {
            if (Funciones.EsNúmeroValido(TxtBoxCP.Text))
            {
                // Consultar y obtener los datos del registro si existe
                DatosRegistro datosRegistro = ObtenerDatosRegistro(int.Parse(TxtBoxCP.Text));

                if (datosRegistro != null)
                {
                    // Rellenar los campos a mostrar
                    TxtBoxLocalidad.Text = datosRegistro.Localidad;
                    TxtBoxPartido.Text = datosRegistro.Partido;
                    comboBox1.SelectedItem = datosRegistro.Provincia;
                    TxtBoxDomicilio.Text = datosRegistro.Domicilio;
                }
                else
                {
                    // Limpiar los campos si no se encontró ningún registro con ese CP
                    TxtBoxLocalidad.Clear();
                    TxtBoxPartido.Clear();
                    comboBox1.SelectedItem = null;
                    TxtBoxDomicilio.Clear();
                }
            }
            else
            {
                // Limpiar si el valor ingresado no es un número válido
                TxtBoxLocalidad.Clear();
                TxtBoxPartido.Clear();
                comboBox1.SelectedItem = null;
                TxtBoxDomicilio.Clear();
            }
        }
    }
}
