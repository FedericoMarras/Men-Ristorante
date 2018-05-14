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
					
		public List<Interfaces.MenuObj> ListaMenu() {
			try{
				return DAO.ListaMenu();
			}catch(SystemException){
				throw new Exception("Errore nella visualizzazione dell'elenco!");
			}catch(Exception e){
				throw e;
			}
		}

		public MenuObj VisualizzaMenu(int id) {		
			try{
				return DAO.VisualizzaMenu(id);
			}catch(SystemException){
				throw new Exception("Errore nella visualizzazione del dettaglio DM");
			}catch(Exception e){
				throw e;
			}
		}
	}
}