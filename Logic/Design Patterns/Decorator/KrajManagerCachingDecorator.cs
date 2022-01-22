using FotoDB_WPA.ILogic;
using FotoDB_WPA.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Decorator
{
    public class KrajManagerCachingDecorator : IKrajManager
    {
        private readonly IKrajManager _krajManager;
        private readonly IMemoryCache _memoryCache;

        private const string GET_KRAJS_LIST_CACHE_KEY = "krajs.list";

        public KrajManagerCachingDecorator(IKrajManager krajManager, IMemoryCache memoryCache)
        {
            _krajManager = krajManager;
            _memoryCache = memoryCache;

        }
        public KrajManager AddKraj(KrajModel krajModel)
        {
            throw new NotImplementedException();
        }

        public KrajManager ChangeNazwa(int id, string newNazwa)
        {
            throw new NotImplementedException();
        }

        public KrajModel GetKraj(int id)
        {
            throw new NotImplementedException();
        }

        public List<KrajModel> GetKrajs()
        {
            IEnumerable<KrajModel> krajs = null;

            //Poszukaj klucza w pamięci podręcznej
            if (!_memoryCache.TryGetValue(GET_KRAJS_LIST_CACHE_KEY, out krajs))
            {
                //Klucz nie znajduje się w pamięci podręcznej, więc pobierz listę krajów.
                krajs = _krajManager.GetKrajs();
                //Ustaw opcje pamięci podręcznej
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    //Trzymaj kraje w pamięci podręcznej przez ten czas, zresetuj czas, jeśli uzyskasz dostęp.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));
                //Zapisz listę krajów w pamięci podręcznej.
                _memoryCache.Set(GET_KRAJS_LIST_CACHE_KEY, krajs, cacheEntryOptions);
            }

            return krajs.ToList();
        }

        public KrajManager RemoveKraj(int id)
        {
            throw new NotImplementedException();
        }

        public KrajManager UpdateKraj(KrajModel krajModel)
        {
            throw new NotImplementedException();
        }
    }
}
