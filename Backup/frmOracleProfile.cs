using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

using AccountMgmt.BusinessFacade;

namespace AccountMgmt
{
	/// <summary>
	/// Description résumée de frmOracleProfile.
	/// </summary>
	public class frmOracleProfile : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listViewAffectedUsersWithProfile;
		private System.Windows.Forms.ColumnHeader columnHeaderUserOracle;
		private System.Windows.Forms.ColumnHeader columnHeaderUserName;
		private System.ComponentModel.IContainer components;
		private AccountMgmt.BusinessFacade.ListViewOracleProfile m_listOracleProfile = null;
		private OracleConnection m_connection = null;
		private string m_strOracleProfile = "";
		private System.Windows.Forms.RadioButton radioButtonUsersAffectedOracleProfile;
		private System.Windows.Forms.RadioButton radioButtonUsersAffectedMOUProfile;
		private System.Windows.Forms.Button buttonAllSel;
		private System.Windows.Forms.Button buttonAllDesel;
		private System.Windows.Forms.Button buttonValiser;
		private long m_lIdProfile = -1;
		private System.Windows.Forms.ColumnHeader columnHeaderOracleProfile;
		private System.Windows.Forms.ToolTip toolTipColor;
		private System.Windows.Forms.CheckBox checkBoxProfileOracleDefault;
		private AccountMgmt.DataAccess.AccessOracleProfile m_oracleProfile = null;
		
		public frmOracleProfile()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOracleProfile));
			this.listViewAffectedUsersWithProfile = new System.Windows.Forms.ListView();
			this.columnHeaderUserOracle = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderUserName = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderOracleProfile = new System.Windows.Forms.ColumnHeader();
			this.radioButtonUsersAffectedOracleProfile = new System.Windows.Forms.RadioButton();
			this.radioButtonUsersAffectedMOUProfile = new System.Windows.Forms.RadioButton();
			this.buttonAllSel = new System.Windows.Forms.Button();
			this.buttonAllDesel = new System.Windows.Forms.Button();
			this.buttonValiser = new System.Windows.Forms.Button();
			this.toolTipColor = new System.Windows.Forms.ToolTip(this.components);
			this.checkBoxProfileOracleDefault = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// listViewAffectedUsersWithProfile
			// 
			this.listViewAffectedUsersWithProfile.CheckBoxes = true;
			this.listViewAffectedUsersWithProfile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																											   this.columnHeaderUserOracle,
																											   this.columnHeaderUserName,
																											   this.columnHeaderOracleProfile});
			this.listViewAffectedUsersWithProfile.FullRowSelect = true;
			this.listViewAffectedUsersWithProfile.GridLines = true;
			this.listViewAffectedUsersWithProfile.Location = new System.Drawing.Point(8, 96);
			this.listViewAffectedUsersWithProfile.Name = "listViewAffectedUsersWithProfile";
			this.listViewAffectedUsersWithProfile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.listViewAffectedUsersWithProfile.Size = new System.Drawing.Size(384, 320);
			this.listViewAffectedUsersWithProfile.TabIndex = 0;
			this.listViewAffectedUsersWithProfile.View = System.Windows.Forms.View.Details;
			this.listViewAffectedUsersWithProfile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMoveColor);
			// 
			// columnHeaderUserOracle
			// 
			this.columnHeaderUserOracle.Text = "User Oracle";
			this.columnHeaderUserOracle.Width = 100;
			// 
			// columnHeaderUserName
			// 
			this.columnHeaderUserName.Text = "User Name";
			this.columnHeaderUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeaderUserName.Width = 180;
			// 
			// columnHeaderOracleProfile
			// 
			this.columnHeaderOracleProfile.Text = "ORACLE Profile";
			this.columnHeaderOracleProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeaderOracleProfile.Width = 100;
			// 
			// radioButtonUsersAffectedOracleProfile
			// 
			this.radioButtonUsersAffectedOracleProfile.Location = new System.Drawing.Point(8, 40);
			this.radioButtonUsersAffectedOracleProfile.Name = "radioButtonUsersAffectedOracleProfile";
			this.radioButtonUsersAffectedOracleProfile.Size = new System.Drawing.Size(368, 24);
			this.radioButtonUsersAffectedOracleProfile.TabIndex = 1;
			this.radioButtonUsersAffectedOracleProfile.Text = "Affected users with ORACLE Profile in any MOU Profile";
			this.radioButtonUsersAffectedOracleProfile.Click += new System.EventHandler(this.OnClickUsersAffectedOracleProfile);
			// 
			// radioButtonUsersAffectedMOUProfile
			// 
			this.radioButtonUsersAffectedMOUProfile.Checked = true;
			this.radioButtonUsersAffectedMOUProfile.Location = new System.Drawing.Point(8, 8);
			this.radioButtonUsersAffectedMOUProfile.Name = "radioButtonUsersAffectedMOUProfile";
			this.radioButtonUsersAffectedMOUProfile.Size = new System.Drawing.Size(240, 24);
			this.radioButtonUsersAffectedMOUProfile.TabIndex = 2;
			this.radioButtonUsersAffectedMOUProfile.TabStop = true;
			this.radioButtonUsersAffectedMOUProfile.Text = "Affected users with MOU Profile";
			this.radioButtonUsersAffectedMOUProfile.Click += new System.EventHandler(this.OnClickUsersAffectedMOUProfile);
			// 
			// buttonAllSel
			// 
			this.buttonAllSel.Location = new System.Drawing.Point(8, 72);
			this.buttonAllSel.Name = "buttonAllSel";
			this.buttonAllSel.Size = new System.Drawing.Size(128, 23);
			this.buttonAllSel.TabIndex = 3;
			this.buttonAllSel.Text = "All to select";
			this.buttonAllSel.Click += new System.EventHandler(this.OnClickAllSelect);
			// 
			// buttonAllDesel
			// 
			this.buttonAllDesel.Location = new System.Drawing.Point(264, 72);
			this.buttonAllDesel.Name = "buttonAllDesel";
			this.buttonAllDesel.Size = new System.Drawing.Size(128, 23);
			this.buttonAllDesel.TabIndex = 4;
			this.buttonAllDesel.Text = "Remove all selections";
			this.buttonAllDesel.Click += new System.EventHandler(this.OnClickAllDeselect);
			// 
			// buttonValiser
			// 
			this.buttonValiser.Location = new System.Drawing.Point(64, 424);
			this.buttonValiser.Name = "buttonValiser";
			this.buttonValiser.TabIndex = 5;
			this.buttonValiser.Text = "Validation";
			this.buttonValiser.Click += new System.EventHandler(this.OnClickValider);
			// 
			// toolTipColor
			// 
			this.toolTipColor.AutoPopDelay = 5000;
			this.toolTipColor.InitialDelay = 250;
			this.toolTipColor.ReshowDelay = 100;
			// 
			// checkBoxProfileOracleDefault
			// 
			this.checkBoxProfileOracleDefault.Location = new System.Drawing.Point(152, 424);
			this.checkBoxProfileOracleDefault.Name = "checkBoxProfileOracleDefault";
			this.checkBoxProfileOracleDefault.Size = new System.Drawing.Size(184, 24);
			this.checkBoxProfileOracleDefault.TabIndex = 6;
			this.checkBoxProfileOracleDefault.Text = "with Oracle Profile \'DEFAULT\'";
			// 
			// frmOracleProfile
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 454);
			this.Controls.Add(this.checkBoxProfileOracleDefault);
			this.Controls.Add(this.buttonValiser);
			this.Controls.Add(this.buttonAllDesel);
			this.Controls.Add(this.buttonAllSel);
			this.Controls.Add(this.radioButtonUsersAffectedMOUProfile);
			this.Controls.Add(this.radioButtonUsersAffectedOracleProfile);
			this.Controls.Add(this.listViewAffectedUsersWithProfile);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmOracleProfile";
			this.Text = "Oracle Profile Management";
			this.Load += new System.EventHandler(this.frmOracleProfile_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmOracleProfile_Load(object sender, System.EventArgs e)
		{
			m_oracleProfile = new AccountMgmt.DataAccess.AccessOracleProfile();
			SearchUsersAffected();
		}

		/// <summary>
		/// Utilisateurs affectés au profile MOU
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickUsersAffectedMOUProfile(object sender, System.EventArgs e)
		{
			SearchUsersAffected();
		}

		/// <summary>
		/// Utilisateurs affectés au profile ORACLE
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickUsersAffectedOracleProfile(object sender, System.EventArgs e)
		{
			SearchUsersAffected();
		}

		/// <summary>
		/// Recherche les utilisateurs affectés
		/// </summary>
		private void SearchUsersAffected()
		{
			Cursor.Current = Cursors.WaitCursor;
			listViewAffectedUsersWithProfile.SuspendLayout();
			listViewAffectedUsersWithProfile.Items.Clear();
			if(m_listOracleProfile != null)
			{
				m_listOracleProfile.Dispose();
				m_listOracleProfile = null;
			}
			if(m_oracleProfile.ListOracleProfile != null)
				m_oracleProfile.Dispose();

			if(m_oracleProfile.Select(m_connection, m_strOracleProfile, m_lIdProfile, radioButtonUsersAffectedOracleProfile.Checked))
			{
				m_listOracleProfile = new AccountMgmt.BusinessFacade.ListViewOracleProfile();
				m_listOracleProfile.ListOracleProfile = (ArrayList)(m_oracleProfile.ListOracleProfile.Clone());

				for(int i=0; i<m_listOracleProfile.ListOracleProfile.Count; i++)
				{
					ListViewItem items = new ListViewItem(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).UserOracle);
					items.SubItems.Add(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).UserName);
					items.SubItems.Add(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).OracleProfileAffected);
					//recherche le type de contrôle et en fonction définit la couleur de la ligne dans le tableau
					if(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).Color == "vert")
						items.BackColor = System.Drawing.Color.GreenYellow;
					if(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).Color == "jaune")
						items.BackColor = System.Drawing.Color.Yellow;
					if(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).Color == "orange")
						items.BackColor = System.Drawing.Color.Orange;
					if(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).Color == "rouge")
						items.BackColor = System.Drawing.Color.Red;
					listViewAffectedUsersWithProfile.Items.Add(items);
				}
					
			}

			listViewAffectedUsersWithProfile.ResumeLayout();
			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Valider les affectations
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickValider(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			string strProfileOracle = m_strOracleProfile;
			if(checkBoxProfileOracleDefault.Checked)
				strProfileOracle = "DEFAULT";
			for(int i=0; i<listViewAffectedUsersWithProfile.Items.Count; i++)
			{
				if(listViewAffectedUsersWithProfile.Items[i].Checked)
				{
					if(!((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).AffectUser(m_connection, strProfileOracle))
						return;
				}
			}

			Cursor.Current = Cursors.Default;
			buttonValiser.DialogResult = DialogResult.OK;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// Sélectionner tous les utilisateurs du tableau
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickAllSelect(object sender, System.EventArgs e)
		{
			for(int i=0; i<listViewAffectedUsersWithProfile.Items.Count; i++)
			{
				listViewAffectedUsersWithProfile.Items[i].Checked = true;
			}
		}

		/// <summary>
		/// Déselectionner tous les utilisateurs du tableau
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickAllDeselect(object sender, System.EventArgs e)
		{
			for(int i=0; i<listViewAffectedUsersWithProfile.Items.Count; i++)
			{
				listViewAffectedUsersWithProfile.Items[i].Checked = false;
			}
		}

		/// <summary>
		/// Définit le texte du tooltip en fonction de la couleur de la ligne
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMouseMoveColor(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Point point = new Point(e.X, e.Y);
			for(int i=0; i<listViewAffectedUsersWithProfile.Items.Count; i++)
			{
				if(listViewAffectedUsersWithProfile.GetItemRect(i).Contains(point))
				{
					if(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).Color == "vert")
						toolTipColor.SetToolTip(listViewAffectedUsersWithProfile, "MOU Profile Oracle déjà affecté + aucun autre MOU Profile Oracle possible différent de 'DEFAULT'");
					if(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).Color == "jaune")
						toolTipColor.SetToolTip(listViewAffectedUsersWithProfile, "MOU Profile Oracle déjà affecté + autre MOU Profile Oracle possible différent de 'DEFAULT'");
					if(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).Color == "orange")
						toolTipColor.SetToolTip(listViewAffectedUsersWithProfile, "MOU Profile Oracle pas affecté + aucun autre MOU Profile Oracle possible différent de 'DEFAULT'");
					if(((AccountMgmt.DataAccess.OracleProfile)m_listOracleProfile.ListOracleProfile[i]).Color == "rouge")
						toolTipColor.SetToolTip(listViewAffectedUsersWithProfile, "MOU Profile Oracle pas affecté + autre MOU Profile Oracle possible différent de 'DEFAULT'");
					
					i=listViewAffectedUsersWithProfile.Items.Count;
				}
			}
		}

		#region Définit les paramètres du profile à étudier
		/// <summary>
		/// Définit la connection
		/// </summary>
		/// <param name="connection"></param>
		public void SetConnexion(OracleConnection connection)
		{
			m_connection = connection;
		}

		/// <summary>
		/// Définit le profile oracle du profile sélectionné
		/// </summary>
		public string OracleProfile
		{
			set{
				/*if(value == null || value == "")
					m_strOracleProfile = "DEFAULT";
				else*/
					m_strOracleProfile = value;
			}
		}

		/// <summary>
		/// Définit l'identificateur du profile sélectionné
		/// </summary>
		public long IdProfile
		{
			set{ m_lIdProfile = value; }
		}
		#endregion
	}
}
