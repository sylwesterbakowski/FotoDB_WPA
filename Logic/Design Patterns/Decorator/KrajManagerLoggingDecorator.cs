using FotoDB_WPA.ILogic;
using FotoDB_WPA.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Decorator
{
    public class KrajManagerLoggingDecorator : IKrajManager
    {
        private readonly IKrajManager _krajManager;
        private ILogger<KrajManagerLoggingDecorator> _logger;


        public KrajManagerLoggingDecorator(IKrajManager krajManager,
                                            ILogger<KrajManagerLoggingDecorator> logger)
        {
            _krajManager = krajManager;
            _logger = logger;
        }



        public KrajManager AddKraj(KrajModel krajModel)
        {
            return _krajManager.AddKraj(krajModel);
        }

        public KrajManager ChangeNazwa(int id, string newNazwa)
        {
            return _krajManager.ChangeNazwa(id, newNazwa);
        }

        public KrajModel GetKraj(int id)
        {
            return _krajManager.GetKraj(id);
        }

        public List<KrajModel> GetKrajs()
        {
            _logger.LogInformation("Rozpoczęcie pobierania danych");

            var stopwatch = Stopwatch.StartNew();

            IEnumerable<KrajModel> krajs = _krajManager.GetKrajs();

            foreach (var kraj in krajs)
            {
                _logger.LogInformation("Kraj: " + kraj.KrajModelID + ", Nazwa: " + kraj.Nazwa);
            }

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Zakończęcie pobierania danych w ciągu {elapsedTime} ms");

            return krajs.ToList();
        }

        public KrajManager RemoveKraj(int id)
        {
            return _krajManager.RemoveKraj(id);
        }

        public KrajManager UpdateKraj(KrajModel krajModel)
        {
            return _krajManager.UpdateKraj(krajModel);
        }
    }
}
