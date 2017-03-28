using System;
using System.Windows.Forms;
using System.Collections;
using Oracle.DataAccess.Client;

namespace AccountMgmt.DataAccess
{
	public class AccessAffectation
	{
		private ArrayList m_listAffectedUser = null;

		public AccessAffectation()
		{
			m_listAffectedUser = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		public void Dispose()
		{
			if(m_listAffectedUser.Count != 0)
				m_listAffectedUser.Clear();
		}

		/// <summary>
		/// Permet de sélectionner des enregistrements suivant un critère de recherche et de trier ces résultats
		/// </summary>
		/// <param name="connection">Objet de connexion à la base de données</param>
		/// <param name="idProfile">Identificateur du profile affecté</param>
		/// <param name="strSort">Critère de trie</param>
		/// <returns></returns>
		public bool Select(OracleConnection connection, long idProfile, string strSort)
		{
			OracleCommand sqlCommand=null;
			OracleDataReader sqlReader=null;
			string sql = "SELECT u.id_user_, u.id_language_data_i, u.id_region_data, u.user_, u.user_oracle, u.service, u.date_creation, u.date_modification, u.commentary, u.activation, u.id_language_user_, u.pwd, u.date_beginning, u.date_end, u.id_user_modification, u.id_temporary_tablespace, u.dba_status, id_source," + 
						" a.admin, a.date_creation, a.date_modification, a.commentary, a.activation, a.date_beginning, a.date_end FROM MOU01.list_user u, MOU01.AFFECTATION a " + 
						" WHERE u.id_user_ = a.id_user_ AND a.id_profile = " + idProfile.ToString("0");
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
					User newUser = new User();
					newUser.Id = long.Parse(sqlReader.GetValue(0).ToString());//sqlReader.GetInt64(0);
					newUser.IdLanguageData = long.Parse(sqlReader.GetValue(1).ToString());//sqlReader.GetInt64(1);
					newUser.IdRegionData = long.Parse(sqlReader.GetValue(2).ToString());//sqlReader.GetInt64(2);
					newUser.Name = sqlReader.GetString(3);
					newUser.UserOracle = sqlReader.GetString(4);
					newUser.Service = sqlReader.GetString(5);
					newUser.DateCreation = sqlReader.GetDateTime(6);
					if(!sqlReader.IsDBNull(7))
						newUser.DateModification = sqlReader.GetDateTime(7);
					if(!sqlReader.IsDBNull(8))
						newUser.Commentary = sqlReader.GetString(8);
					if(/*sqlReader.GetInt16(9)*/short.Parse(sqlReader.GetValue(9).ToString()) == AccountMgmt.Common.Constants.ActivationLevel)
						newUser.Activation = true;
					else
						newUser.Activation = false;
					newUser.IdLanguageUser = long.Parse(sqlReader.GetValue(10).ToString());//sqlReader.GetInt64(10);
					if(!sqlReader.IsDBNull(11))
						newUser.Password = sqlReader.GetString(11);
					if(!sqlReader.IsDBNull(12))
						newUser.DateBeginning = sqlReader.GetDateTime(12);
					if(!sqlReader.IsDBNull(13))
						newUser.DateEnd = sqlReader.GetDateTime(13);
					if(!sqlReader.IsDBNull(14))
						newUser.IdUserModification = long.Parse(sqlReader.GetValue(14).ToString());//sqlReader.GetInt64(14);
					newUser.IdTemporaryTableSpace = long.Parse(sqlReader.GetValue(15).ToString());//sqlReader.GetInt64(15);
					if(!sqlReader.IsDBNull(16))
						newUser.Admin = short.Parse(sqlReader.GetValue(16).ToString());
					else
						newUser.Admin = AccountMgmt.Common.Constants.NoAdminLevel;
					if(!sqlReader.IsDBNull(17))
						newUser.IdSource = long.Parse(sqlReader.GetValue(17).ToString());

					Affectation newAffectation = new Affectation();
					newAffectation.IdUser = long.Parse(sqlReader.GetValue(0).ToString());//sqlReader.GetInt64(0);
					newAffectation.IdProfile = idProfile;
					if(sqlReader.GetInt16(18) == AccountMgmt.Common.Constants.AdminLevel)
						newAffectation.Admin = true;
					else
						newAffectation.Admin = false;
					newAffectation.DateCreation = sqlReader.GetDateTime(19);
					if(!sqlReader.IsDBNull(20))
						newAffectation.DateModification = sqlReader.GetDateTime(20);
					if(!sqlReader.IsDBNull(21))
						newAffectation.Commentary = sqlReader.GetString(21);
					if(sqlReader.GetInt16(22) == AccountMgmt.Common.Constants.ActivationLevel)
						newAffectation.Activation = true;
					else
						newAffectation.Activation = false;
					if(!sqlReader.IsDBNull(23))
						newAffectation.DateBeginning = sqlReader.GetDateTime(23);
					if(!sqlReader.IsDBNull(24))
						newAffectation.DateEnd = sqlReader.GetDateTime(24);
					newAffectation.AffectedUser = newUser;
					m_listAffectedUser.Add(newAffectation);
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

		public ArrayList ListAffectedUsers
		{
			get
			{
				return m_listAffectedUser;
			}
		}
	}

	/// <summary>
	/// Description résumée de Affectation. Lien entre la classe User et Profile
	/// </summary>
	public class Affectation
	{
		private long m_dIdUser;
		private long m_dIdProfile;
		private bool m_bAdmin;
		private DateTime m_dtCreation;
		private DateTime m_dtModification;
		private string m_strCommentary;
		private bool m_bActivation;
		private DateTime m_dtBeginning;
		private DateTime m_dtEnd;
		private User m_affectedUser;

		/// <summary>
		/// Obtient ou définit les membres de la classe Affectation
		/// </summary>
		#region

		/// <summary>
		/// Obtient ou définit l'identificateur "id_user"
		/// </summary>
		public long IdUser
		{
			get
			{
				return m_dIdUser;
			}

			set
			{
				m_dIdUser = value;
			}
		}

		/// <summary>
		/// Obtient ou définit l'identificateur "id_profile"
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
		/// Obtient ou définit le champ admin
		/// </summary>
		public bool Admin
		{
			get
			{
				return m_bAdmin;
			}
			set
			{
				m_bAdmin = value;
			}
		}

		/// <summary>
		/// Obtient ou définit la date de création de l'affecation
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
		/// Obtient ou définit la date de dernière modification de l'affecation
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
		/// Obtient ou définit le commentaires de l'affecation
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
		/// Obtient ou définit l'activation de l'affecation
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

		/// <summary>
		/// Obtient ou définit la date de début de validité de l'affectation
		/// </summary>
		public DateTime DateBeginning
		{
			get
			{
				return m_dtBeginning;
			}
			set
			{
				m_dtBeginning = value;
			}
		}

		/// <summary>
		/// Obtient ou définit la date de fin de validité de l'affectation
		/// </summary>
		public DateTime DateEnd
		{
			get
			{
				return m_dtEnd;
			}
			set
			{
				m_dtEnd = value;
			}
		}

		/// <summary>
		/// Obtient ou définit l'utilisateur affecté
		/// </summary>
		public User AffectedUser
		{
			get
			{
				return m_affectedUser;
			}
			set
			{
				m_affectedUser = value;
			}
		}

		#endregion

		/// <summary>
		/// Méthodes de la classe Affectation
		/// </summary>
		#region
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
			string sql = "SELECT id_user, id_profile, admin, date_creation, date_modification, commentary, activation, date_beginning, date_end FROM MOU01.AFFECTATION WHERE " + 
				strWhere + " ORDER BY " + strSort;
			bool bResult = false;

			try
			{
				sqlCommand=new OracleCommand(sql,connection);
				sqlReader=sqlCommand.ExecuteReader();
				//lecture des données
				sqlReader.Read();
				m_dIdUser = sqlReader.GetInt64(0);
				m_dIdProfile = sqlReader.GetInt64(1);
				m_bAdmin = sqlReader.GetBoolean(2);
				m_dtCreation = sqlReader.GetDateTime(3);
				m_dtModification = sqlReader.GetDateTime(4);
				m_strCommentary = sqlReader.GetString(5);
				m_bActivation = sqlReader.GetBoolean(6);
				m_dtBeginning = sqlReader.GetDateTime(7);
				m_dtEnd = sqlReader.GetDateTime(8);
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
		/// Affectation d'un utilisateur à un profil en grantant les roles du profile à l'utilisateur
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="listRoles">Roles du profile</param>
		/// <param name="strUserOracle">UserOracle de l'utilisateur</param>
		/// <param name="strNewProfileOracle">ProfileOracle du profile</param>
		/// <returns></returns>
		public bool Add(OracleConnection connection, ArrayList listRoles, string strUserOracle, string strNewProfileOracle)
		{
			bool bResult = false;
			// Start a local transaction
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			OracleTransaction transaction = null;
			string sql = "";
						
			try
			{
				//lock de la table affectation
				sql = "LOCK TABLE MOU01.affectation IN EXCLUSIVE MODE";
				command.CommandText = sql;
				command.ExecuteNonQuery();
			}
			catch(Exception error)
			{
				sql = "ROLLBACK";
				command.CommandText = sql;
				command.ExecuteNonQuery();
				MessageBox.Show("Problème lors du lock de la table Affectation avec l'erreur : " + error.Message);
				return bResult;
			}
			try
			{
				transaction=connection.BeginTransaction();
				//grante les roles du profile à l'utilisateur
				if(listRoles.Count != 0)
				{
					sql = "GRANT ";
					for(int i=0; i<listRoles.Count; i++)
					{
						if(sql != "GRANT ")
							sql += ", ";
						sql += ((Role)listRoles[i]).Name;
					}
					sql = sql + " TO " + strUserOracle;
					if(this.m_bAdmin)
						sql += " WITH ADMIN OPTION";
					command.CommandText = sql;
					command.ExecuteNonQuery();
				}

				//mise à jour de la table affectation
				short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				if(this.m_bActivation)
					dActivation = AccountMgmt.Common.Constants.ActivationLevel;
				else
					dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				short dAdmin = AccountMgmt.Common.Constants.NoAdminLevel;
				if(this.m_bAdmin)
					dAdmin = AccountMgmt.Common.Constants.AdminLevel;
				else
					dAdmin = AccountMgmt.Common.Constants.NoAdminLevel;
				//string strDateCreation = "TO_DATE ('" + this.m_dtCreation.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				string strDateCreation = "TO_DATE ('" + m_dtCreation.Day.ToString("00") + "/" + m_dtCreation.Month.ToString("00") + "/" + m_dtCreation.Year.ToString("0000") + " " + m_dtCreation.Hour.ToString("00") + ":" + m_dtCreation.Minute.ToString("00") + ":" + m_dtCreation.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
				sql = "INSERT INTO MOU01.affectation(id_user_,id_profile,admin,date_creation,date_modification, commentary,activation, date_beginning, date_end) VALUES(" +
					this.m_dIdUser.ToString("0") + "," + this.m_dIdProfile.ToString("0") + "," + dAdmin.ToString("0") + "," + strDateCreation + ", " + strDateCreation + ",'" + this.m_strCommentary.Replace("'", "''") + "'," + dActivation.ToString("0") + ", NULL, NULL)";
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				sql = "COMMIT";
				command.CommandText = sql;
				command.ExecuteNonQuery();
				bResult = true;
				
				//affecter le profileOracle à l'utilisateur
				/*ArrayList listOracleProfile = null;
				bool bContinu = true;
				if(GetProfileOracleForUser(connection, this.m_dIdUser, out listOracleProfile))
				{
					if(listOracleProfile.Count == 0 && strNewProfileOracle != "DEFAULT") //l'utilisateur n'est pas affecté à un autre profile que 'DEFAULT'
					{
						sql = "ALTER USER " + this.m_affectedUser.UserOracle + " PROFILE " + strNewProfileOracle;
						command.CommandText = sql;
						command.ExecuteNonQuery();
					}
					
					/*if(strNewProfileOracle != "DEFAULT")
					{
						bool bDejaAffecte = false;
						for(int i=0; i<listOracleProfile.Count; i++)
						{
							if(((string)listOracleProfile[i]) == strNewProfileOracle)
								bDejaAffecte = true;
						}
						if(!bDejaAffecte)
						{
							sql = "ALTER USER " + this.m_affectedUser.UserOracle + " PROFILE " + strNewProfileOracle;
							command.CommandText = sql;
							command.ExecuteNonQuery();
						}
					}
					else
					{
						bool bDejaAffecte = true;
						int index = -1;
						for(int i=0; i<listOracleProfile.Count; i++)
						{
							if(((string)listOracleProfile[i]) != strNewProfileOracle)
							{
								bDejaAffecte = false;
								index = i;
							}
						}
						if(!bDejaAffecte)
						{
							sql = "ALTER USER " + this.m_affectedUser.UserOracle + " PROFILE " + ((string)listOracleProfile[index]);
							command.CommandText = sql;
							command.ExecuteNonQuery();
						}
					}*/
				/*}
				else
					bContinu = false;

				if(bContinu)
				{
					transaction.Commit();
					sql = "COMMIT";
					command.CommandText = sql;
					command.ExecuteNonQuery();
					bResult = true;
				}
				else
				{
					transaction.Rollback();
					sql = "ROLLBACK";
					command.CommandText = sql;
					command.ExecuteNonQuery();
				}*/
			}
			catch(Exception error)
			{
				transaction.Rollback();
				sql = "ROLLBACK";
				command.CommandText = sql;
				command.ExecuteNonQuery();
				MessageBox.Show("Problème lors de l'affectation de l'utilisateur au profile avec l'erreur : " + error.Message);
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
		/// Récupère la liste des profile oracle d'un utilisateur
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="idUser"></param>
		/// <param name="listOracleProfile"></param>
		/// <returns></returns>
		private bool GetProfileOracleForUser(OracleConnection connection, long idUser, out ArrayList listOracleProfile)
		{
			bool bResult = false;
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			OracleDataReader sqlReader=null;
			string sql = "";
			listOracleProfile = new ArrayList();
							
			try
			{
				sql = "SELECT p.Profile_oracle FROM MOU01.profile p, MOU01.affectation a WHERE " + 
					" p.Profile_oracle <> 'DEFAULT' AND p.id_profile = a.id_profile AND a.id_user_ = " + idUser.ToString("0");
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				while (sqlReader.Read())
				{
					listOracleProfile.Add(sqlReader.GetString(0));
				}
				bResult = true;
			}
			catch(Exception error)
			{
				MessageBox.Show("Problème lors de la recherche du profile oracle de l'utilisateur avec l'erreur : " + error.Message);
			}
			finally
			{
				//deconnexion
				try
				{
					// Fermeture de la base de données
					if (sqlReader!=null)
					{
						sqlReader.Close();
						sqlReader.Dispose();
					}
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
		/// Modifie les paramètres de l'affectation
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="listRoles">Roles du profile</param>
		/// <param name="strUserOracle">User_oracle de l'utilisateur</param>
		/// <returns></returns>
		public bool Update(OracleConnection connection, ArrayList listRoles, string strUserOracle)
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
				short dAdmin = AccountMgmt.Common.Constants.NoAdminLevel;
				if(this.m_bAdmin)
					dAdmin = AccountMgmt.Common.Constants.AdminLevel;
				else
					dAdmin = AccountMgmt.Common.Constants.NoAdminLevel;
				string strDateModification = "TO_DATE ('" + DateModification.Day.ToString("00") + "/" + DateModification.Month.ToString("00") + "/" + DateModification.Year.ToString("0000") + " " + DateModification.Hour.ToString("00") + ":" + DateModification.Minute.ToString("00") + ":" + DateModification.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
				//string strDateModification = "TO_DATE ('" + this.DateModification.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				string strDateBeginning = "NULL";
				if(this.m_dtBeginning != new DateTime())
					strDateBeginning = "TO_DATE ('" + m_dtBeginning.Day.ToString("00") + "/" + m_dtBeginning.Month.ToString("00") + "/" + m_dtBeginning.Year.ToString("0000") + " " + m_dtBeginning.Hour.ToString("00") + ":" + m_dtBeginning.Minute.ToString("00") + ":" + m_dtBeginning.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
					//strDateBeginning = "TO_DATE ('" + this.m_dtBeginning.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				string strDateEnd = "NULL";
				if(this.m_dtEnd != new DateTime())
					strDateEnd = "TO_DATE ('" + m_dtEnd.Day.ToString("00") + "/" + m_dtEnd.Month.ToString("00") + "/" + m_dtEnd.Year.ToString("0000") + " " + m_dtEnd.Hour.ToString("00") + ":" + m_dtEnd.Minute.ToString("00") + ":" + m_dtEnd.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
					//strDateEnd = "TO_DATE ('" + this.m_dtEnd.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				sql = "UPDATE MOU01.affectation SET admin=" + dAdmin.ToString("0") + ", date_modification=" + strDateModification + 
					", commentary='" + this.m_strCommentary + "', activation=" + dActivation.ToString("0") + 
					", date_beginning=" + strDateBeginning + ", date_end=" + strDateEnd + 
					" WHERE id_user_=" + this.m_dIdUser.ToString("0") + " AND id_profile=" + this.m_dIdProfile.ToString("0");
				command.CommandText = sql;
				command.ExecuteNonQuery();

				if(listRoles.Count != 0)
				{
					//revoke les roles du profile à l'utilisateur
					sql = "REVOKE ";
					for(int i=0; i<listRoles.Count; i++)
					{
						if(sql != "REVOKE ")
							sql += ", ";
						sql += ((Role)listRoles[i]).Name;
					}
					sql = sql + " FROM " + strUserOracle;
					command.CommandText = sql;
					command.ExecuteNonQuery();

					//grante les roles du profile à l'utilisateur
					sql = "GRANT ";
					for(int i=0; i<listRoles.Count; i++)
					{
						if(sql != "GRANT ")
							sql += ", ";
						sql += ((Role)listRoles[i]).Name;
					}
					sql = sql + " TO " + strUserOracle;
					if(this.m_bAdmin)
						sql += " WITH ADMIN OPTION";
					command.CommandText = sql;
					command.ExecuteNonQuery();
				}

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la modification de l'affectation de l'utilisateur au profile avec l'erreur : " + error.Message);
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
		/// Supprime l'affectation entre les rôles du profile et l'utilisateur, revoke aussi les rôles à l'utilisateur
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="strUserOracle">UserOrcale</param>
		/// <returns></returns>
		public bool Delete(OracleConnection connection, string strUserOracle)
		{
			bool bResult = false;
			// Start a local transaction
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			OracleDataReader sqlReader=null;
			OracleTransaction transaction = null;
			string sql = "", strRoleList = "";
						
			try
			{
				//lock de la table affectation
				sql = "LOCK TABLE MOU01.affectation IN EXCLUSIVE MODE";
				command.CommandText = sql;
				command.ExecuteNonQuery();

				try
				{
					transaction=connection.BeginTransaction();
					//Recherche des rôles à REVOKER
                    sql = "SELECT nom, SUM(nb) FROM(" +
                             "(SELECT role.role nom, '+'||COUNT(role.role) nb FROM MOU01.role, MOU01.right, MOU01.profile, MOU01.affectation " +
                             "WHERE Role.id_role = Right.id_role " +
                             "  AND right.id_profile = profile.id_profile " +
                             "  AND affectation.id_profile = profile.id_profile " +
                             "  AND affectation.id_user_=" + this.m_dIdUser.ToString("0") + " " +
                             "GROUP BY role.role) " +
                             "UNION ALL " +
                             "(SELECT role.role nom, '-'||COUNT(role.role) nb FROM MOU01.role, MOU01.right " +
                             "WHERE Role.id_role = Right.id_role" +
                             "  AND right.id_profile=" + this.m_dIdProfile.ToString("0") + " " +
                             "GROUP BY role.role)) GROUP BY nom HAVING SUM(nb)=0";
					command.CommandText = sql;
					sqlReader=command.ExecuteReader();
					//lecture des données
					while(sqlReader.Read())
					{
						if(strRoleList != "")
							strRoleList += ", ";
						strRoleList = strRoleList + sqlReader.GetString(0);
					}
					
					//revoke les roles du profile à l'utilisateur
					if(strRoleList != "")
					{
						sql = "REVOKE " + strRoleList + " FROM " + strUserOracle;
						command.CommandText = sql;
						command.ExecuteNonQuery();
					}

					//mise à jour de la table affectation
					sql = "DELETE FROM MOU01.affectation WHERE id_user_=" + this.m_dIdUser.ToString("0") + " AND id_profile=" + this.m_dIdProfile.ToString("0");
					command.CommandText = sql;
					command.ExecuteNonQuery();

					transaction.Commit();
					sql = "COMMIT";
					command.CommandText = sql;
					command.ExecuteNonQuery();
					bResult = true;
				}
				catch(Exception error)
				{
					transaction.Rollback();
					sql = "ROLLBACK";
					command.CommandText = sql;
					command.ExecuteNonQuery();
					MessageBox.Show("Problème lors de la suppression de l'affectation de l'utilisateur au profile avec l'erreur : " + error.Message);
				}
			}
			catch(Exception error)
			{
				sql = "ROLLBACK";
				command.CommandText = sql;
				command.ExecuteNonQuery();
				MessageBox.Show("Problème lors du lock de la table Affectation avec l'erreur : " + error.Message);
			}
			finally
			{
				//deconnexion
				try
				{
					// Fermeture de la base de données
					if (sqlReader!=null)
					{
						sqlReader.Close();
						sqlReader.Dispose();
					}
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
	}
}
