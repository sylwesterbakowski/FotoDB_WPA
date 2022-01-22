using FotoDB_WPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Observer
{
    /// <summary>
    /// Interface Obserwatora
    /// </summary>
    public interface IAutorModelObserver
    {
        void UpdateAutor(AutorModel autorModel);
    }
}
