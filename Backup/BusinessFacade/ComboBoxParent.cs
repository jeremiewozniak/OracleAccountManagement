using System;
using System.Collections;

namespace AccountMgmt.BusinessFacade
{
	/// <summary>
	/// Description résumée de ComboBoxParent.
	/// </summary>
	public class ComboBoxParent
	{
		private ArrayList m_listParent;

		public ComboBoxParent()
		{
			m_listParent = new ArrayList();
		}

		public void Dispose()
		{
			if(m_listParent != null)
				m_listParent.Clear();
		}

		public ArrayList ListParent
		{
			get
			{
				return m_listParent;
			}
			set
			{
				m_listParent = value;
			}
		}
	}
}
