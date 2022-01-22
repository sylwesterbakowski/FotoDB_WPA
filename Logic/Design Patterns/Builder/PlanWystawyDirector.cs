using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Builder
{
    public class PlanWystawyDirector : IPlanWystawyDirector
    {
        private IPlanWystawyBuilder _planWystawyBuilder;

        
        public void BuildPermanentPlanWystawy()
        {
            _planWystawyBuilder.BuildFotoEksponat();
            _planWystawyBuilder.BuildMonetaEksponat();
            _planWystawyBuilder.BuildObrazEksponat();
            _planWystawyBuilder.BuildRzezbaEksponat();
        }

        public void BuildTemporaryPlanWystawy()
        {
            _planWystawyBuilder.BuildFotoEksponat();
            _planWystawyBuilder.BuildObrazEksponat();
            _planWystawyBuilder.BuildRzezbaEksponat();
        }

        public void SetPlanWystawyBuilder(IPlanWystawyBuilder planWystawyBuilder)
        {
            _planWystawyBuilder = planWystawyBuilder;
        }
    }
}
