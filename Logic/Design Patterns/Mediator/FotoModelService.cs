using FotoDB_WPA.Contexts;
using FotoDB_WPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Mediator
{
    public class FotoModelService : IFotoModelService
    {
        private readonly FotoDBContext _fotoDBContext;

        public FotoModelService(FotoDBContext fotoDBContext)
        {
            _fotoDBContext = fotoDBContext;
        }
        public FotoModel GetFoto(int id)
        {
            var foto = _fotoDBContext.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            return foto;
        }
    }
}
