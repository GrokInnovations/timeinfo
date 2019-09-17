using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Timezone
{
    class Reader : IReader, IDisposable
    {
        public List<Tuple<string, string>> Read()
        {
            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();

           
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Timezone.Timezone.txt"))
            {
                if (stream != null)
                {
                    using (BufferedStream bs = new BufferedStream(stream))
                    {

                        using (StreamReader sr = new StreamReader(bs))
                        {

                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] s = line.Split(new char[] { ' ' }, 2);
                                Tuple<string, string> timeZone = new Tuple<string, string>(s.First(), s.Last());

                                lReturn.Add(timeZone);


                            }

                        }
                    }

                }
                else
                {
                    throw new ArgumentException("No resource with name " + "Timezone.txt");
                }


            }
          

            return lReturn;
        }
        public void Dispose()
        {
        }
    }
}
