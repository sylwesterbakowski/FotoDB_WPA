using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Mediator
{
    public interface IShoppingFotoModelMediator
    {
        void Handle(int id);
    }
}
