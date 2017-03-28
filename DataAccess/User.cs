using System;
using System.Windows.Forms;
using System.Collections;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace AccountMgmt.DataAccess
{
	public class AccessUser
	{
		private ArrayList m_listUser = null;

		public AccessUser()
		{
			m_listUser = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		public void Dispose()
		{
			if(m_listUser.Count != 0)
				m_listUser.Clear();
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
			//recherche les utilisateurs
			OracleCommand sqlCommand=null;
			OracleDataReader sqlReader=null;
			string sql = "SELECT u.id_user_, u.id_language_data_i, u.id_region_data, " + 
				"u.user_, u.user_oracle, u.service, u.date_creation, u.date_modification, " + 
				"u.commentary, u.activation, u.id_language_user_, u.pwd, u.date_beginning, " + 
				"u.date_end, u.id_user_modification, u.id_temporary_tablespace, u.dba_status, u.id_source, " + 
				"temp.temporary_tablespace " + 
				"FROM MOU01.list_user u, MOU01.temporary_tablespace temp";
			sql += " WHERE temp.id_temporary_tablespace = u.id_temporary_tablespace";
			if(strWhere != "")
				sql = sql + " and " + strWhere;
			if(strSort != "")
				sql = sql + " ORDER BY " + strSort;

			bool bResult = false;

			try
			{
				//connexion user
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
						newUser.Admin = short.Parse(sqlReader.GetValue(16).ToString());//sqlReader.GetInt16(16);
					else
						newUser.Admin = AccountMgmt.Common.Constants.NoAdminLevel;
					if(!sqlReader.IsDBNull(17))
						newUser.IdSource = long.Parse(sqlReader.GetValue(17).ToString());//sqlReader.GetInt64(17);
					newUser.TemporaryTableSpace = sqlReader.GetValue(18).ToString();
					m_listUser.Add(newUser);
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

		public ArrayList ListUser
		{
			get
			{
				return m_listUser;
			}
		}
	}

	/// <summary>
	/// Accès à la table User
	/// </summary>
	public class User
	{
		private long m_dIdUser;
		private long m_dIdLanguageData;
		private long m_dIdRegionData;
		private string m_strUser;
		private string m_strUserOracle;
		private string m_strService;
		private DateTime m_dtCreation;
		private DateTime m_dtModification;
		private string m_strCommentary;
		private bool m_bActivation;
		private long m_dIdLanguageUser;
		private string m_strPassword;
		private DateTime m_dtBeginning;
		private DateTime m_dtEnd;
		private long m_dIdUserModification;
		private long m_dIdTemporaryTableSpace;
		private short m_dAdmin;
		private long m_dIdSource;
		private string m_strTemporaryTableSpace;


		/// <summary>
		/// Méthodes de la classe User
		/// </summary>
		#region

		/// <summary>
		/// Récupère l'identificateur du type source de notre application
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="strTypeSource"></param>
		/// <param name="idTypeSource"></param>
		/// <returns></returns>
		public bool GetIdSource(OracleConnection connection, string strTypeSource, out long idTypeSource)
		{
			bool bResult = false;
			// Start a local transaction
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			string sql = "";
			OracleDataReader sqlReader=null;
			idTypeSource = 1;
						
			try
			{
				sql = "SELECT id_type_source FROM MOU01.type_source WHERE type_source='" + strTypeSource + "'";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				if (sqlReader.Read())
					idTypeSource = sqlReader.GetInt64(0);
				bResult = true;
			}
			catch(Exception error)
			{
				MessageBox.Show("Problème lors de la recherche du type source avec l'erreur : " + error.Message);
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
		/// Ajout en base d'un utilisateur
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="strDefaultTablespace"></param>
		/// <returns></returns>
		public bool Add(OracleConnection connection, string strDefaultTablespace)
		{
			bool bResult = false;
			// Start a local transaction
			OracleTransaction transaction=connection.BeginTransaction();
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			string sql = "";
			OracleDataReader sqlReader=null;
			/*long idTemporaryTablespace = -1;
			string strTemporaryTableSpace = "";*/
			
			
			try
			{
				/*//récupère la tablespace disponible avec le nombre d'utilisateur min
				sql = "SELECT id_temporary_tablespace, temporary_tablespace FROM MOU01.temporary_tablespace WHERE (max_user-user_count)=(select min(max_user-user_count) from MOU01.temporary_tablespace where (max_user-user_count) > 0)";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				if (sqlReader.Read())
				{
					idTemporaryTablespace = sqlReader.GetInt64(0);
					strTemporaryTableSpace = sqlReader.GetString(1);
				}
				if(idTemporaryTablespace == -1)
					MessageBox.Show("Pas de TableSpace disponible, impossible de créer un nouvel utilisateur.");
				else
				{*/
					//création d'un utilisateur oracle
					sql = "CREATE USER " + this.m_strUserOracle + @" IDENTIFIED BY """ + this.m_strPassword + @""" " +
						"DEFAULT TABLESPACE " + strDefaultTablespace.Replace("'", "''").ToUpper() + " " +
                             "TEMPORARY TABLESPACE " + this.TemporaryTableSpace.Replace("'", "''").ToUpper();
					command.CommandText = sql;
					command.ExecuteNonQuery();

					//Mise à jour de la Tablespace temporaire
					sql = "UPDATE MOU01.temporary_tablespace SET user_count=(user_count+1) WHERE id_temporary_tablespace=" + this.IdTemporaryTableSpace.ToString("0");
					command.CommandText = sql;
					command.ExecuteNonQuery();

					//Ajout de l'utilisateur dans la table user_
					short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
					if(this.m_bActivation)
						dActivation = AccountMgmt.Common.Constants.ActivationLevel;
					else
						dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				string strDateCreation = "TO_DATE ('" + m_dtCreation.Day.ToString("00") + "/" + m_dtCreation.Month.ToString("00") + "/" + m_dtCreation.Year.ToString("0000") + " " + m_dtCreation.Hour.ToString("00") + ":" + m_dtCreation.Minute.ToString("00") + ":" + m_dtCreation.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
				//string strDateCreation = "TO_DATE ('" + this.m_dtCreation.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
					string strDateBeginning = "NULL";
					if(this.m_dtBeginning != new DateTime())
						strDateBeginning = "TO_DATE ('" + m_dtBeginning.Day.ToString("00") + "/" + m_dtBeginning.Month.ToString("00") + "/" + m_dtBeginning.Year.ToString("0000") + " " + m_dtBeginning.Hour.ToString("00") + ":" + m_dtBeginning.Minute.ToString("00") + ":" + m_dtBeginning.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
						//strDateBeginning = "TO_DATE ('" + this.m_dtBeginning.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
					string strDateEnd = "NULL";
					if(this.m_dtEnd != new DateTime())
						strDateEnd = "TO_DATE ('" + m_dtEnd.Day.ToString("00") + "/" + m_dtEnd.Month.ToString("00") + "/" + m_dtEnd.Year.ToString("0000") + " " + m_dtEnd.Hour.ToString("00") + ":" + m_dtEnd.Minute.ToString("00") + ":" + m_dtEnd.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
						//strDateEnd = "TO_DATE ('" + this.m_dtEnd.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
					sql = "INSERT INTO MOU01.user_ VALUES(MOU01.SEQ_USER_.NEXTVAL,33,1,'" + this.m_strUser.Replace("'", "''") + "','" +
                        this.m_strUserOracle + "','" + this.m_strService.Replace("'", "''") + "'," + strDateCreation + ",NULL,'" + this.m_strCommentary.Replace("'", "''") +
                        "'," + dActivation.ToString("0") + ",33,'" + this.m_strPassword.Replace("'", "''") + "'," + strDateBeginning + "," + strDateEnd + "," + this.m_dIdUserModification.ToString("0") + "," + this.IdTemporaryTableSpace.ToString("0") + 
						", NULL, " + this.m_dAdmin.ToString("0") + ", " + this.m_dIdSource.ToString("0") + ")";
					command.CommandText = sql;
					command.ExecuteNonQuery();

					//granter les roles de manager si utilisateur est un responsable
					if(this.m_dAdmin == AccountMgmt.Common.Constants.ResponsableLevel)
					{
						sql = "GRANT MANAGE_RIGHT_SEL TO " + this.m_strUserOracle;
						command.CommandText = sql;
						command.ExecuteNonQuery();

						sql = "GRANT MANAGE_RIGHT_MOD TO " + this.m_strUserOracle;
						command.CommandText = sql;
						command.ExecuteNonQuery();
					}

					//recherche de l'identificateur du nouvel utilisateur
					sql = "SELECT id_user_ FROM MOU01.list_user WHERE user_oracle='" + this.m_strUserOracle + "'";
					command.CommandText = sql;
					sqlReader=command.ExecuteReader();
					//lecture des données
					if (sqlReader.Read())
						this.m_dIdUser = long.Parse(sqlReader.GetValue(0).ToString());//sqlReader.GetInt64(0);
					
					bResult = true;
				//}

				if(bResult)
					transaction.Commit();
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la création de l'utilisateur avec l'erreur : " + error.Message);
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
		/// Modifie un utilisateur en base
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="strPswd"></param>
		/// <param name="oldAdmin"></param>
		/// <returns></returns>
		public bool Modify(OracleConnection connection, string strPswd, short oldAdmin)
		{
			bool bResult = false;
			OracleTransaction transaction=connection.BeginTransaction();
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			string sql = "";

			try
			{
				//modifie le mot de passe de l'utilisateur oracle
				if(strPswd != this.m_strPassword)
				{
					sql = "ALTER USER " + this.m_strUserOracle + @" IDENTIFIED BY """ + strPswd + @"""";
					command.CommandText = sql;
					command.ExecuteNonQuery();
				}

				short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				if(this.m_bActivation)
					dActivation = AccountMgmt.Common.Constants.ActivationLevel;
				else
					dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				string strDateModification = "TO_DATE ('" + m_dtModification.Day.ToString("00") + "/" + m_dtModification.Month.ToString("00") + "/" + m_dtModification.Year.ToString("0000") + " " + m_dtModification.Hour.ToString("00") + ":" + m_dtModification.Minute.ToString("00") + ":" + m_dtModification.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
				//string strDateModification = "TO_DATE ('" + this.m_dtModification.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				string strDateBeginning = "NULL";
				if(this.m_dtBeginning != new DateTime())
					strDateBeginning = "TO_DATE ('" + m_dtBeginning.Day.ToString("00") + "/" + m_dtBeginning.Month.ToString("00") + "/" + m_dtBeginning.Year.ToString("0000") + " " + m_dtBeginning.Hour.ToString("00") + ":" + m_dtBeginning.Minute.ToString("00") + ":" + m_dtBeginning.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
					//strDateBeginning = "TO_DATE ('" + this.m_dtBeginning.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				string strDateEnd = "NULL";
				if(this.m_dtEnd != new DateTime())
					strDateEnd = "TO_DATE ('" + m_dtEnd.Day.ToString("00") + "/" + m_dtEnd.Month.ToString("00") + "/" + m_dtEnd.Year.ToString("0000") + " " + m_dtEnd.Hour.ToString("00") + ":" + m_dtEnd.Minute.ToString("00") + ":" + m_dtEnd.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
					//strDateEnd = "TO_DATE ('" + this.m_dtEnd.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				sql = "UPDATE MOU01.user_ SET user_='" + this.m_strUser.Replace("'", "''") + 
					"', service='" + this.m_strService.Replace("'", "''") + 
					"', commentary='" + this.m_strCommentary.Replace("'", "''") +
					"', pwd='" + strPswd +
					"', activation=" + dActivation.ToString("0") + 
					", date_beginning=" + strDateBeginning + 
					", date_end=" + strDateEnd + 
					", date_modification=" + strDateModification + 
					", dba_status=" + this.m_dAdmin.ToString("0") + 
					", id_user_modification=" + this.m_dIdUserModification.ToString("0") + 
					" WHERE id_user_=" + this.m_dIdUser.ToString("0");
				command.CommandText = sql;
				command.ExecuteNonQuery();

				//granter les roles de manager si utilisateur est un responsable
				if(this.m_dAdmin == AccountMgmt.Common.Constants.ResponsableLevel && oldAdmin != AccountMgmt.Common.Constants.ResponsableLevel)
				{
					sql = "GRANT MANAGE_RIGHT_SEL TO " + this.m_strUserOracle;
					command.CommandText = sql;
					command.ExecuteNonQuery();

					sql = "GRANT MANAGE_RIGHT_MOD TO " + this.m_strUserOracle;
					command.CommandText = sql;
					command.ExecuteNonQuery();
				}
				//revoker les roles de manager si utilisateur ne l'est plus
				if(this.m_dAdmin == AccountMgmt.Common.Constants.NoAdminLevel && oldAdmin == AccountMgmt.Common.Constants.ResponsableLevel)
				{
					sql = "REVOKE MANAGE_RIGHT_SEL FROM " + this.m_strUserOracle;
					command.CommandText = sql;
					command.ExecuteNonQuery();

					sql = "REVOKE MANAGE_RIGHT_MOD FROM " + this.m_strUserOracle;
					command.CommandText = sql;
					command.ExecuteNonQuery();
				}

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la modification de l'utilisateur avec l'erreur : " + error.Message);
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
		/// Supprime un utilisateur en base
		/// </summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		public bool Delete(OracleConnection connection)
		{
			bool bResult = false;
			OracleTransaction transaction = null/*=connection.BeginTransaction()*/;
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			string sql = "", strRoleList = "", sqlDelete = "";
			OracleDataReader sqlReader=null;
			OracleCommand commandDelete= new OracleCommand();
			commandDelete.Connection = connection;
			
			try
			{
				//desaffecter les roles de tous les profiles affectés a l'utilisateur
				//lock de la table affectation
				sql = "LOCK TABLE MOU01.affectation IN EXCLUSIVE MODE";
				command.CommandText = sql;
				command.ExecuteNonQuery();

				try
				{
					transaction=connection.BeginTransaction();
					//Recherche des rôles à REVOKER
					sql = "SELECT role.role nom FROM MOU01.role, MOU01.right, MOU01.profile, MOU01.affectation " +
						"WHERE Role.id_role = Right.id_role " +
						" AND right.id_profile = profile.id_profile " +
						" AND affectation.id_profile = profile.id_profile " +
						" AND affectation.id_user_=" + this.m_dIdUser.ToString("0") + 
						" GROUP BY role.role ";
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
						sql = "REVOKE " + strRoleList + " FROM " + this.UserOracle;
						command.CommandText = sql;
						command.ExecuteNonQuery();
					}

					//Recherche des rôles et profiles à desaffecter
					sql = "SELECT affectation.id_profile FROM MOU01.affectation " +
						"WHERE affectation.id_user_=" + this.m_dIdUser.ToString("0");
					command.CommandText = sql;
					sqlReader=command.ExecuteReader();
					//lecture des données
					while(sqlReader.Read())
					{
						//mise à jour de la table affectation
						sqlDelete = "DELETE FROM MOU01.affectation WHERE id_user_=" + this.m_dIdUser.ToString("0") + " AND id_profile=" + sqlReader.GetInt64(0).ToString();
						commandDelete.CommandText = sqlDelete;
						commandDelete.ExecuteNonQuery();
					}

					//Suppression du compte Oracle
					sql = "DROP USER " + this.m_strUserOracle;
					command.CommandText = sql;
					command.ExecuteNonQuery();

					//Mise à jour de la table temporary_tablespace
					sql = "UPDATE MOU01.temporary_tablespace SET user_count=(user_count-1) WHERE id_temporary_tablespace=" + this.IdTemporaryTableSpace.ToString("0");
					command.CommandText = sql;
					command.ExecuteNonQuery();

					//Suppression dand la table user_
					sql = "DELETE FROM MOU01.user_ WHERE user_oracle='" + this.m_strUserOracle + "'";
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
					MessageBox.Show("Problème lors de la suppression de l'utilisateur avec l'erreur : " + error.Message);
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

		/// <summary>
		/// Obtient ou définit les membres de la classe User
		/// </summary>
		#region
		/// <summary>
		/// Obtient ou définit l'identificateur "id_user"
		/// </summary>
		public long Id
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
		/// Obtient ou définit l'identificateur "id_language_data_i" 
		/// </summary>
		public long IdLanguageData
		{
			get
			{
				return m_dIdLanguageData;
			}

			set
			{
				m_dIdLanguageData = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le champ "id_region_data
		/// </summary>
		public long IdRegionData
		{
			get
			{
				return m_dIdRegionData;
			}
			set
			{
				m_dIdRegionData = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le nom de l'utilisateur
		/// </summary>
		public string Name
		{
			get
			{
				return m_strUser;
			}
			set
			{
				m_strUser = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le nom de l'utilisateur oracle
		/// </summary>
		public string UserOracle
		{
			get
			{
				return m_strUserOracle;
			}
			set
			{
				m_strUserOracle = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le service
		/// </summary>
		public string Service
		{
			get
			{
				return m_strService;
			}
			set
			{
				m_strService = value;
			}
		}

		/// <summary>
		/// Obtient ou définit la date de création de l'utilisateur
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
		/// Obtient ou définit la date de dernière modification de l'utilisateur
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
		/// Obtient ou définit le commentaires de l'utilisateur
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
		/// Obtient ou définit l'activation de l'utilisateur
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
		/// Obtient ou définit le champ "id_language_user_"
		/// </summary>
		public long IdLanguageUser
		{
			get
			{
				return m_dIdLanguageUser;
			}
			set
			{
				m_dIdLanguageUser = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le champ "pwd"
		/// </summary>
		public string Password
		{
			get
			{
				return m_strPassword;
			}
			set
			{
				m_strPassword = value;
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
		/// Obtient ou définit le champ "id_user_modification"
		/// </summary>
		public long IdUserModification
		{
			get
			{
				return m_dIdUserModification;
			}
			set
			{
				m_dIdUserModification = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le champ "id_temporary_tablespace"
		/// </summary>
		public long IdTemporaryTableSpace
		{
			get
			{
				return m_dIdTemporaryTableSpace;
			}
			set
			{
				m_dIdTemporaryTableSpace = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le champ "admin"
		/// </summary>
		public short Admin
		{
			get
			{
				return m_dAdmin;
			}
			set
			{
				m_dAdmin = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le champ "id_source"
		/// </summary>
		public long IdSource
		{
			get
			{
				return m_dIdSource;
			}
			set
			{
				m_dIdSource = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le nom de la table temporaire qui a servi à créer le user
		/// </summary>
		public string TemporaryTableSpace
		{
			get
			{
				return m_strTemporaryTableSpace;
			}
			set
			{
				m_strTemporaryTableSpace = value;
			}
		}
		#endregion

	}
}
