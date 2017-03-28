using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Collections;

namespace AccountMgmt.DataAccess
{
	public class AccessProject
	{
		private ArrayList m_listProject = null;

		public AccessProject()
		{
			m_listProject = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		public void Dispose()
		{
			if(m_listProject.Count != 0)
				m_listProject.Clear();
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
			string sql = "SELECT id_project, project, date_creation, date_modification, commentary, activation FROM MOU01.project";
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
				while (sqlReader.Read())
				{
					Project newProject = new Project();
					newProject.Id = sqlReader.GetInt64(0);
					newProject.Name = sqlReader.GetString(1);
					newProject.DateCreation = sqlReader.GetDateTime(2);
					if(!sqlReader.IsDBNull(3))
						newProject.DateModification = sqlReader.GetDateTime(3);
					if(!sqlReader.IsDBNull(4))
						newProject.Commentary = sqlReader.GetString(4);
					if(sqlReader.GetInt16(5) == AccountMgmt.Common.Constants.ActivationLevel)
						newProject.Activation = true;
					else
						newProject.Activation = false;
					m_listProject.Add(newProject);
				}
				bResult = true;
			}
			catch(Exception error)
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

		public ArrayList ListProject
		{
			get
			{
				return m_listProject;
			}
		}
	}

	/// <summary>
	/// Accès à la table Project
	/// </summary>
	public class Project
	{
		private long m_dIdProject;
		private string m_strProject;
		private DateTime m_dtCreation;
		private DateTime m_dtModification;
		private string m_strCommentary;
		private bool m_bActivation;

		/// <summary>
		/// Méthodes de la classe Project
		/// </summary>
		#region
		/// <summary>
		/// Ajout d'un profile en base
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
				sql = "SELECT MAX(id_project) + 1  FROM MOU01.project";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				if (sqlReader.Read())
				{
					if(!sqlReader.IsDBNull(0))
						this.m_dIdProject = long.Parse(sqlReader.GetValue(0).ToString());
					else
						this.m_dIdProject = 1;
				}
				
				short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				if(this.m_bActivation)
					dActivation = AccountMgmt.Common.Constants.ActivationLevel;
				else
					dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				string strDateCreation = "TO_DATE ('" + m_dtCreation.Day.ToString("00") + "/" + m_dtCreation.Month.ToString("00") + "/" + m_dtCreation.Year.ToString("0000") + " " + m_dtCreation.Hour.ToString("00") + ":" + m_dtCreation.Minute.ToString("00") + ":" + m_dtCreation.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
				//string strDateCreation = "TO_DATE ('" + this.m_dtCreation.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				sql = "INSERT INTO MOU01.project VALUES (" + this.m_dIdProject.ToString("0") + ",'" + this.m_strProject.Replace("'", "''") + "'," + strDateCreation + ",NULL,'" + this.m_strCommentary.Replace("'", "''") + "'," + dActivation.ToString("0") + ")";
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la création du projet avec l'erreur : " + error.Message);
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
		/// Modification du projet en base
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
				sql = "UPDATE MOU01.project SET project='" + this.m_strProject.Replace("'", "''") + "', commentary='" + this.m_strCommentary.Replace("'", "''") + "', " +
                                     "date_modification = " + strDateModification + ", activation = " + dActivation.ToString("0") + " WHERE id_project=" + this.m_dIdProject.ToString("0");
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la modification du projet avec l'erreur : " + error.Message);
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
		/// Supprime le projet en base
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
				sql = "DELETE FROM MOU01.project WHERE id_project=" + this.m_dIdProject.ToString("0");
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la suppression du projet avec l'erreur : " + error.Message);
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
		/// Obtient ou définit les membres de la classe Project
		/// </summary>
		#region

		/// <summary>
		/// Obtient ou définit l'identificateur "id_projet" de la classe "Project"
		/// </summary>
		public long Id
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
		/// Obtient ou définit le nom du projet
		/// </summary>
		public string Name
		{
			get
			{
				return m_strProject;
			}
			set
			{
				m_strProject = value;
			}
		}

		/// <summary>
		/// Obtient ou définit la date de création du projet
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
		/// Obtient ou définit la date de dernière modification du projet
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
		/// Obtient ou définit le commentaires du projet
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
		/// Obtient ou définit l'activation du projet
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
