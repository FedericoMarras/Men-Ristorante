using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using Interfaces;


namespace DAO {
public interface iDao {
		

	void AddMenu(MenuObj m);   //Metodo per l'aggiunta di un Menù
	List<MenuObj> ListaMenu(int id);  //Metodo per la visualizzazione dell'elenco dei menù completo
	void VisualizzaMenu(MenuObj menu);   //Visualizzazione del dettaglio del menù
	
	}

	public class  DataAccesObject : iDao {



	public void AddMenu(MenuObj m){
				
	SqlConnection connection = new SqlConnection(GetConnection());		
				try{				 
				  connection.Open();
				SqlCommand cmd = new SqlCommand("AddMenu",connection);	
			    cmd.CommandType = System.Data.CommandType.StoredProcedure;
							
				SqlParameter[] parameters = { 
					new SqlParameter("@Primo",m.Primo),
					new SqlParameter("@Secondo",m.Secondo),
					new SqlParameter("@Contorno",m.Contorno),
					new SqlParameter("@Dolce",m.Dolce),
					new SqlParameter("@Giorno",m.Giorno),
					new SqlParameter("@Pasto",m.Pasto)
					};
				cmd.Parameters.AddRange(parameters) ;
				cmd.ExecuteNonQuery();
				
				
			} catch(SqlException){
				throw new Exception("Errore dell'inserimento del Menu");
			} catch(Exception e){
				throw e;
			} finally {
				connection.Close();
			}
		}

		public List<MenuObj> ListaMenu(int id) {
			throw new NotImplementedException();
		}

		public void VisualizzaMenu(MenuObj menu) {
			throw new NotImplementedException();
		}

		 private string GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(localdb)\MSSQLLocalDB";
            builder.InitialCatalog = "Ristorante";
            return builder.ConnectionString;
        }  /*Genero connessione*/
	}
}

