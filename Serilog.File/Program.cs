namespace Serilog.File
{
    class Program
    {
        public static void Main(string[] args)
        {
            // CREAMOS LA CONFIGURACION DE LA RUTA DEL ARCHIVO .txt
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(@"C:\Users\Mario\Desktop\Serilog.Intro\Serilog.File\Logs\log.txt")
                .MinimumLevel.Verbose()
                .CreateLogger();

            try
            {
                // AGREGAMOS DISTINTOS NIVELES

                Log.Debug("La Aplicacion esta comenzando..");

                Log.Information("Hola {Name}!", Environment.GetEnvironmentVariable("Nombre Usuario"));

                Log.Warning("No deberías poder estar aquí");

                ThrowError();
            }
            catch (Exception e)
            {
                Log.Error(e, "Algo salio mal..");

            }

            Log.CloseAndFlush();
        }

        static void ThrowError()
        {
            throw new NullReferenceException();
        }
    }
}