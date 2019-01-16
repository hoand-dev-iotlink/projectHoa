using ProjectModelCommon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectService.InterfaceRep
{
    public abstract class ACustomerRep
    {
        public abstract bool SignIn();
        public virtual bool Check() { return false;}
    }
}
