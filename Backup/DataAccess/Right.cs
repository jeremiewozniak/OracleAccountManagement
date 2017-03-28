using System;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Collections;

namespace AccountMgmt.DataAccess
{
	/// <summary>
	/// Accès à la table Right.
	/// </summary>
	public class Right
	{
		private long m_dIdProfile;
		private long m_dIdRole;
		private DateTime m_dtCreation;
		private DateTime m_dtModification;
		private string m_strCommentary;
		private bool m_bActivation;

		/// <summary>
		/// Obtient ou définit les membres de la classe Right
		/// </summary>
		#region

		/// <summary>
		/// Obtient ou définit l'identificateur du profile lié au droit
		/// </summary>
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

		/// <summary>
		/// Obtient ou définit l'identificateur du role lié au droit
		/// </summary>
		public long IdRole
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
		/// Obtient ou définit la date de création du droit
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
		/// Obtient ou définit la date de dernière modification du droit
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
		/// Obtient ou définit le commentaires du droit
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
		/// Obtient ou définit l'activation du droit
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


		/// <summary>
		/// Méthodes de la classe Right
		/// </summary>
		#region
		/// <summary>
		/// Ajout d'un lien entre un profile et un rôle
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="transaction"></param>
		/// <param name="strRole">Nom du rôle</param>
		/// <returns></returns>
		public bool Add(OracleConnection connection, OracleTransaction transaction, string strRole)
		{
			bool bResult = false;
			// Start a local transaction
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			string sql = "";
						
			try
			{
				/// grant avant insert car commit d'office !!!!!!
				//grante le role aux utilisateurs
				if(Grant(connection, transaction, strRole))
				{
					//ajout du droit
					short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
					if(this.m_bActivation)
						dActivation = AccountMgmt.Common.Constants.ActivationLevel;
					else
						dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
					string strDateCreation = "TO_DATE ('" + m_dtCreation.Day.ToString("00") + "/" + m_dtCreation.Month.ToString("00") + "/" + m_dtCreation.Year.ToString("0000") + " " + m_dtCreation.Hour.ToString("00") + ":" + m_dtCreation.Minute.ToString("00") + ":" + m_dtCreation.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
					//string strDateCreation = "TO_DATE ('" + this.m_dtCreation.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
					sql = "INSERT INTO MOU01.right(id_profile, id_role, date_creation,activation) VALUES (" + this.m_dIdProfile.ToString("0") + "," + this.m_dIdRole.ToString("0") + "," + strDateCreation + "," + dActivation.ToString("0") + ")";
					command.CommandText = sql;
					command.ExecuteNonQuery();

					bResult = true;
				}
			}
			catch(Exception error)
			{
				MessageBox.Show("Problème lors de l'affectation d'un rôle à un profile avec l'erreur : " + error.Message);
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
		/// Grante le rôle aux utilisateurs
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="strRole">Nom du rôle</param>
		/// <returns></returns>
		private bool Grant(OracleConnection connection, OracleTransaction transaction, string strRole)
		{
			bool bResult = false;
			// Start a local transaction
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			OracleDataReader sqlReader=null;
			string sql = "", strUserList = "", strUserAdminList = "";
						
			try
			{
				//recherche de tous les utilisateurs actifs, affectés au profile
				sql = "SELECT u.user_oracle, a.admin FROM MOU01.list_user u, MOU01.affectation a WHERE " + 
						" u.activation<" + AccountMgmt.Common.Constants.DesactivationLevel.ToString("0") + 
						" AND u.id_user_=a.id_user_" + 
						" AND a.activation<" + AccountMgmt.Common.Constants.DesactivationLevel.ToString("0") + 
						" AND a.id_profile=" + this.m_dIdProfile.ToString("0");
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				while (sqlReader.Read())
				{
					if(sqlReader.GetInt16(1) >= AccountMgmt.Common.Constants.AdminLevel)
					{
						if(strUserAdminList != "")
							strUserAdminList += ", ";
						strUserAdminList = strUserAdminList + sqlReader.GetString(0);
					}
					else
					{
						if(strUserList != "")
							strUserList += ", ";
						strUserList = strUserList + sqlReader.GetString(0);
					}
				}

				//grant le role aux utilisateurs
				if(strUserList != "")
				{
					sql = "GRANT " + strRole + " TO " + strUserList;
					command.CommandText = sql;
					command.ExecuteNonQuery();
				}

				//grant le role aux utilisateurs administrateurs
				if(strUserAdminList != "")
				{
					sql = "GRANT " + strRole + " TO " + strUserAdminList + " WITH ADMIN OPTION";
					command.CommandText = sql;
					command.ExecuteNonQuery();
				}

				bResult = true;
			}
			catch(Exception error)
			{
				MessageBox.Show("Problème lors du grant du rôle aux utilisateurs avec l'erreur : " + error.Message);
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
		/// Supprime le lien entre le rôle et le profile
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
				///Revoke avant delete car commit d'office !!!!!!!!!!!!!!
				//revoke le rôle aux utilisateurs
				if(Revoke(connection, transaction))
				{
					sql = "DELETE FROM MOU01.right WHERE id_role=" + this.m_dIdRole.ToString("0") + " AND id_profile=" + this.m_dIdProfile.ToString("0");
					command.CommandText = sql;
					command.ExecuteNonQuery();

					transaction.Commit();
					bResult = true;
				}
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la suppression du lien entre le rôle et le profile avec l'erreur : " + error.Message);
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
		/// Revoke le rôle aux utilisateurs
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="transaction"></param>
		/// <returns></returns>
		private bool Revoke(OracleConnection connection, OracleTransaction transaction)
		{
			bool bResult = false;
			// Start a local transaction
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			OracleDataReader sqlReader=null;
			string sql = "";
			ArrayList userOracleList, roleList;
			userOracleList = new ArrayList();
			roleList = new ArrayList();
						
			try
			{
				//recherche les roles liés au profile, affectés à des utilisateurs
				sql = "SELECT DISTINCT u.user_oracle, ro.role " +
                        "FROM MOU01.list_user u, MOU01.affectation a, MOU01.right r, MOU01.role ro " +
                        "WHERE a.id_profile = " + this.m_dIdProfile + 
						" AND ro.id_role = " + this.m_dIdRole + 
                        //"  AND a.activation <" + AccountMgmt.Common.Constants.DesactivationLevel.ToString("0") +
                        //"  AND u.activation<" + AccountMgmt.Common.Constants.DesactivationLevel.ToString("0") +
                        "  AND a.id_profile = r.id_profile" +
                        "  AND a.id_user_=u.id_user_" +
                        "  AND r.id_role = ro.id_role " +
                        "MINUS " +
                        "SELECT DISTINCT u.user_oracle, r.role " +
                        "FROM MOU01.role r, MOU01.right, MOU01.affectation a, MOU01.list_user u " +
                        "WHERE a.id_profile = right.id_profile " +
						"AND a.id_profile<> " + this.m_dIdProfile.ToString() + 
                        "  AND right.id_role = r.id_role" +
                        "  AND a.id_user_ = u.id_user_ " +
                        "GROUP BY u.id_user_, u.user_oracle, r.role ";
                        //"HAVING Count(r.id_role) > 1";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				while (sqlReader.Read())
				{
					userOracleList.Add(sqlReader.GetString(0));
					roleList.Add(sqlReader.GetString(1));
				}

				//revoke les roles aux utilisateurs
				for(int i=0; i<userOracleList.Count; i++)
				{
					sql = "REVOKE " + ((string)roleList[i]) + " FROM " + ((string)userOracleList[i]);
					command.CommandText = sql;
					command.ExecuteNonQuery();
				}

				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors du revoke du rôle aux utilisateurs avec l'erreur : " + error.Message);
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

			if(userOracleList.Count != 0)
				userOracleList.Clear();
			if(roleList.Count != 0)
				roleList.Clear();
				
			return bResult;
		}
		#endregion
	}
}
