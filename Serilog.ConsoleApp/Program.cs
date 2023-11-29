using Serilog.Sinks.SystemConsole.Themes;

namespace Serilog.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            // CREAMOS LA CONFIGURACION  DEL LOG
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code) // DONDE LO TIENE QUE ESCRIBIR
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