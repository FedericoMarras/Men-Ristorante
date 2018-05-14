using System;
using System.Collections.Generic;
using DAO;

namespace Interfaces {
	public interface iMenu {
	
	void AddMenu(MenuObj m);   //Metodo per l'aggiunta di un Menù
	List<MenuObj> ListaMenu();  //Metodo per la visualizzazione dell'elenco dei menù completo
	MenuObj VisualizzaMenu(int id);   //Visualizzazione del dettaglio del menù
	
	}

	public class MenuObj {
	    public int Id { get; set; }   //Id identificativo del menù
        public string Primo { get; set; }
        public string Secondo { get; set; }
		public string Contorno { get; set; }
		public string Dolce{ get; set; }      
		public DateTime Giorno{ get; set; }   // DateTime del giorno a cui appartiene un determinato menù
		public string Pasto{ get; set; }  //Gestisce se il menù è per pranzo o per cena

		} 
}