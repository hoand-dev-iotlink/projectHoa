using ProjectAuthen.AuthenService;
using ProjectAuthen.Controllers;
using ProjectModelCommon.ViewModel;
using ProjectService.DatacontextRep;
using ProjectService.InterfaceRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectAuthen.Areas.Administrator.Controllers
{
    //[Authorize]
    [AuthoriAccessAction]
    public class CustomerAdminController : BaseController
    {
        ACustomerRep aCustomerRep = new CustomerRep();
        // GET: Administrator/Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetCustomer(JQueryDataTableParamModel jQueryDataTableParamModel)
        {
            try
            {
                CommonParamDataTable commonParamDataTable = new CommonParamDataTable();
                // set query
                int sortColumnIndex = jQueryDataTableParamModel.ISortCol_0;
                commonParamDataTable.OrderBy = jQueryDataTableParamModel.SSortDir_0;

                commonParamDataTable.ColumOrder = "CreateTime";

                // set sort colunm
                //switch (sortColumnIndex)
                //{
                //    case 4:
                //        orderBy = "SoTo";
                //        break;
                //    case 5:
                //        orderBy = "CreateTime";
                //        break;
                //}

                string search = jQueryDataTableParamModel.SSearchValue1 != null ? jQueryDataTableParamModel.SSearchValue1 : "";

                // set page, limit
                int munberPage = (jQueryDataTableParamModel.IDisplayStart / jQueryDataTableParamModel.IDisplayLength);
                commonParamDataTable.Page = (jQueryDataTableParamModel.IDisplayStart / jQueryDataTableParamModel.IDisplayLength) + 1; //(munberPage > 1)? (munberPage + 1):0;
                commonParamDataTable.Limit = jQueryDataTableParamModel.IDisplayLength;
                commonParamDataTable.Search = search;
                int total = 0;
                List <CustomerUserModel> ss= await aCustomerRep.GetCustomer(commonParamDataTable);
                return Json(new
                {
                    sEcho = jQueryDataTableParamModel.SEcho,
                    iTotalRecords = 100,
                    iTotalDisplayRecords = 100,
                    aaData = ss
                },JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult UpdateCustomer(string id)
        {
            return View();
        }
    }
}