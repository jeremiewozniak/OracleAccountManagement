using System;
using System.Collections;

namespace AccountMgmt.BusinessFacade
{
	/// <summary>
	/// Description résumée de ListViewAllUsers.
	/// </summary>
	public class ListViewAllUsers
	{
		private ArrayList m_listUsers;

		public ListViewAllUsers()
		{
			m_listUsers = null;
		}

		public void Dispose()
		{
			if(m_listUsers != null)
				m_listUsers.Clear();
		}

		public ArrayList ListUsers
		{
			get
			{
				return m_listUsers;
			}
			set
			{
				m_listUsers = value;
			}
		}
	}
}
