public class Logger{
    public static void SaveLog(string errorMessage)
    {
         string versionEnv = Environment.GetEnvironmentVariable("PROGRAM_VERSION") ?? "Versions unknown";
        // if(versionEnv=="" || versionEnv ==null){
        //     versionEnv="1.0.0";
        // }
        // versionEnv 
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

       
        string logEntry = $"[v{versionEnv}]{timestamp} - ERROR: {errorMessage}";

        // Abrir el archivo en modo de escritura (si no existe, se creará)
        using (StreamWriter writer = new StreamWriter("Utils/error_logs.txt", true))
        {
            // Escribir el mensaje de log en el archivo
            writer.WriteLine(logEntry);
        }
    }   

    public static string GetExceptionMessage()
    {
        try
        {
            throw new FormatException();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    }