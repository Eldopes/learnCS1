using System;


namespace LogGenerator
{
      class Helper
    {      

        public static string RandomMethodString()
        {
            Random rand_one = new Random();
            int id = rand_one.Next(3);

            switch (id)
            {
                case 0:
                    return "GET";
                case 1:
                    return "HEAD";               
                case 2:
                    return "DELETE";
                default:
                    return "undefined";                    
            }            
        }

        public static string RandomCacheStatusString()
        {
            Random rand_two = new Random();
            int id = rand_two.Next(3);

            switch (id)
            {
                case 0:
                    return "HIT";
                case 1:
                    return "MISS";
                case 2:
                    return "BYPASS";
                default:
                    return "undefined";
            }
        }

    }
}
