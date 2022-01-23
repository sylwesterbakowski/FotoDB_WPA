using FotoDB_WPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Mediator
{
    public interface IFotoModelService
    {
        FotoModel GetFoto(int id);
    }
}
