using System.Data;
using System.Data.SqlClient;

namespace TP5
{
    public partial class CRUD_Clientes : Form
    {
        private readonly string SQLString;

        public CRUD_Clientes(string SQLStringConnection)
        {
            InitializeComponent();
            SQLString = SQLStringConnection;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarIngresos()
        {
            if (!Funciones.ValidezTextBox(TxtCode, "El Codigo no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezTextBox(TxtRS, "La Razón Social no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezTextBox(TxtDomicilio, "El Domicilio no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezTextBox(TxtLocalidad, "La Localidad no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezTextBox(TxtCUIT, "El Código Postal no puede ser <NULO>"))
                return false;

            return true;
        }

        private int ExisteClave(int COD)
        {
            // Conectar a la BD
            var LocalCNX = new SqlConnection(SQLString);
            LocalCNX.Open();

            var LocalCMD = new SqlCommand("SELECT COUNT(*) FROM dbo.CLIENTES WHERE CODIGO = " + COD.ToString(), LocalCNX);

            var LocalDA = new SqlDataAdapter(LocalCMD);

            var LocalDT = new DataTable();

            LocalDA.Fill(LocalDT);

            return int.Parse(LocalDT.Rows[0][0].ToString()); // Convierte el resultado a entero
            // LocalDT.Rows[0] accede a la primera Fila y el segundo [0] a la columna
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // Valido los ingresos
            if (!ValidarIngresos())
            {
                return;
            }

            // Convertir los textos a mayúsculas
            TxtRS.Text = TxtRS.Text.ToUpper();
            TxtDomicilio.Text = TxtDomicilio.Text.ToUpper();
            TxtLocalidad.Text = TxtLocalidad.Text.ToUpper();

            // Validar valores numéricos (CUIT y CODIGO) 
            if (!Funciones.EsNúmeroValido(TxtCode.Text))
            {
                MessageBox.Show("El Código debe ser un número.");
                return;
            }

            if (!Funciones.EsNúmeroValido(TxtCUIT.Text))
            {
                MessageBox.Show("El CUIT debe ser un número.");
                return;
            }

            if (!Funciones.ValidarCUIT(TxtCUIT.Text))
            {
                MessageBox.Show("El CUIT no es válido.");
                return;
            }

            // Mostrar mensaje de confirmación antes de guardar
            if (!MostrarMensajeConfirmacion("¿Está seguro de realizar la operación?"))
            {
                return;
            }

            string operacion;

            // Valido si existe el CP
            if (ExisteClave(int.Parse(TxtCode.Text)) == 0)
            {
                operacion = "INSERT INTO dbo.CLIENTES (CODIGO, RS, DOMICILIO, LOCALIDAD, CP, FECHA_ALTA, CUIT) VALUES (@CODIGO, @RS, @DOMICILIO, @LOCALIDAD, @CP, @FECHA_ALTA, @CUIT)";
            }
            else
            {
                operacion = "UPDATE dbo.CLIENTES SET RS = @RS, DOMICILIO = @DOMICILIO, LOCALIDAD = @LOCALIDAD, CP = @CP WHERE CODIGO = @CODIGO";
            }

            // Ejecuto el comando correspondiente
            using (var LocalCNX = new SqlConnection(SQLString))
            {
                LocalCNX.Open();

                using (var LocalCMD = new SqlCommand(operacion, LocalCNX))
                {
                    // Agregar parámetros
                    LocalCMD.Parameters.AddWithValue("@CODIGO", int.Parse(TxtCode.Text));
                    LocalCMD.Parameters.AddWithValue("@RS", TxtRS.Text);
                    LocalCMD.Parameters.AddWithValue("@DOMICILIO", TxtDomicilio.Text);
                    LocalCMD.Parameters.AddWithValue("@LOCALIDAD", TxtLocalidad.Text);
                    LocalCMD.Parameters.AddWithValue("@CP", comboBox1.SelectedItem.ToString().Split("-")[0].Trim());
                    LocalCMD.Parameters.AddWithValue("@FECHA_ALTA", DateTime.Now);
                    LocalCMD.Parameters.AddWithValue("@CUIT", long.Parse(TxtCUIT.Text));

                    try
                    {
                        MessageBox.Show("Operación realizada con exito <Filas afectadas>: " + LocalCMD.ExecuteNonQuery());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

                LocalCNX.Close();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            // Validar si hay un CP
            if (string.IsNullOrEmpty(TxtCode.Text))
            {
                MessageBox.Show("Debe ingresar un Código.");
                return;
            }

            // Validar el tipo de dato
            if (!Funciones.EsNúmeroValido(TxtCode.Text))
            {
                MessageBox.Show("El Código debe ser un número.");
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

                using (var LocalCMD = new SqlCommand("DELETE FROM dbo.CLIENTES WHERE CODIGO = @CODIGO", LocalCNX))
                {
                    // Agregar parámetro
                    LocalCMD.Parameters.AddWithValue("@CODIGO", int.Parse(TxtCode.Text));

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

        private bool MostrarMensajeConfirmacion(string mensaje)
        {
            DialogResult resultado = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (resultado == DialogResult.Yes);
        }

        // Clase para almacenar los datos del registro
        private class DatosRegistro
        {
            public int Codigo { get; set; }
            public string CUIT { get; set; }
            public string RS { get; set; }
            public string Domicilio { get; set; }
            public string Localidad { get; set; }
            public int CP { get; set; }
            public string Fecha_Alta { get; set; }
        }

        private DatosRegistro ObtenerDatosRegistro(int codigo)
        {
            string query = "SELECT * FROM dbo.CLIENTES WHERE CODIGO = @CODIGO";

            using (var LocalCNX = new SqlConnection(SQLString))
            {
                LocalCNX.Open();

                using (var LocalCMD = new SqlCommand(query, LocalCNX))
                {
                    LocalCMD.Parameters.AddWithValue("@CODIGO", codigo);

                    using (var registro = LocalCMD.ExecuteReader())
                    {
                        // Verificar si se encontraron resultados
                        if (registro.Read())
                        {
                            // Crear un nuevo objeto 'DatosRegistro' con los datos obtenidos
                            return new DatosRegistro
                            {
                                Codigo = Convert.ToInt32(registro["CODIGO"]),
                                CUIT = registro["CUIT"].ToString(),
                                RS = registro["RS"].ToString(),
                                Domicilio = registro["DOMICILIO"].ToString(),
                                Localidad = registro["LOCALIDAD"].ToString(),
                                CP = Convert.ToInt32(registro["CP"]),
                                Fecha_Alta = registro["FECHA ALTA"].ToString(),
                            };
                        }
                    }
                }

                LocalCNX.Close();
            }

            return null; // Retorna null si no se encontraron datos para el CP dado
        }

        private void TxtCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCode.Text))
            {
                CargarDatosEnLaGrilla(TxtCode.Text);
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void TxtRS_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtRS.Text))
            {
                CargarDatosEnLaGrilla(TxtRS.Text);
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void CargarDatosEnLaGrilla(string criterio)
        {
            try
            {
                string query = "SELECT * FROM dbo.CLIENTES WHERE CAST(CODIGO AS VARCHAR) LIKE @Criterio OR RS LIKE @Criterio";

                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        LocalCMD.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                        var LocalDA = new SqlDataAdapter(LocalCMD);
                        var LocalDT = new DataTable();
                        LocalDA.Fill(LocalDT);
                        GrillaClientes.DataSource = LocalDT;
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            TxtCode.Clear();
            TxtCUIT.Clear();
            TxtRS.Clear();
            TxtLocalidad.Clear();
            TxtDomicilio.Clear();
            comboBox1.SelectedItem = null;
            LblFecha.Text = "";
            LblFecha.Visible = false;

            try
            {
                string query = "SELECT * FROM CLIENTES";

                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        var LocalDA = new SqlDataAdapter(LocalCMD);
                        var LocalDT = new DataTable();
                        LocalDA.Fill(LocalDT);
                        GrillaClientes.DataSource = LocalDT;
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos en la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrillaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = GrillaClientes.Rows[e.RowIndex];

                // Obtengo los valores de las celdas de la fila donde se hizo doble clic
                string codigo = fila.Cells["CODIGO"].Value.ToString();
                string cuit = fila.Cells["CUIT"].Value.ToString();
                string rs = fila.Cells["RS"].Value.ToString();
                string domicilio = fila.Cells["DOMICILIO"].Value.ToString();
                string localidad = fila.Cells["LOCALIDAD"].Value.ToString();
                string cp = fila.Cells["CP"].Value.ToString();
                string fecha_alta = fila.Cells["FECHA_ALTA"].Value.ToString();


                // Asigno los valores
                TxtCode.Text = codigo;
                TxtCUIT.Text = cuit;
                TxtRS.Text = rs;
                TxtLocalidad.Text = localidad;
                comboBox1.Text = cp + " - " + localidad;
                TxtDomicilio.Text = domicilio;
                LblFecha.Text = "Fecha de alta: " + fecha_alta;
                LblFecha.Visible = true;
            }
        }

        private void CargarCP()
        {
            try
            {
                string query = "SELECT DISTINCT CONVERT(VARCHAR, CP) + ' - ' + LOCALIDAD AS CP_SUCURSAL FROM SUCURSALES";

                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        using (var reader = LocalCMD.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string cp_sucursal = reader["CP_SUCURSAL"].ToString();
                                comboBox1.Items.Add(cp_sucursal);
                            }
                        }
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los CP: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CRUD_Clientes_Load(object sender, EventArgs e)
        {
            CargarCP();

            string query = "SELECT * FROM CLIENTES";

            try
            {
                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        var LocalDA = new SqlDataAdapter(LocalCMD);
                        var LocalDT = new DataTable();
                        LocalDA.Fill(LocalDT);
                        GrillaClientes.DataSource = LocalDT;
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los Clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string cp_sucursal = comboBox1.SelectedItem.ToString();

                // Separo la cadena
                string cp = cp_sucursal.Split("-")[0].Trim();

                // Busco la localidad correspondiente
                string localidad = BuscarLocalidad(cp);

                // Los muestro en pantalla
                TxtLocalidad.Text = localidad;
            }
        }

        private string BuscarLocalidad(string cp)
        {
            string localidad = string.Empty;

            try
            {
                string query = "SELECT LOCALIDAD FROM SUCURSALES WHERE CP = @CP";

                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        LocalCMD.Parameters.AddWithValue("@CP", cp);

                        object result = LocalCMD.ExecuteScalar();

                        if (result != null)
                        {
                            localidad = result.ToString();
                        }
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la localidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return localidad;
        }
    }
}

