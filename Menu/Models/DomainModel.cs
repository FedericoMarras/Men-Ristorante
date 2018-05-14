using System;
using System.Collections.Generic;
using Interfaces;
using DAO;

namespace Menu.Models {
	public class DomainModel : iMenu{
		DataAccesObject DAO = new DataAccesObject();
	

		public void AddMenu(Interfaces.MenuObj m) {
            try{
				DAO.AddMenu(m);
			}catch(SystemException){
				throw new Exception("Errore nell'inserimento del menu");
			}catch(Exception e){
				throw e;
			}
        }
					
		public List<Interfaces.MenuObj> ListaMenu(int id) {
			throw new NotImplementedException();
		}

		public void VisualizzaMenu(Interfaces.MenuObj menu) {
			throw new NotImplementedException();
		}
	}
}