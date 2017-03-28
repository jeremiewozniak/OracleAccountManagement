using System;
using System.Windows.Forms;
using System.Collections;
using Oracle.DataAccess.Client;

namespace AccountMgmt.DataAccess
{
	public class AccessTemporaryTableSpace
	{
		private ArrayList m_listAccessTemporaryTableSpace = null;

		public AccessTemporaryTableSpace()
		{
			m_listAccessTemporaryTableSpace = new ArrayList();
		}

		/// <summary>
		/// Nettoyage des ressources utilis�es.
		/// </summary>
		public void Dispose()
		{
			if(m_listAccessTemporaryTableSpace.Count != 0)
				m_listAccessTemporaryTableSpace.Clear();
		}

		public bool Select(OracleConnection connection)
		{
			Dispose();

			bool bResult = false;
			// Start a local transaction
			OracleCommand command= new OracleCommand();
			command.Connection = connection;
			string sql = "";
			OracleDataReader sqlReader=null;
			
			
			try
			{
				//r�cup�re la tablespace disponible avec le nombre d'utilisateur min
				sql = "SELECT id_temporary_tablespace, temporary_tablespace FROM MOU01.temporary_tablespace WHERE (max_user-user_count)=(select min(max_user-user_count) from MOU01.temporary_tablespace where (max_user-user_count) > 0)";
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				//lecture des donn�es
				while (sqlReader.Read())
				{
					TemporaryTableSpace newTemporaryTableSpace= new TemporaryTableSpace();
					newTemporaryTableSpace.Id = sqlReader.GetInt64(0);
					newTemporaryTableSpace.Name = sqlReader.GetString(1);
					m_listAccessTemporaryTableSpace.Add(newTemporaryTableSpace);
				}
				bResult = true;
			}
			catch(Exception error)
			{
				MessageBox.Show("Probl�me lors de la recherche des tables temporaires disponibles avec l'erreur : " + error.Message);
			}
			finally
			{
				//deconnexion
				try
				{
					// Fermeture de la base de donn�es
					if (sqlReader!=null)
					{
						sqlReader.Close();
						sqlReader.Dispose();
					}
					if(command!=null)
						command.Dispose();
				}
				catch(Exception error)
				{
					MessageBox.Show("Message d�erreur : "+error.Message);
				}
			}

			return bResult;
		}

		/// <summary>
		/// Obtient ou d�finit la liste des tables temporaires disponibles
		/// </summary>
		public ArrayList TemporaryTableSpaceList
		{
			get
			{
				return m_listAccessTemporaryTableSpace;
			}
			set
			{
				m_listAccessTemporaryTableSpace = value;
			}
		}
	}

	/// <summary>
	/// Description r�sum�e de TemporaryTableSpace.
	/// </summary>
	public class TemporaryTableSpace
	{
		private long m_lIdTemporaryTableSpace;
		private string m_strTemporaryTableSpace;

		/// <summary>
		/// Obtient ou d�finit l'identificateur de la table temporaire
		/// </summary>
		public long Id
		{
			get
			{
				return m_lIdTemporaryTableSpace;
			}
			set
			{
				m_lIdTemporaryTableSpace = value;
			}
		}

		/// <summary>
		/// Obtient ou d�finit le nom de la table temporaire
		/// </summary>
		public string Name
		{
			get
			{
				return m_strTemporaryTableSpace;
			}
			set
			{
				m_strTemporaryTableSpace = value;
			}
		}
	}
}
