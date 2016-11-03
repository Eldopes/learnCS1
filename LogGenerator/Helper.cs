using System;


namespace LogGenerator
{
      class Helper
    {
        public static Random rand = new Random(); 

        public static string RandomMethodString()
        {
            
            int id = rand.Next(3);

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
            
            int id = rand.Next(3);

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
