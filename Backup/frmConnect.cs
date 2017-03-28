using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace AccountMgmt
{
	/// <summary>
	/// Description résumée de frmConnect.
	/// </summary>
	public class frmConnect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxLogin;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxServer;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.Button buttonUndo;
		private System.Windows.Forms.TextBox textBoxPassword;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private AccountMgmt.DataAccess.ConnectedUser m_connectedUser = null;
		
		public frmConnect(string strEnvironementOracle)
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
			m_connectedUser = new AccountMgmt.DataAccess.ConnectedUser();
			
			//recherche les serveurs oracle dispos
			IDictionary environmentVariables = Environment.GetEnvironmentVariables();
			System.Collections.IDictionaryEnumerator myEnumerator = environmentVariables.GetEnumerator();
			
			while ( myEnumerator.MoveNext() )
			{
				string strServer = "", strPath = "";
				string strEspace = " ";
				if((string)(myEnumerator.Key) == "Path")
				{
					string[] strEnvironmentVars = ((string)(myEnumerator.Value)).Split(';');
					foreach(string strEnvironmentVar in strEnvironmentVars)
					{
						if(strEnvironmentVar.ToUpper().Equals(/*@"C:\ORACLE\ORA92\BIN"*/strEnvironementOracle.ToUpper() + @"\BIN"))
						{
							//strPath = strEnvironmentVar.Remove(strEnvironmentVar.Length - 3, 3);
							strPath = strEnvironementOracle + @"\network\Admin\Tnsnames.ora";
							System.IO.StreamReader sr;
							if(System.IO.File.Exists(strPath))
							{
								sr = System.IO.File.OpenText(strPath);
								strServer = sr.ReadLine();
								while(sr.Peek() >= 0)
								{
										if(strServer.Length > 1)
										{
											if(strServer.Substring(1, 1).CompareTo(strEspace) != 0)
												comboBoxServer.Items.Add(strServer.Split(' ')[0]);
										}
										strServer = sr.ReadLine();
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxServer = new System.Windows.Forms.ComboBox();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.buttonUndo = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Login";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.BackColor = System.Drawing.Color.White;
			this.textBoxLogin.Location = new System.Drawing.Point(80, 16);
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(192, 20);
			this.textBoxLogin.TabIndex = 1;
			this.textBoxLogin.Text = "";
			this.textBoxLogin.Leave += new System.EventHandler(this.OnLeaveLogin);
			this.textBoxLogin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUpLogin);
			this.textBoxLogin.Enter += new System.EventHandler(this.OnEnterLogin);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(80, 56);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(192, 20);
			this.textBoxPassword.TabIndex = 3;
			this.textBoxPassword.Text = "";
			this.textBoxPassword.Leave += new System.EventHandler(this.OnLeavePassword);
			this.textBoxPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUpPassword);
			this.textBoxPassword.Enter += new System.EventHandler(this.OnEnterPassword);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Server";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxServer
			// 
			this.comboBoxServer.Location = new System.Drawing.Point(80, 96);
			this.comboBoxServer.Name = "comboBoxServer";
			this.comboBoxServer.Size = new System.Drawing.Size(192, 21);
			this.comboBoxServer.TabIndex = 5;
			this.comboBoxServer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUpServer);
			this.comboBoxServer.Leave += new System.EventHandler(this.OnLeaveServer);
			this.comboBoxServer.Enter += new System.EventHandler(this.OnEnterServer);
			// 
			// buttonConnect
			// 
			this.buttonConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonConnect.Location = new System.Drawing.Point(38, 152);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(72, 24);
			this.buttonConnect.TabIndex = 6;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.Click += new System.EventHandler(this.OnClickConnect);
			// 
			// buttonUndo
			// 
			this.buttonUndo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonUndo.Location = new System.Drawing.Point(182, 152);
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.Size = new System.Drawing.Size(72, 24);
			this.buttonUndo.TabIndex = 7;
			this.buttonUndo.Text = "Undo";
			this.buttonUndo.Click += new System.EventHandler(this.OnClickUndo);
			// 
			// frmConnect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 190);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.buttonUndo);
			this.Controls.Add(this.buttonConnect);
			this.Controls.Add(this.comboBoxServer);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmConnect";
			this.Text = "Connection";
			this.Load += new System.EventHandler(this.frmConnect_Load);
			this.ResumeLayout(false);

		}
		#endregion


		private void OnEnterLogin(object sender, System.EventArgs e)
		{
			textBoxLogin.BackColor = System.Drawing.Color.LightYellow;
		}

		private void OnLeaveLogin(object sender, System.EventArgs e)
		{
			textBoxLogin.BackColor = System.Drawing.Color.White;
		}

		private void OnEnterPassword(object sender, System.EventArgs e)
		{
			textBoxPassword.BackColor = System.Drawing.Color.LightYellow;
		}

		private void OnLeavePassword(object sender, System.EventArgs e)
		{
			textBoxPassword.BackColor = System.Drawing.Color.White;
		}

		private void OnEnterServer(object sender, System.EventArgs e)
		{
			comboBoxServer.BackColor = System.Drawing.Color.LightYellow;
		}

		private void OnLeaveServer(object sender, System.EventArgs e)
		{
			comboBoxServer.BackColor = System.Drawing.Color.White;
		}

		/// <summary>
		/// Permet de se connecter à la base de données souhaitée en sélectionnant son login, password et server
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickConnect(object sender, System.EventArgs e)
		{
			//tests parametres de connection
			if(textBoxLogin.ToString() == "")
			{
				MessageBox.Show("Could you check your login, please.");
				return;
			}
			if(comboBoxServer.SelectedIndex < 0)
			{
				MessageBox.Show("Could you check your server, please.");
				return;
			}

			//frmConnect.ActiveForm.Text = "Load connexion...";
			Text= "Load connexion...";
			Cursor.Current = Cursors.WaitCursor;
			
			//connection à la base de données
			m_connectedUser.Login = this.textBoxLogin.Text;
			m_connectedUser.Password = this.textBoxPassword.Text;
			m_connectedUser.Server = (string)comboBoxServer.Items[comboBoxServer.SelectedIndex];
			if(m_connectedUser.DataBasisConnection())
				this.Close();
			Cursor.Current = Cursors.Default;
		}

		private void OnClickUndo(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmConnect_Load(object sender, System.EventArgs e)
		{
		
		}

		private void OnKeyUpLogin(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue == 13)
			{
				OnClickConnect(sender, e);
				this.DialogResult = DialogResult.OK;
			}
		}

		private void OnKeyUpPassword(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue == 13)
			{
				OnClickConnect(sender, e);
				this.DialogResult = DialogResult.OK;
			}
		}

		private void OnKeyUpServer(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue == 13)
			{
				OnClickConnect(sender, e);
				this.DialogResult = DialogResult.OK;
			}
		}

		public AccountMgmt.DataAccess.ConnectedUser ConnectedUser
		{
			get
			{
				return m_connectedUser;
			}
		}
	}
}
