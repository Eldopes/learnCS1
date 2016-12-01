using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using static LogGenerator.Helper; // to allow static access to rand object in Helper class

namespace LogGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start_time = DateTime.Now;
            LogOutput();
           // ConsoleOutput();
            Console.WriteLine("Time elapsed: {0}", DateTime.Now.Subtract(start_time));            
         
        }
        
        static void ConsoleOutput()  // console output
        {
            try
            {
                for (int i = 0; i < 20000; i++)
                {
                    Console.WriteLine(LogEntry()); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot write to console:");
                Console.WriteLine(e.Message);
            }
        }


        static void LogOutput() // file output
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("C:\\Users\\Eugene\\Desktop\\log_cs"))
                {
                    for (int i = 0; i < 500000; i++)
                    {
                        
                        sw.WriteLine(LogEntry());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot write to file:");
                Console.WriteLine(e.Message);
            }
        }

        static string LogEntry() // generate log
        { 
          
            string address = string.Format("{0}.{1}.{2}.{3}", rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255));
            int response_size = rand.Next(1000);
            int response_time = rand.Next(10);
            int response_code = 200;
            string method = RandomMethodString();
            string path = string.Format("/{0}/ file{1}.bin", rand.Next(100), rand.Next(1000));
            int gzip_ratio = rand.Next(7, 10);

            switch (rand.Next(1000))
            {
                case 100:
                case 105:
                    response_code = 404;
                    break;
                case 101:
                    response_code = 403;
                    break;
                case 102:
                    response_code = 500;
                    break;
            }

            var values = new {
                time = DateTime.UtcNow.ToString(),
                level = "INFO",
                address = address,
                request = string.Format("{0} {1} {2}", response_code, method, path),
                user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
                response_time = response_time,
                response_size = response_size,
                method = method,
                response_code = response_code,
                cache_status = (method == "DELETE" ? "MISS" : Helper.RandomCacheStatusString()),
                gzip_ratio = gzip_ratio
            };

            string log_format = string.Format("[{0}] {1} {2} '{3}' \"{4}\" {5} {6} {7} {8}\n", values.time, values.level, values.request, values.user_agent, values.address, values.response_size, values.response_time, values.cache_status, values.gzip_ratio);

              return log_format;
        }    

    }    
}
