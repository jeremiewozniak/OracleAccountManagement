using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace AccountMgmt
{
	/// <summary>
	/// Description résumée de frmAffectedUser.
	/// </summary>
	public class frmAffectedUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxUserName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxProfileName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxMadeThe;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxModifiedThe;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxCommentary;
		private System.Windows.Forms.CheckBox checkBoxActivation;
		private System.Windows.Forms.DateTimePicker dateTimePickerBeginning;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
		private System.Windows.Forms.Button buttonModify;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.CheckBox checkBoxAdmin;

		private AccountMgmt.DataAccess.Affectation m_affectedUser = null;
		private OracleConnection m_connection = null;

		private ArrayList m_listRoles = null;
		private string m_strUserOracle = "";

		public frmAffectedUser()
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMadeThe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxModifiedThe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCommentary = new System.Windows.Forms.TextBox();
            this.checkBoxActivation = new System.Windows.Forms.CheckBox();
            this.dateTimePickerBeginning = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonModify = new System.Windows.Forms.Button();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxUserName.Location = new System.Drawing.Point(98, 16);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.ReadOnly = true;
            this.textBoxUserName.Size = new System.Drawing.Size(190, 20);
            this.textBoxUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Profile";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxProfileName.Location = new System.Drawing.Point(98, 48);
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.ReadOnly = true;
            this.textBoxProfileName.Size = new System.Drawing.Size(190, 20);
            this.textBoxProfileName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Made the";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxMadeThe
            // 
            this.textBoxMadeThe.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMadeThe.Location = new System.Drawing.Point(98, 112);
            this.textBoxMadeThe.Name = "textBoxMadeThe";
            this.textBoxMadeThe.ReadOnly = true;
            this.textBoxMadeThe.Size = new System.Drawing.Size(190, 20);
            this.textBoxMadeThe.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Modified the";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxModifiedThe
            // 
            this.textBoxModifiedThe.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxModifiedThe.Location = new System.Drawing.Point(98, 144);
            this.textBoxModifiedThe.Name = "textBoxModifiedThe";
            this.textBoxModifiedThe.ReadOnly = true;
            this.textBoxModifiedThe.Size = new System.Drawing.Size(190, 20);
            this.textBoxModifiedThe.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Commentary";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxCommentary
            // 
            this.textBoxCommentary.Location = new System.Drawing.Point(98, 176);
            this.textBoxCommentary.Multiline = true;
            this.textBoxCommentary.Name = "textBoxCommentary";
            this.textBoxCommentary.Size = new System.Drawing.Size(190, 49);
            this.textBoxCommentary.TabIndex = 9;
            // 
            // checkBoxActivation
            // 
            this.checkBoxActivation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxActivation.Checked = true;
            this.checkBoxActivation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActivation.Location = new System.Drawing.Point(16, 240);
            this.checkBoxActivation.Name = "checkBoxActivation";
            this.checkBoxActivation.Size = new System.Drawing.Size(96, 20);
            this.checkBoxActivation.TabIndex = 10;
            this.checkBoxActivation.Text = "Activation";
            // 
            // dateTimePickerBeginning
            // 
            this.dateTimePickerBeginning.Checked = false;
            this.dateTimePickerBeginning.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBeginning.Location = new System.Drawing.Point(184, 272);
            this.dateTimePickerBeginning.Name = "dateTimePickerBeginning";
            this.dateTimePickerBeginning.ShowCheckBox = true;
            this.dateTimePickerBeginning.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerBeginning.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Beginning Period";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "End Period";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Checked = false;
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(184, 304);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ShowCheckBox = true;
            this.dateTimePickerEnd.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerEnd.TabIndex = 14;
            // 
            // buttonModify
            // 
            this.buttonModify.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonModify.Location = new System.Drawing.Point(116, 352);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(72, 24);
            this.buttonModify.TabIndex = 15;
            this.buttonModify.Text = "Modify";
            this.buttonModify.Click += new System.EventHandler(this.OnClickModify);
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAdmin.Location = new System.Drawing.Point(16, 80);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(96, 20);
            this.checkBoxAdmin.TabIndex = 16;
            this.checkBoxAdmin.Text = "Administrator";
            // 
            // frmAffectedUser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(304, 398);
            this.Controls.Add(this.checkBoxAdmin);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerBeginning);
            this.Controls.Add(this.checkBoxActivation);
            this.Controls.Add(this.textBoxCommentary);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxModifiedThe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMadeThe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxProfileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label1);
            this.Name = "frmAffectedUser";
            this.Text = "Affected User";
            this.Load += new System.EventHandler(this.frmAffectedUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmAffectedUser_Load(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// Définit le nom du profile
		/// </summary>
		/// <param name="strProfileName"></param>
		public void SetProfileName(string strProfileName)
		{
			textBoxProfileName.Text = strProfileName;
		}

		/// <summary>
		/// Définit le nom de l'utilisateur
		/// </summary>
		/// <param name="strUserName"></param>
		public void SetUserName(string strUserName)
		{
			textBoxUserName.Text = strUserName;
		}

		/// <summary>
		/// Définit la liste des roles associés au profile
		/// </summary>
		/// <param name="listRoles"></param>
		/// <returns></returns>
		public void SetListRoles(ArrayList listRoles)
		{
			m_listRoles = (ArrayList)listRoles.Clone();
		}

		/// <summary>
		/// Définit le user_oracle de l'utilisateur
		/// </summary>
		/// <param name="userOracle"></param>
		/// <returns></returns>
		public void SetUserOracle(string userOracle)
		{
			m_strUserOracle = userOracle;
		}

		/// <summary>
		/// Définit l'utilisateur
		/// </summary>
		/// <param name="affectation"></param>
		public void SetAffectedUser(AccountMgmt.DataAccess.Affectation affectation)
		{
			m_affectedUser = affectation;

			checkBoxAdmin.Checked = affectation.Admin;
			textBoxMadeThe.Text = affectation.DateCreation.ToString("G");
			if(affectation.DateModification != new DateTime())
				textBoxModifiedThe.Text = affectation.DateModification.ToString("G");
			textBoxCommentary.Text = affectation.Commentary;
			checkBoxActivation.Checked = affectation.Activation;
			if(affectation.DateBeginning != new DateTime())
			{
				dateTimePickerBeginning.Value = affectation.DateBeginning;
				dateTimePickerBeginning.Checked = true;
			}
			else
			{
				dateTimePickerBeginning.Checked = true;
				dateTimePickerBeginning.Checked = false;
			}
			if(affectation.DateEnd != new DateTime())
			{
				dateTimePickerEnd.Value = affectation.DateEnd;
				dateTimePickerEnd.Checked = true;
			}
			else
			{
				dateTimePickerEnd.Checked = true;
				dateTimePickerEnd.Checked = false;
			}
		}

		/// <summary>
		/// Définit la connection
		/// </summary>
		/// <param name="connection"></param>
		public void SetConnexion(OracleConnection connection)
		{
			m_connection = connection;
		}

		/// <summary>
		/// Modifie l'affectation
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickModify(object sender, System.EventArgs e)
		{
			m_affectedUser.Admin = checkBoxAdmin.Checked;
			m_affectedUser.DateModification = DateTime.Now;
			m_affectedUser.Commentary = textBoxCommentary.Text;
			m_affectedUser.Activation = checkBoxActivation.Checked;
			if(dateTimePickerBeginning.Checked)
				m_affectedUser.DateBeginning = dateTimePickerBeginning.Value;
			else
				m_affectedUser.DateBeginning = new DateTime();
			if(dateTimePickerEnd.Checked)
				m_affectedUser.DateEnd = dateTimePickerEnd.Value;
			else
				m_affectedUser.DateEnd = new DateTime();
			
			if(!m_affectedUser.Update(m_connection, m_listRoles, m_strUserOracle))
				return;
		}
	}
}
