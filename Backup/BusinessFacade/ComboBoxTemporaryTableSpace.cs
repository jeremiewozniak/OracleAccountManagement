using System;
using System.Collections;

namespace AccountMgmt.BusinessFacade
{
	/// <summary>
	/// Description résumée de ComboBoxTemporaryTableSpace.
	/// </summary>
	public class ComboBoxTemporaryTableSpace
	{
		private ArrayList m_listTemporaryTableSpace;

		public ComboBoxTemporaryTableSpace()
		{
			m_listTemporaryTableSpace = null;
		}

		public void Dispose()
		{
			if(m_listTemporaryTableSpace != null)
				m_listTemporaryTableSpace.Clear();
		}

		public ArrayList ListTemporaryTableSpace
		{
			get
			{
				return m_listTemporaryTableSpace;
			}
			set
			{
				m_listTemporaryTableSpace = value;
			}
		}
	}
}
