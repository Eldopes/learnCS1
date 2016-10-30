using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace LogGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
           //  ConsoleOutput();  
             LogOutput();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(LogEntry());
            }

            // TODO: with sleep
               
        }
        
        static void ConsoleOutput()  // срать в консоль
        {
            try
            {
                for (int i = 0; i < 1000; i++)
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


        static void LogOutput() // срать в файл
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("C:\\Users\\Eldopes\\Desktop\\log_cs.txt"))
                {
                    for (int i = 0; i < 1000; i++)
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

        static string LogEntry() // генерить лог
        {
            Random rand = new Random();
            string address = string.Format("{0}.{1}.{2}.{3}", rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255));
            int response_size = rand.Next(1000);
            int response_time = rand.Next(10);
            int response_code = 200;
            string method = Helper.RandomMethodString();
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

            string log_format = string.Format("[{0}] {1} {2} '{3}' \"{4}\" {5} {6} {7} {8}", values.time, values.level, values.request, values.user_agent, values.address, values.response_size, values.response_time, values.cache_status, values.gzip_ratio);

            //  return log_format;

            return path;
            
        }    

    }    
}
