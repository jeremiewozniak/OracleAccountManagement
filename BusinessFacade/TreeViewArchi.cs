using System;
using System.Collections;

namespace AccountMgmt.BusinessFacade
{
	/// <summary>
	/// Description résumée de TreeViewArchi.
	/// </summary>
	public class TreeViewArchi
	{
		private ArrayList m_listProjectsArchi;
		private ArrayList m_listApplicationsArchi;
		private ArrayList m_listModulesArchi;
		private ArrayList m_listProfilesArchi;
		private ArrayList m_listRolesArchi;

		public TreeViewArchi()
		{
			m_listProjectsArchi = null;
			m_listProjectsArchi = new ArrayList();
			m_listApplicationsArchi = null;
			m_listApplicationsArchi = new ArrayList();
			m_listModulesArchi = null;
			m_listModulesArchi = new ArrayList();
			m_listProfilesArchi = null;
			m_listProfilesArchi = new ArrayList();
			m_listRolesArchi = null;
			m_listRolesArchi = new ArrayList();
		}

		public void Dispose()
		{
			if(m_listProjectsArchi != null)
				m_listProjectsArchi.Clear();
			if(m_listApplicationsArchi != null)
				m_listApplicationsArchi.Clear();
			if(m_listModulesArchi != null)
				m_listModulesArchi.Clear();
			if(m_listProfilesArchi != null)
				m_listProfilesArchi.Clear();
			if(m_listRolesArchi != null)
				m_listRolesArchi.Clear();
		}

		public ArrayList ListProjects
		{
			get
			{
				return m_listProjectsArchi;
			}
			set
			{
				m_listProjectsArchi = value;
			}
		}

		public ArrayList ListApplication
		{
			get
			{
				return m_listApplicationsArchi;
			}
			set
			{
				m_listApplicationsArchi = value;
			}
		}

		public ArrayList ListModules
		{
			get
			{
				return m_listModulesArchi;
			}
			set
			{
				m_listModulesArchi = value;
			}
		}

		public ArrayList ListProfiles
		{
			get
			{
				return m_listProfilesArchi;
			}
			set
			{
				m_listProfilesArchi = value;
			}
		}

		public ArrayList ListRoles
		{
			get
			{
				return m_listRolesArchi;
			}
			set
			{
				m_listRolesArchi = value;
			}
		}
	}

}
