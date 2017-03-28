using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Oracle.DataAccess.Client;

namespace AccountMgmt
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabPage AccountTabPage;
		private System.Windows.Forms.ListView listViewRole;
		private System.Windows.Forms.ColumnHeader columnHeaderRole;
		private System.Windows.Forms.GroupBox groupBoxParameters;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonModify;
		private System.Windows.Forms.Button buttonDelete;
		internal System.Windows.Forms.ImageList ImageList;
		internal System.Windows.Forms.ContextMenu contextMenuAccount;
		internal System.Windows.Forms.MenuItem menuItemCreate;
		internal System.Windows.Forms.MenuItem menuItemShowAffUsers;
		private System.Windows.Forms.TabControl frmTabControle;
		private System.Windows.Forms.TabPage tabPageAffectation;
		private System.Windows.Forms.GroupBox groupBoxAffectedUsers;
		private System.Windows.Forms.TabPage tabPageUsers;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderUserOracle;
		private System.Windows.Forms.ColumnHeader columnHeaderService;
		private System.Windows.Forms.ColumnHeader columnHeaderCommentary;
		private System.Windows.Forms.ColumnHeader columnHeaderPassword;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxNameUser;
		private System.Windows.Forms.CheckBox checkBoxActivateUser;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxUserOracle;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBoxCommentaryUser;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBoxPasswordUser;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBoxServiceUser;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.DateTimePicker dateTimePickerBeginUser;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.DateTimePicker dateTimePickerEndUser;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBoxCreationDate;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textBoxLastModifUser;
		private System.Windows.Forms.Button buttonAddUser;
		private System.Windows.Forms.Button buttonModifyUser;
		private System.Windows.Forms.Button buttonDeleteUser;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboBoxModule;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxApplication;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxProject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonNewUser;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TreeView treeViewArchi;
		
		private System.Windows.Forms.GroupBox groupBoxArchi;
		private System.Windows.Forms.CheckBox checkBoxActive;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxMadeThe;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxCommentary;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxModifiedThe;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxName;

		static private AccountMgmt.DataAccess.ConnectedUser m_connectedUser = null;
		private AccountMgmt.BusinessFacade.TreeViewArchi m_treeViewArchi = null;
		private System.Windows.Forms.TreeView treeViewArchiAffectation;
		private System.Windows.Forms.ListView listViewAllUsers;
		private AccountMgmt.BusinessFacade.ListViewRoles m_listViewRoles = null;
		private System.Windows.Forms.ListView listViewAffectedUsers;
		private AccountMgmt.BusinessFacade.ListViewAllUsers m_listViewAllUsers = null;
		private System.Windows.Forms.ListView listViewUsersRetails;
		private System.Windows.Forms.Label labelTablespace;
		private System.Windows.Forms.TextBox textBoxTablespace;
		private System.Windows.Forms.ComboBox comboBoxUserProfile;
		private AccountMgmt.BusinessFacade.ListViewAffectedUsers m_listAffectedUsers = null;
		private System.Windows.Forms.TextBox textBoxProfileCommentary;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.ContextMenu contextMenuAllRoles;
		private System.Windows.Forms.MenuItem menuItemCreateNewRole;
		private AccountMgmt.BusinessFacade.ComboBoxDefaultProfiles m_defaultProfiles = null;
		private AccountMgmt.BusinessFacade.ComboBoxParent m_cbProject = null;
		private AccountMgmt.BusinessFacade.ComboBoxParent m_cbApplication = null;
		private System.Windows.Forms.Button buttonDesaffectedUsers;
		private System.Windows.Forms.Button buttonAffectedUsers;
		private System.Windows.Forms.Button buttonRefreshTreeView;
		private System.Windows.Forms.ContextMenu contextMenuAffectedUser;
		private System.Windows.Forms.MenuItem menuItemShowParemeters;
		private System.Windows.Forms.TextBox textBoxProfileOracle;
		private System.Windows.Forms.TextBox textBoxRscrConsoGroup;
		private System.Windows.Forms.Label labelRsrcConsoGroup;
		private System.Windows.Forms.Label labelDba;
		private System.Windows.Forms.ComboBox comboBoxDba;
		private AccountMgmt.BusinessFacade.ComboBoxParent m_cbModule = null;
		private System.Windows.Forms.ToolTip toolTipAffectation;
		private System.Windows.Forms.ToolTip toolTipDesaffectation;
		private System.Windows.Forms.Label labelDefaultProfile;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemOptions;
		private System.Windows.Forms.MenuItem menuItemEnglish;
		private System.Windows.Forms.MenuItem menuItemFrench;
		private System.Windows.Forms.ComboBox comboBoxTemporaryTableSpaceUser;
		private System.Windows.Forms.TextBox textBoxTemporaryTableSpaceUser;
		private System.Windows.Forms.Label labelTemporaryTableSpaceUser;
		private char m_cNoPassword;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ColumnHeader columnHeaderLogin;
		private AccountMgmt.BusinessFacade.ComboBoxTemporaryTableSpace m_cbTemporaryTableSpace = null;
		private System.Windows.Forms.ColumnHeader columnHeaderUserOracle2;
		private System.Windows.Forms.ColumnHeader columnHeaderAffectedUsers;
		private System.Windows.Forms.ColumnHeader columnHeaderAdministrateur;
		private System.Windows.Forms.ColumnHeader columnHeaderAllUsers2;
		private System.Windows.Forms.Button buttonProfileOracle;
		private bool bDragAndDropRole = false;
		private System.Windows.Forms.ColumnHeader columnHeaderActivation;
		private System.Windows.Forms.CheckBox checkBoxSortBySrevice;
		private System.Windows.Forms.MenuItem menuItemLogin;
		private System.Windows.Forms.MenuItem menuItemDisconnect;
		private bool IsProfileDefined = false;
		static private string strArguments = "";

		public frmMain()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
			if(m_connectedUser.UserConnected != null && m_connectedUser.UserConnected.Admin != AccountMgmt.Common.Constants.AdminLevel)
				this.frmTabControle.Controls.Remove(this.AccountTabPage);

			m_cNoPassword = textBoxPasswordUser.PasswordChar;
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(m_connectedUser != null)
			{
				if(m_connectedUser.IsConnected)
					m_connectedUser.DataBasisDisconnection();
			}
			if( disposing )
			{
				if (components != null) 
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Projects", 6, 6);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Projects", 6, 6);
            this.frmTabControle = new System.Windows.Forms.TabControl();
            this.AccountTabPage = new System.Windows.Forms.TabPage();
            this.buttonRefreshTreeView = new System.Windows.Forms.Button();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.groupBoxArchi = new System.Windows.Forms.GroupBox();
            this.buttonProfileOracle = new System.Windows.Forms.Button();
            this.textBoxRscrConsoGroup = new System.Windows.Forms.TextBox();
            this.labelRsrcConsoGroup = new System.Windows.Forms.Label();
            this.textBoxProfileOracle = new System.Windows.Forms.TextBox();
            this.textBoxTablespace = new System.Windows.Forms.TextBox();
            this.labelTablespace = new System.Windows.Forms.Label();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.textBoxModifiedThe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMadeThe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCommentary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxApplication = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxProject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxModule = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listViewRole = new System.Windows.Forms.ListView();
            this.columnHeaderRole = new System.Windows.Forms.ColumnHeader();
            this.contextMenuAllRoles = new System.Windows.Forms.ContextMenu();
            this.menuItemCreateNewRole = new System.Windows.Forms.MenuItem();
            this.treeViewArchi = new System.Windows.Forms.TreeView();
            this.contextMenuAccount = new System.Windows.Forms.ContextMenu();
            this.menuItemCreate = new System.Windows.Forms.MenuItem();
            this.menuItemShowAffUsers = new System.Windows.Forms.MenuItem();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPageAffectation = new System.Windows.Forms.TabPage();
            this.groupBoxAffectedUsers = new System.Windows.Forms.GroupBox();
            this.buttonAffectedUsers = new System.Windows.Forms.Button();
            this.buttonDesaffectedUsers = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxProfileCommentary = new System.Windows.Forms.TextBox();
            this.listViewAllUsers = new System.Windows.Forms.ListView();
            this.columnHeaderLogin = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAllUsers2 = new System.Windows.Forms.ColumnHeader();
            this.listViewAffectedUsers = new System.Windows.Forms.ListView();
            this.columnHeaderUserOracle2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAffectedUsers = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAdministrateur = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderActivation = new System.Windows.Forms.ColumnHeader();
            this.contextMenuAffectedUser = new System.Windows.Forms.ContextMenu();
            this.menuItemShowParemeters = new System.Windows.Forms.MenuItem();
            this.treeViewArchiAffectation = new System.Windows.Forms.TreeView();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.checkBoxSortBySrevice = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTemporaryTableSpaceUser = new System.Windows.Forms.TextBox();
            this.comboBoxTemporaryTableSpaceUser = new System.Windows.Forms.ComboBox();
            this.comboBoxDba = new System.Windows.Forms.ComboBox();
            this.labelDba = new System.Windows.Forms.Label();
            this.comboBoxUserProfile = new System.Windows.Forms.ComboBox();
            this.buttonNewUser = new System.Windows.Forms.Button();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.buttonModifyUser = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.textBoxLastModifUser = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxCreationDate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePickerEndUser = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePickerBeginUser = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.labelDefaultProfile = new System.Windows.Forms.Label();
            this.textBoxServiceUser = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPasswordUser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCommentaryUser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxUserOracle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxActivateUser = new System.Windows.Forms.CheckBox();
            this.textBoxNameUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTemporaryTableSpaceUser = new System.Windows.Forms.Label();
            this.listViewUsersRetails = new System.Windows.Forms.ListView();
            this.columnHeaderId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderUserOracle = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderService = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderCommentary = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPassword = new System.Windows.Forms.ColumnHeader();
            this.toolTipAffectation = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipDesaffectation = new System.Windows.Forms.ToolTip(this.components);
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemLogin = new System.Windows.Forms.MenuItem();
            this.menuItemDisconnect = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemOptions = new System.Windows.Forms.MenuItem();
            this.menuItemEnglish = new System.Windows.Forms.MenuItem();
            this.menuItemFrench = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.frmTabControle.SuspendLayout();
            this.AccountTabPage.SuspendLayout();
            this.groupBoxParameters.SuspendLayout();
            this.groupBoxArchi.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageAffectation.SuspendLayout();
            this.groupBoxAffectedUsers.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmTabControle
            // 
            this.frmTabControle.Controls.Add(this.AccountTabPage);
            this.frmTabControle.Controls.Add(this.tabPageAffectation);
            this.frmTabControle.Controls.Add(this.tabPageUsers);
            this.frmTabControle.Location = new System.Drawing.Point(8, 8);
            this.frmTabControle.Name = "frmTabControle";
            this.frmTabControle.SelectedIndex = 0;
            this.frmTabControle.Size = new System.Drawing.Size(968, 432);
            this.frmTabControle.TabIndex = 0;
            this.frmTabControle.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            // 
            // AccountTabPage
            // 
            this.AccountTabPage.Controls.Add(this.buttonRefreshTreeView);
            this.AccountTabPage.Controls.Add(this.groupBoxParameters);
            this.AccountTabPage.Controls.Add(this.listViewRole);
            this.AccountTabPage.Controls.Add(this.treeViewArchi);
            this.AccountTabPage.Location = new System.Drawing.Point(4, 22);
            this.AccountTabPage.Name = "AccountTabPage";
            this.AccountTabPage.Size = new System.Drawing.Size(960, 406);
            this.AccountTabPage.TabIndex = 0;
            this.AccountTabPage.Text = "Account";
            // 
            // buttonRefreshTreeView
            // 
            this.buttonRefreshTreeView.Location = new System.Drawing.Point(16, 16);
            this.buttonRefreshTreeView.Name = "buttonRefreshTreeView";
            this.buttonRefreshTreeView.Size = new System.Drawing.Size(200, 17);
            this.buttonRefreshTreeView.TabIndex = 3;
            this.buttonRefreshTreeView.Text = "Refresh";
            this.buttonRefreshTreeView.Click += new System.EventHandler(this.OnClickRefreshTreeView);
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.groupBoxArchi);
            this.groupBoxParameters.Controls.Add(this.groupBox2);
            this.groupBoxParameters.Controls.Add(this.buttonDelete);
            this.groupBoxParameters.Controls.Add(this.buttonModify);
            this.groupBoxParameters.Controls.Add(this.buttonAdd);
            this.groupBoxParameters.Location = new System.Drawing.Point(440, 8);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(512, 384);
            this.groupBoxParameters.TabIndex = 2;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Parameters";
            // 
            // groupBoxArchi
            // 
            this.groupBoxArchi.Controls.Add(this.buttonProfileOracle);
            this.groupBoxArchi.Controls.Add(this.textBoxRscrConsoGroup);
            this.groupBoxArchi.Controls.Add(this.labelRsrcConsoGroup);
            this.groupBoxArchi.Controls.Add(this.textBoxProfileOracle);
            this.groupBoxArchi.Controls.Add(this.textBoxTablespace);
            this.groupBoxArchi.Controls.Add(this.labelTablespace);
            this.groupBoxArchi.Controls.Add(this.checkBoxActive);
            this.groupBoxArchi.Controls.Add(this.textBoxModifiedThe);
            this.groupBoxArchi.Controls.Add(this.label6);
            this.groupBoxArchi.Controls.Add(this.textBoxMadeThe);
            this.groupBoxArchi.Controls.Add(this.label5);
            this.groupBoxArchi.Controls.Add(this.textBoxCommentary);
            this.groupBoxArchi.Controls.Add(this.label4);
            this.groupBoxArchi.Controls.Add(this.textBoxName);
            this.groupBoxArchi.Controls.Add(this.labelName);
            this.groupBoxArchi.Location = new System.Drawing.Point(16, 144);
            this.groupBoxArchi.Name = "groupBoxArchi";
            this.groupBoxArchi.Size = new System.Drawing.Size(480, 176);
            this.groupBoxArchi.TabIndex = 7;
            this.groupBoxArchi.TabStop = false;
            // 
            // buttonProfileOracle
            // 
            this.buttonProfileOracle.Location = new System.Drawing.Point(248, 80);
            this.buttonProfileOracle.Name = "buttonProfileOracle";
            this.buttonProfileOracle.Size = new System.Drawing.Size(81, 20);
            this.buttonProfileOracle.TabIndex = 8;
            this.buttonProfileOracle.Text = "Oracle Profile";
            this.buttonProfileOracle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonProfileOracle.Visible = false;
            this.buttonProfileOracle.Click += new System.EventHandler(this.OnClickOracleProfile);
            // 
            // textBoxRscrConsoGroup
            // 
            this.textBoxRscrConsoGroup.Location = new System.Drawing.Point(328, 108);
            this.textBoxRscrConsoGroup.Name = "textBoxRscrConsoGroup";
            this.textBoxRscrConsoGroup.Size = new System.Drawing.Size(128, 20);
            this.textBoxRscrConsoGroup.TabIndex = 10;
            this.textBoxRscrConsoGroup.Visible = false;
            // 
            // labelRsrcConsoGroup
            // 
            this.labelRsrcConsoGroup.Location = new System.Drawing.Point(248, 104);
            this.labelRsrcConsoGroup.Name = "labelRsrcConsoGroup";
            this.labelRsrcConsoGroup.Size = new System.Drawing.Size(80, 24);
            this.labelRsrcConsoGroup.TabIndex = 25;
            this.labelRsrcConsoGroup.Text = "Ressource Conso Group";
            this.labelRsrcConsoGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelRsrcConsoGroup.Visible = false;
            // 
            // textBoxProfileOracle
            // 
            this.textBoxProfileOracle.Location = new System.Drawing.Point(328, 80);
            this.textBoxProfileOracle.Name = "textBoxProfileOracle";
            this.textBoxProfileOracle.Size = new System.Drawing.Size(128, 20);
            this.textBoxProfileOracle.TabIndex = 9;
            this.textBoxProfileOracle.Visible = false;
            this.textBoxProfileOracle.TextChanged += new System.EventHandler(this.OnTextChangedOracleProfile);
            // 
            // textBoxTablespace
            // 
            this.textBoxTablespace.Location = new System.Drawing.Point(320, 80);
            this.textBoxTablespace.MaxLength = 50;
            this.textBoxTablespace.Name = "textBoxTablespace";
            this.textBoxTablespace.Size = new System.Drawing.Size(136, 20);
            this.textBoxTablespace.TabIndex = 8;
            this.textBoxTablespace.Visible = false;
            // 
            // labelTablespace
            // 
            this.labelTablespace.Location = new System.Drawing.Point(248, 80);
            this.labelTablespace.Name = "labelTablespace";
            this.labelTablespace.Size = new System.Drawing.Size(64, 20);
            this.labelTablespace.TabIndex = 22;
            this.labelTablespace.Text = "Tablespace";
            this.labelTablespace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTablespace.Visible = false;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Location = new System.Drawing.Point(376, 32);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(80, 20);
            this.checkBoxActive.TabIndex = 6;
            this.checkBoxActive.Text = "Active";
            // 
            // textBoxModifiedThe
            // 
            this.textBoxModifiedThe.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxModifiedThe.Location = new System.Drawing.Point(328, 144);
            this.textBoxModifiedThe.Name = "textBoxModifiedThe";
            this.textBoxModifiedThe.ReadOnly = true;
            this.textBoxModifiedThe.Size = new System.Drawing.Size(128, 20);
            this.textBoxModifiedThe.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(248, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Modified the";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxMadeThe
            // 
            this.textBoxMadeThe.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMadeThe.Location = new System.Drawing.Point(96, 144);
            this.textBoxMadeThe.Name = "textBoxMadeThe";
            this.textBoxMadeThe.ReadOnly = true;
            this.textBoxMadeThe.Size = new System.Drawing.Size(128, 20);
            this.textBoxMadeThe.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Made the";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxCommentary
            // 
            this.textBoxCommentary.Location = new System.Drawing.Point(16, 80);
            this.textBoxCommentary.MaxLength = 199;
            this.textBoxCommentary.Multiline = true;
            this.textBoxCommentary.Name = "textBoxCommentary";
            this.textBoxCommentary.Size = new System.Drawing.Size(208, 48);
            this.textBoxCommentary.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Commentary";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(96, 32);
            this.textBoxName.MaxLength = 49;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(264, 20);
            this.textBoxName.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(16, 32);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(72, 20);
            this.labelName.TabIndex = 14;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxApplication);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxProject);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxModule);
            this.groupBox2.Location = new System.Drawing.Point(72, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 112);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parent";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Module";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxApplication
            // 
            this.comboBoxApplication.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxApplication.Location = new System.Drawing.Point(120, 48);
            this.comboBoxApplication.Name = "comboBoxApplication";
            this.comboBoxApplication.Size = new System.Drawing.Size(176, 21);
            this.comboBoxApplication.TabIndex = 3;
            this.comboBoxApplication.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChangedApplication);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Application";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxProject
            // 
            this.comboBoxProject.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxProject.Location = new System.Drawing.Point(120, 24);
            this.comboBoxProject.Name = "comboBoxProject";
            this.comboBoxProject.Size = new System.Drawing.Size(176, 21);
            this.comboBoxProject.TabIndex = 2;
            this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChangedProject);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxModule
            // 
            this.comboBoxModule.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxModule.Location = new System.Drawing.Point(120, 72);
            this.comboBoxModule.Name = "comboBoxModule";
            this.comboBoxModule.Size = new System.Drawing.Size(176, 21);
            this.comboBoxModule.TabIndex = 4;
            this.comboBoxModule.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChangedModule);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(420, 344);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.OnClickDeleteButton);
            // 
            // buttonModify
            // 
            this.buttonModify.Enabled = false;
            this.buttonModify.Location = new System.Drawing.Point(222, 344);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(75, 23);
            this.buttonModify.TabIndex = 14;
            this.buttonModify.Text = "Modify";
            this.buttonModify.Click += new System.EventHandler(this.OnClickModifyButton);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(24, 344);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 13;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Click += new System.EventHandler(this.OnClickAddButton);
            // 
            // listViewRole
            // 
            this.listViewRole.AllowDrop = true;
            this.listViewRole.BackColor = System.Drawing.SystemColors.Window;
            this.listViewRole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRole});
            this.listViewRole.ContextMenu = this.contextMenuAllRoles;
            this.listViewRole.Location = new System.Drawing.Point(224, 16);
            this.listViewRole.Name = "listViewRole";
            this.listViewRole.Size = new System.Drawing.Size(200, 376);
            this.listViewRole.TabIndex = 1;
            this.listViewRole.UseCompatibleStateImageBehavior = false;
            this.listViewRole.View = System.Windows.Forms.View.Details;
            this.listViewRole.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChangedAllRoles);
            this.listViewRole.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUpAllRoles);
            this.listViewRole.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropRoles);
            this.listViewRole.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownAllRoles);
            this.listViewRole.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnterRoles);
            this.listViewRole.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUpAllRoles);
            this.listViewRole.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.OnItemDragAllRoles);
            // 
            // columnHeaderRole
            // 
            this.columnHeaderRole.Text = "All Roles";
            this.columnHeaderRole.Width = 196;
            // 
            // contextMenuAllRoles
            // 
            this.contextMenuAllRoles.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCreateNewRole});
            // 
            // menuItemCreateNewRole
            // 
            this.menuItemCreateNewRole.Index = 0;
            this.menuItemCreateNewRole.Text = "Create a new Role...";
            this.menuItemCreateNewRole.Click += new System.EventHandler(this.OnCreateNewRole);
            // 
            // treeViewArchi
            // 
            this.treeViewArchi.AllowDrop = true;
            this.treeViewArchi.ContextMenu = this.contextMenuAccount;
            this.treeViewArchi.HideSelection = false;
            this.treeViewArchi.ImageIndex = 5;
            this.treeViewArchi.ImageList = this.ImageList;
            this.treeViewArchi.Location = new System.Drawing.Point(16, 32);
            this.treeViewArchi.Name = "treeViewArchi";
            treeNode1.ImageIndex = 6;
            treeNode1.Name = "";
            treeNode1.SelectedImageIndex = 6;
            treeNode1.Text = "Projects";
            this.treeViewArchi.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewArchi.SelectedImageIndex = 5;
            this.treeViewArchi.Size = new System.Drawing.Size(200, 360);
            this.treeViewArchi.TabIndex = 0;
            this.treeViewArchi.DoubleClick += new System.EventHandler(this.OnDoubleClickTreeViewProject);
            this.treeViewArchi.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropTreeViewArchi);
            this.treeViewArchi.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnAfterSelectTreeViewArchi);
            this.treeViewArchi.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnterTreeViewProject);
            this.treeViewArchi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUpTreeViewArchi);
            this.treeViewArchi.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.OnItemDragTreeViewArchi);
            // 
            // contextMenuAccount
            // 
            this.contextMenuAccount.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCreate,
            this.menuItemShowAffUsers});
            this.contextMenuAccount.Popup += new System.EventHandler(this.contextMenuAccount_Popup);
            // 
            // menuItemCreate
            // 
            this.menuItemCreate.Index = 0;
            this.menuItemCreate.Text = "&Create a new";
            this.menuItemCreate.Click += new System.EventHandler(this.OnCreateANewArchi);
            // 
            // menuItemShowAffUsers
            // 
            this.menuItemShowAffUsers.Index = 1;
            this.menuItemShowAffUsers.Text = "&Show affected users";
            this.menuItemShowAffUsers.Click += new System.EventHandler(this.OnClickShowAffectedUsers);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            // 
            // tabPageAffectation
            // 
            this.tabPageAffectation.Controls.Add(this.groupBoxAffectedUsers);
            this.tabPageAffectation.Controls.Add(this.treeViewArchiAffectation);
            this.tabPageAffectation.Location = new System.Drawing.Point(4, 22);
            this.tabPageAffectation.Name = "tabPageAffectation";
            this.tabPageAffectation.Size = new System.Drawing.Size(960, 406);
            this.tabPageAffectation.TabIndex = 1;
            this.tabPageAffectation.Text = "Affectation";
            // 
            // groupBoxAffectedUsers
            // 
            this.groupBoxAffectedUsers.Controls.Add(this.buttonAffectedUsers);
            this.groupBoxAffectedUsers.Controls.Add(this.buttonDesaffectedUsers);
            this.groupBoxAffectedUsers.Controls.Add(this.label17);
            this.groupBoxAffectedUsers.Controls.Add(this.textBoxProfileCommentary);
            this.groupBoxAffectedUsers.Controls.Add(this.listViewAllUsers);
            this.groupBoxAffectedUsers.Controls.Add(this.listViewAffectedUsers);
            this.groupBoxAffectedUsers.Location = new System.Drawing.Point(328, 16);
            this.groupBoxAffectedUsers.Name = "groupBoxAffectedUsers";
            this.groupBoxAffectedUsers.Size = new System.Drawing.Size(616, 376);
            this.groupBoxAffectedUsers.TabIndex = 1;
            this.groupBoxAffectedUsers.TabStop = false;
            this.groupBoxAffectedUsers.Text = "Affectation";
            // 
            // buttonAffectedUsers
            // 
            this.buttonAffectedUsers.AccessibleDescription = "";
            this.buttonAffectedUsers.AccessibleName = "";
            this.buttonAffectedUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAffectedUsers.Image = ((System.Drawing.Image)(resources.GetObject("buttonAffectedUsers.Image")));
            this.buttonAffectedUsers.Location = new System.Drawing.Point(292, 128);
            this.buttonAffectedUsers.Name = "buttonAffectedUsers";
            this.buttonAffectedUsers.Size = new System.Drawing.Size(33, 33);
            this.buttonAffectedUsers.TabIndex = 4;
            this.toolTipAffectation.SetToolTip(this.buttonAffectedUsers, "Affect user(s)");
            this.buttonAffectedUsers.Click += new System.EventHandler(this.OnClickAffectedUsers);
            // 
            // buttonDesaffectedUsers
            // 
            this.buttonDesaffectedUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDesaffectedUsers.Image = ((System.Drawing.Image)(resources.GetObject("buttonDesaffectedUsers.Image")));
            this.buttonDesaffectedUsers.Location = new System.Drawing.Point(292, 176);
            this.buttonDesaffectedUsers.Name = "buttonDesaffectedUsers";
            this.buttonDesaffectedUsers.Size = new System.Drawing.Size(33, 33);
            this.buttonDesaffectedUsers.TabIndex = 3;
            this.toolTipDesaffectation.SetToolTip(this.buttonDesaffectedUsers, "Disaffect user(s)");
            this.buttonDesaffectedUsers.Click += new System.EventHandler(this.OnClickDesaffectedUsers);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(64, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 32);
            this.label17.TabIndex = 4;
            this.label17.Text = "Profile Commentary";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProfileCommentary
            // 
            this.textBoxProfileCommentary.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxProfileCommentary.Location = new System.Drawing.Point(144, 24);
            this.textBoxProfileCommentary.Multiline = true;
            this.textBoxProfileCommentary.Name = "textBoxProfileCommentary";
            this.textBoxProfileCommentary.ReadOnly = true;
            this.textBoxProfileCommentary.Size = new System.Drawing.Size(416, 40);
            this.textBoxProfileCommentary.TabIndex = 1;
            // 
            // listViewAllUsers
            // 
            this.listViewAllUsers.AllowDrop = true;
            this.listViewAllUsers.BackColor = System.Drawing.SystemColors.Window;
            this.listViewAllUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLogin,
            this.columnHeaderAllUsers2});
            this.listViewAllUsers.FullRowSelect = true;
            this.listViewAllUsers.Location = new System.Drawing.Point(344, 80);
            this.listViewAllUsers.Name = "listViewAllUsers";
            this.listViewAllUsers.Size = new System.Drawing.Size(264, 272);
            this.listViewAllUsers.TabIndex = 5;
            this.listViewAllUsers.UseCompatibleStateImageBehavior = false;
            this.listViewAllUsers.View = System.Windows.Forms.View.Details;
            this.listViewAllUsers.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropAllUsers);
            this.listViewAllUsers.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnterAllUsers);
            this.listViewAllUsers.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.OnItemDragAllUsers);
            // 
            // columnHeaderLogin
            // 
            this.columnHeaderLogin.Text = "User Oracle";
            this.columnHeaderLogin.Width = 80;
            // 
            // columnHeaderAllUsers2
            // 
            this.columnHeaderAllUsers2.Text = "All Users";
            this.columnHeaderAllUsers2.Width = 180;
            // 
            // listViewAffectedUsers
            // 
            this.listViewAffectedUsers.AllowDrop = true;
            this.listViewAffectedUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUserOracle2,
            this.columnHeaderAffectedUsers,
            this.columnHeaderAdministrateur,
            this.columnHeaderActivation});
            this.listViewAffectedUsers.ContextMenu = this.contextMenuAffectedUser;
            this.listViewAffectedUsers.FullRowSelect = true;
            this.listViewAffectedUsers.Location = new System.Drawing.Point(8, 80);
            this.listViewAffectedUsers.MultiSelect = false;
            this.listViewAffectedUsers.Name = "listViewAffectedUsers";
            this.listViewAffectedUsers.Size = new System.Drawing.Size(272, 272);
            this.listViewAffectedUsers.TabIndex = 2;
            this.listViewAffectedUsers.UseCompatibleStateImageBehavior = false;
            this.listViewAffectedUsers.View = System.Windows.Forms.View.Details;
            this.listViewAffectedUsers.DoubleClick += new System.EventHandler(this.OnDoubleClickAffectedUser);
            this.listViewAffectedUsers.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropAffectedUsers);
            this.listViewAffectedUsers.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnterAffectedUsers);
            this.listViewAffectedUsers.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.OnItemDragAffectedUsers);
            // 
            // columnHeaderUserOracle2
            // 
            this.columnHeaderUserOracle2.Text = "User Oracle";
            this.columnHeaderUserOracle2.Width = 70;
            // 
            // columnHeaderAffectedUsers
            // 
            this.columnHeaderAffectedUsers.Text = "Affected Users";
            this.columnHeaderAffectedUsers.Width = 105;
            // 
            // columnHeaderAdministrateur
            // 
            this.columnHeaderAdministrateur.Text = "Admin";
            this.columnHeaderAdministrateur.Width = 42;
            // 
            // columnHeaderActivation
            // 
            this.columnHeaderActivation.Text = "Activate";
            this.columnHeaderActivation.Width = 51;
            // 
            // contextMenuAffectedUser
            // 
            this.contextMenuAffectedUser.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemShowParemeters});
            // 
            // menuItemShowParemeters
            // 
            this.menuItemShowParemeters.Index = 0;
            this.menuItemShowParemeters.Text = "Show Parameters...";
            this.menuItemShowParemeters.Click += new System.EventHandler(this.OnShowParameters);
            // 
            // treeViewArchiAffectation
            // 
            this.treeViewArchiAffectation.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewArchiAffectation.HideSelection = false;
            this.treeViewArchiAffectation.ImageIndex = 5;
            this.treeViewArchiAffectation.ImageList = this.ImageList;
            this.treeViewArchiAffectation.Location = new System.Drawing.Point(16, 16);
            this.treeViewArchiAffectation.Name = "treeViewArchiAffectation";
            treeNode2.ImageIndex = 6;
            treeNode2.Name = "";
            treeNode2.SelectedImageIndex = 6;
            treeNode2.Text = "Projects";
            this.treeViewArchiAffectation.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeViewArchiAffectation.SelectedImageIndex = 5;
            this.treeViewArchiAffectation.Size = new System.Drawing.Size(272, 376);
            this.treeViewArchiAffectation.TabIndex = 0;
            this.treeViewArchiAffectation.DoubleClick += new System.EventHandler(this.OnDoubleClickTreeViewArchiAffectation);
            this.treeViewArchiAffectation.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnAfterSelectArchiAffectation);
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.checkBoxSortBySrevice);
            this.tabPageUsers.Controls.Add(this.label12);
            this.tabPageUsers.Controls.Add(this.groupBox1);
            this.tabPageUsers.Controls.Add(this.listViewUsersRetails);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Size = new System.Drawing.Size(960, 406);
            this.tabPageUsers.TabIndex = 2;
            this.tabPageUsers.Text = "Users";
            // 
            // checkBoxSortBySrevice
            // 
            this.checkBoxSortBySrevice.Location = new System.Drawing.Point(416, 16);
            this.checkBoxSortBySrevice.Name = "checkBoxSortBySrevice";
            this.checkBoxSortBySrevice.Size = new System.Drawing.Size(104, 24);
            this.checkBoxSortBySrevice.TabIndex = 3;
            this.checkBoxSortBySrevice.Text = "Sort by service";
            this.checkBoxSortBySrevice.CheckedChanged += new System.EventHandler(this.OnCheckedChangedSortByService);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 23);
            this.label12.TabIndex = 2;
            this.label12.Text = "Liste des utilisateurs sans DBA";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTemporaryTableSpaceUser);
            this.groupBox1.Controls.Add(this.comboBoxTemporaryTableSpaceUser);
            this.groupBox1.Controls.Add(this.comboBoxDba);
            this.groupBox1.Controls.Add(this.labelDba);
            this.groupBox1.Controls.Add(this.comboBoxUserProfile);
            this.groupBox1.Controls.Add(this.buttonNewUser);
            this.groupBox1.Controls.Add(this.buttonDeleteUser);
            this.groupBox1.Controls.Add(this.buttonModifyUser);
            this.groupBox1.Controls.Add(this.buttonAddUser);
            this.groupBox1.Controls.Add(this.textBoxLastModifUser);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.textBoxCreationDate);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dateTimePickerEndUser);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dateTimePickerBeginUser);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.labelDefaultProfile);
            this.groupBox1.Controls.Add(this.textBoxServiceUser);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBoxPasswordUser);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxCommentaryUser);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxUserOracle);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.checkBoxActivateUser);
            this.groupBox1.Controls.Add(this.textBoxNameUser);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labelTemporaryTableSpaceUser);
            this.groupBox1.Location = new System.Drawing.Point(536, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 376);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters User";
            // 
            // textBoxTemporaryTableSpaceUser
            // 
            this.textBoxTemporaryTableSpaceUser.Location = new System.Drawing.Point(296, 200);
            this.textBoxTemporaryTableSpaceUser.Name = "textBoxTemporaryTableSpaceUser";
            this.textBoxTemporaryTableSpaceUser.ReadOnly = true;
            this.textBoxTemporaryTableSpaceUser.Size = new System.Drawing.Size(104, 20);
            this.textBoxTemporaryTableSpaceUser.TabIndex = 10;
            this.textBoxTemporaryTableSpaceUser.Visible = false;
            // 
            // comboBoxTemporaryTableSpaceUser
            // 
            this.comboBoxTemporaryTableSpaceUser.Location = new System.Drawing.Point(296, 200);
            this.comboBoxTemporaryTableSpaceUser.Name = "comboBoxTemporaryTableSpaceUser";
            this.comboBoxTemporaryTableSpaceUser.Size = new System.Drawing.Size(104, 21);
            this.comboBoxTemporaryTableSpaceUser.TabIndex = 11;
            this.comboBoxTemporaryTableSpaceUser.Visible = false;
            // 
            // comboBoxDba
            // 
            this.comboBoxDba.Location = new System.Drawing.Point(296, 80);
            this.comboBoxDba.Name = "comboBoxDba";
            this.comboBoxDba.Size = new System.Drawing.Size(104, 21);
            this.comboBoxDba.TabIndex = 5;
            this.comboBoxDba.Visible = false;
            // 
            // labelDba
            // 
            this.labelDba.Location = new System.Drawing.Point(232, 80);
            this.labelDba.Name = "labelDba";
            this.labelDba.Size = new System.Drawing.Size(40, 20);
            this.labelDba.TabIndex = 20;
            this.labelDba.Text = "Dba";
            this.labelDba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDba.Visible = false;
            // 
            // comboBoxUserProfile
            // 
            this.comboBoxUserProfile.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxUserProfile.Location = new System.Drawing.Point(96, 200);
            this.comboBoxUserProfile.Name = "comboBoxUserProfile";
            this.comboBoxUserProfile.Size = new System.Drawing.Size(120, 21);
            this.comboBoxUserProfile.TabIndex = 9;
            // 
            // buttonNewUser
            // 
            this.buttonNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNewUser.Location = new System.Drawing.Point(328, 0);
            this.buttonNewUser.Name = "buttonNewUser";
            this.buttonNewUser.Size = new System.Drawing.Size(75, 23);
            this.buttonNewUser.TabIndex = 1;
            this.buttonNewUser.Text = "New User";
            this.buttonNewUser.Click += new System.EventHandler(this.OnClickNewUser);
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Location = new System.Drawing.Point(324, 336);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteUser.TabIndex = 18;
            this.buttonDeleteUser.Text = "Delete";
            this.buttonDeleteUser.Click += new System.EventHandler(this.OnClickDeleteUser);
            // 
            // buttonModifyUser
            // 
            this.buttonModifyUser.Location = new System.Drawing.Point(170, 336);
            this.buttonModifyUser.Name = "buttonModifyUser";
            this.buttonModifyUser.Size = new System.Drawing.Size(75, 23);
            this.buttonModifyUser.TabIndex = 17;
            this.buttonModifyUser.Text = "Modify";
            this.buttonModifyUser.Click += new System.EventHandler(this.OnClickModifyUser);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(16, 336);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(75, 23);
            this.buttonAddUser.TabIndex = 16;
            this.buttonAddUser.Text = "Add";
            this.buttonAddUser.Click += new System.EventHandler(this.OnClickAddUser);
            // 
            // textBoxLastModifUser
            // 
            this.textBoxLastModifUser.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLastModifUser.Location = new System.Drawing.Point(288, 280);
            this.textBoxLastModifUser.Name = "textBoxLastModifUser";
            this.textBoxLastModifUser.ReadOnly = true;
            this.textBoxLastModifUser.Size = new System.Drawing.Size(112, 20);
            this.textBoxLastModifUser.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(232, 280);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 20);
            this.label16.TabIndex = 19;
            this.label16.Text = "Last Modif";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxCreationDate
            // 
            this.textBoxCreationDate.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCreationDate.Location = new System.Drawing.Point(104, 280);
            this.textBoxCreationDate.Name = "textBoxCreationDate";
            this.textBoxCreationDate.ReadOnly = true;
            this.textBoxCreationDate.Size = new System.Drawing.Size(112, 20);
            this.textBoxCreationDate.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(16, 280);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 20);
            this.label15.TabIndex = 17;
            this.label15.Text = "Creation Date";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerEndUser
            // 
            this.dateTimePickerEndUser.Checked = false;
            this.dateTimePickerEndUser.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEndUser.Location = new System.Drawing.Point(296, 240);
            this.dateTimePickerEndUser.Name = "dateTimePickerEndUser";
            this.dateTimePickerEndUser.ShowCheckBox = true;
            this.dateTimePickerEndUser.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerEndUser.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(232, 240);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 20);
            this.label14.TabIndex = 15;
            this.label14.Text = "End Period";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerBeginUser
            // 
            this.dateTimePickerBeginUser.Checked = false;
            this.dateTimePickerBeginUser.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBeginUser.Location = new System.Drawing.Point(112, 240);
            this.dateTimePickerBeginUser.Name = "dateTimePickerBeginUser";
            this.dateTimePickerBeginUser.ShowCheckBox = true;
            this.dateTimePickerBeginUser.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerBeginUser.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 240);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 24);
            this.label13.TabIndex = 13;
            this.label13.Text = "Beginning Period";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDefaultProfile
            // 
            this.labelDefaultProfile.Location = new System.Drawing.Point(16, 200);
            this.labelDefaultProfile.Name = "labelDefaultProfile";
            this.labelDefaultProfile.Size = new System.Drawing.Size(80, 24);
            this.labelDefaultProfile.TabIndex = 11;
            this.labelDefaultProfile.Text = "Default MOU Profile";
            this.labelDefaultProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxServiceUser
            // 
            this.textBoxServiceUser.Location = new System.Drawing.Point(96, 160);
            this.textBoxServiceUser.MaxLength = 49;
            this.textBoxServiceUser.Name = "textBoxServiceUser";
            this.textBoxServiceUser.Size = new System.Drawing.Size(120, 20);
            this.textBoxServiceUser.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "Service";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPasswordUser
            // 
            this.textBoxPasswordUser.Location = new System.Drawing.Point(96, 120);
            this.textBoxPasswordUser.MaxLength = 49;
            this.textBoxPasswordUser.Name = "textBoxPasswordUser";
            this.textBoxPasswordUser.Size = new System.Drawing.Size(120, 20);
            this.textBoxPasswordUser.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Password";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxCommentaryUser
            // 
            this.textBoxCommentaryUser.Location = new System.Drawing.Point(232, 148);
            this.textBoxCommentaryUser.MaxLength = 49;
            this.textBoxCommentaryUser.Multiline = true;
            this.textBoxCommentaryUser.Name = "textBoxCommentaryUser";
            this.textBoxCommentaryUser.Size = new System.Drawing.Size(168, 32);
            this.textBoxCommentaryUser.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(232, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Commentary";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxUserOracle
            // 
            this.textBoxUserOracle.Location = new System.Drawing.Point(96, 80);
            this.textBoxUserOracle.MaxLength = 29;
            this.textBoxUserOracle.Name = "textBoxUserOracle";
            this.textBoxUserOracle.Size = new System.Drawing.Size(120, 20);
            this.textBoxUserOracle.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "User Oracle";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxActivateUser
            // 
            this.checkBoxActivateUser.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxActivateUser.Checked = true;
            this.checkBoxActivateUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActivateUser.Location = new System.Drawing.Point(232, 40);
            this.checkBoxActivateUser.Name = "checkBoxActivateUser";
            this.checkBoxActivateUser.Size = new System.Drawing.Size(168, 20);
            this.checkBoxActivateUser.TabIndex = 3;
            this.checkBoxActivateUser.Text = "Activate";
            // 
            // textBoxNameUser
            // 
            this.textBoxNameUser.Location = new System.Drawing.Point(96, 40);
            this.textBoxNameUser.MaxLength = 49;
            this.textBoxNameUser.Name = "textBoxNameUser";
            this.textBoxNameUser.Size = new System.Drawing.Size(120, 20);
            this.textBoxNameUser.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTemporaryTableSpaceUser
            // 
            this.labelTemporaryTableSpaceUser.Location = new System.Drawing.Point(232, 200);
            this.labelTemporaryTableSpaceUser.Name = "labelTemporaryTableSpaceUser";
            this.labelTemporaryTableSpaceUser.Size = new System.Drawing.Size(72, 32);
            this.labelTemporaryTableSpaceUser.TabIndex = 21;
            this.labelTemporaryTableSpaceUser.Text = "Temporary TableSpace";
            this.labelTemporaryTableSpaceUser.Visible = false;
            // 
            // listViewUsersRetails
            // 
            this.listViewUsersRetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderName,
            this.columnHeaderUserOracle,
            this.columnHeaderService,
            this.columnHeaderCommentary,
            this.columnHeaderPassword});
            this.listViewUsersRetails.FullRowSelect = true;
            this.listViewUsersRetails.GridLines = true;
            this.listViewUsersRetails.Location = new System.Drawing.Point(16, 40);
            this.listViewUsersRetails.MultiSelect = false;
            this.listViewUsersRetails.Name = "listViewUsersRetails";
            this.listViewUsersRetails.Size = new System.Drawing.Size(504, 352);
            this.listViewUsersRetails.TabIndex = 0;
            this.listViewUsersRetails.UseCompatibleStateImageBehavior = false;
            this.listViewUsersRetails.View = System.Windows.Forms.View.Details;
            this.listViewUsersRetails.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUpUserList);
            this.listViewUsersRetails.Click += new System.EventHandler(this.OnClickUserList);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            this.columnHeaderId.Width = 50;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 150;
            // 
            // columnHeaderUserOracle
            // 
            this.columnHeaderUserOracle.Text = "User Oracle";
            this.columnHeaderUserOracle.Width = 80;
            // 
            // columnHeaderService
            // 
            this.columnHeaderService.Text = "Service";
            // 
            // columnHeaderCommentary
            // 
            this.columnHeaderCommentary.Text = "Commentary";
            this.columnHeaderCommentary.Width = 100;
            // 
            // columnHeaderPassword
            // 
            this.columnHeaderPassword.Text = "Password";
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItemOptions,
            this.menuItemHelp});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemLogin,
            this.menuItemDisconnect,
            this.menuItemExit});
            this.menuItem1.Text = "File";
            // 
            // menuItemLogin
            // 
            this.menuItemLogin.Index = 0;
            this.menuItemLogin.Text = "Login...";
            this.menuItemLogin.Click += new System.EventHandler(this.OnClickLogin);
            // 
            // menuItemDisconnect
            // 
            this.menuItemDisconnect.Index = 1;
            this.menuItemDisconnect.Text = "Disconnect";
            this.menuItemDisconnect.Click += new System.EventHandler(this.OnClickDisconnect);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 2;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.OnClickExit);
            // 
            // menuItemOptions
            // 
            this.menuItemOptions.Index = 1;
            this.menuItemOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemEnglish,
            this.menuItemFrench});
            this.menuItemOptions.Text = "Options";
            this.menuItemOptions.Click += new System.EventHandler(this.OnClickOptions);
            // 
            // menuItemEnglish
            // 
            this.menuItemEnglish.Checked = true;
            this.menuItemEnglish.Index = 0;
            this.menuItemEnglish.Text = "English";
            // 
            // menuItemFrench
            // 
            this.menuItemFrench.Index = 1;
            this.menuItemFrench.Text = "French";
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 2;
            this.menuItemHelp.Text = "?";
            this.menuItemHelp.Click += new System.EventHandler(this.OnClickHelp);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(984, 446);
            this.Controls.Add(this.frmTabControle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "frmMain";
            this.Text = "MOA";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.frmTabControle.ResumeLayout(false);
            this.AccountTabPage.ResumeLayout(false);
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxArchi.ResumeLayout(false);
            this.groupBoxArchi.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabPageAffectation.ResumeLayout(false);
            this.groupBoxAffectedUsers.ResumeLayout(false);
            this.groupBoxAffectedUsers.PerformLayout();
            this.tabPageUsers.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

				//lance la fenêtre qui permet la connection
				strArguments = args[0];
				frmConnect myFrmConnect = null;
				if(strArguments.Length > 0)
					myFrmConnect = new frmConnect(strArguments);
				else
					myFrmConnect = new frmConnect("");
				Application.Run(myFrmConnect);
				m_connectedUser = myFrmConnect.ConnectedUser;
				if(myFrmConnect.DialogResult == DialogResult.OK)
				{
					//lance l'application
					Application.Run(new frmMain());
				}
			}
			catch(Exception error)
			{
				MessageBox.Show(error.ToString());
			}
		}

		// Gestion des onglets
		#region
		
		/// <summary>
		/// L'utilisateur affiche un autre onglet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSelectedIndexChanged(object sender, System.EventArgs e)
		{
			//affiche l'onglet de la gestion des comptes
			if(frmTabControle.SelectedTab == AccountTabPage)
			{
				//GetArchiAccount();
				SetTreeViewAccountLikeTreeViewAffectation();
			}
			//affiche l'onglet de la gestion des affectations
			if(frmTabControle.SelectedTab == tabPageAffectation)
			{
				GetArchiAffectation();
				SetTreeViewAffectationLikeTreeViewAccount();
				GetAffectedUsers();
				AffichageAllUsers();
			}
			//affiche l'onglet de la gestion des utilisateurs
			if(frmTabControle.SelectedTab == tabPageUsers)
			{
				AffichageUsers();
				GetDefaultTablespace();
				AfficheValeursDba();
				AfficheNewUser();
			}
		}

		#endregion

		// Gestion de l'onglet Account
		#region

		/// <summary>
		/// Récupère la structure des comptes
		/// </summary>
		/// <returns>Erreur si problème lors de la recherche des comptes</returns>
		private bool GetArchiAccount()
		{
			//arbre de l'onglet Account
			treeViewArchi.BeginUpdate();
			treeViewArchi.Nodes[0].Nodes.Clear();
			treeViewArchi.Nodes[0].Tag = null;
			//listes représentant les arbres
			if(m_treeViewArchi != null)
			{
				m_treeViewArchi.Dispose();
				m_treeViewArchi = null;
			}

			bool bResult = false;
			AccountMgmt.DataAccess.AccessArchi selArchi = new AccountMgmt.DataAccess.AccessArchi();
			//récupère la structe des comptes
			if(selArchi.SelectArchi(m_connectedUser))
			{
				bResult = true;
				m_treeViewArchi = new AccountMgmt.BusinessFacade.TreeViewArchi();
				m_treeViewArchi.ListRoles = (ArrayList)(selArchi.ListRole.Clone());

				//remplir l arbre
				TreeNode treeNodeProjet = null, treeNodeApplication = null, treeNodeModule = null, treeNodeProfile = null, treeNodeRole = null;
				AccountMgmt.BusinessFacade.TreeNodeArchi treeNodeIndex = null;
				for(int numProject=0; numProject<selArchi.ListProject.Count; numProject++)
				{
					//ajout du noeud "Projet"
					treeNodeProjet = new TreeNode(((AccountMgmt.DataAccess.Project)(selArchi.ListProject[numProject])).Name, 0, 0);
					treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
					treeNodeIndex.SelList = numProject;
					treeNodeIndex.SelNode = 1;
					treeNodeProjet.Tag = treeNodeIndex;
					if(!((AccountMgmt.DataAccess.Project)(selArchi.ListProject[numProject])).Activation)
						treeNodeProjet.BackColor = System.Drawing.Color.Tomato;
					treeViewArchi.Nodes[0].Nodes.Add(treeNodeProjet);
					m_treeViewArchi.ListProjects.Add(((AccountMgmt.DataAccess.Project)selArchi.ListProject[numProject]));

					//ajout du noeud "Application"
					for(int numApp=0; numApp<selArchi.ListApplication.Count; numApp++)
					{
						if(((AccountMgmt.DataAccess.Project)selArchi.ListProject[numProject]).Id == ((AccountMgmt.DataAccess.Application)selArchi.ListApplication[numApp]).IdProject)
						{
							treeNodeApplication = new TreeNode(((AccountMgmt.DataAccess.Application)(selArchi.ListApplication[numApp])).Name, 1, 1);
							treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
							treeNodeIndex.SelList = numApp;
							treeNodeIndex.SelNode = 2;
							treeNodeApplication.Tag = treeNodeIndex;
							if(!((AccountMgmt.DataAccess.Application)(selArchi.ListApplication[numApp])).Activation)
								treeNodeApplication.BackColor = System.Drawing.Color.Tomato;
							treeNodeProjet.Nodes.Add(treeNodeApplication);
							m_treeViewArchi.ListApplication.Add(((AccountMgmt.DataAccess.Application)selArchi.ListApplication[numApp]));
						
							//ajout du noeud "Module"
							for(int numModule=0; numModule<selArchi.ListModule.Count; numModule++)
							{
								if(((AccountMgmt.DataAccess.Application)selArchi.ListApplication[numApp]).Id == ((AccountMgmt.DataAccess.Module)selArchi.ListModule[numModule]).IdApplication)
								{
									treeNodeModule = new TreeNode(((AccountMgmt.DataAccess.Module)(selArchi.ListModule[numModule])).Name, 2, 2);
									treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
									treeNodeIndex.SelList = numModule;
									treeNodeIndex.SelNode = 3;
									treeNodeModule.Tag = treeNodeIndex;
									if(!((AccountMgmt.DataAccess.Module)(selArchi.ListModule[numModule])).Activation)
										treeNodeModule.BackColor = System.Drawing.Color.Tomato;
									treeNodeApplication.Nodes.Add(treeNodeModule);
									m_treeViewArchi.ListModules.Add(((AccountMgmt.DataAccess.Module)selArchi.ListModule[numModule]));
								
									//ajout du noeud "Profile"
									for(int numProfile=0; numProfile<selArchi.ListProfile.Count; numProfile++)
									{
										if(((AccountMgmt.DataAccess.Module)selArchi.ListModule[numModule]).Id == ((AccountMgmt.DataAccess.Profile)selArchi.ListProfile[numProfile]).IdModule )
										{
											treeNodeProfile = new TreeNode(((AccountMgmt.DataAccess.Profile)(selArchi.ListProfile[numProfile])).Name, 3, 3);
											treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
											treeNodeIndex.SelList = numProfile;
											treeNodeIndex.SelNode = 4;
											treeNodeProfile.Tag = treeNodeIndex;
											if(!((AccountMgmt.DataAccess.Profile)(selArchi.ListProfile[numProfile])).Activation)
												treeNodeProfile.BackColor = System.Drawing.Color.Tomato;
											treeNodeModule.Nodes.Add(treeNodeProfile);
											m_treeViewArchi.ListProfiles.Add(selArchi.ListProfile[numProfile]);
										
											for(int numRole=0; numRole<selArchi.ListRole.Count; numRole++)
											{
												//ajout du noeud "Role"
												if(((AccountMgmt.DataAccess.Profile)selArchi.ListProfile[numProfile]).Id == ((AccountMgmt.DataAccess.Role)selArchi.ListRole[numRole]).IdProfile)
												{
													treeNodeRole = new TreeNode(((AccountMgmt.DataAccess.Role)(selArchi.ListRole[numRole])).Name, 4, 4);
													treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
													treeNodeIndex.SelList = numRole;
													treeNodeIndex.SelNode = 5;
													treeNodeRole.Tag = treeNodeIndex;
													if(!((AccountMgmt.DataAccess.Role)(selArchi.ListRole[numRole])).Activation)
														treeNodeRole.BackColor = System.Drawing.Color.Tomato;
													treeNodeProfile.Nodes.Add(treeNodeRole);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}

			treeViewArchi.EndUpdate();
			selArchi.Dispose();
			
			return bResult;
		}

		
		
		/// <summary>
		/// Récupère la liste des roles disponibles en base
		/// </summary>
		/// <returns>Erreur si problème lors de la recherche des roles</returns>
		private bool GetRoles()
		{
			listViewRole.BeginUpdate();
			listViewRole.Items.Clear();
			if(m_listViewRoles != null)
			{
				m_listViewRoles.Dispose();
				m_listViewRoles = null;
			}

			bool bResult = false;
			AccountMgmt.DataAccess.AccessRole role = new AccountMgmt.DataAccess.AccessRole();
			int compt = 0;
			if(role.Select(m_connectedUser.Connection, "", "role"))
			{
				bResult = true;
				m_listViewRoles = new AccountMgmt.BusinessFacade.ListViewRoles();
				m_listViewRoles.ListRoles = (ArrayList)(role.ListRole.Clone());
				foreach(AccountMgmt.DataAccess.Role myRole in m_listViewRoles.ListRoles)
				{
					listViewRole.Items.Add(myRole.Name);
					listViewRole.Items[compt].Tag = myRole.Id;
					if(!myRole.Activation)
						listViewRole.Items[compt].BackColor = System.Drawing.Color.Tomato;
					compt++;
				}
			}

			role.Dispose();
			listViewRole.EndUpdate();
			return bResult;
		}

		/// <summary>
		/// Rechargement en base des données et refresh de l'arbre
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickRefreshTreeView(object sender, System.EventArgs e)
		{
			GetArchiAccount();
		}

		/// <summary>
		/// Affiche le popup menu en fonction du noeud sélectionné
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void contextMenuAccount_Popup(object sender, System.EventArgs e)
		{
			int selNode = 0;
			if(treeViewArchi.SelectedNode.Tag != null)
				selNode = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode;
			
			menuItemCreate.Visible = true;
			menuItemCreate.Enabled = true;
			menuItemShowAffUsers.Visible = true;
			switch(selNode)
			{
				case 0: //new projet
					menuItemCreate.Text = "Create a new Project...";
					menuItemShowAffUsers.Visible = false;
					break;
				case 1: //new app
					menuItemCreate.Text = "Create a new Application...";
					if(!((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).Activation)
						menuItemCreate.Enabled = false;
					menuItemShowAffUsers.Visible = false;
					break;
				case 2: //new module
					menuItemCreate.Text = "Create a new Module...";
					if(!((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).Activation)
						menuItemCreate.Enabled = false;
					menuItemShowAffUsers.Visible = false;
					break;
				case 3: //new profile
					menuItemCreate.Text = "Create a new Profile...";
					if(!((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).Activation)
						menuItemCreate.Enabled = false;
					menuItemShowAffUsers.Visible = false;
					break;
				case 4: //new role
					menuItemCreate.Text = "Create a new Role...";
					if(!((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).Activation)
						menuItemCreate.Enabled = false;
					break;
				case 5:
					menuItemCreate.Visible = false;
					menuItemShowAffUsers.Visible = false;
					break;
			}
		}

		/// <summary>
		/// Creer un nouveau noeud
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCreateANewArchi(object sender, System.EventArgs e)
		{
			//mettre tous les champs à null
			comboBoxProject.BeginUpdate();
			comboBoxProject.Items.Clear();
			comboBoxProject.Text = "";
			if(m_cbProject != null)
			{
				m_cbProject.Dispose();
				m_cbProject = null;
			}
			comboBoxApplication.BeginUpdate();
			comboBoxApplication.Items.Clear();
			comboBoxApplication.Text = "";
			if(m_cbApplication != null)
			{
				m_cbApplication.Dispose();
				m_cbApplication = null;
			}
			comboBoxModule.BeginUpdate();
			comboBoxModule.Items.Clear();
			comboBoxModule.Text = "";
			if(m_cbModule != null)
			{
				m_cbModule.Dispose();
				m_cbModule = null;
			}
			textBoxName.Text = "";
			checkBoxActive.Checked = true;
			textBoxCommentary.Text = "";
			textBoxMadeThe.Text = "";
			textBoxModifiedThe.Text = "";
			labelTablespace.Visible = false;
			textBoxTablespace.Text = "";
			textBoxTablespace.Visible = false;
			//labelOracleProfile.Visible = false;
			textBoxProfileOracle.Text = "";
			textBoxProfileOracle.Visible = false;
			buttonProfileOracle.Visible = false;
			labelRsrcConsoGroup.Visible = false;
			textBoxRscrConsoGroup.Text = "";
			textBoxRscrConsoGroup.Visible = false;
			buttonAdd.Enabled = true;
			buttonModify.Enabled = true;
			buttonDelete.Enabled = true;

			if(treeViewArchi.SelectedNode.Tag == null)//new project
			{
				comboBoxProject.SelectedIndex = -1;
				comboBoxApplication.SelectedIndex = -1;
				comboBoxModule.SelectedIndex = -1;
				groupBoxArchi.Text = "Project";
			}
			else
			{
				switch(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode)
				{
					case 1: //new application
						groupBoxArchi.Text = "Application";
						comboBoxApplication.SelectedIndex = -1;
						comboBoxModule.SelectedIndex = -1;
						m_cbProject = new AccountMgmt.BusinessFacade.ComboBoxParent();
						for(int i=0; i<treeViewArchi.SelectedNode.Parent.Nodes.Count; i++)
						{
							m_cbProject.ListParent.Add(((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Nodes[i].Tag).SelList]).Id);
							comboBoxProject.Items.Add(treeViewArchi.SelectedNode.Parent.Nodes[i].Text);
							if(((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Nodes[i].Tag).SelList]).Id == ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList])).Id) 
								comboBoxProject.SelectedIndex = i;
						}
						labelTablespace.Visible = true;
						textBoxTablespace.Visible = true;
						break;
					case 2: //new module
						groupBoxArchi.Text = "Module";
						comboBoxModule.SelectedIndex = -1;
						m_cbProject = new AccountMgmt.BusinessFacade.ComboBoxParent();
						for(int i=0; i<treeViewArchi.SelectedNode.Parent.Parent.Nodes.Count; i++)
						{
							m_cbProject.ListParent.Add(((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Tag).SelList]).Id);
							comboBoxProject.Items.Add(treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Text);
							if(((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Tag).SelList]).Id == ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList])).Id) 
								comboBoxProject.SelectedIndex = i;
						}
						m_cbApplication = new AccountMgmt.BusinessFacade.ComboBoxParent();
						for(int i=0; i<treeViewArchi.SelectedNode.Parent.Nodes.Count; i++)
						{
							m_cbApplication.ListParent.Add(((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Nodes[i].Tag).SelList]).Id);
							comboBoxApplication.Items.Add(treeViewArchi.SelectedNode.Parent.Nodes[i].Text);
							if(((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Nodes[i].Tag).SelList]).Id == ((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList])).Id) 
								comboBoxApplication.SelectedIndex = i;
						}
						break;
					case 3: //new profile
						groupBoxArchi.Text = "Profile";
						m_cbProject = new AccountMgmt.BusinessFacade.ComboBoxParent();
						for(int i=0; i<treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes.Count; i++)
						{
							m_cbProject.ListParent.Add(((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes[i].Tag).SelList]).Id);
							comboBoxProject.Items.Add(treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes[i].Text);
							if(((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes[i].Tag).SelList]).Id == ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Tag).SelList])).Id) 
								comboBoxProject.SelectedIndex = i;
						}
						m_cbApplication = new AccountMgmt.BusinessFacade.ComboBoxParent();
						for(int i=0; i<treeViewArchi.SelectedNode.Parent.Parent.Nodes.Count; i++)
						{
							m_cbApplication.ListParent.Add(((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Tag).SelList]).Id);
							comboBoxApplication.Items.Add(treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Text);
							if(((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Tag).SelList]).Id == ((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList])).Id) 
								comboBoxApplication.SelectedIndex = i;
						}
						m_cbModule = new AccountMgmt.BusinessFacade.ComboBoxParent();
						for(int i=0; i<treeViewArchi.SelectedNode.Parent.Nodes.Count; i++)
						{
							m_cbModule.ListParent.Add(((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Nodes[i].Tag).SelList]).Id);
							comboBoxModule.Items.Add(treeViewArchi.SelectedNode.Parent.Nodes[i].Text);
							if(((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Nodes[i].Tag).SelList]).Id == ((AccountMgmt.DataAccess.Module)(m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList])).Id) 
								comboBoxModule.SelectedIndex = i;
						}
						//labelOracleProfile.Visible = true;
						textBoxProfileOracle.Visible = true;
						buttonProfileOracle.Visible = true;
						buttonProfileOracle.Enabled = false;
						labelRsrcConsoGroup.Visible = true;
						textBoxRscrConsoGroup.Visible = true;
						break;
					case 4://new role
						groupBoxArchi.Text = "Role";
						break;
				}
			}

			comboBoxProject.EndUpdate();
			comboBoxApplication.EndUpdate();
			comboBoxModule.EndUpdate();
		}

				
		/// <summary>
		/// Sélectionne un noeud de l'arbre pour afficher ses parametres
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnKeyUpTreeViewArchi(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			SelectTreeViewArchi();
		}

		/// <summary>
		/// Sélectionne un noeud de l'arbre pour afficher ses parametres
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfterSelectTreeViewArchi(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			SelectTreeViewArchi();
		}

		private void SelectTreeViewArchi()
		{
			if(treeViewArchi.SelectedNode == null)
			{
				GetArchiParam(-1, 0);
				return;
			}

			if(treeViewArchi.SelectedNode.Tag != null)
				GetArchiParam(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList, ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode);
			else
				GetArchiParam(-1, 0);

			listViewRole.SelectedItems.Clear();
		}

		/// <summary>
		/// Remplire les combobox et sélectionner les parents
		/// </summary>
		/// <param name="selList"></param>
		/// <param name="selNode"></param>
		private void FillComboboxParent(int selList, int selNode)
		{
			comboBoxProject.BeginUpdate();
			comboBoxProject.Items.Clear();
			comboBoxProject.Text = "";
			if(m_cbProject != null)
			{
				m_cbProject.Dispose();
				m_cbProject = null;
			}
			comboBoxApplication.BeginUpdate();
			comboBoxApplication.Items.Clear();
			comboBoxApplication.Text = "";
			if(m_cbApplication != null)
			{
				m_cbApplication.Dispose();
				m_cbApplication = null;
			}
			comboBoxModule.BeginUpdate();
			comboBoxModule.Items.Clear();
			comboBoxModule.Text = "";
			if(m_cbModule != null)
			{
				m_cbModule.Dispose();
				m_cbModule = null;
			}


			ArrayList collecProject = new ArrayList();
			switch(selNode)
			{
				case 0:
					comboBoxProject.SelectedIndex = -1;
					comboBoxApplication.SelectedIndex = -1;
					comboBoxModule.SelectedIndex = -1;
					break;
				case 1:
					comboBoxProject.SelectedIndex = -1;
					comboBoxApplication.SelectedIndex = -1;
					comboBoxModule.SelectedIndex = -1;
					break;
				case 2:
					m_cbProject = new AccountMgmt.BusinessFacade.ComboBoxParent();
					for(int i=0; i<treeViewArchi.SelectedNode.Parent.Parent.Nodes.Count; i++)
					{
						m_cbProject.ListParent.Add(((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Tag).SelList])).Id);
						comboBoxProject.Items.Add(treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Text);
						if(((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).IdProject == ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Tag).SelList])).Id) 
							comboBoxProject.SelectedIndex = i;
					}
					comboBoxApplication.SelectedIndex = -1;
					comboBoxModule.SelectedIndex = -1;
					break;
				case 3:
					m_cbProject = new AccountMgmt.BusinessFacade.ComboBoxParent();
					for(int i=0; i<treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes.Count; i++)
					{
						m_cbProject.ListParent.Add(((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes[i].Tag).SelList])).Id);
						comboBoxProject.Items.Add(treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes[i].Text);
						if(((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Tag).SelList]).Id == ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes[i].Tag).SelList])).Id) 
							comboBoxProject.SelectedIndex = i;
					}
					m_cbApplication = new AccountMgmt.BusinessFacade.ComboBoxParent();
					for(int i=0; i<treeViewArchi.SelectedNode.Parent.Parent.Nodes.Count; i++)
					{
						m_cbApplication.ListParent.Add(((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Tag).SelList])).Id);
						comboBoxApplication.Items.Add(treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Text);
						if(((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList]).Id == ((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Tag).SelList])).Id) 
							comboBoxApplication.SelectedIndex = i;
					}
					comboBoxModule.SelectedIndex = -1;
					break;
				case 4:
					m_cbProject = new AccountMgmt.BusinessFacade.ComboBoxParent();
					for(int i=0; i<treeViewArchi.SelectedNode.Parent.Parent.Parent.Parent.Nodes.Count; i++)
					{
						m_cbProject.ListParent.Add(((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Parent.Nodes[i].Tag).SelList])).Id);
						comboBoxProject.Items.Add(treeViewArchi.SelectedNode.Parent.Parent.Parent.Parent.Nodes[i].Text);
						if(((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Tag).SelList]).Id == ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Parent.Nodes[i].Tag).SelList])).Id) 
							comboBoxProject.SelectedIndex = i;
					}
					m_cbApplication = new AccountMgmt.BusinessFacade.ComboBoxParent();
					for(int i=0; i<treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes.Count; i++)
					{
						m_cbApplication.ListParent.Add(((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes[i].Tag).SelList])).Id);
						comboBoxApplication.Items.Add(treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes[i].Text);
						if(((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Tag).SelList]).Id == ((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Nodes[i].Tag).SelList])).Id) 
							comboBoxApplication.SelectedIndex = i;
					}
					m_cbModule = new AccountMgmt.BusinessFacade.ComboBoxParent();
					for(int i=0; i<treeViewArchi.SelectedNode.Parent.Parent.Nodes.Count; i++)
					{
						m_cbModule.ListParent.Add(((AccountMgmt.DataAccess.Module)(m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Tag).SelList])).Id);
						comboBoxModule.Items.Add(treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Text);
						if(((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList]).Id == ((AccountMgmt.DataAccess.Module)(m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Nodes[i].Tag).SelList])).Id) 
							comboBoxModule.SelectedIndex = i;
					}
					break;
			}

			comboBoxProject.EndUpdate();
			comboBoxApplication.EndUpdate();
			comboBoxModule.EndUpdate();
		}

		/// <summary>
		/// Affichage des paramètres du noeud sélectionné dans l'arbre
		/// </summary>
		/// <param name="selList">Index des listes correspondant au noeud sélectionné</param>
		/// <param name="selTree">Index du noeud de l'arbre sélectionné</param>
		private void GetArchiParam(int selList, int selTree)
		{
			labelTablespace.Visible = false;
			textBoxTablespace.Visible = false;
			//labelOracleProfile.Visible = false;
			textBoxProfileOracle.Visible = false;
			buttonProfileOracle.Visible = false;
			labelRsrcConsoGroup.Visible = false;
			textBoxRscrConsoGroup.Visible = false;
			buttonAdd.Enabled = true;
			buttonModify.Enabled = true;
			buttonDelete.Enabled = true;
			switch(selTree)
			{
				case 0:
					textBoxName.Text = "";
					checkBoxActive.Checked = true;
					textBoxCommentary.Text = "";
					textBoxMadeThe.Text = "";
					textBoxModifiedThe.Text = "";
					groupBoxArchi.Text = "";
					FillComboboxParent(selList, selTree);
					buttonAdd.Enabled = false;
					buttonModify.Enabled = false;
					buttonDelete.Enabled = false;
					break;
				case 1 : //project
					textBoxName.Text = ((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).Name;
					checkBoxActive.Checked = ((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).Activation;
					textBoxCommentary.Text = ((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).Commentary;
					textBoxMadeThe.Text = ((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).DateCreation.ToString("G");
					if(((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).DateModification != new DateTime())
						textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).DateModification.ToString("G");
					else
						textBoxModifiedThe.Text = "";
					groupBoxArchi.Text = "Project";
					FillComboboxParent(selList, selTree);
					break;
				case 2 : //application
					textBoxName.Text = ((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).Name;
					checkBoxActive.Checked = ((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).Activation;
					textBoxCommentary.Text = ((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).Commentary;
					textBoxMadeThe.Text = ((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).DateCreation.ToString("G");
					if(((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).DateModification != new DateTime())
						textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).DateModification.ToString("G");
					else
						textBoxModifiedThe.Text = "";
					groupBoxArchi.Text = "Application";
					labelTablespace.Visible = true;
					textBoxTablespace.Visible = true;
					textBoxTablespace.Text = ((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).DefaultTableSpace;
					FillComboboxParent(selList, selTree);
					break;
				case 3 : //module
					textBoxName.Text = ((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).Name;
					checkBoxActive.Checked = ((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).Activation;
					textBoxCommentary.Text = ((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).Commentary;
					textBoxMadeThe.Text = ((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).DateCreation.ToString("G");
					if(((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).DateModification != new DateTime())
						textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).DateModification.ToString("G");
					else
						textBoxModifiedThe.Text = "";
					groupBoxArchi.Text = "Module";
					FillComboboxParent(selList, selTree);
					break;
				case 4 : //profile
					IsProfileDefined = true;
					textBoxName.Text = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).Name;
					checkBoxActive.Checked = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).Activation;
					textBoxCommentary.Text = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).Commentary;
					textBoxMadeThe.Text = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).DateCreation.ToString("G");
					if(((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).DateModification != new DateTime())
						textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).DateModification.ToString("G");
					else
						textBoxModifiedThe.Text = "";
					groupBoxArchi.Text = "Profile";
					//labelOracleProfile.Visible = true;
					textBoxProfileOracle.Visible = true;
					textBoxProfileOracle.Text = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).OracleProfile;
					buttonProfileOracle.Visible = true;
					labelRsrcConsoGroup.Visible = true;
					textBoxRscrConsoGroup.Visible = true;
					textBoxRscrConsoGroup.Text = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).RsrcConsoGroup;
					FillComboboxParent(selList, selTree);
					break;
				case 5:
					textBoxName.Text = "";
					checkBoxActive.Checked = true;
					textBoxCommentary.Text = "";
					textBoxMadeThe.Text = "";
					textBoxModifiedThe.Text = "";
					groupBoxArchi.Text = "";
					FillComboboxParent(selList, selTree);
					break;
					/*case 5 :
						textBoxName.Text = ((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[selList]).Name;
						checkBoxActive.Checked = ((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[selList]).Activation;
						textBoxCommentary.Text = ((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[selList]).Commentary;
						textBoxMadeThe.Text = ((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[selList]).DateCreation.ToString("G");
						if(((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[selList]).DateModification != new DateTime())
							textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[selList]).DateModification.ToString("G");
						else
							textBoxModifiedThe.Text = "";
						groupBoxArchi.Text = "Role";
						FillComboboxParent(selList, selTree);
						break;*/
				default :
					break;
			}
		}

		
		/// <summary>
		/// Désire créer un nouveau rôle
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCreateNewRole(object sender, System.EventArgs e)
		{
			//mettre tous les champs à null
			comboBoxProject.BeginUpdate();
			comboBoxProject.Items.Clear();
			comboBoxProject.Text = "";
			comboBoxApplication.BeginUpdate();
			comboBoxApplication.Items.Clear();
			comboBoxApplication.Text = "";
			comboBoxModule.BeginUpdate();
			comboBoxModule.Items.Clear();
			comboBoxModule.Text = "";
			textBoxName.Text = "";
			checkBoxActive.Checked = true;
			textBoxCommentary.Text = "";
			textBoxMadeThe.Text = "";
			textBoxModifiedThe.Text = "";
			labelTablespace.Visible = false;
			textBoxTablespace.Text = "";
			textBoxTablespace.Visible = false;
			groupBoxArchi.Text = "Role";
			comboBoxProject.EndUpdate();
			comboBoxApplication.EndUpdate();
			comboBoxModule.EndUpdate();
			//labelOracleProfile.Visible = false;
			textBoxProfileOracle.Text = "";
			textBoxProfileOracle.Visible = false;
			buttonProfileOracle.Visible = false;
			labelRsrcConsoGroup.Visible = false;
			textBoxRscrConsoGroup.Text = "";
			textBoxRscrConsoGroup.Visible = false;
			buttonAdd.Enabled = true;
			buttonModify.Enabled = true;
			buttonDelete.Enabled = true;
		}

		/// <summary>
		/// Sélectionne un rôle pour afficher ses paramètres
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnKeyUpAllRoles(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			SelectRole();
		}

		/// <summary>
		/// Sélectionne un rôle pour afficher ses paramètres
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMouseUpAllRoles(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(!bDragAndDropRole)
				SelectRole();
			bDragAndDropRole = false;
		}
		
		private void OnMouseDownAllRoles(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//bDragAndDropRole = true;
		}
		
		private void OnSelectedIndexChangedAllRoles(object sender, System.EventArgs e)
		{
			/*if(!bDragAndDropRole)
				SelectRole();*/
		}

		private void SelectRole()
		{
			//force la sélection éventuelle d'un noeud de l'arbre à se déselectionner
			treeViewArchi.SelectedNode = null;
			
			if(listViewRole.SelectedIndices.Count == 0)
				return;

			textBoxName.Text = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[listViewRole.SelectedIndices[0]]).Name;
			checkBoxActive.Checked = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[listViewRole.SelectedIndices[0]]).Activation;
			textBoxCommentary.Text = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[listViewRole.SelectedIndices[0]]).Commentary;
			textBoxMadeThe.Text = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[listViewRole.SelectedIndices[0]]).DateCreation.ToString("G");
			if(((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[listViewRole.SelectedIndices[0]]).DateModification != new DateTime())
				textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[listViewRole.SelectedIndices[0]]).DateModification.ToString("G");
			else
				textBoxModifiedThe.Text = "";
			groupBoxArchi.Text = "Role";
			FillComboboxParent(listViewRole.SelectedIndices[0], 5);
		}

		/// <summary>
		/// Ouvre la vue Affectation
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDoubleClickTreeViewProject(object sender, System.EventArgs e)
		{
			if(treeViewArchi.SelectedNode.Tag == null)
				return;
			if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode != 4)
				return;
			
			frmTabControle.SelectedTab = tabPageAffectation;
		}

		/// <summary>
		/// Ouvre la vue Affectation
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickShowAffectedUsers(object sender, System.EventArgs e)
		{
			frmTabControle.SelectedTab = tabPageAffectation;
		}

		/// <summary>
		/// Ouvrir l'arbre de l'onglet "Account" de la même façon que l'arbre de l'onglet "Affectation"
		/// </summary>
		private void SetTreeViewAccountLikeTreeViewAffectation()
		{
			if(treeViewArchiAffectation.SelectedNode == null)
			{
				treeViewArchi.SelectedNode = null;
				return;
			}
			if(treeViewArchiAffectation.SelectedNode.Tag == null)
			{
				treeViewArchi.SelectedNode = treeViewArchi.Nodes[0];
				if(treeViewArchiAffectation.SelectedNode.IsExpanded)
					treeViewArchi.SelectedNode.Expand();
				else
					treeViewArchi.SelectedNode.Toggle();
				return;
			}
			
			if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelNode == 5)
				return;

			switch(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelNode)
			{
				case 1:
					treeViewArchi.SelectedNode = treeViewArchi.Nodes[0].Nodes[treeViewArchiAffectation.SelectedNode.Index];
					break;
				case 2:
					treeViewArchi.SelectedNode = treeViewArchi.Nodes[0].Nodes[treeViewArchiAffectation.SelectedNode.Parent.Index].Nodes[treeViewArchiAffectation.SelectedNode.Index];
					break;
				case 3:
					treeViewArchi.SelectedNode = treeViewArchi.Nodes[0].Nodes[treeViewArchiAffectation.SelectedNode.Parent.Parent.Index].Nodes[treeViewArchiAffectation.SelectedNode.Parent.Index].Nodes[treeViewArchiAffectation.SelectedNode.Index];
					break;
				case 4:
					treeViewArchi.SelectedNode = treeViewArchi.Nodes[0].Nodes[treeViewArchiAffectation.SelectedNode.Parent.Parent.Parent.Index].Nodes[treeViewArchiAffectation.SelectedNode.Parent.Parent.Index].Nodes[treeViewArchiAffectation.SelectedNode.Parent.Index].Nodes[treeViewArchiAffectation.SelectedNode.Index];
					break;
			}
			if(treeViewArchiAffectation.SelectedNode.IsExpanded)
				treeViewArchi.SelectedNode.Expand();
			else
				treeViewArchi.SelectedNode.Toggle();

			SelectTreeViewArchi();
		}

		/// <summary>
		/// Définit le type de données à dragdroper
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnItemDragAllRoles(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			bDragAndDropRole = true;
			if(listViewRole.SelectedItems.Count > 0)
				listViewRole.DoDragDrop(listViewRole.SelectedItems, System.Windows.Forms.DragDropEffects.Link);
		}

		/// <summary>
		/// Définit le type de lien
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDragEnterTreeViewProject(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(treeViewArchi.SelectedNode == null)
				return;
			if(!e.Data.GetDataPresent(listViewRole.SelectedItems.GetType()))
				return;

			if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode == 4)
				e.Effect = System.Windows.Forms.DragDropEffects.Link;
			else
				e.Effect = System.Windows.Forms.DragDropEffects.None;
		}

		/// <summary>
		/// Ajoute un rôle au profile sélectionné
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDragDropTreeViewArchi(object sender, System.Windows.Forms.DragEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if(!e.Data.GetDataPresent(listViewRole.SelectedItems.GetType()))
				return;

			ListView.SelectedListViewItemCollection itemCollection = ((ListView.SelectedListViewItemCollection)e.Data.GetData(listViewRole.SelectedItems.GetType()));
			bool bContinue = true;
			TreeNode newNode = null;
			AccountMgmt.BusinessFacade.TreeNodeArchi treeNodeIndex = null;
			int selection;
			for(int numListRoles = 0; numListRoles<itemCollection.Count; numListRoles++)
			{
				//recherche si le role n'appartient pas déjà au profile
				bContinue = true;
				for(int i=0; i<treeViewArchi.SelectedNode.Nodes.Count; i++)
				{
					selection = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Nodes[i].Tag).SelList;
					if(((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[selection]).Name == itemCollection[numListRoles].Text)
						bContinue = false;
				}
				//ajout du role au profile
				if(bContinue)
				{
					//ajout en base du lien entre le rôle et le profile
					AccountMgmt.DataAccess.Right newRight = new AccountMgmt.DataAccess.Right();
					newRight.IdProfile = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).Id;
					newRight.IdRole = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[itemCollection[numListRoles].Index]).Id;
					newRight.Activation = true;
					newRight.DateCreation = DateTime.Now;
					OracleTransaction transaction=m_connectedUser.Connection.BeginTransaction();
					if(newRight.Add(m_connectedUser.Connection, transaction, ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[itemCollection[numListRoles].Index]).Name))
					{
						transaction.Commit();
					
						//ajout dans la liste
						AccountMgmt.DataAccess.Role newRole = new AccountMgmt.DataAccess.Role();
						newRole.Id = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[itemCollection[numListRoles].Index]).Id;
						newRole.Name = itemCollection[numListRoles].Text;
						newRole.DateCreation = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[itemCollection[numListRoles].Index]).DateCreation;
						newRole.DateModification = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[itemCollection[numListRoles].Index]).DateModification;
						newRole.Commentary = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[itemCollection[numListRoles].Index]).Commentary;
						newRole.Activation = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[itemCollection[numListRoles].Index]).Activation;
						newRole.IdProfile = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).Id;
						m_treeViewArchi.ListRoles.Add(newRole);

						//ajout dans l'arbre
						newNode = new TreeNode(itemCollection[numListRoles].Text, 4, 4);
						treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
						treeNodeIndex.SelList = m_treeViewArchi.ListRoles.Count-1;
						treeNodeIndex.SelNode = 5;
						newNode.Tag = treeNodeIndex;
						if(!((AccountMgmt.DataAccess.Role)(m_listViewRoles.ListRoles[itemCollection[numListRoles].Index])).Activation)
							newNode.BackColor = System.Drawing.Color.Tomato;
						treeViewArchi.SelectedNode.Nodes.Add(newNode);
						treeViewArchi.Focus();
					}
					else
						transaction.Rollback();
				}
			}
			Cursor.Current = Cursors.Default;
		}
		
		private void OnItemDragTreeViewArchi(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			if(treeViewArchi.SelectedNode != null)
				treeViewArchi.DoDragDrop(treeViewArchi.SelectedNode, System.Windows.Forms.DragDropEffects.Link);
		}

		private void OnDragEnterRoles(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(!e.Data.GetDataPresent(treeViewArchi.SelectedNode.GetType()))
				return;

			e.Effect = System.Windows.Forms.DragDropEffects.Link;
		}
		
		private void OnDragDropRoles(object sender, System.Windows.Forms.DragEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if(!e.Data.GetDataPresent(treeViewArchi.SelectedNode.GetType()))
				return;
			if(treeViewArchi.SelectedNode == null)
				return;
			if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode != 5)
				return;

			int selection = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList;
			//supprimer en base le lien entre le profile et le rôle
			AccountMgmt.DataAccess.Right delRight = new AccountMgmt.DataAccess.Right();
			delRight.IdProfile = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList]).Id;
			delRight.IdRole = ((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[selection]).Id;
			if(!delRight.Delete(m_connectedUser.Connection))
				return;

			//mettre à jour les indices
			for(int i=treeViewArchi.SelectedNode.Index+1; i<treeViewArchi.SelectedNode.Parent.Nodes.Count; i++)
			{
				((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Nodes[i].Tag).SelList = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Nodes[i].Tag).SelList-1;
			}
			//supprime le role du profile
			m_treeViewArchi.ListRoles.RemoveAt(selection);
			treeViewArchi.SelectedNode.Remove();

			Cursor.Current = Cursors.Default;
		}

		
		/// <summary>
		/// On interdit la sélection d'un autre projet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSelectedIndexChangedProject(object sender, System.EventArgs e)
		{
			if(treeViewArchi.SelectedNode == null)
				return;
			if(treeViewArchi.SelectedNode.Tag == null)
				return;

			int selNode = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode;
			switch(selNode)
			{
				case 1: //projet (creation d'une application)
					if(((long)m_cbProject.ListParent[comboBoxProject.SelectedIndex]) != ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList])).Id) 
					{
						for(int i=0; i<comboBoxProject.Items.Count; i++)
						{
							if(((long)m_cbProject.ListParent[i]) == ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList])).Id)
								comboBoxProject.SelectedIndex = i;
						}
					}
					break;
				case 2: //application
					if(((long)m_cbProject.ListParent[comboBoxProject.SelectedIndex]) != ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList])).Id) 
					{
						for(int i=0; i<comboBoxProject.Items.Count; i++)
						{
							if(((long)m_cbProject.ListParent[i]) == ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList])).Id)
								comboBoxProject.SelectedIndex = i;
						}
					}
					break;
				case 3: //module
					if(((long)m_cbProject.ListParent[comboBoxProject.SelectedIndex]) != ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Tag).SelList])).Id) 
					{
						for(int i=0; i<comboBoxProject.Items.Count; i++)
						{
							if(((long)m_cbProject.ListParent[i]) == ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Tag).SelList])).Id)
								comboBoxProject.SelectedIndex = i;
						}
					}
					break;
				case 4: //profile
					if(((long)m_cbProject.ListParent[comboBoxProject.SelectedIndex]) != ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Tag).SelList])).Id) 
					{
						for(int i=0; i<comboBoxProject.Items.Count; i++)
						{
							if(((long)m_cbProject.ListParent[i]) == ((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Parent.Tag).SelList])).Id)
								comboBoxProject.SelectedIndex = i;
						}
					}
					break;
			}
		}

		/// <summary>
		/// On interdit la sélection d'une autre application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSelectedIndexChangedApplication(object sender, System.EventArgs e)
		{
			if(treeViewArchi.SelectedNode == null)
				return;
			if(treeViewArchi.SelectedNode.Tag == null)
				return;

			int selNode = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode;
			switch(selNode)
			{
				case 2: //application (création d'un module)
					if(((long)m_cbApplication.ListParent[comboBoxApplication.SelectedIndex]) != ((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList])).Id) 
					{
						for(int i=0; i<comboBoxApplication.Items.Count; i++)
						{
							if(((long)m_cbApplication.ListParent[i]) == ((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList])).Id)
								comboBoxApplication.SelectedIndex = i;
						}
					}
					break;
				case 3: //module
					if(((long)m_cbApplication.ListParent[comboBoxApplication.SelectedIndex]) != ((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList])).Id) 
					{
						for(int i=0; i<comboBoxApplication.Items.Count; i++)
						{
							if(((long)m_cbApplication.ListParent[i]) == ((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList])).Id)
								comboBoxApplication.SelectedIndex = i;
						}
					}
					break;
				case 4: //profile
					if(((long)m_cbApplication.ListParent[comboBoxApplication.SelectedIndex]) != ((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Tag).SelList])).Id) 
					{
						for(int i=0; i<comboBoxApplication.Items.Count; i++)
						{
							if(((long)m_cbApplication.ListParent[i]) == ((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Parent.Tag).SelList])).Id)
								comboBoxApplication.SelectedIndex = i;
						}
					}
					break;
			}
		}

		/// <summary>
		/// On interdit la sélection d'un autre module
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSelectedIndexChangedModule(object sender, System.EventArgs e)
		{
			if(treeViewArchi.SelectedNode == null)
				return;
			if(treeViewArchi.SelectedNode.Tag == null)
				return;

			int selNode = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode;
			switch(selNode)
			{
				case 3: //module (creation d'un profile)
					if(((long)m_cbModule.ListParent[comboBoxModule.SelectedIndex]) != ((AccountMgmt.DataAccess.Module)(m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList])).Id) 
					{
						for(int i=0; i<comboBoxModule.Items.Count; i++)
						{
							if(((long)m_cbModule.ListParent[i]) == ((AccountMgmt.DataAccess.Module)(m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList])).Id)
								comboBoxModule.SelectedIndex = i;
						}
					}
					break;
				case 4: //profile
					if(((long)m_cbModule.ListParent[comboBoxModule.SelectedIndex]) != ((AccountMgmt.DataAccess.Module)(m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList])).Id) 
					{
						for(int i=0; i<comboBoxModule.Items.Count; i++)
						{
							if(((long)m_cbModule.ListParent[i]) == ((AccountMgmt.DataAccess.Module)(m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Parent.Tag).SelList])).Id)
								comboBoxModule.SelectedIndex = i;
						}
					}
					break;
			}
		}

		/// <summary>
		/// Le profile oracle a changé
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTextChangedOracleProfile(object sender, System.EventArgs e)
		{
			if(IsProfileDefined) //le profile vient d'être affiché
			{
				IsProfileDefined = false;
				return;
			}

			buttonProfileOracle.Enabled = false;
		}

		/// <summary>
		/// Affichage des utilisateurs affectés
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickOracleProfile(object sender, System.EventArgs e)
		{
			frmOracleProfile oracleProfile = new frmOracleProfile();
			oracleProfile.SetConnexion(m_connectedUser.Connection);
			oracleProfile.OracleProfile = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).OracleProfile;
			oracleProfile.IdProfile = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).Id;
			oracleProfile.ShowDialog();
		}

		/// <summary>
		/// Ajout d'un élément dans l'archivage
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickAddButton(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			int selNode = 0;
			if(treeViewArchi.SelectedNode != null)
			{
				if(treeViewArchi.SelectedNode.Tag != null)
					selNode = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode;
			}
			else
				selNode = 4;
			TreeNode treeNode = null;
			AccountMgmt.BusinessFacade.TreeNodeArchi treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
			switch(selNode)
			{
				case 0://ajout d un projet
					//tests
					if(textBoxName.Text == "")
					{
						MessageBox.Show("Veuillez donner un nom au projet.");
						return;
					}
					//ajout en base
					AccountMgmt.DataAccess.Project newProject = new AccountMgmt.DataAccess.Project();
					newProject.Name = textBoxName.Text.ToUpper();
					newProject.Activation = checkBoxActive.Checked;
					newProject.Commentary = textBoxCommentary.Text;
					newProject.DateCreation = DateTime.Now;
					if(!newProject.Add(m_connectedUser.Connection))
						return;
					textBoxName.Text = textBoxName.Text.ToUpper();
					textBoxMadeThe.Text = newProject.DateCreation.ToString("G");
					//ajout dans la liste
					m_treeViewArchi.ListProjects.Add(newProject);

					//ajout dans l'arbre
					treeNode = new TreeNode(textBoxName.Text.ToUpper(), 0, 0);
					treeNodeIndex.SelList = m_treeViewArchi.ListProjects.Count-1;
					treeNodeIndex.SelNode = 1;
					treeNode.Tag = treeNodeIndex;
					if(!checkBoxActive.Checked)
						treeNode.BackColor = System.Drawing.Color.Tomato;
					treeViewArchi.Nodes[0].Nodes.Add(treeNode);
					treeViewArchi.Nodes[0].Expand();
					break;
				case 1://ajout d une application
					//tests 
					if(textBoxName.Text == "")
					{
						MessageBox.Show("Veuillez donner un nom à l'application.");
						return;
					}
					if(comboBoxProject.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner un projet.");
						return;
					}
					//ajout en base
					AccountMgmt.DataAccess.Application newApplication = new AccountMgmt.DataAccess.Application();
					newApplication.Name = textBoxName.Text.ToUpper();
					newApplication.Activation = checkBoxActive.Checked;
					newApplication.Commentary = textBoxCommentary.Text;
					newApplication.DateCreation = DateTime.Now;
					newApplication.DefaultTableSpace = textBoxTablespace.Text.ToUpper();
					newApplication.IdProject = ((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).Id;
					if(!newApplication.Add(m_connectedUser.Connection))
						return;
					textBoxName.Text = textBoxName.Text.ToUpper();
					textBoxTablespace.Text = textBoxTablespace.Text.ToUpper();
					textBoxMadeThe.Text = newApplication.DateCreation.ToString("G");
					//ajout dans la liste
					m_treeViewArchi.ListApplication.Add(newApplication);

					//ajout dans l'arbre
					treeNode = new TreeNode(textBoxName.Text.ToUpper(), 1, 1);
					treeNodeIndex.SelList = m_treeViewArchi.ListApplication.Count-1;
					treeNodeIndex.SelNode = 2;
					treeNode.Tag = treeNodeIndex;
					if(!checkBoxActive.Checked)
						treeNode.BackColor = System.Drawing.Color.Tomato;
					treeViewArchi.SelectedNode.Nodes.Add(treeNode);
					treeViewArchi.SelectedNode.Expand();
					break;
				case 2://ajout d un module
					//tests 
					if(textBoxName.Text == "")
					{
						MessageBox.Show("Veuillez donner un nom au module.");
						return;
					}
					if(comboBoxProject.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner un projet.");
						return;
					}
					if(comboBoxApplication.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner une application.");
						return;
					}
					//ajout en base
					AccountMgmt.DataAccess.Module newModule = new AccountMgmt.DataAccess.Module();
					newModule.Name = textBoxName.Text.ToUpper();
					newModule.Activation = checkBoxActive.Checked;
					newModule.Commentary = textBoxCommentary.Text;
					newModule.DateCreation = DateTime.Now;
					newModule.IdApplication = ((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).Id;
					if(!newModule.Add(m_connectedUser.Connection))
						return;
					textBoxName.Text = textBoxName.Text.ToUpper();
					textBoxMadeThe.Text = newModule.DateCreation.ToString("G");
					//ajout dans la liste
					m_treeViewArchi.ListModules.Add(newModule);

					//ajout dans l'arbre
					treeNode = new TreeNode(textBoxName.Text.ToUpper(), 2, 2);
					treeNodeIndex.SelList = m_treeViewArchi.ListModules.Count-1;
					treeNodeIndex.SelNode = 3;
					treeNode.Tag = treeNodeIndex;
					if(!checkBoxActive.Checked)
						treeNode.BackColor = System.Drawing.Color.Tomato;
					treeViewArchi.SelectedNode.Nodes.Add(treeNode);
					treeViewArchi.SelectedNode.Expand();
					break;
				case 3://ajout d un profile
					//tests 
					if(textBoxName.Text == "")
					{
						MessageBox.Show("Veuillez donner un nom au profile.");
						return;
					}
					if(comboBoxProject.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner un projet.");
						return;
					}
					if(comboBoxApplication.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner une application.");
						return;
					}
					if(comboBoxModule.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner un module.");
						return;
					}
					//ajout en base
					AccountMgmt.DataAccess.Profile newProfile = new AccountMgmt.DataAccess.Profile();
					newProfile.Name = textBoxName.Text.ToUpper();
					newProfile.Activation = checkBoxActive.Checked;
					newProfile.Commentary = textBoxCommentary.Text;
					newProfile.DateCreation = DateTime.Now;
					newProfile.IdModule = ((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList]).Id;
					if(textBoxProfileOracle.Text == "")
						textBoxProfileOracle.Text = "DEFAULT";
					newProfile.OracleProfile = textBoxProfileOracle.Text.ToUpper();
					newProfile.RsrcConsoGroup = textBoxRscrConsoGroup.Text.ToUpper();
					if(!newProfile.Add(m_connectedUser.Connection))
						return;
					textBoxName.Text = textBoxName.Text.ToUpper();
					textBoxMadeThe.Text = newProfile.DateCreation.ToString("G");
					textBoxProfileOracle.Text = newProfile.OracleProfile;
					textBoxRscrConsoGroup.Text = textBoxRscrConsoGroup.Text.ToUpper();
					//ajout dans la liste
					m_treeViewArchi.ListProfiles.Add(newProfile);

					//ajout dans l'arbre
					treeNode = new TreeNode(textBoxName.Text.ToUpper(), 3, 3);
					treeNodeIndex.SelList = m_treeViewArchi.ListProfiles.Count-1;
					treeNodeIndex.SelNode = 4;
					treeNode.Tag = treeNodeIndex;
					if(!checkBoxActive.Checked)
						treeNode.BackColor = System.Drawing.Color.Tomato;
					treeViewArchi.SelectedNode.Nodes.Add(treeNode);
					treeViewArchi.SelectedNode.Expand();
					buttonProfileOracle.Enabled = true;
					break;
				case 4: //ajout d'un rôle
					//tests 
					if(textBoxName.Text == "")
					{
						MessageBox.Show("Veuillez donner un nom au profile.");
						return;
					}

					//ajout en base
					AccountMgmt.DataAccess.Role newRole = new AccountMgmt.DataAccess.Role();
					newRole.Name = textBoxName.Text.ToUpper();
					newRole.Activation = checkBoxActive.Checked;
					newRole.Commentary = textBoxCommentary.Text;
					newRole.DateCreation = DateTime.Now;
					if(!newRole.Add(m_connectedUser.Connection))
						return;

					textBoxName.Text = textBoxName.Text.ToUpper();
					textBoxMadeThe.Text = newRole.DateCreation.ToString("G");
					//ajout dans la liste
					m_listViewRoles.ListRoles.Add(newRole);

					//ajout dans la listView
					listViewRole.Items.Add(textBoxName.Text);
					listViewRole.Items[listViewRole.Items.Count-1].Tag = newRole.Id;
					if(!checkBoxActive.Checked)
						listViewRole.Items[listViewRole.Items.Count-1].BackColor = System.Drawing.Color.Tomato;
					treeViewArchi.SelectedNode.Expand();
					break;
			}

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Modifie un élément dans l'archivage
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickModifyButton(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			if(listViewRole.SelectedItems.Count == 0)
			{
				if(treeViewArchi.SelectedNode == null)
				{
					MessageBox.Show("Veuillez sélectionner un objet avant de vouloir le modifier");
					return;
				}
				if(treeViewArchi.SelectedNode.Tag == null)
				{
					MessageBox.Show("Problème : l'objet que vous souhaitez modifier n'est pas valide.");
					return;
				}
			}
				
			int	selNode, selList;
			if(listViewRole.SelectedItems.Count == 0)
			{
				selNode = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode;
				selList = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList;
			}
			else //si sélection d'un rôle dans la liste
			{
				selNode = 5;
				selList = listViewRole.SelectedIndices[0];
			}
			switch(selNode)
			{
				case 1://modif d un projet
					//tests
					if(textBoxName.Text == "")
					{
						MessageBox.Show("Veuillez donner un nom au projet.");
						return;
					}
					//modification en base
					((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).Name = textBoxName.Text.ToUpper();
					((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).Activation = checkBoxActive.Checked;
					((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).Commentary = textBoxCommentary.Text;
					((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).DateModification = DateTime.Now;
					if(!((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).Update(m_connectedUser.Connection))
						return;
					//modifications interface
					textBoxName.Text = textBoxName.Text.ToUpper();
					textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).DateModification.ToString("G");
					
					//modification arbre
					if(!checkBoxActive.Checked)
						treeViewArchi.SelectedNode.BackColor = System.Drawing.Color.Tomato;
					else
						treeViewArchi.SelectedNode.BackColor = System.Drawing.Color.White;
					treeViewArchi.SelectedNode.Text = textBoxName.Text;
					break;
				case 2://modif d une application
					//tests 
					if(textBoxName.Text == "")
					{
						MessageBox.Show("Veuillez donner un nom à l'application.");
						return;
					}
					if(comboBoxProject.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner un projet.");
						return;
					}
					//modification en base
					((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).Name = textBoxName.Text.ToUpper();
					((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).Activation = checkBoxActive.Checked;
					((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).Commentary = textBoxCommentary.Text;
					((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).DateModification = DateTime.Now;
					((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).DefaultTableSpace = textBoxTablespace.Text.ToUpper();
					if(!((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).Update(m_connectedUser.Connection))
						return;
					//modification de l'interface
					textBoxName.Text = textBoxName.Text.ToUpper();
					textBoxTablespace.Text = textBoxTablespace.Text.ToUpper();
					textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).DateModification.ToString("G");
					
					//modification de l'arbre
					if(!checkBoxActive.Checked)
						treeViewArchi.SelectedNode.BackColor = System.Drawing.Color.Tomato;
					else
						treeViewArchi.SelectedNode.BackColor = System.Drawing.Color.White;
					treeViewArchi.SelectedNode.Text = textBoxName.Text;
					break;
				case 3://modif d un module
					//tests 
					if(textBoxName.Text == "")
					{
						MessageBox.Show("Veuillez donner un nom au module.");
						return;
					}
					if(comboBoxProject.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner un projet.");
						return;
					}
					if(comboBoxApplication.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner une application.");
						return;
					}
					//modification en base
					((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).Name = textBoxName.Text.ToUpper();
					((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).Activation = checkBoxActive.Checked;
					((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).Commentary = textBoxCommentary.Text;
					((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).DateModification = DateTime.Now;
					if(!((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).Update(m_connectedUser.Connection))
						return;
					//modification de l'interface
					textBoxName.Text = textBoxName.Text.ToUpper();
					textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).DateModification.ToString("G");
					
					//modification de l'arbre
					if(!checkBoxActive.Checked)
						treeViewArchi.SelectedNode.BackColor = System.Drawing.Color.Tomato;
					else
						treeViewArchi.SelectedNode.BackColor = System.Drawing.Color.White;
					treeViewArchi.SelectedNode.Text = textBoxName.Text;
					break;
				case 4://modif d un profile
					//tests 
					if(textBoxName.Text == "")
					{
						MessageBox.Show("Veuillez donner un nom au profile.");
						return;
					}
					if(comboBoxProject.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner un projet.");
						return;
					}
					if(comboBoxApplication.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner une application.");
						return;
					}
					if(comboBoxModule.SelectedIndex<0)
					{
						MessageBox.Show("Veuillez sélectionner un module.");
						return;
					}
					//modification en base
					((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).Name = textBoxName.Text.ToUpper();
					((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).Activation = checkBoxActive.Checked;
					((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).Commentary = textBoxCommentary.Text;
					((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).DateModification = DateTime.Now;
					//((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).OracleProfile = textBoxProfileOracle.Text.ToUpper();
					((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).RsrcConsoGroup = textBoxRscrConsoGroup.Text.ToUpper();
					if(!((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).Update(m_connectedUser.Connection, textBoxProfileOracle.Text.ToUpper()))
						return;
					//modification de l'interface
					textBoxName.Text = textBoxName.Text.ToUpper();
					textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).DateModification.ToString("G");
					textBoxProfileOracle.Text = textBoxProfileOracle.Text.ToUpper();
					textBoxRscrConsoGroup.Text = textBoxRscrConsoGroup.Text.ToUpper();
					
					//modification de l'arbre
					if(!checkBoxActive.Checked)
						treeViewArchi.SelectedNode.BackColor = System.Drawing.Color.Tomato;
					else
						treeViewArchi.SelectedNode.BackColor = System.Drawing.Color.White;
					treeViewArchi.SelectedNode.Text = textBoxName.Text;
					buttonProfileOracle.Enabled = true;
					break;
				case 5: //modif d'un rôle
					//tests 
					if(textBoxName.Text == "")
					{
						MessageBox.Show("Veuillez donner un nom au profile.");
						return;
					}
					//modification en base
					((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[selList]).Name = textBoxName.Text.ToUpper();
					((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[selList]).Commentary = textBoxCommentary.Text;
					((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[selList]).Activation = checkBoxActive.Checked;
					((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[selList]).DateModification = DateTime.Now;
					if(!((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[selList]).Update(m_connectedUser.Connection))
						return;
					//modification de l'interface
					textBoxName.Text = textBoxName.Text.ToUpper();
					textBoxModifiedThe.Text = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[selList]).DateModification.ToString("G");
					listViewRole.Items[selList].Text = textBoxName.Text;
					if(!checkBoxActive.Checked)
						listViewRole.Items[selList].BackColor = System.Drawing.Color.Tomato;
					else
						listViewRole.Items[selList].BackColor = System.Drawing.Color.White;
					
					break;
			}

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Supprime un élément dans l'archivage
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickDeleteButton(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			if(listViewRole.SelectedItems.Count == 0)
			{
				if(treeViewArchi.SelectedNode == null)
				{
					MessageBox.Show("Veuillez sélectionner un objet avant de vouloir le supprimer");
					return;
				}
			
				if(treeViewArchi.SelectedNode.Tag == null)
				{
					MessageBox.Show("Problème : l'objet que vous souhaitez supprimer n'est pas valide.");
					return;
				}

				if(treeViewArchi.SelectedNode.Nodes.Count != 0)
				{
					MessageBox.Show("Vous devez d'abord supprimer les sous-objets");
					return;
				}
			}

			DialogResult result;
			string strObjectName = "";
			int	selNode, selList;
			if(listViewRole.SelectedItems.Count == 0)
			{
				selNode = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode;
				selList = ((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelList;
			}
			else //si sélection d'un rôle dans la liste
			{
				selNode = 5;
				selList = listViewRole.SelectedIndices[0];
			}
			switch(selNode)
			{
				case 1://suppr d un projet
					strObjectName = ((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).Name;
					result = MessageBox.Show("Etes-vous certain de vouloir supprimer l'objet " + strObjectName + " ?", "", MessageBoxButtons.YesNo);
					if(result == DialogResult.No)
						return;
					if(!((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[selList]).Delete(m_connectedUser.Connection))
						return;
					treeViewArchi.SelectedNode.Remove();
					m_treeViewArchi.ListProjects.RemoveAt(selList);
					//réinit des index
					for(int numProject=0; numProject<treeViewArchi.Nodes[0].Nodes.Count; numProject++)
					{
						if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.Nodes[0].Nodes[numProject].Tag).SelList > selList)
							((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.Nodes[0].Nodes[numProject].Tag).SelList--;
					}
					break;
				case 2://suppr d une application
					strObjectName = ((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).Name;
					result = MessageBox.Show("Etes-vous certain de vouloir supprimer l'objet " + strObjectName + " ?", "", MessageBoxButtons.YesNo);
					if(result == DialogResult.No)
						return;
					if(!((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[selList]).Delete(m_connectedUser.Connection))
						return;
					treeViewArchi.SelectedNode.Remove();
					m_treeViewArchi.ListApplication.RemoveAt(selList);
					//réinit des index
					for(int numProject=0; numProject<treeViewArchi.Nodes[0].Nodes.Count; numProject++)
					{
						for(int numApp=0; numApp<treeViewArchi.Nodes[0].Nodes[numProject].Nodes.Count; numApp++)
						{
							if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.Nodes[0].Nodes[numProject].Nodes[numApp].Tag).SelList > selList)
								((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.Nodes[0].Nodes[numProject].Nodes[numApp].Tag).SelList--;
						}
					}
					break;
				case 3://suppr d un module
					strObjectName = ((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).Name;
					result = MessageBox.Show("Etes-vous certain de vouloir supprimer l'objet " + strObjectName + " ?", "", MessageBoxButtons.YesNo);
					if(result == DialogResult.No)
						return;
					if(!((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[selList]).Delete(m_connectedUser.Connection))
						return;
					treeViewArchi.SelectedNode.Remove();
					m_treeViewArchi.ListModules.RemoveAt(selList);
					//réinit des index
					for(int numProject=0; numProject<treeViewArchi.Nodes[0].Nodes.Count; numProject++)
					{
						for(int numApp=0; numApp<treeViewArchi.Nodes[0].Nodes[numProject].Nodes.Count; numApp++)
						{
							for(int numModule=0; numModule<treeViewArchi.Nodes[0].Nodes[numProject].Nodes[numApp].Nodes.Count; numModule++)
							{
								if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.Nodes[0].Nodes[numProject].Nodes[numApp].Nodes[numModule].Tag).SelList > selList)
									((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.Nodes[0].Nodes[numProject].Nodes[numApp].Nodes[numModule].Tag).SelList--;
							}
						}
					}
					break;
				case 4://suppr d un profile
					strObjectName = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).Name;
					result = MessageBox.Show("Etes-vous certain de vouloir supprimer l'objet " + strObjectName + " ?", "", MessageBoxButtons.YesNo);
					if(result == DialogResult.No)
						return;
					ArrayList listIdUserAffected = null, listUserOracleAffected = null;
					if(!((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).IsAffectedProfile(m_connectedUser.Connection, out listIdUserAffected, out listUserOracleAffected))
						return;
					if(listIdUserAffected != null)
					{
						if(listIdUserAffected.Count != 0)
						{
							result = MessageBox.Show("Ce profile est affecté à au moins un utilisateur, souhaitez-vous toujours le supprimer et donc le désaffecter ?", "", MessageBoxButtons.YesNo);
							if(result == DialogResult.No)
								return;
						}
					}
					if(!((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[selList]).Delete(m_connectedUser.Connection, listIdUserAffected))
						return;
					treeViewArchi.SelectedNode.Remove();
					m_treeViewArchi.ListProfiles.RemoveAt(selList);
					//réinit index
					for(int numProject=0; numProject<treeViewArchi.Nodes[0].Nodes.Count; numProject++)
					{
						for(int numApp=0; numApp<treeViewArchi.Nodes[0].Nodes[numProject].Nodes.Count; numApp++)
						{
							for(int numModule=0; numModule<treeViewArchi.Nodes[0].Nodes[numProject].Nodes[numApp].Nodes.Count; numModule++)
							{
								for(int numProfile=0; numProfile<treeViewArchi.Nodes[0].Nodes[numProject].Nodes[numApp].Nodes[numModule].Nodes.Count; numProfile++)
								{
									if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.Nodes[0].Nodes[numProject].Nodes[numApp].Nodes[numModule].Nodes[numProfile].Tag).SelList > selList)
										((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.Nodes[0].Nodes[numProject].Nodes[numApp].Nodes[numModule].Nodes[numProfile].Tag).SelList--;
								}
							}
						}
					}
					break;
				case 5://suppr d'un rôle
					strObjectName = ((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[selList]).Name;
					result = MessageBox.Show("Etes-vous certain de vouloir supprimer l'objet " + strObjectName + " ?", "", MessageBoxButtons.YesNo);
					if(result == DialogResult.No)
						return;
					if(!((AccountMgmt.DataAccess.Role)m_listViewRoles.ListRoles[selList]).Delete(m_connectedUser.Connection))
						return;
					listViewRole.Items.RemoveAt(selList);
					m_listViewRoles.ListRoles.RemoveAt(selList);
					break;
			}
			SelectTreeViewArchi();

			Cursor.Current = Cursors.Default;
		}

		#endregion

		// Gestion de l'onglet Affectation
		#region

		/// <summary>
		/// Récupère la structure des comptes
		/// </summary>
		/// <returns>Erreur si problème lors de la recherche des comptes</returns>
		private bool GetArchiAffectation()
		{
			//arbre de l'onglet Affectation
			treeViewArchiAffectation.BeginUpdate();
			treeViewArchiAffectation.Nodes[0].Nodes.Clear();
			treeViewArchiAffectation.Nodes[0].Tag = null;
			textBoxProfileCommentary.Text = "";

			//remplir l arbre
			TreeNode treeNodeProjet = null, treeNodeApplication = null, treeNodeModule = null, treeNodeProfile = null, treeNodeRole = null;
			AccountMgmt.BusinessFacade.TreeNodeArchi treeNodeIndex = null;
			for(int numProject=0; numProject<m_treeViewArchi.ListProjects.Count; numProject++)
			{
				//ajout du noeud "Projet"
				treeNodeProjet = new TreeNode(((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[numProject])).Name, 0, 0);
				treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
				treeNodeIndex.SelList = numProject;
				treeNodeIndex.SelNode = 1;
				treeNodeProjet.Tag = treeNodeIndex;
				if(!((AccountMgmt.DataAccess.Project)(m_treeViewArchi.ListProjects[numProject])).Activation)
					treeNodeProjet.BackColor = System.Drawing.Color.Tomato;
				treeViewArchiAffectation.Nodes[0].Nodes.Add(treeNodeProjet);

				//ajout du noeud "Application"
				for(int numApp=0; numApp<m_treeViewArchi.ListApplication.Count; numApp++)
				{
					if(((AccountMgmt.DataAccess.Project)m_treeViewArchi.ListProjects[numProject]).Id == ((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[numApp]).IdProject)
					{
						treeNodeApplication = new TreeNode(((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[numApp])).Name, 1, 1);
						treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
						treeNodeIndex.SelList = numApp;
						treeNodeIndex.SelNode = 2;
						treeNodeApplication.Tag = treeNodeIndex;
						if(!((AccountMgmt.DataAccess.Application)(m_treeViewArchi.ListApplication[numApp])).Activation)
							treeNodeApplication.BackColor = System.Drawing.Color.Tomato;
						treeNodeProjet.Nodes.Add(treeNodeApplication);

						//ajout du noeud "Module"
						for(int numModule=0; numModule<m_treeViewArchi.ListModules.Count; numModule++)
						{
							if(((AccountMgmt.DataAccess.Application)m_treeViewArchi.ListApplication[numApp]).Id == ((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[numModule]).IdApplication)
							{
								treeNodeModule = new TreeNode(((AccountMgmt.DataAccess.Module)(m_treeViewArchi.ListModules[numModule])).Name, 2, 2);
								treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
								treeNodeIndex.SelList = numModule;
								treeNodeIndex.SelNode = 3;
								treeNodeModule.Tag = treeNodeIndex;
								if(!((AccountMgmt.DataAccess.Module)(m_treeViewArchi.ListModules[numModule])).Activation)
									treeNodeModule.BackColor = System.Drawing.Color.Tomato;
								treeNodeApplication.Nodes.Add(treeNodeModule);
								
								//ajout du noeud "Profile"
								for(int numProfile=0; numProfile<m_treeViewArchi.ListProfiles.Count; numProfile++)
								{
									if(((AccountMgmt.DataAccess.Module)m_treeViewArchi.ListModules[numModule]).Id == ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[numProfile]).IdModule )
									{			
										treeNodeProfile = new TreeNode(((AccountMgmt.DataAccess.Profile)(m_treeViewArchi.ListProfiles[numProfile])).Name, 3, 3);
										treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
										treeNodeIndex.SelList = numProfile;
										treeNodeIndex.SelNode = 4;
										treeNodeProfile.Tag = treeNodeIndex;
										if(!((AccountMgmt.DataAccess.Profile)(m_treeViewArchi.ListProfiles[numProfile])).Activation)
											treeNodeProfile.BackColor = System.Drawing.Color.Tomato;
										treeNodeModule.Nodes.Add(treeNodeProfile);
										
										//ajout du noeud "Role"
										if(m_connectedUser.UserConnected == null || m_connectedUser.UserConnected.Admin == AccountMgmt.Common.Constants.AdminLevel)
										{
											for(int numRole=0; numRole<m_treeViewArchi.ListRoles.Count; numRole++)
											{
												if(((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[numProfile]).Id == ((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[numRole]).IdProfile)
												{							
													treeNodeRole = new TreeNode(((AccountMgmt.DataAccess.Role)(m_treeViewArchi.ListRoles[numRole])).Name, 4, 4);
													treeNodeIndex = new AccountMgmt.BusinessFacade.TreeNodeArchi();
													treeNodeIndex.SelList = numRole;
													treeNodeIndex.SelNode = 5;
													treeNodeRole.Tag = treeNodeIndex;
													if(!((AccountMgmt.DataAccess.Role)(m_treeViewArchi.ListRoles[numRole])).Activation)
														treeNodeRole.BackColor = System.Drawing.Color.Tomato;
													treeNodeProfile.Nodes.Add(treeNodeRole);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}

			treeViewArchiAffectation.EndUpdate();
			
			return true;
		}


		/// <summary>
		/// Affiche dans la liste tous les utilisateurs
		/// </summary>
		private void AffichageAllUsers()
		{
			listViewAllUsers.BeginUpdate();
			listViewAllUsers.Items.Clear();
			
			int compt = 0;
			foreach(AccountMgmt.DataAccess.User myUser in m_listViewAllUsers.ListUsers)
			{
				ListViewItem items = new ListViewItem(myUser.UserOracle);
				items.SubItems.Add(myUser.Name);
				listViewAllUsers.Items.Add(items);
				//listViewAllUsers.Items.Add(myUser.Name);
				listViewAllUsers.Items[compt].Tag = myUser.Id;
				if(!myUser.Activation)
					listViewAllUsers.Items[compt].BackColor = System.Drawing.Color.Tomato;
				else if(myUser.DateEnd != new DateTime() && myUser.DateEnd < DateTime.Now)
					listViewAllUsers.Items[compt].BackColor = System.Drawing.Color.Purple;
				compt++;
			}

			listViewAllUsers.EndUpdate();
		}

		/// <summary>
		/// Ouvrir l'arbre de l'onglet "Affectation" de la même façon que l'arbre de l'onglet "Account"
		/// </summary>
		private void SetTreeViewAffectationLikeTreeViewAccount()
		{
			if(treeViewArchi.SelectedNode == null)
			{
				treeViewArchiAffectation.SelectedNode = null;
				return;
			}
			if(treeViewArchi.SelectedNode.Tag == null)
			{
				treeViewArchiAffectation.SelectedNode = treeViewArchiAffectation.Nodes[0];
				if(treeViewArchi.SelectedNode.IsExpanded)
					treeViewArchiAffectation.SelectedNode.Expand();
				else
					treeViewArchiAffectation.SelectedNode.Toggle();
				return;
			}
			
			if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode == 5)
				return;

			switch(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchi.SelectedNode.Tag).SelNode)
			{
				case 1:
					treeViewArchiAffectation.SelectedNode = treeViewArchiAffectation.Nodes[0].Nodes[treeViewArchi.SelectedNode.Index];
					break;
				case 2:
					treeViewArchiAffectation.SelectedNode = treeViewArchiAffectation.Nodes[0].Nodes[treeViewArchi.SelectedNode.Parent.Index].Nodes[treeViewArchi.SelectedNode.Index];
					break;
				case 3:
					treeViewArchiAffectation.SelectedNode = treeViewArchiAffectation.Nodes[0].Nodes[treeViewArchi.SelectedNode.Parent.Parent.Index].Nodes[treeViewArchi.SelectedNode.Parent.Index].Nodes[treeViewArchi.SelectedNode.Index];
					break;
				case 4:
					treeViewArchiAffectation.SelectedNode = treeViewArchiAffectation.Nodes[0].Nodes[treeViewArchi.SelectedNode.Parent.Parent.Parent.Index].Nodes[treeViewArchi.SelectedNode.Parent.Parent.Index].Nodes[treeViewArchi.SelectedNode.Parent.Index].Nodes[treeViewArchi.SelectedNode.Index];
					break;
			}
			if(treeViewArchi.SelectedNode.IsExpanded)
				treeViewArchiAffectation.SelectedNode.Expand();
			else
				treeViewArchiAffectation.SelectedNode.Toggle();
		}

		/// <summary>
		/// En fonction du noeud sélectionné, recherche les utilisateurs affectés
		/// </summary>
		private bool GetAffectedUsers()
		{
			listViewAffectedUsers.BeginUpdate();
			listViewAffectedUsers.Items.Clear();
			if(m_listAffectedUsers != null)
			{
				m_listAffectedUsers.Dispose();
				m_listAffectedUsers = null;
			}
			bool bResult = false;
			textBoxProfileCommentary.Text = "";

			//on donne les utilisateurs affectés au profile uniquement
			if(treeViewArchiAffectation.SelectedNode == null)
			{
				listViewAffectedUsers.EndUpdate();
				return bResult;
			}
			if(treeViewArchiAffectation.SelectedNode.Tag == null)
			{
				listViewAffectedUsers.EndUpdate();
				return bResult;
			}
			if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelNode != 4)
			{
				listViewAffectedUsers.EndUpdate();
				return bResult;
			}

			//recherche les utilisateurs du profile
			AccountMgmt.DataAccess.AccessAffectation affectedUsers = new AccountMgmt.DataAccess.AccessAffectation();
			if(affectedUsers.Select(m_connectedUser.Connection, ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelList]).Id, "user_oracle"))
			{
				m_listAffectedUsers = new AccountMgmt.BusinessFacade.ListViewAffectedUsers();
				m_listAffectedUsers.ListAffectedUsers = (ArrayList)(affectedUsers.ListAffectedUsers.Clone());
				int compt = 0;
				foreach(AccountMgmt.DataAccess.Affectation myAffectation in m_listAffectedUsers.ListAffectedUsers)
				{
					ListViewItem items = new ListViewItem(myAffectation.AffectedUser.UserOracle);
					items.SubItems.Add(myAffectation.AffectedUser.Name);
					if(myAffectation.Admin)
						items.SubItems.Add("Admin");
					else
						items.SubItems.Add("");
					if(myAffectation.Activation)
						items.SubItems.Add("Activate");
					else
						items.SubItems.Add("");
					listViewAffectedUsers.Items.Add(items);
					//listViewAffectedUsers.Items.Add(myAffectation.AffectedUser.Name);
					listViewAffectedUsers.Items[compt].Tag = myAffectation.AffectedUser.Id;
					if(!myAffectation.AffectedUser.Activation)
						listViewAffectedUsers.Items[compt].BackColor = System.Drawing.Color.Tomato;
					else if(myAffectation.AffectedUser.DateEnd != new DateTime() && myAffectation.AffectedUser.DateEnd < DateTime.Now)
						listViewAffectedUsers.Items[compt].BackColor = System.Drawing.Color.Purple;
					compt++;
				}
				bResult = true;
			}

			//commentaires du profile sélectionné
			textBoxProfileCommentary.Text = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelList]).Commentary;
					
			affectedUsers.Dispose();
			listViewAffectedUsers.EndUpdate();

			return bResult;
		}

		
		private void OnAfterSelectArchiAffectation(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			GetAffectedUsers();
		}
		private void OnDoubleClickTreeViewArchiAffectation(object sender, System.EventArgs e)
		{
			GetAffectedUsers();
		}

		private void OnItemDragAllUsers(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			if(listViewAllUsers.SelectedItems.Count > 0)
				listViewAllUsers.DoDragDrop(listViewAllUsers.SelectedItems, System.Windows.Forms.DragDropEffects.Link);
		}

		private void OnDragEnterAffectedUsers(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(treeViewArchiAffectation.SelectedNode == null)
				return;
			if(!e.Data.GetDataPresent(listViewAllUsers.SelectedItems.GetType()))
				return;

			if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelNode == 4)
				e.Effect = System.Windows.Forms.DragDropEffects.Link;
			else
				e.Effect = System.Windows.Forms.DragDropEffects.None;
		}

		private void OnDragDropAffectedUsers(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(!e.Data.GetDataPresent(listViewAllUsers.SelectedItems.GetType()))
				return;
			
			ListView.SelectedListViewItemCollection itemCollection = ((ListView.SelectedListViewItemCollection)e.Data.GetData(listViewAllUsers.SelectedItems.GetType()));
			AffectUsers(itemCollection);
		}

		private void OnClickAffectedUsers(object sender, System.EventArgs e)
		{
			AffectUsers(listViewAllUsers.SelectedItems);
		}

		/// <summary>
		/// Affecte les utilisateurs sélectionnés au profile
		/// <param name="itemCollection">Liste des utilisateurs sélectionnés</param>
		/// </summary>
		private void AffectUsers(ListView.SelectedListViewItemCollection itemCollection)
		{
			Cursor.Current = Cursors.WaitCursor;

			if(treeViewArchiAffectation.SelectedNode == null)
			{
				MessageBox.Show("Un profile doit être sélectionné.");
				return;
			}
			if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelNode != 4)
			{
				MessageBox.Show("Un profile doit être sélectionné.");
				return;
			}
			
			bool bContinue = true;
			int compt = listViewAffectedUsers.Items.Count;
			for(int numListUsers = 0; numListUsers<itemCollection.Count; numListUsers++)
			{
				//on ne peut affecter un utilisateur à un profile que s'il est actif
				if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[itemCollection[numListUsers].Index]).Activation)
				{
					//recherche si l'utilisateur n'est pas déjà affecté au profile
					bContinue = true;
					for(int i=0; i<listViewAffectedUsers.Items.Count; i++)
					{
						if(listViewAffectedUsers.Items[i].Text == itemCollection[numListUsers].Text)
							bContinue = false;
					}
					//affecte un utilisateur au profile
					if(bContinue)
					{
						//affectation de l'utilisateur au profile en base
						AccountMgmt.DataAccess.Affectation newAffect = new AccountMgmt.DataAccess.Affectation();
						newAffect.IdUser = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[itemCollection[numListUsers].Index]).Id;
						newAffect.IdProfile = ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelList]).Id;
						newAffect.DateCreation = DateTime.Now;
						newAffect.Activation = true;
						newAffect.Admin = false;
						newAffect.Commentary = "";
						newAffect.AffectedUser = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[itemCollection[numListUsers].Index]);
						ArrayList listRoles = new ArrayList();
						for(int i=0; i<m_treeViewArchi.ListRoles.Count; i++)
						{
							if(((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[i]).IdProfile == ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelList]).Id)
								listRoles.Add(((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[i]));
						}
						if(!newAffect.Add(m_connectedUser.Connection, listRoles, ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[itemCollection[numListUsers].Index]).UserOracle, ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelList]).OracleProfile))
						{
							listRoles.Clear();
							return;
						}
						listRoles.Clear();

						//ajout dans la liste des utilisateurs affectés
						if(m_listAffectedUsers == null)
						{
							m_listAffectedUsers = new AccountMgmt.BusinessFacade.ListViewAffectedUsers();
							m_listAffectedUsers.ListAffectedUsers = new ArrayList();
						}
						m_listAffectedUsers.ListAffectedUsers.Add(/*newUser*/newAffect);

						//ajout dans l'interface
						ListViewItem items = new ListViewItem(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[itemCollection[numListUsers].Index]).UserOracle);
						items.SubItems.Add(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[itemCollection[numListUsers].Index]).Name);
						items.SubItems.Add("");
						if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[itemCollection[numListUsers].Index]).Activation)
							items.SubItems.Add("Activate");
						else
							items.SubItems.Add("");
						listViewAffectedUsers.Items.Add(items);
						//listViewAffectedUsers.Items.Add(itemCollection[numListUsers].Text);
						listViewAffectedUsers.Items[compt].Tag = itemCollection[numListUsers].Tag;
						if(!newAffect.AffectedUser.Activation)
							listViewAffectedUsers.Items[compt].BackColor = System.Drawing.Color.Tomato;
						else if(newAffect.AffectedUser.DateEnd != new DateTime() && newAffect.AffectedUser.DateEnd < DateTime.Now)
							listViewAffectedUsers.Items[compt].BackColor = System.Drawing.Color.Purple;
						compt++;
					}
				}
			}

			Cursor.Current = Cursors.Default;
		}

		private void OnItemDragAffectedUsers(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			if(listViewAffectedUsers.SelectedItems.Count > 0)
				listViewAffectedUsers.DoDragDrop(listViewAffectedUsers.SelectedItems, System.Windows.Forms.DragDropEffects.Link);
		}

		private void OnDragEnterAllUsers(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(treeViewArchiAffectation.SelectedNode == null)
				return;
			if(!e.Data.GetDataPresent(listViewAffectedUsers.SelectedItems.GetType()))
				return;

			if(((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelNode == 4)
				e.Effect = System.Windows.Forms.DragDropEffects.Link;
			else
				e.Effect = System.Windows.Forms.DragDropEffects.None;
		}

		private void OnDragDropAllUsers(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(!e.Data.GetDataPresent(listViewAffectedUsers.SelectedItems.GetType()))
				return;
			
			ListView.SelectedListViewItemCollection itemCollection = ((ListView.SelectedListViewItemCollection)e.Data.GetData(listViewAffectedUsers.SelectedItems.GetType()));
			DesaffectUsers(itemCollection);
		}
		
		private void OnClickDesaffectedUsers(object sender, System.EventArgs e)
		{
			DesaffectUsers(listViewAffectedUsers.SelectedItems);
		}

		/// <summary>
		/// Desaffecte les utilisateurs sélectionnés au profile
		/// <param name="itemCollection">Liste des utilisateurs sélectionnés</param>
		/// </summary>
		private void DesaffectUsers(ListView.SelectedListViewItemCollection itemCollection)
		{
			Cursor.Current = Cursors.WaitCursor;

			//supprime l'utilisateur affecté au profile
			for(int i=itemCollection.Count-1; i>=0; i--)
			{
				//supprime en base l'affectation de l'utilisateur au profile
				AccountMgmt.DataAccess.Affectation newAffect = new AccountMgmt.DataAccess.Affectation();
				newAffect.IdUser = ((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[itemCollection[i].Index]).IdUser;
				newAffect.IdProfile = ((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[itemCollection[i].Index]).IdProfile;
				if(!newAffect.Delete(m_connectedUser.Connection, ((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[itemCollection[i].Index]).AffectedUser.UserOracle))
					return;
				
				//supprime dans la liste
				m_listAffectedUsers.ListAffectedUsers.RemoveAt(itemCollection[i].Index);
				//supprime dans l'interface
				listViewAffectedUsers.Items.RemoveAt(itemCollection[i].Index);
			}

			Cursor.Current = Cursors.Default;
		}

		
		private void OnShowParameters(object sender, System.EventArgs e)
		{
			if(listViewAffectedUsers.SelectedIndices.Count == 0)
				return;

			ShowAffectedUserParameters(listViewAffectedUsers.SelectedIndices[0]);
		}

		
		private void OnDoubleClickAffectedUser(object sender, System.EventArgs e)
		{
			if(listViewAffectedUsers.SelectedIndices.Count == 0)
				return;

			ShowAffectedUserParameters(listViewAffectedUsers.SelectedIndices[0]);
		}

		private void ShowAffectedUserParameters(int selection)
		{
			frmAffectedUser myFrmAffectedUser = new frmAffectedUser();
			myFrmAffectedUser.SetProfileName(((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelList]).Name);
			myFrmAffectedUser.SetUserName(((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[selection]).AffectedUser.Name);
			myFrmAffectedUser.SetAffectedUser(((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[selection]));
			myFrmAffectedUser.SetConnexion(m_connectedUser.Connection);
			//recherche la liste des roles associés au profile
			ArrayList listRoles = new ArrayList();
			for(int i=0; i<m_treeViewArchi.ListRoles.Count; i++)
			{
				if(((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[i]).IdProfile == ((AccountMgmt.DataAccess.Profile)m_treeViewArchi.ListProfiles[((AccountMgmt.BusinessFacade.TreeNodeArchi)treeViewArchiAffectation.SelectedNode.Tag).SelList]).Id)
					listRoles.Add(((AccountMgmt.DataAccess.Role)m_treeViewArchi.ListRoles[i]));
			}
			myFrmAffectedUser.SetListRoles(listRoles);
			listRoles.Clear();
			myFrmAffectedUser.SetUserOracle(((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[selection]).AffectedUser.UserOracle);
			myFrmAffectedUser.ShowDialog();

			//modifie l'utilisateur affecte dans la liste
			//listViewAffectedUsers.Items[selection].Text = ((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[selection]).AffectedUser.Name;
			if(((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[selection]).Admin)
				listViewAffectedUsers.Items[selection].SubItems[2].Text = "Admin";
			else
				listViewAffectedUsers.Items[selection].SubItems[2].Text = "";
			if(((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[selection]).Activation)
				listViewAffectedUsers.Items[selection].SubItems[3].Text = "Activate";
			else
				listViewAffectedUsers.Items[selection].SubItems[3].Text = "";
			/*listViewAffectedUsers.Items[selection].Tag = ((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[selection]).AffectedUser.Id;
			if(!((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[selection]).AffectedUser.Activation)
				listViewAffectedUsers.Items[selection].BackColor = System.Drawing.Color.Tomato;
			else
			{
				if(((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[selection]).AffectedUser.DateEnd != new DateTime() && ((AccountMgmt.DataAccess.Affectation)m_listAffectedUsers.ListAffectedUsers[selection]).AffectedUser.DateEnd < DateTime.Now)
					listViewAffectedUsers.Items[selection].BackColor = System.Drawing.Color.Purple;
				else
					listViewAffectedUsers.Items[selection].BackColor = System.Drawing.Color.White;
			}*/
					
		}
		#endregion

		//gestion de l onglet User
		#region

		/// <summary>
		/// Tri par service ou pas
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCheckedChangedSortByService(object sender, System.EventArgs e)
		{
			if(checkBoxSortBySrevice.Checked)
				GetAllUsers("u.service");
			else
				GetAllUsers("u.user_oracle");
			AffichageUsers();
		}

		/// <summary>
		/// Affiche dans un tableau la liste des utilisateurs de la base
		/// </summary>
		private void AffichageUsers()
		{
			listViewUsersRetails.BeginUpdate();
			listViewUsersRetails.Items.Clear();

			for(int i=0; i<m_listViewAllUsers.ListUsers.Count; i++)
			{
				ListViewItem items = new ListViewItem(string.Format("{0}", ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).Id));
				items.SubItems.Add(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).Name);
				items.SubItems.Add(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).UserOracle);
				items.SubItems.Add(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).Service);
				if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).Commentary != null)
					items.SubItems.Add(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).Commentary.Replace("\r", " "));
				else
					items.SubItems.Add(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).Commentary);
				items.SubItems.Add(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).Password);
				listViewUsersRetails.Items.Add(items);
				if(!((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).Activation)
					listViewUsersRetails.Items[i].BackColor = System.Drawing.Color.Tomato;
				else if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).DateEnd != new DateTime() && ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[i]).DateEnd < DateTime.Now)
					listViewUsersRetails.Items[i].BackColor = System.Drawing.Color.Purple;
			}

			listViewUsersRetails.EndUpdate();
		}

		/// <summary>
		/// Récupère en base les profiles par défaut permettant d'avoir le nom d'une tablespace
		/// </summary>
		private void GetDefaultTablespace()
		{
			if(m_defaultProfiles != null)
			{
				m_defaultProfiles.Dispose();
				m_defaultProfiles = null;
			}
			
			AccountMgmt.DataAccess.AccessDefaultProfile defaultProfile = new AccountMgmt.DataAccess.AccessDefaultProfile();
			if(defaultProfile.Select(m_connectedUser.Connection))
			{
				m_defaultProfiles = new AccountMgmt.BusinessFacade.ComboBoxDefaultProfiles();
				m_defaultProfiles.ListDefaultProfiles = ((ArrayList)defaultProfile.ListDefaultProfile.Clone());
				m_defaultProfiles.ListDefaultTablespace = ((ArrayList)defaultProfile.ListDefaultTablespace.Clone());
			}

			defaultProfile.Dispose();
		}


		/// <summary>
		/// Remplit la combobox des valeurs possibles de dba
		/// </summary>
		private void AfficheValeursDba()
		{
			//combobox sur dba status
			comboBoxDba.Items.Clear();
			comboBoxDba.Items.Add("Dba");
			comboBoxDba.Items.Add("Responsable");
			comboBoxDba.Items.Add("Default");
			if(m_connectedUser.UserConnected.Admin == AccountMgmt.Common.Constants.AdminLevel)
			{
				labelDba.Visible = true;
				comboBoxDba.Visible = true;
			}
			else
			{
				labelDba.Visible = false;
				comboBoxDba.Visible = false;
			}

			//combobox ou ediat ctrl sur la temporary_tablespace
			GetTemporaryTableSpace();
			if(m_connectedUser.UserConnected.Admin == AccountMgmt.Common.Constants.AdminLevel)
			{
				labelTemporaryTableSpaceUser.Visible = true;
				textBoxTemporaryTableSpaceUser.Visible = false;
				comboBoxTemporaryTableSpaceUser.Visible = true;
			}
			else
			{
				labelTemporaryTableSpaceUser.Visible = false;
				textBoxTemporaryTableSpaceUser.Visible = false;
				comboBoxTemporaryTableSpaceUser.Visible = false;
			}
		}

		/// <summary>
		/// Recherche les tables temporaires disponibles
		/// </summary>
		private void GetTemporaryTableSpace()
		{
			comboBoxTemporaryTableSpaceUser.Items.Clear();
			comboBoxTemporaryTableSpaceUser.Text = "";
			if(m_cbTemporaryTableSpace != null)
			{
				m_cbTemporaryTableSpace.Dispose();
				m_cbTemporaryTableSpace = null;
			}
			
			AccountMgmt.DataAccess.AccessTemporaryTableSpace temporaryTableSpace = new AccountMgmt.DataAccess.AccessTemporaryTableSpace();
			if(temporaryTableSpace.Select(m_connectedUser.Connection))
			{
				m_cbTemporaryTableSpace = new AccountMgmt.BusinessFacade.ComboBoxTemporaryTableSpace();
				m_cbTemporaryTableSpace.ListTemporaryTableSpace = ((ArrayList)temporaryTableSpace.TemporaryTableSpaceList.Clone());
				for(int i=0; i<m_cbTemporaryTableSpace.ListTemporaryTableSpace.Count; i++)
				{
					comboBoxTemporaryTableSpaceUser.Items.Add(((AccountMgmt.DataAccess.TemporaryTableSpace)m_cbTemporaryTableSpace.ListTemporaryTableSpace[i]).Name);
				}
				if(comboBoxTemporaryTableSpaceUser.Items.Count > 0)
					comboBoxTemporaryTableSpaceUser.SelectedIndex = 0;
			}

			temporaryTableSpace.Dispose();
		}

		/// <summary>
		/// Affiche les profiles par défault
		/// </summary>
		private void AfficheDefaultProfiles()
		{
			comboBoxUserProfile.BeginUpdate();
			comboBoxUserProfile.Visible = true;
			labelDefaultProfile.Visible = true;
			comboBoxUserProfile.Items.Clear();
			comboBoxUserProfile.Text = "";
			for(int i=0; i<m_defaultProfiles.ListDefaultProfiles.Count; i++)
			{
				comboBoxUserProfile.Items.Add((string)m_defaultProfiles.ListDefaultProfiles[i]);
			}
			comboBoxUserProfile.EndUpdate();
		}

		/// <summary>
		/// L'utilisateur désire voir tous les paramètres de l'utilisateur sélectionné
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickUserList(object sender, System.EventArgs e)
		{
			AfficheUserRetails();
		}
		
		/// <summary>
		/// L'utilisateur désire voir tous les paramètres de l'utilisateur sélectionné
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnKeyUpUserList(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			AfficheUserRetails();
		}

		/// <summary>
		/// Affiche les paramètres d'un utilisateur
		/// </summary>
		private void AfficheUserRetails()
		{
			if(listViewUsersRetails.SelectedItems.Count<=0)
				return;

			//affichage des paramètres de l'utilsateur
			textBoxNameUser.Text = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Name;
			checkBoxActivateUser.Checked = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Activation;
			textBoxUserOracle.Text = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).UserOracle;
			textBoxCommentaryUser.Text = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Commentary;
			if(m_connectedUser.UserConnected.Admin != AccountMgmt.Common.Constants.AdminLevel)
				textBoxPasswordUser.PasswordChar = '*';
			else
				textBoxPasswordUser.PasswordChar = m_cNoPassword;
			textBoxPasswordUser.Text = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Password;
			textBoxServiceUser.Text = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Service;
			if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateBeginning != new DateTime())
			{
				dateTimePickerBeginUser.Value = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateBeginning;
				dateTimePickerBeginUser.Checked = true;
			}
			else 
			{
				dateTimePickerBeginUser.Checked = true; //bug Microsoft
				dateTimePickerBeginUser.Checked = false;
			}
			if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateEnd != new DateTime())
			{
				dateTimePickerEndUser.Value = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateEnd;
				dateTimePickerEndUser.Checked = true;
			}
			else 
			{
				dateTimePickerEndUser.Checked = true; //bug Microsoft
				dateTimePickerEndUser.Checked = false;
			}
			textBoxCreationDate.Text = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateCreation.ToString("G");
			if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateModification != new DateTime())
				textBoxLastModifUser.Text = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateModification.ToString("G");
			comboBoxUserProfile.BeginUpdate();
			comboBoxUserProfile.Visible = false;
			labelDefaultProfile.Visible = false;
			comboBoxUserProfile.EndUpdate();
			if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Admin == AccountMgmt.Common.Constants.AdminLevel)
				comboBoxDba.SelectedIndex = 0;
			else
			{
				if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Admin == AccountMgmt.Common.Constants.ResponsableLevel)
					comboBoxDba.SelectedIndex = 1;
				else
				{
					if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Admin == AccountMgmt.Common.Constants.NoAdminLevel)
						comboBoxDba.SelectedIndex = 2;
				}
			}
			if(m_connectedUser.UserConnected.Admin == AccountMgmt.Common.Constants.AdminLevel)
			{
				comboBoxTemporaryTableSpaceUser.Visible = false;
				textBoxTemporaryTableSpaceUser.Visible = true;
				textBoxTemporaryTableSpaceUser.Text = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).TemporaryTableSpace;
			}
		}

		/// <summary>
		/// Créer un nouvel utilisateur
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickNewUser(object sender, System.EventArgs e)
		{
			AfficheNewUser();
		}

		/// <summary>
		/// Efface tous les champs et renseigne les profiles par défault
		/// </summary>
		private void AfficheNewUser()
		{
			//clear tous les champs
			textBoxNameUser.Text = "";
			checkBoxActivateUser.Checked = true;
			textBoxUserOracle.Text = "";
			textBoxCommentaryUser.Text = "";
			if(m_connectedUser.UserConnected.Admin != AccountMgmt.Common.Constants.AdminLevel)
				textBoxPasswordUser.PasswordChar = '*';
			else
				textBoxPasswordUser.PasswordChar = m_cNoPassword;
			textBoxPasswordUser.Text = "";
			textBoxServiceUser.Text = "";
			dateTimePickerBeginUser.Value = DateTime.Now;
			dateTimePickerBeginUser.Checked = true; //bug Microsoft
			dateTimePickerBeginUser.Checked = false;
			dateTimePickerEndUser.Value = DateTime.Now;
			dateTimePickerEndUser.Checked = true; //bug Microsoft
			dateTimePickerEndUser.Checked = false;
			textBoxCreationDate.Text = "";
			textBoxLastModifUser.Text = "";
			comboBoxDba.SelectedIndex = 2;
			AfficheDefaultProfiles();
			GetTemporaryTableSpace();
			if(m_connectedUser.UserConnected.Admin == AccountMgmt.Common.Constants.AdminLevel)
			{
				comboBoxTemporaryTableSpaceUser.Visible = true;
				textBoxTemporaryTableSpaceUser.Visible = false;
			}
		}
		
		/// <summary>
		/// Ajout d'un utilisateur
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickAddUser(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			//tests
			if(textBoxNameUser.Text == "")
			{
				MessageBox.Show("Veuillez donner un nom à l'utilisateur.");
				return;
			}
			if(textBoxUserOracle.Text == "")
			{
				MessageBox.Show("Veuillez donner un nom Oracle à l'utilisateur.");
				return;
			}
			if(textBoxServiceUser.Text == "")
			{
				MessageBox.Show("Veuillez donner un service à l'utilisateur.");
				return;
			}
			if(comboBoxUserProfile.SelectedIndex < 0)
			{
				MessageBox.Show("Veuillez sélectionner un profile par défault.");
				return;
			}
			if(comboBoxTemporaryTableSpaceUser.Items.Count == 0) //plus de temporary_tableSpace dispo
			{
				MessageBox.Show("Impossible de créer un utilisateur, il n'y a plus de 'Temporary_TableSpace' disponible. Veuillez prévenir le service 'Base de données'.");
				return;
			}
			if(comboBoxTemporaryTableSpaceUser.SelectedIndex < 0)
			{
				MessageBox.Show("Veuillez sélectionner une 'Temporary_TableSpace'.");
				return;
			}

			//ajout en base d'un nouvel utilisateur
			AccountMgmt.DataAccess.User user = new AccountMgmt.DataAccess.User();
			user.Name = textBoxNameUser.Text.ToUpper();
			user.Activation = checkBoxActivateUser.Checked;
			user.Commentary = textBoxCommentaryUser.Text;
			if(dateTimePickerBeginUser.Checked)
				user.DateBeginning = new DateTime(dateTimePickerBeginUser.Value.Year, dateTimePickerBeginUser.Value.Month, dateTimePickerBeginUser.Value.Day, 0, 0, 0, 0);
			else
				user.DateBeginning = new DateTime();
			if(dateTimePickerEndUser.Checked)
				user.DateEnd = new DateTime(dateTimePickerEndUser.Value.Year, dateTimePickerEndUser.Value.Month, dateTimePickerEndUser.Value.Day, 0, 0, 0, 0);
			else
				user.DateEnd = new DateTime();
			user.DateCreation = DateTime.Now;
			user.Password = textBoxPasswordUser.Text;
			user.Service = textBoxServiceUser.Text.ToUpper();
			user.UserOracle = textBoxUserOracle.Text.ToUpper();
			user.Admin = AccountMgmt.Common.Constants.NoAdminLevel;
			if(comboBoxDba.SelectedIndex == 0)
				user.Admin = AccountMgmt.Common.Constants.AdminLevel;
			else
			{
				if(comboBoxDba.SelectedIndex == 1)
					user.Admin = AccountMgmt.Common.Constants.ResponsableLevel;
				else
					user.Admin = AccountMgmt.Common.Constants.NoAdminLevel;
			}
			long idTypeSource;
			user.GetIdSource(m_connectedUser.Connection, "APPLICATION", out idTypeSource);
			user.IdSource = idTypeSource;
			user.IdUserModification = m_connectedUser.UserConnected.Id;
			user.IdTemporaryTableSpace = ((AccountMgmt.DataAccess.TemporaryTableSpace)m_cbTemporaryTableSpace.ListTemporaryTableSpace[comboBoxTemporaryTableSpaceUser.SelectedIndex]).Id;
			user.TemporaryTableSpace = ((AccountMgmt.DataAccess.TemporaryTableSpace)m_cbTemporaryTableSpace.ListTemporaryTableSpace[comboBoxTemporaryTableSpaceUser.SelectedIndex]).Name;
			if(!user.Add(m_connectedUser.Connection, (string)m_defaultProfiles.ListDefaultTablespace[comboBoxUserProfile.SelectedIndex]))
				return;

			//rafraichissement de la liste des temporary_tablespace dispo
			GetTemporaryTableSpace();

			//ajout dans la liste
			m_listViewAllUsers.ListUsers.Add(user);

			//ajout dans la liste du nouvel utilisateur
			listViewUsersRetails.BeginUpdate();
			ListViewItem item = new ListViewItem(string.Format("{0}", user.Id));
			item.SubItems.Add(textBoxNameUser.Text.ToUpper());
			textBoxNameUser.Text = textBoxNameUser.Text.ToUpper();
			item.SubItems.Add(textBoxUserOracle.Text.ToUpper());
			textBoxUserOracle.Text = textBoxUserOracle.Text.ToUpper();
			item.SubItems.Add(textBoxServiceUser.Text.ToUpper());
			textBoxServiceUser.Text = textBoxServiceUser.Text.ToUpper();
			if(textBoxCommentaryUser.Text != null)
				item.SubItems.Add(textBoxCommentaryUser.Text.Replace("\r", " "));
			else
				item.SubItems.Add(textBoxCommentaryUser.Text);
			item.SubItems.Add(textBoxPasswordUser.Text);
			listViewUsersRetails.Items.Add(item);
			if(!checkBoxActivateUser.Checked)
				listViewUsersRetails.Items[listViewUsersRetails.Items.Count-1].BackColor = System.Drawing.Color.Tomato;
			else if(user.DateEnd != new DateTime() && user.DateEnd < DateTime.Now)
				listViewUsersRetails.Items[listViewUsersRetails.Items.Count-1].BackColor = System.Drawing.Color.Purple;
			listViewUsersRetails.EndUpdate();
			textBoxCreationDate.Text = user.DateCreation.ToString("G");
			comboBoxUserProfile.BeginUpdate();
			comboBoxUserProfile.Visible = false;
			labelDefaultProfile.Visible = false;
			comboBoxUserProfile.EndUpdate();

			Cursor.Current = Cursors.Default;
		}

		private void OnClickModifyUser(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			if(listViewUsersRetails.SelectedItems.Count <= 0)
			{
				MessageBox.Show("Veuillez sélectionner un utilisateur avant de le modifier.");
				return;
			}
			//tests
			if(textBoxNameUser.Text == "")
			{
				MessageBox.Show("Veuillez donner un nom à l'utilisateur.");
				return;
			}
			if(textBoxUserOracle.Text == "")
			{
				MessageBox.Show("Veuillez donner un nom Oracle à l'utilisateur.");
				return;
			}
			if(textBoxServiceUser.Text == "")
			{
				MessageBox.Show("Veuillez donner un service à l'utilisateur.");
				return;
			}

			//modifie en base l'utilisateur
			((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Name = textBoxNameUser.Text.ToUpper();
			((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Activation = checkBoxActivateUser.Checked;
			((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Commentary = textBoxCommentaryUser.Text;
			if(dateTimePickerBeginUser.Checked)
				((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateBeginning = new DateTime(dateTimePickerBeginUser.Value.Year, dateTimePickerBeginUser.Value.Month, dateTimePickerBeginUser.Value.Day, 0, 0, 0, 0);
			else
				((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateBeginning = new DateTime();
			if(dateTimePickerEndUser.Checked)
				((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateEnd = new DateTime(dateTimePickerEndUser.Value.Year, dateTimePickerEndUser.Value.Month, dateTimePickerEndUser.Value.Day, 0, 0, 0, 0);
			else
				((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateEnd = new DateTime();
			((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateModification = DateTime.Now;
			((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Service = textBoxServiceUser.Text.ToUpper();
			((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).UserOracle = textBoxUserOracle.Text.ToUpper();
			short oldAdmin = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Admin;
			((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Admin = AccountMgmt.Common.Constants.NoAdminLevel;
			if(comboBoxDba.SelectedIndex == 0)
				((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Admin = AccountMgmt.Common.Constants.AdminLevel;
			else
			{
				if(comboBoxDba.SelectedIndex == 1)
					((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Admin = AccountMgmt.Common.Constants.ResponsableLevel;
				else
					((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Admin = AccountMgmt.Common.Constants.NoAdminLevel;
			}
			((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).IdUserModification = m_connectedUser.UserConnected.Id;
			if(!((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Modify(m_connectedUser.Connection, textBoxPasswordUser.Text, oldAdmin))
				return;
			((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Password = textBoxPasswordUser.Text;

			//modif dans la liste de l'utilisateur sélectionné
			listViewUsersRetails.BeginUpdate();
			listViewUsersRetails.Items[listViewUsersRetails.SelectedIndices[0]].SubItems[1].Text = textBoxNameUser.Text.ToUpper();
			textBoxNameUser.Text = textBoxNameUser.Text.ToUpper();
			listViewUsersRetails.Items[listViewUsersRetails.SelectedIndices[0]].SubItems[2].Text = textBoxUserOracle.Text.ToUpper();
			textBoxUserOracle.Text = textBoxUserOracle.Text.ToUpper();
			listViewUsersRetails.Items[listViewUsersRetails.SelectedIndices[0]].SubItems[3].Text = textBoxServiceUser.Text.ToUpper();
			textBoxServiceUser.Text = textBoxServiceUser.Text.ToUpper();
			if(textBoxCommentaryUser.Text != null)
				listViewUsersRetails.Items[listViewUsersRetails.SelectedIndices[0]].SubItems[4].Text = textBoxCommentaryUser.Text.Replace("\r", " ");
			else
				listViewUsersRetails.Items[listViewUsersRetails.SelectedIndices[0]].SubItems[4].Text = textBoxCommentaryUser.Text;
			listViewUsersRetails.Items[listViewUsersRetails.SelectedIndices[0]].SubItems[5].Text = textBoxPasswordUser.Text;
			if(!checkBoxActivateUser.Checked)
				listViewUsersRetails.Items[listViewUsersRetails.SelectedIndices[0]].BackColor = System.Drawing.Color.Tomato;
			else 
			{
				if(((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateEnd != new DateTime() && ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateEnd < DateTime.Now)
					listViewUsersRetails.Items[listViewUsersRetails.SelectedIndices[0]].BackColor = System.Drawing.Color.Purple;
				else
					listViewUsersRetails.Items[listViewUsersRetails.SelectedIndices[0]].BackColor = System.Drawing.Color.White;
			}
			listViewUsersRetails.EndUpdate();
			textBoxLastModifUser.Text = ((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).DateModification.ToString("G");

			Cursor.Current = Cursors.Default;
		}

		private void OnClickDeleteUser(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			if(listViewUsersRetails.SelectedItems.Count <= 0)
			{
				MessageBox.Show("Veuillez sélectionner un utilisateur avant de le supprimer.");
				return;
			}

			DialogResult result;
			result = MessageBox.Show("Etes-vous certain de vouloir supprimer l'utilisateur " + textBoxNameUser.Text + "?", "", MessageBoxButtons.YesNo);
			if(result == DialogResult.No)
				return;

			//supprime l'utilisateur en base
			if(!((AccountMgmt.DataAccess.User)m_listViewAllUsers.ListUsers[listViewUsersRetails.SelectedIndices[0]]).Delete(m_connectedUser.Connection))
				return;
			
			m_listViewAllUsers.ListUsers.RemoveAt(listViewUsersRetails.SelectedIndices[0]);
			listViewUsersRetails.BeginUpdate();
			listViewUsersRetails.Items.RemoveAt(listViewUsersRetails.SelectedIndices[0]);
			listViewUsersRetails.EndUpdate();
			//clear zone parametres
			AfficheNewUser();

			Cursor.Current = Cursors.Default;
		}
		#endregion

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			LoadData();
		}

		/// <summary>
		/// Chargement de l'appli à chaque login
		/// </summary>
		private void LoadData()
		{
			//remplir l'archive
			GetArchiAccount();

			//remplir la liste des roles
			GetRoles();

			//remplir la liste des users
			GetAllUsers("u.user_oracle");
			if(m_connectedUser.UserConnected != null && m_connectedUser.UserConnected.Admin != AccountMgmt.Common.Constants.AdminLevel)
			{
				GetArchiAffectation();
				AffichageAllUsers();
			}
		}

		/// <summary>
		/// Récupère la liste des utilisateurs en base
		/// </summary>
		/// <returns>Erreur si problème lors de la recherche des utilisateurs</returns>
		private bool GetAllUsers(string strSort)
		{
			if(m_listViewAllUsers != null)
			{
				m_listViewAllUsers.Dispose();
				m_listViewAllUsers = null;
			}

			bool bResult = false;
			AccountMgmt.DataAccess.AccessUser user = new AccountMgmt.DataAccess.AccessUser();
			if(user.Select(m_connectedUser.Connection, "u.dba_status <> " + AccountMgmt.Common.Constants.AdminLevel.ToString("0"), strSort/*"u.user_oracle"*/))
			{
				bResult = true;
				m_listViewAllUsers = new AccountMgmt.BusinessFacade.ListViewAllUsers();
				m_listViewAllUsers.ListUsers = (ArrayList)(user.ListUser.Clone());
			}

			user.Dispose();
			return bResult;
		}

		private void OnClickExit(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void OnClickOptions(object sender, System.EventArgs e)
		{
		
		}

		private void OnClickHelp(object sender, System.EventArgs e)
		{
			AccountMgmt.frmHelp helpFrm = new frmHelp();
			helpFrm.ShowDialog();
		}

		/// <summary>
		/// Se loguer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickLogin(object sender, System.EventArgs e)
		{
			if(m_connectedUser.IsConnected)
				m_connectedUser.DataBasisDisconnection();

			//lance la fenêtre qui permet la connection
			frmConnect myFrmConnect = null;
			if(strArguments.Length > 0)
				myFrmConnect = new frmConnect(strArguments);
			else
				myFrmConnect = new frmConnect("");
			myFrmConnect.ShowDialog();
			if(myFrmConnect.DialogResult == DialogResult.OK)
			{
				m_connectedUser = myFrmConnect.ConnectedUser;
				if(this.frmTabControle.Controls.Contains(this.AccountTabPage) && m_connectedUser.UserConnected != null && m_connectedUser.UserConnected.Admin != AccountMgmt.Common.Constants.AdminLevel)
					this.frmTabControle.Controls.Remove(this.AccountTabPage);
				if(!this.frmTabControle.Controls.Contains(this.AccountTabPage) && m_connectedUser.UserConnected != null && m_connectedUser.UserConnected.Admin == AccountMgmt.Common.Constants.AdminLevel)
					this.frmTabControle.Controls.Add(this.AccountTabPage);
				LoadData();
			}
		}

		private void OnClickDisconnect(object sender, System.EventArgs e)
		{
			m_connectedUser.DataBasisDisconnection();
		}
	}
}
