using System.Drawing.Imaging;

namespace ApiLoggin.Class
{
    public class LogsError
    {
        public static void WriteLogAplication(string mensaje, string modulo)
        {
            string fileName = @"Logs\Logs.txt";
            string fullPath;
            fullPath = Path.GetFullPath(fileName);
            using (StreamWriter file = new StreamWriter(fullPath, true))
            {
                file.WriteLine("--------------------------------------------------------------------------------------");
                file.WriteLine(DateTime.Now.ToString() + " Modulo-Metodo: " + modulo + " System Message: " + mensaje);
                file.Close();
            }
        }

    }
}
