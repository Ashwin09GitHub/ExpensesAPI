using ExpensesAPI.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExpensesAPI.Controllers
{
    // [RoutePrefix("Expense")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExpenseController : ApiController
    {
        private ExpenseBusinessClass busObj;
        public ExpenseController()
        {
            busObj = new ExpenseBusinessClass();
        }

       // [HttpGet,Route("GetUser/id")]
        public HttpResponseMessage GetUserDetails(int id)
        {
            var res = busObj.GetUserDeatils(id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Uesr = res });
        }

      //  [Route("userlogin")]
        [HttpPost]
        public HttpResponseMessage UserLogin(UserClass user)
        {
             try
            {
                var res = busObj.GetUsers(user);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,new { User = res });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent,new { Message="User Not Found!"});
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex);
            }
            
        }

        [HttpPost]
        public HttpResponseMessage Resgister(UserClass user)
        {
            try
            {
                var res = busObj.ResgisterUser(user);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { User = res });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new { Message="User Not register!" });
                }

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetExpenseType()
        {
            try
            {

                var res = busObj.GetExpesneType();
                return Request.CreateResponse(HttpStatusCode.OK, new { ExpenseType = res });
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage CreateExpense(IEnumerable<ExpensClass> exp)
        {
            try
            {
                var res = busObj.SaveExpense(exp);
                if (res > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Result = res });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new { Message = "Data Not Save!" });
                }

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }



    }
}
