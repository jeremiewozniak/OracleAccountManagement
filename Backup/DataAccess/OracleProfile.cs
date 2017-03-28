using System;
using System.Windows.Forms;
using System.Collections;
using Oracle.DataAccess.Client;

namespace AccountMgmt.DataAccess
{
	public class AccessOracleProfile
	{
		private ArrayList m_listOracleProfile = null;

		public AccessOracleProfile()
		{
			m_listOracleProfile = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		public void Dispose()
		{
			if(m_listOracleProfile.Count != 0)
				m_listOracleProfile.Clear();
		}

		/// <summary>
		/// Recherche des utilisateurs affectés à un profile
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="OracleProfile"></param>
		/// <param name="IdProfile"></param>
		/// <param name="bAllUsers"></param>
		/// <returns></returns>
		public bool Select(OracleConnection connection, string OracleProfile, long IdProfile, bool bAllUsers)
		{
			OracleCommand sqlCommand=null;
			OracleDataReader sqlReader=null;
			string sql = "";
			string strOracleProfileNull = "";
			if(OracleProfile == null)
				strOracleProfileNull = " is null ";
			else
				strOracleProfileNull = " = '" + OracleProfile + "'";
			if(!bAllUsers) //Etude de profil sur l'ensemble des utilisateurs affectés au profil MOU
				sql = "select distinct f.username,f.user_,f.profile,f.profile_oracle,f.color from " + 
					"( " + 
					//-- Vert ( Affecté - Pas autre profile possible )
					"select du.username,u.user_, du.profile,p.profile_oracle,'vert' as color from dba_users du,mou01.affectation a, mou01.profile p, mou01.user_ u " + 
					"where p.id_profile= " + IdProfile + 
					" and p.id_profile=a.id_profile " + 
					"and u.id_user_=a.id_user_ " + 
					"and u.user_oracle=du.username " + 
					"and du.profile=nvl(p.profile_oracle,'DEFAULT') " + 
					"and du.username not in " + 
					"(select u1.user_oracle from mou01.user_ u1,mou01.affectation a1, mou01.profile p1 " + 
					"where p1.profile_oracle <> 'DEFAULT' " + 
					"and p1.profile_oracle is not null " + 
					"and p1.profile_oracle<> '" + OracleProfile + "' " + 
					"and a1.id_profile=p1.id_profile " + 
					"and u1.id_user_=a1.id_user_ " + 
					") " + 
					"union " + 
					//-- Jaune ( Affecté - Autre profile possible )
					"select du.username,u.user_, du.profile,p.profile_oracle,'jaune' as color " + 
					"from dba_users du,mou01.affectation a, mou01.profile p, mou01.user_ u " + 
					"where p.id_profile = " + IdProfile + 
					" and p.id_profile=a.id_profile " + 
					"and u.id_user_=a.id_user_ " + 
					"and u.user_oracle=du.username " + 
					"and du.profile=nvl(p.profile_oracle,'DEFAULT') " + 
					"and du.username in " + 
					"(select u1.user_oracle from mou01.user_ u1,mou01.affectation a1, mou01.profile p1 " + 
					"where p1.profile_oracle <> 'DEFAULT' " + 
					"and p1.profile_oracle is not null " + 
					"and p1.profile_oracle <> '" + OracleProfile + "' " + 
					"and a1.id_profile=p1.id_profile " + 
					"and u1.id_user_=a1.id_user_ " + 
					") " + 
					"union " + 
					//-- Orange ( Pas affecté - Pas autre profile possible )
					"select du.username,u.user_, du.profile,p.profile_oracle,'orange' as color from dba_users du,mou01.affectation a, mou01.profile p, mou01.user_ u " + 
					"where p.id_profile= " + IdProfile + 
					" and p.id_profile=a.id_profile " + 
					"and u.id_user_=a.id_user_ " + 
					"and u.user_oracle=du.username " + 
					"and du.profile<>nvl(p.profile_oracle,'DEFAULT') " + 
					"and du.username not in " + 
					"(select u1.user_oracle from mou01.user_ u1,mou01.affectation a1, mou01.profile p1 " + 
					"where p1.profile_oracle <> 'DEFAULT' " + 
					"and p1.profile_oracle is not null " + 
					"and p1.profile_oracle<> '" + OracleProfile + "' " + 
					"and a1.id_profile=p1.id_profile " + 
					"and u1.id_user_=a1.id_user_ " + 
					") " + 
					"union " + 
					//-- Rouge ( Pas affecté - Autre profile possible )
					"select du.username,u.user_, du.profile,p.profile_oracle,'rouge' as color from dba_users du,mou01.affectation a, mou01.profile p, mou01.user_ u " + 
					"where p.id_profile= " + IdProfile + 
					" and p.id_profile=a.id_profile " + 
					"and u.id_user_=a.id_user_ " + 
					"and u.user_oracle=du.username " + 
					"and du.profile<>nvl(p.profile_oracle,'DEFAULT') " + 
					"and du.username in " + 
					"(select u1.user_oracle from mou01.user_ u1,mou01.affectation a1, mou01.profile p1 " + 
					"where p1.profile_oracle <> 'DEFAULT' " + 
					"and p1.profile_oracle is not null " + 
					"and p1.profile_oracle <> '" + OracleProfile + "' " + 
					"and a1.id_profile=p1.id_profile " + 
					"and u1.id_user_=a1.id_user_ " + 
					") " + 
					") f " + 
					"order by f.username";
			else //Etude de profil sur l'ensemble des utilisateurs affectés au profil ORACLE
				sql = "select distinct f.username,f.user_,f.profile,f.profile_oracle,f.color from " + 
					"( " + 
					//-- Vert ( Affecté - Pas autre profile possible )
					"select du.username,u.user_, du.profile,p.profile_oracle,'vert' as color from dba_users du,mou01.affectation a, mou01.profile p, mou01.user_ u " + 
					"where p.id_profile=a.id_profile " + 
					"and u.id_user_=a.id_user_ " + 
					"and u.user_oracle=du.username " + 
					"and du.profile=nvl(p.profile_oracle,'DEFAULT') " + 
					"and du.username not in " + 
					"(select u1.user_oracle from mou01.user_ u1,mou01.affectation a1, mou01.profile p1 " + 
					"where p1.profile_oracle <> 'DEFAULT' " + 
					"and p1.profile_oracle is not null " + 
					"and p1.profile_oracle<> '" + OracleProfile + "' " + 
					"and a1.id_profile=p1.id_profile " + 
					"and u1.id_user_=a1.id_user_ " + 
					") " + 
					"and p.profile_oracle " + strOracleProfileNull + 
					"union " + 
					//-- Jaune ( Affecté - Autre profile possible )
					"select du.username,u.user_, du.profile,p.profile_oracle,'jaune' as color from dba_users du,mou01.affectation a, mou01.profile p, mou01.user_ u " + 
					"where p.id_profile=a.id_profile " + 
					"and u.id_user_=a.id_user_ " + 
					"and u.user_oracle=du.username " + 
					"and du.profile=nvl(p.profile_oracle,'DEFAULT') " + 
					"and du.username in " + 
					"(select u1.user_oracle from mou01.user_ u1,mou01.affectation a1, mou01.profile p1 " + 
					"where p1.profile_oracle <> 'DEFAULT' " + 
					"and p1.profile_oracle is not null " + 
					"and p1.profile_oracle <> '" + OracleProfile + "' " + 
					"and a1.id_profile=p1.id_profile " + 
					"and u1.id_user_=a1.id_user_ " + 
					") " + 
					"and p.profile_oracle " + strOracleProfileNull + 
					"union " + 
					//-- Orange ( Pas affecté - Pas autre profile possible )
					"select du.username,u.user_, du.profile,p.profile_oracle,'orange' as color from dba_users du,mou01.affectation a, mou01.profile p, mou01.user_ u " + 
					"where p.id_profile=a.id_profile " + 
					"and u.id_user_=a.id_user_ " + 
					"and u.user_oracle=du.username " + 
					"and du.profile<>nvl(p.profile_oracle,'DEFAULT') " + 
					"and du.username not in " + 
					"(select u1.user_oracle from mou01.user_ u1,mou01.affectation a1, mou01.profile p1 " + 
					"where p1.profile_oracle <> 'DEFAULT' " + 
					"and p1.profile_oracle is not null " + 
					"and p1.profile_oracle<> '" + OracleProfile + "' " + 
					"and a1.id_profile=p1.id_profile " + 
					"and u1.id_user_=a1.id_user_ " + 
					") " + 
					"and p.profile_oracle " + strOracleProfileNull + 
					"union " + 
					//-- Rouge ( Pas affecté - Autre profile possible )
					"select du.username,u.user_, du.profile,p.profile_oracle,'rouge' as color from dba_users du,mou01.affectation a, mou01.profile p, mou01.user_ u " + 
					"where p.id_profile=a.id_profile " + 
					"and u.id_user_=a.id_user_ " + 
					"and u.user_oracle=du.username " + 
					"and du.profile<>nvl(p.profile_oracle,'DEFAULT') " + 
					"and du.username in " + 
					"(select u1.user_oracle from mou01.user_ u1,mou01.affectation a1, mou01.profile p1 " + 
					"where p1.profile_oracle <> 'DEFAULT' " + 
					"and p1.profile_oracle is not null " + 
					"and p1.profile_oracle <> '" + OracleProfile + "' " + 
					"and a1.id_profile=p1.id_profile " + 
					"and u1.id_user_=a1.id_user_ " + 
					") " + 
					"and p.profile_oracle " + strOracleProfileNull + 
					") f " + 
					"order by f.username";

			bool bResult = false;

			try
			{
				sqlCommand=new OracleCommand(sql,connection);
				sqlReader=sqlCommand.ExecuteReader();
				//lecture des données
				while (sqlReader.Read())
				{
					OracleProfile newOracleProfile = new OracleProfile();
					newOracleProfile.UserOracle = sqlReader.GetValue(0).ToString();
					newOracleProfile.UserName = sqlReader.GetValue(1).ToString();
					newOracleProfile.OracleProfileAffected = sqlReader.GetValue(2).ToString();
					newOracleProfile.OracleProfileSel = sqlReader.GetValue(3).ToString();
					newOracleProfile.Color = sqlReader.GetValue(4).ToString();
					m_listOracleProfile.Add(newOracleProfile);
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

		public ArrayList ListOracleProfile
		{
			get
			{
				return m_listOracleProfile;
			}
		}
	}

	/// <summary>
	/// Description résumée de OracleProfile.
	/// </summary>
	public class OracleProfile
	{
		private string m_strUserOracle;
		private string m_strUserName;
		private string m_strOracleProfileAffected;
		private string m_strOracleProfile;
		private string m_strColor;
		
		#region Méthodes de la classe
		/// <summary>
		/// Affectation de l'utilisateur au profile Oracle
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="OracleProfile"></param>
		/// <returns></returns>
		public bool AffectUser(OracleConnection connection, string OracleProfile)
		{
			bool bResult = false;
			try
			{
				OracleCommand command= new OracleCommand();
				command.Connection = connection;
				string sql = "ALTER USER " + m_strUserOracle + " PROFILE " + OracleProfile;
				command.CommandText = sql;
				command.ExecuteNonQuery();
				bResult = true;
			}
			catch(Exception error)
			{
				MessageBox.Show("Problème lors de l'affectation de l'utilisateur au profile avec l'erreur : " + error.Message);
			}

			return bResult;
		}
		#endregion

		/// <summary>
		/// Obtient ou définit les membres de la classe OracleProfile
		/// </summary>
		#region

		/// <summary>
		/// Obtient ou définit "m_strUserOracle"
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
		/// Obtient ou définit "m_strUserName"
		/// </summary>
		public string UserName
		{
			get
			{
				return m_strUserName;
			}

			set
			{
				m_strUserName = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le champ m_strOracleProfileAffected
		/// </summary>
		public string OracleProfileAffected
		{
			get
			{
				return m_strOracleProfileAffected;
			}
			set
			{
				m_strOracleProfileAffected = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le champ 'm_strOracleProfile'
		/// </summary>
		public string OracleProfileSel
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
		/// Obtient ou définit le type de contrôle
		/// </summary>
		public string Color
		{
			get
			{
				return m_strColor;
			}
			set
			{
				m_strColor = value;
			}
		}
		#endregion
	}
}

