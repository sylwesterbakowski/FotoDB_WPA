using FotoDB_WPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Observer
{
    /// <summary>
    /// Interfejs Wydawcy
    /// </summary>
    public interface IAutorModelNotifier
    {
        //Dołącz obserwatora do listy obserwatorów autora.
        void Attach(IAutorModelObserver observer);

        //Odłącz obserwatora z listy obserwatorów autora.
        void Detach(IAutorModelObserver observer);

        //Powiadom wszystkich obserwatorów autora o zdarzeniu.
        void Notify(AutorModel autormodel);
    }
}
