using System;
using System.Collections;

namespace AccountMgmt.BusinessFacade
{
	/// <summary>
	/// Description résumée de ListViewOracleProfile.
	/// </summary>
	public class ListViewOracleProfile
	{
		private ArrayList m_listOracleProfile;

		public ListViewOracleProfile()
		{
			m_listOracleProfile = null;
		}

		public void Dispose()
		{
			if(m_listOracleProfile != null)
				m_listOracleProfile.Clear();
		}

		public ArrayList ListOracleProfile
		{
			get
			{
				return m_listOracleProfile;
			}
			set
			{
				m_listOracleProfile = value;
			}
		}
	}
}
