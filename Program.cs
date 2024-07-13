namespace TP5
{

    public static class LogInActual
    {
        public static string Usuario;
        public static string Contraseña;
        public static string DB; 
    }


    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]     

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            using (var LoginForm = new LoginUI())
            {
                // Chequea si pasó el login
                if (LoginForm.ShowDialog() == DialogResult.OK)
                {
                    // Si el login fue exitoso, continuar con la aplicación principal
                    Application.Run(new MainUI(LogInActual.Usuario, LogInActual.Contraseña, LogInActual.DB));
                }
                else
                {
                    return;
                }
            }    
        }
    }
}