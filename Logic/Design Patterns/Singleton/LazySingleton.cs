using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Singleton
{
    public class LazySingleton : ISingleton
    {
        private static readonly Lazy<LazySingleton> lazy = new Lazy<LazySingleton>(() => new LazySingleton());

        private LazySingleton()
        {
            //Ciało działania klasy
            Console.WriteLine("Utworzono Singleton lazy (Lazy<Singleton>)");
        }

        public static LazySingleton Instance => lazy.Value;
    }
}
