using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Adapter
{
    //Zewnętrzna klasa generowania raportów
    public class AnalyticsService : IAnalyticsService
    {
        public void GenerateReport(string json)
        {
            // Metoda generowania raportu w postaci pliku json.
            Console.WriteLine("");
            Console.WriteLine("################# KLASA ZEWNĘTRZNA #################");
            Console.WriteLine("#     Wygenerowano raport w postaci pliku json     #");
            Console.WriteLine("####################################################");
            Console.WriteLine(json);
            Console.WriteLine("");
        }
    }
}
