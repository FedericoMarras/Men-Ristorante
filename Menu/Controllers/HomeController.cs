using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interfaces;
using Menu.Models;
namespace Menu.Controllers {
	public class HomeController : Controller {
	
		public ActionResult Index() {
			return View();
		}

		public ActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult AddMenu() {		
			
			return View();
		}

		[HttpPost]
		public ActionResult AddMenu(string _primo,string _secondo,string _contorno,string _dolce,DateTime _giorno,string _pasto)
		{
			MenuObj M = new MenuObj {
				
				Primo = _primo,
				Secondo = _secondo,
				Contorno = _contorno,
				Dolce = _dolce,
				Giorno = _giorno,
				Pasto = _pasto
			};
			DomainModel dm = new DomainModel();
			dm.AddMenu(M);
			
			return View("AddMenu");
		}
	}
}