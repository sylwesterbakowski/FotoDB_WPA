using FotoDB_WPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Adapter
{
    public class AnalyticsAdapterKlasowy : AnalyticsService, IAnalyticsAdapter
    {
        public void ProcessAutors(List<AutorModel> autors)
        {
            Console.WriteLine("AnalyticsAdapterKlasowy");
            var json = System.Text.Json.JsonSerializer.Serialize(autors);

            GenerateReport(json);
        }
    }
}
