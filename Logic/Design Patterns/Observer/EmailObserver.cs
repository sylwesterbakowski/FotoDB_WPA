using FotoDB_WPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Observer
{
    public class EmailObserver : IAutorModelObserver
    {
        /// <summary>
        /// Konkretny Obserwator autora
        /// </summary>
        /// <param name="autorModel"></param>
        public void UpdateAutor(AutorModel autorModel)
        {
            Console.WriteLine("E-mail OBSERWATOR: Dane autora nr '{0}' z kraju nr '{1}' zostały zaktualizowane. E-mail wysłany do klienta.",
            autorModel.AutorModelID, autorModel.KrajModelID.ToString());
        }
    }
}
