using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Parser : IParser
    {
        public void DisplayTime(string time, string timezone) {
            Console.WriteLine("The time in the UK is {0} and the time in {1} is {2}",time, timezone, ConvertTimeinfo(time,timezone));

        }

        public string ConvertTimeinfo(string time, string timezone)
        {
            string[] hhmm = time.Split(new char[] { ':' }, 2);
            Int32 HH;
            DateTime timeUtc= new DateTime();
            Int32 MM;
            if(Int32.TryParse(hhmm[0],out HH) && Int32.TryParse(hhmm[1], out MM))
                 timeUtc = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, HH, MM, 0);

            string ireturn= string.Empty;
            try
            {
                TimeZoneInfo cstZone = TimeZoneInfo.GetSystemTimeZones().Where(k => k.DisplayName.Substring(k.DisplayName.IndexOf(')') + 2).ToLower().IndexOf(timezone.ToLower()) >= 0).SingleOrDefault<TimeZoneInfo>();
            
             //  TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById(timezone + " Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
                ireturn= cstTime.ToString("HH:mm");
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("The registry does not define the Standard Time zone.");
            }
            catch (InvalidTimeZoneException)
            {
                Console.WriteLine("Registry data on the Central Standard Time zone has been corrupted.");
            }
            return ireturn;

        }
    }
}
