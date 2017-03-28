using System;
using System.Collections;

namespace AccountMgmt.BusinessFacade
{
	/// <summary>
	/// Description résumée de ListViewRoles.
	/// </summary>
	public class ListViewRoles
	{
		private ArrayList m_listRoles;

		public ListViewRoles()
		{
			m_listRoles = null;
		}

		public void Dispose()
		{
			if(m_listRoles != null)
				m_listRoles.Clear();
		}

		public ArrayList ListRoles
		{
			get
			{
				return m_listRoles;
			}
			set
			{
				m_listRoles = value;
			}
		}
	}
}
