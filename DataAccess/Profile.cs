using System;
using System.Windows.Forms;
using System.Collections;
using Oracle.ManagedDataAccess.Client;

namespace AccountMgmt.DataAccess
{
	public class AccessDefaultProfile
	{
		private ArrayList m_listDefaultProfile = null;
		private ArrayList m_listDefaultTablespace = null;

		public AccessDefaultProfile()
		{
			m_listDefaultProfile = new ArrayList();
			m_listDefaultTablespace = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		public void Dispose()
		{
			if(m_listDefaultProfile.Count != 0)
				m_listDefaultProfile.Clear();
			if(m_listDefaultTablespace.Count != 0)
				m_listDefaultTablespace.Clear();
		}

		/// <summary>
		/// Permet de sélectionner des enregistrements suivant un critère de recherche et de trier ces résultats
		/// </summary>
		/// <param name="connection">Objet de connexion à la base de données</param>
		/// <returns></returns>
		public bool Select(OracleConnection connection)
		{
			OracleCommand sqlCommandProfile=null;
			OracleDataReader sqlReaderProfile=null;
			string sqlProfile = "SELECT DISTINCT p.profile, a.default_tablespace FROM MOU01.PROFILE p, MOU01.MODULE m, MOU01.APPLICATION a " + 
				"WHERE p.id_module = m.id_module AND m.id_application = a.id_application" + 
				" ORDER BY p.profile";
			bool bResult = false;

			try
			{
				sqlCommandProfile=new OracleCommand(sqlProfile,connection);
				sqlReaderProfile=sqlCommandProfile.ExecuteReader();
				while (sqlReaderProfile.Read())
				{
					m_listDefaultProfile.Add(sqlReaderProfile.GetString(0));
					if(!sqlReaderProfile.IsDBNull(1))
						m_listDefaultTablespace.Add(sqlReaderProfile.GetString(1));
					else
						m_listDefaultTablespace.Add("");
				}
				bResult = true;
			}
			catch(Exception error)
			{
				MessageBox.Show("Message d’erreur : "+error.Message);
			}
			//deconnexion profile
			try
			{
				// Fermeture de la base de données
				if (sqlReaderProfile!=null)
				{
					sqlReaderProfile.Close();
					sqlReaderProfile.Dispose();
				}
				if(sqlCommandProfile!=null)
					sqlCommandProfile.Dispose();
			}
			catch(Exception error)
			{
				MessageBox.Show("Message d’erreur : "+error.Message);
			}

			return bResult;
		}

		/// <summary>
		/// Obtient la liste des noms des profiles
		/// </summary>
		public ArrayList ListDefaultProfile
		{
			get
			{
				return m_listDefaultProfile;
			}
		}

		public ArrayList ListDefaultTablespace
		{
			get
			{
				return m_listDefaultTablespace;
			}
		}
	}

	public class AccessProfile
	{
		private ArrayList m_listProfile = null;
		
		public AccessProfile()
		{
			m_listProfile = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		public void Dispose()
		{
			if(m_listProfile.Count != 0)
				m_listProfile.Clear();
		}

		/// <summary>
		/// Permet de sélectionner des enregistrements suivant un critère de recherche et de trier ces résultats
		/// </summary>
		/// <param name="connection">Objet de connexion à la base de données</param>
		/// <returns></returns>
		public bool Select(OracleConnection connection, string strWhere, string strSort)
		{
			OracleCommand sqlCommandProfile=null;
			OracleDataReader sqlReaderProfile=null;
			//string sqlProfile = "SELECT id_profile, profile, id_module, date_creation, date_modification, commentary, activation, Profile_oracle, Rsrc_conso_group FROM MOU01.profile";
			string sqlProfile = "SELECT id_profile, profile, id_module, date_creation, date_modification, commentary, activation, Profile_oracle FROM MOU01.profile";
			if(strWhere != "")
				sqlProfile = sqlProfile + " WHERE " + strWhere;
			if(strSort != "")
				sqlProfile = sqlProfile + " ORDER BY " + strSort;
			bool bResult = false;

			try
			{
				sqlCommandProfile=new OracleCommand(sqlProfile,connection);
				sqlReaderProfile=sqlCommandProfile.ExecuteReader();
				while (sqlReaderProfile.Read())
				{
					Profile newProfile = new Profile();
					newProfile.Id = sqlReaderProfile.GetInt64(0);
					newProfile.Name = sqlReaderProfile.GetString(1);
					newProfile.IdModule = sqlReaderProfile.GetInt64(2);
					newProfile.DateCreation = sqlReaderProfile.GetDateTime(3);
					if(!sqlReaderProfile.IsDBNull(4))
						newProfile.DateModification = sqlReaderProfile.GetDateTime(4);
					if(!sqlReaderProfile.IsDBNull(5))
						newProfile.Commentary = sqlReaderProfile.GetString(5);
					if(sqlReaderProfile.GetInt16(6) == AccountMgmt.Common.Constants.ActivationLevel)
						newProfile.Activation = true;
					else
						newProfile.Activation = false;
					if(!sqlReaderProfile.IsDBNull(7))
						newProfile.OracleProfile = sqlReaderProfile.GetString(7);
					/*if(!sqlReaderProfile.IsDBNull(8))
						newProfile.RsrcConsoGroup = sqlReaderProfile.GetString(8);*/
					m_listProfile.Add(newProfile);
				}
				bResult = true;
			}
			catch(Exception error)
			{
				MessageBox.Show("Message d’erreur : "+error.Message);
			}
			//deconnexion profile
			try
			{
				// Fermeture de la base de données
				if (sqlReaderProfile!=null)
				{
					sqlReaderProfile.Close();
					sqlReaderProfile.Dispose();
				}
				if(sqlCommandProfile!=null)
					sqlCommandProfile.Dispose();
			}
			catch(Exception error)
			{
				MessageBox.Show("Message d’erreur : "+error.Message);
			}

			return bResult;
		}

		/// <summary>
		/// Obtient la liste des noms des profiles
		/// </summary>
		public ArrayList ListProfile
		{
			get
			{
				return m_listProfile;
			}
		}
	}

	/// <summary>
	/// Accès à la table Profile.
	/// </summary>
	public class Profile
	{
		private long m_dIdProfile;
		private string m_strProfile;
		private long m_dIdModule;
		private DateTime m_dtCreation;
		private DateTime m_dtModification;
		private string m_strCommentary;
		private bool m_bActivation;
		private string m_strOracleProfile;
		private string m_strRsrcConsoGroup;

		/// <summary>
		/// Méthodes de la classe Profile
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
				sql = "SELECT MOU01.SEQ_PROFILE.NEXTVAL FROM DUAL";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				if (sqlReader.Read())
					this.m_dIdProfile = long.Parse(sqlReader.GetValue(0).ToString());

				short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				if(this.m_bActivation)
					dActivation = AccountMgmt.Common.Constants.ActivationLevel;
				else
					dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
				string strDateCreation = "TO_DATE ('" + m_dtCreation.Day.ToString("00") + "/" + m_dtCreation.Month.ToString("00") + "/" + m_dtCreation.Year.ToString("0000") + " " + m_dtCreation.Hour.ToString("00") + ":" + m_dtCreation.Minute.ToString("00") + ":" + m_dtCreation.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
				//string strDateCreation = "TO_DATE ('" + this.m_dtCreation.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
				if(this.m_strOracleProfile == "")
					this.m_strOracleProfile = "DEFAULT";
				sql = "INSERT INTO MOU01.profile VALUES (" + this.m_dIdProfile.ToString("0") + ",'" + this.m_strProfile.Replace("'", "''") + "'," + this.m_dIdModule.ToString("0") + "," + strDateCreation + ",NULL,'" + this.m_strCommentary.Replace("'", "''") + "'," + dActivation.ToString("0") + ", '" + this.m_strOracleProfile + "')";//"', '" + this.m_strRsrcConsoGroup + "')";
				command.CommandText = sql;
				command.ExecuteNonQuery();

				transaction.Commit();
				bResult = true;
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la création d'un profile avec l'erreur : " + error.Message);
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
		/// Modification du profile en base
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="strNewProfileOracle"></param>
		/// <returns></returns>
		public bool Update(OracleConnection connection, string strNewProfileOracle)
		{
			bool bResult = false, bAlterUserResult=true;
			// Start a local transaction
			OracleTransaction transaction=connection.BeginTransaction();
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			string sql = "";
				
			if(strNewProfileOracle == "")
				strNewProfileOracle = "DEFAULT";

			try
			{
				//si le profile est affecté
				/*ArrayList listIdUserAffected=null, listUserOracleAffected=null;
				if(IsAffectedProfile(connection, out listIdUserAffected, out listUserOracleAffected))
				{*/
					/// reste à développer dans la partie affectation des profiles aux utilisateurs
					/// une fonction qui va permettre de montrer tous les utilisateurs qui ont comme
					/// premier profile oracle différent de 'DEFAULT' ce profile et qui permet de changer la valeur
					/// profile oracle de ce profile et de modifier certains de ces utilisateurs avec
					/// ce profile oracle
					
				/*if(strNewProfileOracle != this.m_strOracleProfile)
				{
					if(strNewProfileOracle != "DEFAULT")
					{
						if(SearchAffectedProfileOracle(connection, false, out listIdUserAffected, out listUserOracleAffected))
						{
							for(int i=0; i<listUserOracleAffected.Count; i++)
							{
								sql = "ALTER USER " + ((string)listUserOracleAffected[i]) + " PROFILE " + strNewProfileOracle;
								command.CommandText = sql;
								command.ExecuteNonQuery();
							}
						}
					}
					else
					{
						if(SearchAffectedProfileOracle(connection, true, out listIdUserAffected, out listUserOracleAffected))
						{
							if(listUserOracleAffected.Count != 0)
							{
								for(int i=0; i<listUserOracleAffected.Count; i++)
								{
									sql = "ALTER USER " + ((string)listUserOracleAffected[i]) + " PROFILE " + strNewProfileOracle;
									command.CommandText = sql;
									command.ExecuteNonQuery();
								}
							}
						}
					}
				}*/
					/*if(strNewProfileOracle != this.m_strOracleProfile)
					{
						for(int i=0; i<listUserOracleAffected.Count; i++)
						{
							if(strNewProfileOracle != "DEFAULT")
							{
								sql = "ALTER USER " + ((string)listUserOracleAffected[i]) + " PROFILE " + strNewProfileOracle;
								command.CommandText = sql;
								command.ExecuteNonQuery();
							}
							else
							{
								string strOracleProfile = "";
								if(GetProfileOracleForUser(connection, ((long)listIdUserAffected[i]), out strOracleProfile))
								{
									sql = "ALTER USER " + ((string)listUserOracleAffected[i]) + " PROFILE " + strOracleProfile;
									command.CommandText = sql;
									command.ExecuteNonQuery();
								}
								else
								{
									bAlterUserResult = false;
									transaction.Rollback();
									i=listUserOracleAffected.Count;
								}
							}
						}
					}*/
					if(bAlterUserResult)
					{
						this.m_strOracleProfile = strNewProfileOracle;

						short dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
						if(this.m_bActivation)
							dActivation = AccountMgmt.Common.Constants.ActivationLevel;
						else
							dActivation = AccountMgmt.Common.Constants.DesactivationLevel;
						string strDateModification = "TO_DATE ('" + m_dtModification.Day.ToString("00") + "/" + m_dtModification.Month.ToString("00") + "/" + m_dtModification.Year.ToString("0000") + " " + m_dtModification.Hour.ToString("00") + ":" + m_dtModification.Minute.ToString("00") + ":" + m_dtModification.Second.ToString("00") + "', 'DD/MM/YYYY HH24:MI:SS')";
						//string strDateModification = "TO_DATE ('" + this.m_dtModification.ToString("G") + "', 'DD/MM/YYYY HH24:MI:SS')";
						sql = "UPDATE MOU01.profile SET profile='" + this.m_strProfile.Replace("'", "''") + "', commentary='" + this.m_strCommentary.Replace("'", "''") +
							"', activation = " + dActivation.ToString("0") + ", " +
							"date_modification = " + strDateModification  + ", Profile_oracle='" + /*this.m_strOracleProfile*/strNewProfileOracle + 
							//"', Rsrc_conso_group='" + this.m_strRsrcConsoGroup + 
							"' WHERE id_profile=" + this.m_dIdProfile.ToString("0");
						command.CommandText = sql;
						command.ExecuteNonQuery();

						transaction.Commit();
						bResult = true;
					}
				//}
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la modification d'un profile avec l'erreur : " + error.Message);
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
		/// Recherche tous les profiles affectés à l'utilisateur
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="idUser"></param>
		/// <returns></returns>
		private bool GetProfileOracleForUser(OracleConnection connection, long idUser, out string strOracleProfile)
		{
			bool bResult = false;
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			OracleDataReader sqlReader=null;
			string sql = "";
			strOracleProfile = "DEFAULT";
							
			try
			{
				sql = "SELECT Profile_oracle FROM " + 
					"(SELECT p.Profile_oracle FROM MOU01.profile p, MOU01.affectation a WHERE " + 
					" p.Profile_oracle <> 'DEFAULT' and p.Profile_oracle is not null AND p.id_profile = a.id_profile AND a.id_user_ = " + idUser.ToString("0") + ")" + 
					" WHERE rownum=1 order by a.date_creation";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				if (sqlReader.Read())
					strOracleProfile  = sqlReader.GetString(0);
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
		/// Suppression du profile en base
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="listIdUserAffected">Liste des utilisateurs affectés au profile</param>
		/// <returns></returns>
		public bool Delete(OracleConnection connection, ArrayList listIdUserAffected)
		{
			bool bResult = false, bResultDasaffectation = false;
			// Start a local transaction
			OracleTransaction transaction=null;
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			string sql = "";
			
			//s'il est affecté, on supprime juste l'enregistrement dans la table affectation, pas beoisn de revoke car il n est pas lie a un role
			if(listIdUserAffected.Count != 0)
			{
				try
				{
					//lock de la table affectation
					sql = "LOCK TABLE MOU01.affectation IN EXCLUSIVE MODE";
					command.CommandText = sql;
					command.ExecuteNonQuery();
					try
					{
						transaction=connection.BeginTransaction();
						for(int i=0; i<listIdUserAffected.Count; i++)
						{
							sql = "DELETE FROM MOU01.affectation WHERE id_user_=" + ((long)listIdUserAffected[i]).ToString("0") + " AND id_profile=" + this.m_dIdProfile.ToString("0");
							command.CommandText = sql;
							command.ExecuteNonQuery();
						}

						//transaction.Rollback();
						sql = "COMMIT";
						command.CommandText = sql;
						command.ExecuteNonQuery();
						bResultDasaffectation = true;
					}
					catch(Exception error)
					{
						transaction.Rollback();
						sql = "ROLLBACK";
						command.CommandText = sql;
						command.ExecuteNonQuery();
						MessageBox.Show("Problème lors de la désaffectation du profile à un utilisateur avec l'erreur : " + error.Message);
					}
				}
				catch(Exception error)
				{
					sql = "ROLLBACK";
					command.CommandText = sql;
					command.ExecuteNonQuery();
					MessageBox.Show("Problème lors du lock de la table Affectation avec l'erreur : " + error.Message);
				}
			}

			try
			{
				if(bResultDasaffectation)
				{
					//transaction=connection.BeginTransaction();
					sql = "DELETE FROM MOU01.profile WHERE id_profile=" + this.m_dIdProfile.ToString("0");
					command.CommandText = sql;
					command.ExecuteNonQuery();

					transaction.Commit();
					bResult = true;
				}
			}
			catch(Exception error)
			{
				transaction.Rollback();
				MessageBox.Show("Problème lors de la suppression d'un profile avec l'erreur : " + error.Message);
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
		/// Recherche si ce profile est affecté à au moins un utilisateur
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="listIdUserAffected">Liste des identificateurs des utilisateurs affectés</param>
		/// <param name="listUserOracleAffected">Liste des noms des utilisateurs affectés</param>
		/// <returns></returns>
		public bool SearchAffectedProfileOracle(OracleConnection connection, out ArrayList listIdUserAffected, out ArrayList listUserOracleAffected)
		{
			bool bResult = false;
			// Start a local transaction
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			OracleDataReader sqlReader=null;
			string sql = "";
			listIdUserAffected = new ArrayList();
			listUserOracleAffected = new ArrayList();
							
			try
			{
				sql = "select a.id_user_, a.date_creation, a.id_profile, p.profile_oracle " +
						"from MOU01.affectation a, MOU01.profile p " +
						"where p.id_profile = a.id_profile " + 
						"order by a.id_user_, a.date_creation";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				while (sqlReader.Read())
				{
					listIdUserAffected.Add(sqlReader.GetInt64(0));
					listUserOracleAffected.Add(sqlReader.GetString(1));
				}
				bResult = true;
			}
			catch(Exception error)
			{
				MessageBox.Show("Problème lors de la recherche d'affectation d'un profile avec l'erreur : " + error.Message);
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
		/// Recherche si ce profile est affecté à au moins un utilisateur
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="listIdUserAffected">Liste des identificateurs des utilisateurs affectés</param>
		/// <param name="listUserOracleAffected">Liste des noms des utilisateurs affectés</param>
		/// <returns></returns>
		public bool IsAffectedProfile(OracleConnection connection, out ArrayList listIdUserAffected, out ArrayList listUserOracleAffected)
		{
			bool bResult = false;
			// Start a local transaction
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			OracleDataReader sqlReader=null;
			string sql = "";
			listIdUserAffected = new ArrayList();
			listUserOracleAffected = new ArrayList();
							
			try
			{
				sql = "SELECT a.id_user_, u.user_oracle FROM MOU01.affectation a , MOU01.list_user u WHERE " + 
					" u.id_user_ = a.id_user_ AND a.id_profile = " + this.m_dIdProfile.ToString("0");
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des données
				while (sqlReader.Read())
				{
					listIdUserAffected.Add(sqlReader.GetInt64(0));
					listUserOracleAffected.Add(sqlReader.GetString(1));
				}
				bResult = true;
			}
			catch(Exception error)
			{
				MessageBox.Show("Problème lors de la recherche d'affectation d'un profile avec l'erreur : " + error.Message);
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
		/// Obtient ou définit les membres de la classe Profile
		/// </summary>
		#region

		/// <summary>
		/// Obtient ou définit l'identificateur "id_module" de la classe "Profile"
		/// </summary>
		public long Id
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
		/// Obtient ou définit le nom du profile
		/// </summary>
		public string Name
		{
			get
			{
				return m_strProfile;
			}
			set
			{
				m_strProfile = value;
			}
		}

		/// <summary>
		/// Obtient ou définit l'identificateur du module liée au profile
		/// </summary>
		public long IdModule
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
		/// Obtient ou définit la date de création du profile
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
		/// Obtient ou définit la date de dernière modification du profile
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
		/// Obtient ou définit le commentaires du profile
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
		/// Obtient ou définit l'activation du profile
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
		/// Obtient ou définit le profile oracle
		/// </summary>
		public string OracleProfile
		{
			get
			{
				return m_strOracleProfile;
			}
			set
			{
				m_strOracleProfile = value;
			}
		}

		/// <summary>
		/// Obtient ou définit la ressource ConsoGroup
		/// </summary>
		public string RsrcConsoGroup
		{
			get
			{
				return m_strRsrcConsoGroup;
			}
			set
			{
				m_strRsrcConsoGroup = value;
			}
		}
		#endregion
	}
}
