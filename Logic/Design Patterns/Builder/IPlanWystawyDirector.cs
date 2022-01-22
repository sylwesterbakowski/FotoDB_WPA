using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Builder
{
    public interface IPlanWystawyDirector
    {
        void SetPlanWystawyBuilder(IPlanWystawyBuilder builder);

        void BuildPermanentPlanWystawy();

        void BuildTemporaryPlanWystawy();
    }
}
