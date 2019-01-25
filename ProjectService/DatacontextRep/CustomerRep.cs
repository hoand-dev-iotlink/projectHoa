using ProjectModelCommon.Model;
using ProjectModelCommon.ViewModel;
using ProjectService.InterfaceRep;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        /// <summary>
        /// signin user
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        public override async Task<CustomerUserModel> SignIn(CustomerModel customerModel)
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                    var result = db.Database.SqlQuery<CustomerUserModel>("SELECT [Id],[UserName],[Email],[Phone],[Password],[Avatar] FROM[dbo].[CommonUser] WHERE UserName = @username and[Password] = @password",
                         new SqlParameter("@username", customerModel.UserName),
                         new SqlParameter("@password", customerModel.PassWord)).FirstOrDefault();
                    return await Task.FromResult(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override async Task<bool> UpdateCustomerUser(CustomerUser customerUser)
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                    var result = db.Database.SqlQuery<int>(@"UpdateCustomerUser @id,@userName,@email,@phone,@password,@avatar,@name",
                        new SqlParameter("@id", customerUser.Id),
                        new SqlParameter("@userName", customerUser.UserName),
                        new SqlParameter("@email", customerUser.Email),
                        new SqlParameter("@phone", customerUser.Phone),
                        new SqlParameter("@password", customerUser.Password),
                        new SqlParameter("@avatar", customerUser.Avatar),
                        new SqlParameter("@name", customerUser.Name)).FirstOrDefault();
                    bool check = (result > 0) ? true : false;
                    return await Task.FromResult(check);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
