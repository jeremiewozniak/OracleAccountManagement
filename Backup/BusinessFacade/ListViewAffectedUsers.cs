using System;
using System.Collections;

namespace AccountMgmt.BusinessFacade
{
	/// <summary>
	/// Description résumée de ListViewAffectedUsers.
	/// </summary>
	public class ListViewAffectedUsers
	{
		private ArrayList m_listAffectedUsers;

		public ListViewAffectedUsers()
		{
			m_listAffectedUsers = null;
		}

		public void Dispose()
		{
			if(m_listAffectedUsers != null)
				m_listAffectedUsers.Clear();
		}

		public ArrayList ListAffectedUsers
		{
			get
			{
				return m_listAffectedUsers;
			}
			set
			{
				m_listAffectedUsers = value;
			}
		}
	}
}
