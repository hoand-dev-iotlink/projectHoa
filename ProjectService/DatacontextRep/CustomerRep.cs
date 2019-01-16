using ProjectService.InterfaceRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectService.DatacontextRep
{
    public class CustomerRep : ACustomerRep
    {
        public override bool Check()
        {
            return false;
            throw new NotImplementedException();
        }

        public override bool SignIn()
        {
            return false;
            throw new NotImplementedException();
        }
    }
}
