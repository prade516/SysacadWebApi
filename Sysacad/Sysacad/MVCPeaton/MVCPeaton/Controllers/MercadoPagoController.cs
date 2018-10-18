using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPeaton.Controllers
{
    public class MercadoPagoController : Controller
    {
        // GET: MercadoPago
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MercadoPago()
        {
            return View();
        }
        public ActionResult MercadoPagoSubcripciones()
        {
            return View();
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        public ActionResult CreateCardCustomer()
        {
            return View();
        }

        public ActionResult CreateTokenCardCustomer()
        {
            return View();
        }

        public ActionResult GetTokenCardCustomer(string token)
        {
            mercadopago.MP mp = new mercadopago.MP("TEST-6535939912151997-041715-145fad1e31f748516f6537f5290c7116__LD_LC__-252266576");
            mp.sandboxMode(true);
            string data = MVCPeaton.MercadoModels.Builder.CustomsBuilders.Manager.ManagerCustomPacks.GetInstance().GetBasicPack("test@test.com", 200,
                token, "desc1", 12, "master", "first", "last", "2015-06-02T12:58:41.425-04:00", "11",
                "4444-4444", "pepe", 22, "5700");
            System.Collections.Hashtable payment = mp.post("/v1/payments", data);
            return View();
        }

        public ActionResult CreateAnotherTypeMethodPay()
        {
            string data = MVCPeaton.MercadoModels.Builder.CustomsBuilders.Manager.ManagerCustomPacks.GetInstance().GetBasicPack("test@test.com", 200,
    "", "desc1", 12, "rapipago", "first", "last", "2015-06-02T12:58:41.425-04:00", "11",
    "4444-4444", "pepe", 22, "5700");
            System.Collections.Hashtable payment = mp.post("/v1/payments", data);
            return View();

        }

        public ActionResult GetCardsCustomer()
        {
            return View();
        }

        public ActionResult CustomPay()
        {
            return View();
        }

        public ActionResult ConsultaMediosPagos()
        {
            return View();
        }
    }
}