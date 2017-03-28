using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Collections;

namespace AccountMgmt.DataAccess
{
	public class AccessApplication
	{
		private ArrayList m_listApplication = null;

		public AccessApplication()
		{
			m_listApplication = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		public void Dispose()
		{
			if(m_listApplication.Count != 0)
				m_listApplication.Clear();
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
			string sql = "SELECT id_application, application, id_project, default_tablespace, date_creation, date_modification, commentary, activation FROM MOU01.APPLICATION";
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
					Application newApplication = new Application();
					newApplication.Id = sqlReader.GetInt64(0);
					newApplication.Name = sqlReader.GetString(1);
					newApplication.IdProject = sqlReader.GetInt64(2);
					if(!sqlReader.IsDBNull(3))
						newApplication.DefaultTableSpace = sqlReader.GetString(3);
					newApplication.DateCreation = sqlReader.GetDateTime(4);
					if(!sqlReader.IsDBNull(5))
						newApplication.DateModification = sqlReader.GetDateTime(5);
					if(!sqlReader.IsDBNull(6))
						newApplication.Commentary = sqlReader.GetString(6);
					if(sqlReader.GetInt16(7) == AccountMgmt.Common.Constants.ActivationLevel)
						newApplication.Activation = true;
					else
						newApplication.Activation = false;
					m_listApplication.Add(newApplication);
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

		public ArrayList ListApplication
		{
			get
			{
				return m_listApplication;
			}
		}
	}

	/// <summary>
	/// Accès à la table Application.
	/// </summary>
	public class Application
	{
		private long m_dIdApplication;
		private string m_strApplication;
		private long m_dIdProject;
		private string m_strDefaultTableSpace;
		private DateTime m_dtCreation;
		private DateTime m_dtModification;
		private string m_strCommentary;
		private bool m_bActivation;

		/// <summary>
		/// Méthodes de la classe Application
		/// </summary>
		#region
		/// <summary>
		/// Ajout d'une application en base
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
				sql = "SELECT MAX(id_application) + 1 FROM MOU01.application";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				if (sqlReader.Read())
				{
					if(!sqlReader.IsDBNull(0))
						this.m_dIdApplication = long.Parse(sqlReader.GetValue(0).ToString());
					else
						this.m_dIdApplication = 1;
				}

				short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				if(this.m_bActivation)
					dActivation = AccountMgmt.Common.Constants.ActivationLevel;
				else
					dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				string strDateCreation = "TO_DATE ('" + m_dtCreation.Day.ToString("00") + "/" + m_dtCreation.Month.ToString("00") + "/" + m_dtCreation.Year.ToString("0000") + " " + m_dtCreation.Hour.ToString("00") + ":" + m_dtCreation.Minute.ToString("00") + ":" + m_dtCreation.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
				//string strDateCreation = "TO_DATE ('" + this.m_dtCreation.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				sql = "INSERT INTO MOU01.application VALUES (" + this.m_dIdApplication.ToString("0") + ",'" + this.m_strApplication.Replace("'", "''") + "'," + this.m_dIdProject.ToString("0") + ",'" + this.m_strDefaultTableSpace.Replace("'", "''") + "'," + strDateCreation + ",NULL,'" + this.m_strCommentary.Replace("'", "''") + "'," + dActivation.ToString("0") + ")";
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la création d'une application avec l'erreur : " + error.Message);
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
		/// Modification de l'application en base
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
				sql = "UPDATE MOU01.application SET application='" + this.m_strApplication.Replace("'", "''") + "', commentary='" + this.m_strCommentary.Replace("'", "''") + "', " +
                                     "default_tablespace='" + this.m_strDefaultTableSpace.Replace("'", "''") + "', activation= " + dActivation.ToString("0") + ", " + 
                                     "date_modification = " + strDateModification + " WHERE id_application=" + this.m_dIdApplication.ToString("0");
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la modifiacation d'une application avec l'erreur : " + error.Message);
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
		/// Suppression de l'application en base
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
				sql = "DELETE FROM MOU01.application WHERE id_application=" + this.m_dIdApplication.ToString("0");
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la suppression d'une application avec l'erreur : " + error.Message);
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
		/// Obtient ou définit les membres de la classe Application
		/// </summary>
		#region

		/// <summary>
		/// Obtient ou définit l'identificateur "id_application"
		/// </summary>
		public long Id
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
		/// Obtient ou définit le nom de l'application
		/// </summary>
		public string Name
		{
			get
			{
				return m_strApplication;
			}
			set
			{
				m_strApplication = value;
			}
		}

		/// <summary>
		/// Obtient ou définit l'identificateur du projet lié à l'application
		/// </summary>
		public long IdProject
		{
			get
			{
				return m_dIdProject;
			}
			set
			{
				m_dIdProject = value;
			}
		}

		/// <summary>
		/// Obtient ou définit la TableSpace par défaut de l'application
		/// </summary>
		public string DefaultTableSpace
		{
			get
			{
				return m_strDefaultTableSpace;
			}
			set
			{
				m_strDefaultTableSpace = value;
			}
		}

		/// <summary>
		/// Obtient ou définit la date de création de l'application
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
		/// Obtient ou définit la date de dernière modification de l'application
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
		/// Obtient ou définit le commentaires de l'application
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
		/// Obtient ou définit l'activation de l'application
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
