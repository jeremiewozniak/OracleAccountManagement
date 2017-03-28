using System;

namespace AccountMgmt.BusinessFacade
{
	/// <summary>
	/// Description résumée de TreeNodeArchi.
	/// </summary>
	public class TreeNodeArchi
	{
		private int m_selNode;
		private int m_selList;

		public TreeNodeArchi()
		{
			m_selNode = 0;
			m_selList = -1;
		}

		public int SelNode
		{
			get
			{
				return m_selNode;
			}
			set
			{
				m_selNode = value;
			}
		}

		public int SelList
		{
			get
			{
				return m_selList;
			}
			set
			{
				m_selList = value;
			}
		}
	}
}
