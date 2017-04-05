using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleMiddlewareWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Home/Index/{msg}")]
        public async Task<JsonResult> Index(string msg)
        {
            string result=string.Empty;
            HttpClient cons = new HttpClient();
            cons.BaseAddress = new Uri("http://mytrainingwebapisample.azurewebsites.net/");
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = await cons.GetAsync("api/Account/Message/"+msg);
            res.EnsureSuccessStatusCode();
            if (res.IsSuccessStatusCode)
            {
                result = "Message placed in Queue";
            }

                return Json(new { success = true, message = result },
                JsonRequestBehavior.AllowGet);
        }

       
    }
}