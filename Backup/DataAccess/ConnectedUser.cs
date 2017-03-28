using System;
using Oracle.DataAccess.Client;
using System.Windows.Forms;

namespace AccountMgmt.DataAccess
{
	/// <summary>
	/// Connexion à la base données en fonction des paramètres de login, password et server
	/// </summary>
	public class ConnectedUser
	{
		private string m_strLogin;
		private string m_strPassword;
		private string m_strServer;
		private bool m_bConnected;
		private Oracle.DataAccess.Client.OracleConnection m_connection;
		private User m_connectedUser;

		public ConnectedUser()
		{
			m_bConnected = false;
		//	m_strLogin = "gestright";
		//	m_strPassword = "jetwrite";
		//	m_strServer = "PITATESTFR01";
			m_connectedUser = null;
		}

		/// <summary>
		/// Connexion à la base de données
		/// </summary>
		/// <returns></returns>
		public bool DataBasisConnection()
		{
			try
			{
				m_connection = new OracleConnection("data source="+m_strServer+";user id="+m_strLogin+";password="+m_strPassword + ";pooling=false");
				m_connection.Open();
			}
			catch(Exception error)
			{
				MessageBox.Show("Data basis connection error : " + error.Message);
				return false;
			}
			if(m_connection.State != System.Data.ConnectionState.Open)
			{
				MessageBox.Show("Data basis connection error." );
				return false;
			}

			//récupère info sur l'utilisateur connecté
			OracleCommand command= new OracleCommand();
			command.Connection = m_connection;
			OracleDataReader sqlReader=null;
			string sql = "SELECT id_user_ ,user_ ,user_oracle ,service,commentary,dba_status " +
				"FROM MOU01.my_user WHERE user_oracle='" + m_strLogin.ToUpper() + "'";
			try
			{
				command.CommandText = sql;
				sqlReader=command.ExecuteReader();
				if (sqlReader.Read())
				{
					m_connectedUser = new User();
					m_connectedUser.Id = sqlReader.GetInt64(0);
					m_connectedUser.Name = sqlReader.GetString(1);
					m_connectedUser.UserOracle = sqlReader.GetString(2);
					m_connectedUser.Service = sqlReader.GetString(3);
					if(!sqlReader.IsDBNull(4))
						m_connectedUser.Commentary = sqlReader.GetString(4);
					if(!sqlReader.IsDBNull(5))
						m_connectedUser.Admin = sqlReader.GetInt16(5);
					else
						m_connectedUser.Admin = AccountMgmt.Common.Constants.NoAdminLevel;
				}
				else
				{
					MessageBox.Show("L'utilisateur correspondant n'existe pas en base, veuillez en sélectionner un autre ou appeler le responsable base de données.");
					return false;
				}
			}
			catch(Exception error)
			{
				if(error.Message.StartsWith("ORA-00942"))
				{
					MessageBox.Show("Vous n'avez pas les droits suffisants pour lancer cette application. Si ce n'est pas normal, veuillez contacter le responsable base de données.",
                                    "Droits insuffisants", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return false;
				}
			}

			m_bConnected = true;
			return true;
		}

		public bool IsConnected
		{
			get
			{
				return m_bConnected;
			}
		}

		/// <summary>
		/// Déconnexion à la base de données
		/// </summary>
		public void DataBasisDisconnection()
		{
			m_connection.Close();
		}

		/// <summary>
		/// Obtient ou définit le login de l'utilisateur
		/// </summary>
		public string Login
		{
			get
			{
				return m_strLogin;
			}
			set
			{
				m_strLogin = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le mot de passe de l'utilisateur
		/// </summary>
		public string Password
		{
			get
			{
				return m_strPassword;
			}
			set
			{
				m_strPassword = value;
			}
		}

		/// <summary>
		/// Obtient ou définit le server utilisé pour se connecter à la base données
		/// </summary>
		public string Server
		{
			get
			{
				return m_strServer;
			}
			set
			{
				m_strServer = value;
			}
		}

		/// <summary>
		/// Obtient la connection
		/// </summary>
		public Oracle.DataAccess.Client.OracleConnection Connection
		{
			get
			{
				return m_connection;
			}
		}

		/// <summary>
		/// Obtient l'utilisateur connecté
		/// </summary>
		public User UserConnected
		{
			get
			{
				return m_connectedUser;
			}
		}
	}
}
