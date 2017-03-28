using System;
using System.Collections;

namespace AccountMgmt.BusinessFacade
{
	/// <summary>
	/// Description résumée de ComboBoxDefaultProfiles.
	/// </summary>
	public class ComboBoxDefaultProfiles
	{
		private ArrayList m_listDefaultProfiles;
		private ArrayList m_listDefaultTablespace;

		public ComboBoxDefaultProfiles()
		{
			m_listDefaultProfiles = null;
			m_listDefaultTablespace = null;
		}

		public void Dispose()
		{
			if(m_listDefaultProfiles != null)
				m_listDefaultProfiles.Clear();
			if(m_listDefaultTablespace != null)
				m_listDefaultTablespace.Clear();
		}

		public ArrayList ListDefaultProfiles
		{
			get
			{
				return m_listDefaultProfiles;
			}
			set
			{
				m_listDefaultProfiles = value;
			}
		}

		public ArrayList ListDefaultTablespace
		{
			get
			{
				return m_listDefaultTablespace;
			}
			set
			{
				m_listDefaultTablespace = value;
			}
		}
	}
}
