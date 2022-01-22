using FotoDB_WPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Adapter
{
    public class AnalyticsAdapterObiektowy : IAnalyticsAdapter
    {
        private readonly IAnalyticsService _analyticsService;
        public AnalyticsAdapterObiektowy(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }
        public void ProcessAutors(List<AutorModel> autors)
        {
            Console.WriteLine("AnalyticsAdapterObiektowy");
            var json = System.Text.Json.JsonSerializer.Serialize(autors);

            _analyticsService.GenerateReport(json);
        }
    }
}
