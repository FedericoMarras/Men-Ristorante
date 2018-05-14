using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using Interfaces;


namespace DAO {
public interface iDao {
		

	void AddMenu(MenuObj m);   //Metodo per l'aggiunta di un Menù
	List<MenuObj> ListaMenu();  //Metodo per la visualizzazione dell'elenco dei menù completo
	MenuObj VisualizzaMenu(int id);   //Visualizzazione del dettaglio del menù
	
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

		public List<MenuObj> ListaMenu() {
			SqlConnection connection = new SqlConnection(GetConnection());		

			try{
			SqlCommand cmd = new SqlCommand("ElencoMenu",connection);	
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<MenuObj> model = new List<MenuObj>();
            while(reader.Read())
            {
              var details = new MenuObj();
                details.Id = reader.GetInt32(0);
                details.Giorno = reader.GetDateTime(1);
                details.Pasto =  reader.GetString(2);       
                model.Add(details);
            }
			reader.Close();
			connection.Close();
			return model;
			}catch(SqlException){
				throw new Exception("Errore server!");
			}catch(Exception e){
				throw e;
			}
		}

		public MenuObj VisualizzaMenu(int id) {
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
			connection.Open();
			SqlCommand cmd = new SqlCommand("VisualizzaMenu",connection);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			SqlParameter[] parameters = { 
					new SqlParameter("@id",id)
				};
			cmd.Parameters.AddRange(parameters) ;
			cmd.ExecuteNonQuery();
				
            
            SqlDataReader reader = cmd.ExecuteReader();
            MenuObj singolo = new MenuObj();
            while(reader.Read())
            {
              
                singolo.Id = reader.GetInt32(0);
				singolo.Primo =  reader.GetString(1);       
				singolo.Secondo =  reader.GetString(2);       
				singolo.Contorno =  reader.GetString(3);       
			    singolo.Dolce =  reader.GetString(4);       
                singolo.Giorno = reader.GetDateTime(5);
                singolo.Pasto =  reader.GetString(6);       
               
            }
			reader.Close();
			connection.Close();
			return singolo;
			} catch(SqlException){
				throw new Exception("Errore nella visualizzazione del dettaglio");
			} catch(Exception e){
				throw e;
			}
			
		}

		 private string GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(localdb)\MSSQLLocalDB";
            builder.InitialCatalog = "Ristorante";
            return builder.ConnectionString;
        } 
	}
}

