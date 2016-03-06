using System;

namespace BLL.Infrastructure
{
    public static class ExceptionWriter
    {
        public static void WriteException(string service, Exception ex)
        {
            using (System.IO.StreamWriter file =
                   new System.IO.StreamWriter(
                      AppDomain.CurrentDomain.BaseDirectory + @"\Logs\" + service + " log " + 
                      DateTime.Now.ToShortDateString() + ".txt", true))
            {
                file.WriteLine(ex.Message + ": " + ex.StackTrace);
            }
        }
    }
}
