using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;


namespace Timezone
{
    class Program
    {        
        static void Main(string[] args)
        {
            Parser timeZoneParser = new Parser();
            using (Reader fileReader = new Reader())
            {
                List<Tuple<string, string>> lTimes1 = fileReader.Read();
                foreach (var time in lTimes1)
                {
                    timeZoneParser.DisplayTime(time.Item1, time.Item2);
                }
            }
           
          
        }
    }
}
