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

        /// <summary>
        /// update customer user
        /// </summary>
        /// <param name="customerUser"></param>
        /// <returns></returns>
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

        /// <summary>
        /// check user email, user name, phone exit
        /// </summary>
        /// <param name="customerUserModel"></param>
        /// <returns></returns>
        public override async Task<int> CheckEmailUserPhone(CustomerUser customerUserModel)
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                    int Reemail = 0, Recode = 0, Reuser = 0;
                    if (!string.IsNullOrWhiteSpace(customerUserModel.UserName))
                    {
                        var sqlemail = string.Format("select count(*) from CommonUser where Email = '{0}'", customerUserModel.Email);
                        Reemail = db.Database.SqlQuery<int>(sqlemail).FirstOrDefault();
                    }
                    if (!string.IsNullOrWhiteSpace(customerUserModel.Phone))
                    {
                        var sqlcode = string.Format("select count(*) from CommonUser where Phone = '{0}'", customerUserModel.Phone);
                        Recode = db.Database.SqlQuery<int>(sqlcode).FirstOrDefault();
                    }
                    if (!string.IsNullOrWhiteSpace(customerUserModel.UserName))
                    {
                        var sqluser = string.Format("select count(*) from CommonUser where UserName = '{0}'", customerUserModel.UserName);
                        Reuser = db.Database.SqlQuery<int>(sqluser).FirstOrDefault();
                    }
                    int result = (Reemail == 1) ? 1 : ((Recode == 1) ? 2 : ((Reuser == 1) ? 3 : 0));
                    return await Task.FromResult(result);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(0);
            }

        }

        /// <summary>
        /// Get customer
        /// </summary>
        /// <param name="jQueryDataTableParamModel"></param>
        /// <returns></returns>
        public override async Task<List<CustomerUserModel>> GetCustomer(CommonParamDataTable commonParamDataTable)
        {
            List<CustomerUserModel> listCustomer = new List<CustomerUserModel>();
            try
            {
                var count = new SqlParameter();
                count.ParameterName = "@total";
                count.Direction = System.Data.ParameterDirection.Output;
                count.SqlDbType = System.Data.SqlDbType.Int;
                using (var db = new DataBaseContext())
                {
                    listCustomer = db.Database.SqlQuery<CustomerUserModel>(@"GetAllCommonUser @pagesize,@pagecount,@searchValue,@checkOrder,@total out",
                     new SqlParameter("pagesize", commonParamDataTable.Page),
                     new SqlParameter("pagecount", commonParamDataTable.Limit),
                     new SqlParameter("searchValue", commonParamDataTable.Search),
                     new SqlParameter("checkOrder", (commonParamDataTable.OrderBy).ToLower().Contains("asc") ? 0 : 1),
                     count).ToList();
                }
                //total = Convert.ToInt32(count.Value);
                return await Task.FromResult(listCustomer);
            }
            catch (Exception)
            {
                return await Task.FromResult(listCustomer);
            }

        }
    }
}
