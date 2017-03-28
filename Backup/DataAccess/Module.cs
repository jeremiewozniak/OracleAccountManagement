using System;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Collections;

namespace AccountMgmt.DataAccess
{
	public class AccessModule
	{
		private ArrayList m_listModule = null;

		public AccessModule()
		{
			m_listModule = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		public void Dispose()
		{
			if(m_listModule.Count != 0)
				m_listModule.Clear();
		}

		/// <summary>
		/// Permet de sélectionner des enregistrements suivant un critère de recherche et de trier ces résultats
		/// </summary>
		/// <param name="connection">Objet de connexion à la base de données</param>
		/// <param name="strWhere">Critère de recherche</param>
		/// <param name="strSort">Critère de trie</param>
		/// <returns></returns>
		public bool Select(OracleConnection connection, string strWhere, string strSort)
		{
			OracleCommand sqlCommand=null;
			OracleDataReader sqlReader=null;
			string sql = "SELECT id_module, module, id_application, date_creation, date_modification, commentary, activation FROM MOU01.MODULE";
			if(strWhere != "")
				sql = sql + " WHERE " + strWhere;
			if(strSort != "")
				sql = sql + " ORDER BY " + strSort;
			bool bResult = false;

			try
			{
				sqlCommand=new OracleCommand(sql,connection);
				sqlReader=sqlCommand.ExecuteReader();
				//lecture des données
				while(sqlReader.Read())
				{
					Module newModule = new Module();
					newModule.Id = sqlReader.GetInt64(0);
					newModule.Name = sqlReader.GetString(1);
					newModule.IdApplication = sqlReader.GetInt64(2);
					newModule.DateCreation = sqlReader.GetDateTime(3);
					if(!sqlReader.IsDBNull(4))
						newModule.DateModification = sqlReader.GetDateTime(4);
					if(!sqlReader.IsDBNull(5))
						newModule.Commentary = sqlReader.GetString(5);
					if(sqlReader.GetInt16(6) == AccountMgmt.Common.Constants.ActivationLevel)
						newModule.Activation = true;
					else
						newModule.Activation = false;
					m_listModule.Add(newModule);
				}
				bResult = true;
			}
			catch(System.Exception error)
			{
				MessageBox.Show("Message d’erreur : "+error.Message);
			}
			finally
			{
				try
				{
					// Fermeture de la base de données
					if (sqlReader!=null)
					{
						sqlReader.Close();
						sqlReader.Dispose();
					}
					if(sqlCommand!=null)
						sqlCommand.Dispose();
				}
				catch(Exception error)
				{
					MessageBox.Show("Message d’erreur : "+error.Message);
				}
			}

			return bResult;
		}

		public ArrayList ListModule
		{
			get
			{
				return m_listModule;
			}
		}
	}

	/// <summary>
	/// Accès à la table Module.
	/// </summary>
	public class Module
	{
		private long m_dIdModule;
		private string m_strModule;
		private long m_dIdApplication;
		private DateTime m_dtCreation;
		private DateTime m_dtModification;
		private string m_strCommentary;
		private bool m_bActivation;

		/// <summary>
		/// Méthodes de la classe Module
		/// </summary>
		#region
		/// <summary>
		/// Ajout d'un module en base
		/// </summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		public bool Add(OracleConnection connection)
		{
			bool bResult = false;
			// Start a local transaction
			OracleTransaction transaction=connection.BeginTransaction();
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			OracleDataReader sqlReader=null;
			string sql = "";
						
			try
			{
				//crée un nouvel Id pour le projet
				sql = "SELECT MAX(id_module) + 1 FROM MOU01.module";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				if (sqlReader.Read())
				{
					if(!sqlReader.IsDBNull(0))
						this.m_dIdModule = long.Parse(sqlReader.GetValue(0).ToString());
					else
						this.m_dIdModule = 1;
				}

				short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				if(this.m_bActivation)
					dActivation = AccountMgmt.Common.Constants.ActivationLevel;
				else
					dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				string strDateCreation = "TO_DATE ('" + m_dtCreation.Day.ToString("00") + "/" + m_dtCreation.Month.ToString("00") + "/" + m_dtCreation.Year.ToString("0000") + " " + m_dtCreation.Hour.ToString("00") + ":" + m_dtCreation.Minute.ToString("00") + ":" + m_dtCreation.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
				//string strDateCreation = "TO_DATE ('" + this.m_dtCreation.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				sql = "INSERT INTO MOU01.module VALUES (" + this.m_dIdModule.ToString("0") + ",'" + this.m_strModule.Replace("'", "''") + "'," + this.m_dIdApplication.ToString("0") + "," + strDateCreation + ",NULL,'" + this.m_strCommentary.Replace("'", "''") + "'," + dActivation.ToString("0") + ")";
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la création d'un module avec l'erreur : " + error.Message);
			}
			finally
			{
				//deconnexion
				try
				{
					// Fermeture de la base de données
					if(command!=null)
						command.Dispose();
				}
				catch(Exception error)
				{
					MessageBox.Show("Message d’erreur : "+error.Message);
				}
			}

			return bResult;
		}

		/// <summary>
		/// Modification du module en base
		/// </summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		public bool Update(OracleConnection connection)
		{
			bool bResult = false;
			// Start a local transaction
			OracleTransaction transaction=connection.BeginTransaction();
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			string sql = "";
						
			try
			{
				short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				if(this.m_bActivation)
					dActivation = AccountMgmt.Common.Constants.ActivationLevel;
				else
					dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				string strDateModification = "TO_DATE ('" + m_dtModification.Day.ToString("00") + "/" + m_dtModification.Month.ToString("00") + "/" + m_dtModification.Year.ToString("0000") + " " + m_dtModification.Hour.ToString("00") + ":" + m_dtModification.Minute.ToString("00") + ":" + m_dtModification.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
				//string strDateModification = "TO_DATE ('" + this.m_dtModification.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				sql = "UPDATE MOU01.module SET module='" + this.m_strModule.Replace("'", "''") + "', commentary='" + this.m_strCommentary.Replace("'", "''") + "', " +
						"activation = " + dActivation.ToString("0") + ", " + 
                        "date_modification = " + strDateModification + " WHERE id_module=" + this.m_dIdModule.ToString("0");
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la modification d'un module avec l'erreur : " + error.Message);
			}
			finally
			{
				//deconnexion
				try
				{
					// Fermeture de la base de données
					if(command!=null)
						command.Dispose();
				}
				catch(Exception error)
				{
					MessageBox.Show("Message d’erreur : "+error.Message);
				}
			}

			return bResult;
		}

		/// <summary>
		/// Suppression du module en base
		/// </summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		public bool Delete(OracleConnection connection)
		{
			bool bResult = false;
			// Start a local transaction
			OracleTransaction transaction=connection.BeginTransaction();
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			string sql = "";
						
			try
			{
				sql = "DELETE FROM MOU01.module WHERE id_module=" + this.m_dIdModule.ToString("0");
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la suppression d'un module avec l'erreur : " + error.Message);
			}
			finally
			{
				//deconnexion
				try
				{
					// Fermeture de la base de données
					if(command!=null)
						command.Dispose();
				}
				catch(Exception error)
				{
					MessageBox.Show("Message d’erreur : "+error.Message);
				}
			}

			return bResult;
		}
		#endregion
		/// <summary>
		/// Obtient ou définit les membres de la classe Module
		/// </summary>
		#region

		/// <summary>
		/// Obtient ou définit l'identificateur "id_module" de la classe "Module"
		/// </summary>
		public long Id
		{
			get
			{
				return m_dIdModule;
			}

			set
			{
				m_dIdModule = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le nom du module
		/// </summary>
		public string Name
		{
			get
			{
				return m_strModule;
			}
			set
			{
				m_strModule = value;
			}
		}

		/// <summary>
		/// Obtient ou définit l'identificateur de l'application liée au module
		/// </summary>
		public long IdApplication
		{
			get
			{
				return m_dIdApplication;
			}
			set
			{
				m_dIdApplication = value;
			}
		}

		/// <summary>
		/// Obtient ou définit la date de création du module
		/// </summary>
		public DateTime DateCreation
		{
			get
			{
				return m_dtCreation;
			}
			set
			{
				m_dtCreation = value;
			}
		}

		/// <summary>
		/// Obtient ou définit la date de dernière modification du module
		/// </summary>
		public DateTime DateModification
		{
			get
			{
				return m_dtModification;
			}
			set
			{
				m_dtModification = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le commentaires du module
		/// </summary>
		public string Commentary
		{
			get
			{
				return m_strCommentary;
			}
			set
			{
				m_strCommentary = value;
			}
		}

		/// <summary>
		/// Obtient ou définit l'activation du module
		/// </summary>
		public bool Activation
		{
			get
			{
				return m_bActivation;
			}
			set
			{
				m_bActivation = value;
			}
		}
		#endregion
	}
}
