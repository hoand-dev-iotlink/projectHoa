using ProjectModelCommon.Model;
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
        public virtual Task<CustomerUserModel> SignIn(CustomerModel customerModel) { return Task.FromResult(new CustomerUserModel()); }
        public virtual bool Check() { return false;}
        public virtual Task<string> SetHashPassword(string password,string hash) { return Task.FromResult(string.Empty); }
        public virtual Task<bool> UpdateCustomerUser(CustomerUser customerUser) { return Task.FromResult(false); }
        public virtual Task<bool> SendMail(string sendEmail,string subjectEmail,string bodyEmail) { return Task.FromResult(false); }
        public virtual Task<int> CheckEmailUserPhone(CustomerUser customerUserModel) { return Task.FromResult(0); }
        public virtual Task<List<CustomerUserModel>> GetCustomer(CommonParamDataTable commonParamDataTable) { return Task.FromResult(new List<CustomerUserModel>()); }
    }
}
