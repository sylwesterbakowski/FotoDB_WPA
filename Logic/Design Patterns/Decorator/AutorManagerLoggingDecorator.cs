using FotoDB_WPA.ILogic;
using FotoDB_WPA.Logic.Design_Patterns.Observer;
using FotoDB_WPA.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Decorator
{
    public class AutorManagerLoggingDecorator : IAutorManager
    {
        private readonly IAutorManager _autorManager;
        private ILogger<AutorManagerLoggingDecorator> _logger;

        /// <summary>
        /// Lista Obserwatorów
        /// </summary>
        public List<IAutorModelObserver> Observers = new List<IAutorModelObserver>();


        public AutorManagerLoggingDecorator(IAutorManager autorManager,
                                            ILogger<AutorManagerLoggingDecorator> logger)
        {
            _autorManager = autorManager;
            _logger = logger;
        }
        public AutorManager AddAutor(AutorModel autorModel)
        {
            return _autorManager.AddAutor(autorModel);
        }

        public void Attach(IAutorModelObserver observer)
        {
            
            _autorManager.Attach(observer);
            _logger.LogInformation("Dodano obserwatora");
        }

        public AutorManager ChangeImie(int id, string newImie)
        {
            return _autorManager.ChangeImie(id, newImie);
        }

        public AutorManager ChangeKraj(int id, int id_kraj)
        {
            return _autorManager.ChangeKraj(id, id_kraj);
        }

        public AutorManager ChangeNazwisko(int id, string newNazwisko)
        {
            return _autorManager.ChangeNazwisko(id, newNazwisko);
        }

        public void Detach(IAutorModelObserver observer)
        {
            _autorManager.Detach(observer);
            _logger.LogInformation("Usunięto obserwatora");
        }

        public AutorModel GetAutor(int id)
        {
            return _autorManager.GetAutor(id);
        }

        public List<AutorModel> GetAutors()
        {
            _logger.LogInformation("Rozpoczęcie pobierania danych");

            var stopwatch = Stopwatch.StartNew();

            IEnumerable<AutorModel> autors = _autorManager.GetAutors();

            foreach (var autor in autors)
            {
                _logger.LogInformation("Autor: " + autor.AutorModelID + ", Nazwisko: " + autor.Nazwisko + ", Imię: " + autor.Imie + ", KrajID: " + autor.KrajModelID);
            }

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Zakończęcie pobierania danych w ciągu {elapsedTime} ms");

            return autors.ToList();
        }

        public IEnumerable<SelectListItem> GetListKrajs()
        {
            return _autorManager.GetListKrajs();
        }

        public void Notify(AutorModel autormodel)
        {
            _autorManager.Notify(autormodel);
            _logger.LogInformation("Poinformowano obserwatora");
        }

        public AutorManager RemoveAutor(int id)
        {
            return _autorManager.RemoveAutor(id);
        }

        public AutorManager UpdateAutor(AutorModel autorModel)
        {
            _logger.LogWarning("ZMIANA: Autor: " + autorModel.AutorModelID + ", Nazwisko: " + autorModel.Nazwisko + ", Imię: " + autorModel.Imie + ", KrajID: " + autorModel.KrajModelID);
            
            //Notify(autorModel);
            return _autorManager.UpdateAutor(autorModel);
        }
    }
}
