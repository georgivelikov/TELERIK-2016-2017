using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummatorMVC.Controllers
{
    public class SumController : Controller
    {
        public ActionResult Index(string firstNumber, string secondNumber)
        {
            if (firstNumber != null && secondNumber != null)
            {
                this.ViewBag.firstNumber = firstNumber;
                this.ViewBag.secondNumber = secondNumber;

                var result = int.Parse(firstNumber) + int.Parse(secondNumber);
                this.ViewBag.result = result.ToString();

                return this.View();
            }

            return this.View();
        }
    }
}