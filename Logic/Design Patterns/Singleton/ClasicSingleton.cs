using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Singleton
{
    public class ClasicSingleton : ISingleton
    {
        private static readonly ClasicSingleton _instance = new ClasicSingleton();
        //Prywatny konstruktor
        private ClasicSingleton()
        {
            //Ciało działania klasy
            Console.WriteLine("Utworzono Singleton klasyczny");
        }

        public static ClasicSingleton Instance => _instance;
    }
}
