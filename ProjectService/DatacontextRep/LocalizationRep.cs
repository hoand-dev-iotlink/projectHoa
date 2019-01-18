using ProjectModelCommon.Model;
using ProjectService.InterfaceRep;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectService.DatacontextRep
{
    public class LocalizationRep: ILocalizationRep
    {
        public string GetResources(string resourcesKey, string resourcelanguage)
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                    string result = db.Database.SqlQuery<string>("SELECT [LocalizationValue] FROM[dbo].[LocalizationLanguage] WHERE LocalizationLanguage = @lang and LocalizationKey = @key",
                         new SqlParameter("@lang", resourcelanguage),
                         new SqlParameter("@key", resourcesKey)).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ImportFiletoData(string jsonLocalization)
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                    int result = db.Database.SqlQuery<int>(@"UpdateLocalization @jsonLocalization",
                         new SqlParameter("@jsonLocalization", jsonLocalization)).FirstOrDefault();
                    return result > 0 ? true : false;
                }
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LocalizationLanguages> GetListLocalization(int pageSize, int pageNumber, ref int total)
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                    var count = new SqlParameter();
                    count.ParameterName = "@total";
                    count.Direction = System.Data.ParameterDirection.Output;
                    count.SqlDbType = System.Data.SqlDbType.Int;

                    List<LocalizationLanguages> result = db.Database.SqlQuery<LocalizationLanguages>(@"GetAllLocalization @pageSize,@pageNumber,@total OUT",
                         new SqlParameter("@pageSize", pageSize),
                         new SqlParameter("@pageNumber", pageNumber),
                         count).ToList();
                    total = Convert.ToInt32(count.Value);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
