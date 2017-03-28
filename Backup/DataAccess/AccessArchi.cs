using System;
using System.Collections;
using Oracle.DataAccess.Client;
using System.Windows.Forms;

namespace AccountMgmt.DataAccess
{
	/// <summary>
	/// Accès à la structure des comptes
	/// </summary>
	public class AccessArchi
	{
		private ArrayList m_listProject = null;
		private ArrayList m_listApplication = null;
		private ArrayList m_listModule = null;
		private ArrayList m_listProfile = null;
		private ArrayList m_listRole = null;

		public AccessArchi()
		{
			NewArrayList();
		}

		private void NewArrayList()
		{
			m_listProject = new ArrayList();
			m_listApplication = new ArrayList();
			m_listModule = new ArrayList();
			m_listProfile = new ArrayList();
			m_listRole = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		public void Dispose()
		{
			DeleteArrayList();
		}

		private void DeleteArrayList()
		{
			if(m_listProject.Count != 0)
				m_listProject.Clear();
			if(m_listApplication.Count != 0)
				m_listApplication.Clear();
			if(m_listModule.Count != 0)
				m_listModule.Clear();
			if(m_listProfile.Count != 0)
				m_listProfile.Clear();
			if(m_listRole.Count != 0)
				m_listRole.Clear();
		}

		/// <summary>
		/// Permet de récupérer l'arborescence qui permet la gestion des comptes utilisateur
		/// </summary>
		/// <param name="userConnected">Utilisateur connecté</param>
		/// <returns>Permet de savoir si l'accès aux données s'est bien passé</returns>
		public bool SelectArchi(AccountMgmt.DataAccess.ConnectedUser userConnected)
		{
			//delete les tableaux
			DeleteArrayList();
			NewArrayList();

			bool bResult = false;
			if(userConnected.UserConnected == null || userConnected.UserConnected.Admin == AccountMgmt.Common.Constants.AdminLevel)
				bResult = SelectArchiDBA(userConnected);
			else
				bResult = SelectArchiConnectedUser(userConnected);
			
			return bResult;
		}

		/// <summary>
		/// Recherche les informations sur les comptes en mode DBA
		/// </summary>
		/// <param name="userConnected"></param>
		/// <returns></returns>
		private bool SelectArchiDBA(AccountMgmt.DataAccess.ConnectedUser userConnected)
		{
			//project
			AccessProject listProject = new AccessProject();
			if(!listProject.Select(userConnected.Connection, "", "project"))
				return false;
			m_listProject = ((ArrayList)listProject.ListProject.Clone());

			//application
			for(int numProject=0; numProject<listProject.ListProject.Count; numProject++)
			{
				AccessApplication listApplication = new AccessApplication();
				if(!listApplication.Select(userConnected.Connection, "id_project=" + ((Project)listProject.ListProject[numProject]).Id.ToString("0"), "application"))
					return false;
				
				//module
				for(int numApp=0; numApp<listApplication.ListApplication.Count; numApp++)
				{
					AccessModule listModule = new AccessModule();
					if(!listModule.Select(userConnected.Connection, "id_application=" + ((Application)listApplication.ListApplication[numApp]).Id.ToString("0"), "module"))
						return false;

					//profile
					for(int numModule=0; numModule<listModule.ListModule.Count; numModule++)
					{
						AccessProfile listProfile = new AccessProfile();
						if(!listProfile.Select(userConnected.Connection, "id_module=" + ((Module)listModule.ListModule[numModule]).Id.ToString("0"), "profile"))
							return false;

						//role
						for(int numProfile=0; numProfile<listProfile.ListProfile.Count; numProfile++)
						{
							AccessRole listRole = new AccessRole();
							if(!listRole.SelectRight(userConnected.Connection, "ro.id_role = ri.id_role AND ri.id_profile=" + ((Profile)listProfile.ListProfile[numProfile]).Id.ToString("0"), "role"))
								return false;
							m_listRole .AddRange((ArrayList)listRole.ListRole.Clone());
							listRole.Dispose();
						}
						m_listProfile.AddRange((ArrayList)listProfile.ListProfile.Clone());
						listProfile.Dispose();
					}
					m_listModule.AddRange((ArrayList)listModule.ListModule.Clone());
					listModule.Dispose();
				}
				m_listApplication.AddRange((ArrayList)listApplication.ListApplication.Clone());
				listApplication.Dispose();
			}

			return true;
		}


		/// <summary>
		/// Recherche les informations sur les comptes en mode droits restreints
		/// </summary>
		/// <param name="userConnected"></param>
		/// <returns></returns>
		private bool SelectArchiConnectedUser(AccountMgmt.DataAccess.ConnectedUser userConnected)
		{
			OracleCommand sqlCommand=null;
			OracleDataReader sqlReader=null;
			string sql = "SELECT proj.id_project,proj.project, proj.date_creation, proj.date_modification, proj.commentary, proj.activation, " + 
						" app.id_application, app.application, app.id_project, app.default_tablespace, app.date_creation, app.date_modification, app.commentary, app.activation, " + 
						" mod.id_module, mod.module, mod.id_application, mod.date_creation, mod.date_modification, mod.commentary, mod.activation, " + 
						//" prof.id_profile, prof.profile, prof.id_module, prof.date_creation, prof.date_modification, prof.commentary, prof.activation, prof.Profile_oracle, Rsrc_conso_group " +
						" prof.id_profile, prof.profile, prof.id_module, prof.date_creation, prof.date_modification, prof.commentary, prof.activation, prof.Profile_oracle " +
                        "FROM MOU01.module mod, MOU01.profile prof, MOU01.affectation aff, MOU01.application app, MOU01.project proj " +
                         "WHERE aff.id_user_ = " + userConnected.UserConnected.Id.ToString("0") +
                         "  AND aff.activation < " + AccountMgmt.Common.Constants.DesactivationLevel.ToString("0") + 
                         "  AND aff.admin>=" + AccountMgmt.Common.Constants.AdminLevel.ToString("0") +
                         "  AND aff.id_profile = prof.id_profile " +
                         "  AND prof.activation < " + AccountMgmt.Common.Constants.DesactivationLevel.ToString("0") + 
                         "  AND prof.id_module = mod.id_module " +
                         "  AND mod.activation < " + AccountMgmt.Common.Constants.DesactivationLevel.ToString("0") + 
                         "  AND app.id_application = mod.id_application " +
                         "  AND app.activation < " + AccountMgmt.Common.Constants.DesactivationLevel.ToString("0") + 
                         "  AND app.id_project = proj.id_project " +
                         "  AND proj.activation < " + AccountMgmt.Common.Constants.DesactivationLevel.ToString("0") + 
                         " ORDER BY proj.project, app.application, mod.module, prof.profile";
			bool bResult = false;

			try
			{
				sqlCommand=new OracleCommand(sql,userConnected.Connection);
				sqlReader=sqlCommand.ExecuteReader();
				long oldProject=-1, oldApplication=-1, oldModule=-1, oldProfile=-1;
				//lecture des données
				while (sqlReader.Read())
				{
					//recupère le projet
					if(oldProject != sqlReader.GetInt64(0))
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
						oldProject = sqlReader.GetInt64(0);
					}
					
					//recupère l'application
					if(oldApplication != sqlReader.GetInt64(6))
					{
						Application newApplication = new Application();
						newApplication.Id = sqlReader.GetInt64(6);
						newApplication.Name = sqlReader.GetString(7);
						newApplication.IdProject = sqlReader.GetInt64(8);
						newApplication.DateCreation = sqlReader.GetDateTime(10);
						if(!sqlReader.IsDBNull(11))
							newApplication.DateModification = sqlReader.GetDateTime(11);
						if(!sqlReader.IsDBNull(12))
							newApplication.Commentary = sqlReader.GetString(12);
						if(sqlReader.GetInt16(13) == AccountMgmt.Common.Constants.ActivationLevel)
							newApplication.Activation = true;
						else
							newApplication.Activation = false;
						m_listApplication.Add(newApplication);
						oldApplication = sqlReader.GetInt64(6);
					}
					
					//recupère le module
					if(oldModule != sqlReader.GetInt64(14))
					{
						Module newModule = new Module();
						newModule.Id = sqlReader.GetInt64(14);
						newModule.Name = sqlReader.GetString(15);
						newModule.IdApplication = sqlReader.GetInt64(16);
						newModule.DateCreation = sqlReader.GetDateTime(17);
						if(!sqlReader.IsDBNull(18))
							newModule.DateModification = sqlReader.GetDateTime(18);
						if(!sqlReader.IsDBNull(19))
							newModule.Commentary = sqlReader.GetString(19);
						if(sqlReader.GetInt16(20) == AccountMgmt.Common.Constants.ActivationLevel)
							newModule.Activation = true;
						else
							newModule.Activation = false;
						m_listModule.Add(newModule);
						oldModule = sqlReader.GetInt64(14);
					}
					
					//recupère le profile
					if(oldProfile != sqlReader.GetInt64(21))
					{
						Profile newProfile = new Profile();
						newProfile.Id = sqlReader.GetInt64(21);
						newProfile.Name = sqlReader.GetString(22);
						newProfile.IdModule = sqlReader.GetInt64(23);
						newProfile.DateCreation = sqlReader.GetDateTime(24);
						if(!sqlReader.IsDBNull(25))
							newProfile.DateModification = sqlReader.GetDateTime(25);
						if(!sqlReader.IsDBNull(26))
							newProfile.Commentary = sqlReader.GetString(26);
						if(sqlReader.GetInt16(27) == AccountMgmt.Common.Constants.ActivationLevel)
							newProfile.Activation = true;
						else
							newProfile.Activation = false;
						if(!sqlReader.IsDBNull(28))
							newProfile.OracleProfile = sqlReader.GetString(28);
						/*if(!sqlReader.IsDBNull(29))
							newProfile.RsrcConsoGroup = sqlReader.GetString(29);*/
						m_listProfile.Add(newProfile);
						oldProfile = sqlReader.GetInt64(21);

						//récupère les roles associés au profile
						AccessRole listRole = new AccessRole();
						if(!listRole.SelectRight(userConnected.Connection, "ro.id_role = ri.id_role AND ri.id_profile=" + newProfile.Id.ToString(), "role"))
							return false;
						m_listRole .AddRange((ArrayList)listRole.ListRole.Clone());
						listRole.Dispose();
					}
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
		/// Obtient la liste des projects relative à la requête effectuée
		/// </summary>
		public ArrayList ListProject
		{
			get
			{
				return m_listProject;
			}
		}

		/// <summary>
		/// Obtient la liste des applications relative à la requête effectuée
		/// </summary>
		public ArrayList ListApplication
		{
			get
			{
				return m_listApplication;
			}
		}

		/// <summary>
		/// Obtient la liste des modules relative à la requête effectuée
		/// </summary>
		public ArrayList ListModule
		{
			get
			{
				return m_listModule;
			}
		}

		/// <summary>
		/// Obtient la liste des profiles relative à la requête effectuée
		/// </summary>
		public ArrayList ListProfile
		{
			get
			{
				return m_listProfile;
			}
		}

		/// <summary>
		/// Obtient la liste des roles relative à la requête effectuée
		/// </summary>
		public ArrayList ListRole
		{
			get
			{
				return m_listRole;
			}
		}
	}
}
