using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            System.Net.ServicePointManager.SecurityProtocol =  System.Net.SecurityProtocolType.Tls12;
            var driver = GraphDatabase.Driver("bolt://sb10.stations.graphenedb.com:24786", AuthTokens.Basic("db303", "e00nmVjiUcGgGC2grCBb"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());

            using (var session = driver.Session()) {
                Console.WriteLine(session);
                var result = session.Run("MATCH (n) RETURN count(n)");
                Console.WriteLine(result);
            }
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
