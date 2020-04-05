using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        private const string LOGPATH = "../../../log.txt";

        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.CurrUsername + ";"
                + LoginValidation.CurrUserRole + ";"
                + activity;
            currentSessionActivities.Add(activityLine);

            File.AppendAllText(LOGPATH, activityLine + Environment.NewLine);
        }

        public static string GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();

            currentSessionActivities.ForEach((string activity) =>
            {
                sb.AppendLine(activity);
            });

            return sb.ToString();
        }

        public static string GetActivityLog()
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(LOGPATH);

            while (!sr.EndOfStream)
            {
                sb.AppendLine(sr.ReadLine());
            }

            sr.Close();

            return sb.ToString();
        } 
    }
}
