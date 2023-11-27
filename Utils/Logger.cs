public class Logger{
    public static void SaveLog(string errorMessage)
    {
        
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

       
        string logEntry = $"{timestamp} - ERROR: {errorMessage}";

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