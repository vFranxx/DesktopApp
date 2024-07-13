using System;
using System.Globalization;

public class Funciones
{
	public static bool EsFechaValida(string fecha)
    {
        if (DateTime.TryParseExact(fecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _)) // DateTime.TryParseExact transforma un string en un date time
        {                                                                                                       // System.Globalization.DateTimeStyles.None indica que no se aplican estilos de formato adicionales.
            return true;                                                                                        // El resultado de la conversión se almacena en esta variable. El guión bajo se utiliza como marcador para indicar que no estamos interesados en el valor real.
        }
       
        return false;
    }

    public static bool EsFechaValidaEnRango(string fecha, DateTime fecha1, DateTime fecha2)
    {
        if (DateTime.TryParseExact(fecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var fechaIngresada))
        {
            // Verifica si la fecha ingresada está dentro del rango
            return fechaIngresada >= fecha1 && fechaIngresada <= fecha2;
        }

        return false;
    }

    public static bool EsHoraValida(string hora)
    {
        if (DateTime.TryParseExact(hora, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))    // CultureInfo.InvariantCulture especifica la configuración regional (cultura) que se utilizará para el análisis. InvariantCulture se refiere a un formato independiente de la configuración regional.    
        {                                                                                                       // DateTimeStyles.None indica que no se aplicarán estilos adicionales al análisis.
            return true;
        }

        return false;
    }
    
    public static bool EsNúmeroValido(string numero)
    {
        if (decimal.TryParse(numero, out _)) 
        {                                                                                                      
            return true;                                                                                        
        }

        return false;
    }

    public static bool EsNúmeroValido1(string numero, decimal largo, decimal decimales)
    {
        if (!EsNúmeroValido(numero))
        {
            return false;
        }

        if (numero.Length != largo) //Si el largo del string es distinto del largo, devuelve falso.-
        {
            return false;
        }

        string[] cantDecimal = numero.Split('.'); 

        if (cantDecimal[1].Length != decimales) //Si la cantidad de decimales del string es distinta decimales, devuelve falso.-
        {
            return false;
        }

        return true;
    }

    public static bool EsNúmeroValidoEnRango(string numero, string numero1, string numero2)
    {
        if (decimal.TryParse(numero, out decimal valor) &&
            decimal.TryParse(numero1, out decimal valor1) &&
            decimal.TryParse(numero2, out decimal valor2))
        {
            return valor1 <= valor && valor <= valor2;
        }
        
        return false;
    }

    public static bool ValidezTextBox(TextBox text_box, string mensaje) 
    {
        if (string.IsNullOrWhiteSpace(text_box.Text))
        {
            MessageBox.Show(mensaje, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            text_box.Focus();
            text_box.BackColor = Color.IndianRed;
            return false;
        }
        text_box.BackColor = SystemColors.Window;
        return true;
    }

    public static bool ValidezComboBox(ComboBox combo_box, string mensaje)
    {
        if (string.IsNullOrWhiteSpace(combo_box.Text))
        {
            MessageBox.Show(mensaje, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            combo_box.Focus();
            combo_box.BackColor = Color.IndianRed;
            return false;
        }
        combo_box.BackColor = SystemColors.Window; 
        return true;
    }

    public static bool ValidarCUIT(string cuit)
    {
        // Verificar longitud
        if (cuit.Length != 11)
        {
            return false;
        }

        // Verificar primeros dos dígitos
        string primerosDos = cuit.Substring(0, 2);
        if (primerosDos != "20" && primerosDos != "30" && primerosDos != "27")
        {
            return false;
        }

        // Verificar que todos los caracteres sean dígitos numéricos
        foreach (char c in cuit)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }

        return true;
    }
}
