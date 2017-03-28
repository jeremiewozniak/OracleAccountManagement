using System;
using System.Windows.Forms;
using System.Collections;
using Oracle.ManagedDataAccess.Client;

namespace AccountMgmt.DataAccess
{
	public class AccessRole
	{
		private ArrayList m_listRole = null;

		public AccessRole()
		{
			m_listRole = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		public void Dispose()
		{
			if(m_listRole.Count != 0)
				m_listRole.Clear();
		}

		/// <summary>
		/// Permet de sélectionner des enregistrements suivant un critère de recherche et de trier ces résultats
		/// </summary>
		/// <param name="connection">Objet de connexion à la base de données</param>
		/// <param name="strWhere">Critère de recherche</param>
		/// <param name="strSort">Critère de trie</param>
		/// <returns></returns>
		public bool SelectRight(OracleConnection connection, string strWhere, string strSort)
		{
			OracleCommand sqlCommand=null;
			OracleDataReader sqlReader=null;
			string sql = "SELECT ro.id_role, ro.role, ro.date_creation, ro.date_modification, ro.commentary, ro.activation, ri.id_profile FROM MOU01.role ro, MOU01.right ri";
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
					Role newRole = new Role();
					newRole.Id = sqlReader.GetInt64(0);
					newRole.Name = sqlReader.GetString(1);
					newRole.DateCreation = sqlReader.GetDateTime(2);
					if(!sqlReader.IsDBNull(3))
						newRole.DateModification = sqlReader.GetDateTime(3);
					if(!sqlReader.IsDBNull(4))
						newRole.Commentary = sqlReader.GetString(4);
					if(sqlReader.GetInt16(5) == AccountMgmt.Common.Constants.ActivationLevel)
						newRole.Activation = true;
					else
						newRole.Activation = false;
					newRole.IdProfile = sqlReader.GetInt64(6);
					m_listRole.Add(newRole);
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
			string sql = "SELECT ro.id_role, ro.role, ro.date_creation, ro.date_modification, ro.commentary, ro.activation FROM MOU01.role ro";
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
					Role newRole = new Role();
					newRole.Id = sqlReader.GetInt64(0);
					newRole.Name = sqlReader.GetString(1);
					newRole.DateCreation = sqlReader.GetDateTime(2);
					if(!sqlReader.IsDBNull(3))
						newRole.DateModification = sqlReader.GetDateTime(3);
					if(!sqlReader.IsDBNull(4))
						newRole.Commentary = sqlReader.GetString(4);
					if(sqlReader.GetInt16(5) == AccountMgmt.Common.Constants.ActivationLevel)
						newRole.Activation = true;
					else
						newRole.Activation = false;
					m_listRole.Add(newRole);
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

		public ArrayList ListRole
		{
			get
			{
				return m_listRole;
			}
		}
	}

	/// <summary>
	/// Accès à la table Role
	/// </summary>
	public class Role
	{
		private long m_dIdRole;
		private string m_strRole;
		private DateTime m_dtCreation;
		private DateTime m_dtModification;
		private string m_strCommentary;
		private bool m_bActivation;
		private long m_dIdProfile;

		/// <summary>
		/// Méthodes de la classe Role
		/// </summary>
		#region
		/// <summary>
		/// Ajout d'un rôle en base
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
				sql = "SELECT MOU01.SEQ_ROLE.NEXTVAL FROM DUAL";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				if (sqlReader.Read())
					this.m_dIdRole = long.Parse(sqlReader.GetValue(0).ToString());

				short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				if(this.m_bActivation)
					dActivation = AccountMgmt.Common.Constants.ActivationLevel;
				else
					dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				string strDateCreation = "TO_DATE ('" + m_dtCreation.Day.ToString("00") + "/" + m_dtCreation.Month.ToString("00") + "/" + m_dtCreation.Year.ToString("0000") + " " + m_dtCreation.Hour.ToString("00") + ":" + m_dtCreation.Minute.ToString("00") + ":" + m_dtCreation.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
				//string strDateCreation = "TO_DATE ('" + this.m_dtCreation.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				sql = "INSERT INTO MOU01.role VALUES (" + this.m_dIdRole.ToString("0") + ",'" + this.m_strRole.Replace("'", "''") + "'," + strDateCreation + ",NULL,'" + this.m_strCommentary.Replace("'", "''") + "'," + dActivation.ToString("0") + ")";
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la création du rôle avec l'erreur : " + error.Message);
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
		/// Modifie le rôle en base
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
				sql = "UPDATE MOU01.role SET role='" + this.m_strRole.Replace("'", "''") + "', commentary='" + this.m_strCommentary.Replace("'", "''") + "', " +
						"date_modification= " + strDateModification + ", activation=" + dActivation.ToString("0") + " " + 
                                     "WHERE id_role=" + this.m_dIdRole.ToString("0");
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la modification du rôle avec l'erreur : " + error.Message);
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
		/// Supprime le rôle en base
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
				sql = "DELETE FROM MOU01.role WHERE id_role=" + this.m_dIdRole.ToString("0");
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la suppression du rôle avec l'erreur : " + error.Message);
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
		/// Obtient ou définit les membres de la classe Role
		/// </summary>
		#region

		/// <summary>
		/// Obtient ou définit l'identificateur "id_role" de la classe "Role"
		/// </summary>
		public long Id
		{
			get
			{
				return m_dIdRole;
			}

			set
			{
				m_dIdRole = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le nom du role
		/// </summary>
		public string Name
		{
			get
			{
				return m_strRole;
			}
			set
			{
				m_strRole = value;
			}
		}

		/// <summary>
		/// Obtient ou définit la date de création du role
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
		/// Obtient ou définit la date de dernière modification du role
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
		/// Obtient ou définit le commentaires du role
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
		/// Obtient ou définit l'activation du role
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

		public long IdProfile
		{
			get
			{
				return m_dIdProfile;
			}
			set
			{
				m_dIdProfile = value;
			}
		}
		#endregion

	}
}
