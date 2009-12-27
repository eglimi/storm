using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Storm.Lib;

namespace NorthWind
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBoxRegion;
		private System.Windows.Forms.ComboBox comboBoxTerritory;
		private System.Windows.Forms.DataGrid dataGridEmployees;
		private System.ComponentModel.IContainer components;
		private IList m_regions = null;
		private System.Windows.Forms.TextBox textBoxChef;
		private System.Windows.Forms.ListBox listBoxUntergebene;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnDeleteTerritory;
		private System.Windows.Forms.TextBox tbTerritoryName;
		private System.Windows.Forms.Button btnAddTerritory;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbTerritoryID;
		private System.Windows.Forms.ComboBox cbAllNames;
		private System.Windows.Forms.Label label7;
		private ArrayList m_employees = null;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.MonthCalendar calBirthday;
		private System.Windows.Forms.Button btAddPerson;
		private System.Windows.Forms.TextBox tbFirstName;
		private System.Windows.Forms.TextBox tbLastName;
		private System.Windows.Forms.TextBox tbCity;
		private System.Windows.Forms.Button btnAddReportsTo;
		private System.Windows.Forms.Button btnAddToTerritory;
		private System.Windows.Forms.Button btnDeleteEmployee;
		private IList m_allNames = null;

		public Form1()
		{
			Registry.Instance.init(this, "pinfsdw14", "Northwind");

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dataGridEmployees = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.textBoxChef = new System.Windows.Forms.TextBox();
			this.comboBoxRegion = new System.Windows.Forms.ComboBox();
			this.comboBoxTerritory = new System.Windows.Forms.ComboBox();
			this.listBoxUntergebene = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnDeleteTerritory = new System.Windows.Forms.Button();
			this.tbTerritoryName = new System.Windows.Forms.TextBox();
			this.btnAddTerritory = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.tbTerritoryID = new System.Windows.Forms.TextBox();
			this.cbAllNames = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tbFirstName = new System.Windows.Forms.TextBox();
			this.tbLastName = new System.Windows.Forms.TextBox();
			this.tbCity = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.calBirthday = new System.Windows.Forms.MonthCalendar();
			this.btAddPerson = new System.Windows.Forms.Button();
			this.btnAddReportsTo = new System.Windows.Forms.Button();
			this.btnAddToTerritory = new System.Windows.Forms.Button();
			this.btnDeleteEmployee = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridEmployees)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridEmployees
			// 
			this.dataGridEmployees.AllowNavigation = false;
			this.dataGridEmployees.AllowSorting = false;
			this.dataGridEmployees.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridEmployees.DataMember = "";
			this.dataGridEmployees.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridEmployees.Location = new System.Drawing.Point(8, 144);
			this.dataGridEmployees.Name = "dataGridEmployees";
			this.dataGridEmployees.Size = new System.Drawing.Size(768, 136);
			this.dataGridEmployees.TabIndex = 0;
			this.dataGridEmployees.CurrentCellChanged += new System.EventHandler(this.dataGridEmployees_CurrentCellChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(168, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Load";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBoxChef
			// 
			this.textBoxChef.Location = new System.Drawing.Point(544, 320);
			this.textBoxChef.Name = "textBoxChef";
			this.textBoxChef.Size = new System.Drawing.Size(232, 20);
			this.textBoxChef.TabIndex = 3;
			this.textBoxChef.Text = "";
			// 
			// comboBoxRegion
			// 
			this.comboBoxRegion.Location = new System.Drawing.Point(8, 32);
			this.comboBoxRegion.Name = "comboBoxRegion";
			this.comboBoxRegion.Size = new System.Drawing.Size(136, 21);
			this.comboBoxRegion.TabIndex = 4;
			this.comboBoxRegion.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegion_SelectedIndexChanged);
			// 
			// comboBoxTerritory
			// 
			this.comboBoxTerritory.Location = new System.Drawing.Point(8, 104);
			this.comboBoxTerritory.Name = "comboBoxTerritory";
			this.comboBoxTerritory.Size = new System.Drawing.Size(136, 21);
			this.comboBoxTerritory.TabIndex = 5;
			this.comboBoxTerritory.SelectedIndexChanged += new System.EventHandler(this.comboBoxTerritory_SelectedIndexChanged);
			// 
			// listBoxUntergebene
			// 
			this.listBoxUntergebene.Location = new System.Drawing.Point(544, 360);
			this.listBoxUntergebene.Name = "listBoxUntergebene";
			this.listBoxUntergebene.Size = new System.Drawing.Size(232, 95);
			this.listBoxUntergebene.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Region:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Territory:";
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.button3.Location = new System.Drawing.Point(344, 728);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 64);
			this.button3.TabIndex = 9;
			this.button3.Text = "Commit";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(464, 320);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Chef";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(464, 360);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 11;
			this.label4.Text = "Angestellte";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(496, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Territory Name";
			// 
			// btnDeleteTerritory
			// 
			this.btnDeleteTerritory.Location = new System.Drawing.Point(168, 104);
			this.btnDeleteTerritory.Name = "btnDeleteTerritory";
			this.btnDeleteTerritory.Size = new System.Drawing.Size(104, 23);
			this.btnDeleteTerritory.TabIndex = 13;
			this.btnDeleteTerritory.Text = "delete Territory";
			this.btnDeleteTerritory.Click += new System.EventHandler(this.btnDeleteTerritory_Click);
			// 
			// tbTerritoryName
			// 
			this.tbTerritoryName.Location = new System.Drawing.Point(496, 104);
			this.tbTerritoryName.Name = "tbTerritoryName";
			this.tbTerritoryName.Size = new System.Drawing.Size(152, 20);
			this.tbTerritoryName.TabIndex = 14;
			this.tbTerritoryName.Text = "";
			// 
			// btnAddTerritory
			// 
			this.btnAddTerritory.Location = new System.Drawing.Point(664, 104);
			this.btnAddTerritory.Name = "btnAddTerritory";
			this.btnAddTerritory.Size = new System.Drawing.Size(104, 23);
			this.btnAddTerritory.TabIndex = 15;
			this.btnAddTerritory.Text = "add Territory";
			this.btnAddTerritory.Click += new System.EventHandler(this.btnAddTerritory_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(376, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "Zip";
			// 
			// tbTerritoryID
			// 
			this.tbTerritoryID.Location = new System.Drawing.Point(376, 104);
			this.tbTerritoryID.Name = "tbTerritoryID";
			this.tbTerritoryID.Size = new System.Drawing.Size(104, 20);
			this.tbTerritoryID.TabIndex = 17;
			this.tbTerritoryID.Text = "";
			// 
			// cbAllNames
			// 
			this.cbAllNames.Location = new System.Drawing.Point(8, 352);
			this.cbAllNames.Name = "cbAllNames";
			this.cbAllNames.Size = new System.Drawing.Size(144, 21);
			this.cbAllNames.TabIndex = 18;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 320);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 24);
			this.label7.TabIndex = 19;
			this.label7.Text = "All Names";
			// 
			// tbFirstName
			// 
			this.tbFirstName.Location = new System.Drawing.Point(16, 448);
			this.tbFirstName.Name = "tbFirstName";
			this.tbFirstName.Size = new System.Drawing.Size(96, 20);
			this.tbFirstName.TabIndex = 20;
			this.tbFirstName.Text = "";
			// 
			// tbLastName
			// 
			this.tbLastName.Location = new System.Drawing.Point(136, 448);
			this.tbLastName.Name = "tbLastName";
			this.tbLastName.Size = new System.Drawing.Size(96, 20);
			this.tbLastName.TabIndex = 21;
			this.tbLastName.Text = "";
			// 
			// tbCity
			// 
			this.tbCity.Location = new System.Drawing.Point(16, 512);
			this.tbCity.Name = "tbCity";
			this.tbCity.TabIndex = 22;
			this.tbCity.Text = "";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(16, 400);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(120, 16);
			this.label8.TabIndex = 24;
			this.label8.Text = "Create new Person";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 424);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 16);
			this.label9.TabIndex = 25;
			this.label9.Text = "First Name";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(136, 488);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 16);
			this.label10.TabIndex = 26;
			this.label10.Text = "Birthday";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 488);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 16);
			this.label11.TabIndex = 27;
			this.label11.Text = "City";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(136, 424);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 16);
			this.label12.TabIndex = 28;
			this.label12.Text = "Last Name";
			// 
			// calBirthday
			// 
			this.calBirthday.Location = new System.Drawing.Point(136, 512);
			this.calBirthday.Name = "calBirthday";
			this.calBirthday.TabIndex = 30;
			// 
			// btAddPerson
			// 
			this.btAddPerson.Location = new System.Drawing.Point(256, 448);
			this.btAddPerson.Name = "btAddPerson";
			this.btAddPerson.Size = new System.Drawing.Size(104, 23);
			this.btAddPerson.TabIndex = 31;
			this.btAddPerson.Text = "add person";
			this.btAddPerson.Click += new System.EventHandler(this.btAddPerson_Click);
			// 
			// btnAddReportsTo
			// 
			this.btnAddReportsTo.Location = new System.Drawing.Point(376, 488);
			this.btnAddReportsTo.Name = "btnAddReportsTo";
			this.btnAddReportsTo.Size = new System.Drawing.Size(104, 23);
			this.btnAddReportsTo.TabIndex = 32;
			this.btnAddReportsTo.Text = "ReportsTo -->";
			this.btnAddReportsTo.Click += new System.EventHandler(this.btnAddReportsTo_Click);
			// 
			// btnAddToTerritory
			// 
			this.btnAddToTerritory.Location = new System.Drawing.Point(376, 448);
			this.btnAddToTerritory.Name = "btnAddToTerritory";
			this.btnAddToTerritory.Size = new System.Drawing.Size(104, 23);
			this.btnAddToTerritory.TabIndex = 33;
			this.btnAddToTerritory.Text = "Add to Territory";
			this.btnAddToTerritory.Click += new System.EventHandler(this.btnAddToTerritory_Click);
			// 
			// btnDeleteEmployee
			// 
			this.btnDeleteEmployee.Location = new System.Drawing.Point(168, 352);
			this.btnDeleteEmployee.Name = "btnDeleteEmployee";
			this.btnDeleteEmployee.Size = new System.Drawing.Size(112, 23);
			this.btnDeleteEmployee.TabIndex = 34;
			this.btnDeleteEmployee.Text = "delete  Employee";
			this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 813);
			this.Controls.Add(this.btnDeleteEmployee);
			this.Controls.Add(this.btnAddToTerritory);
			this.Controls.Add(this.btnAddReportsTo);
			this.Controls.Add(this.btAddPerson);
			this.Controls.Add(this.calBirthday);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbCity);
			this.Controls.Add(this.tbLastName);
			this.Controls.Add(this.tbFirstName);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cbAllNames);
			this.Controls.Add(this.tbTerritoryID);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnAddTerritory);
			this.Controls.Add(this.tbTerritoryName);
			this.Controls.Add(this.textBoxChef);
			this.Controls.Add(this.btnDeleteTerritory);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBoxUntergebene);
			this.Controls.Add(this.comboBoxTerritory);
			this.Controls.Add(this.comboBoxRegion);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridEmployees);
			this.Name = "Form1";
			this.Text = " STORM Testapplication";
			((System.ComponentModel.ISupportInitialize)(this.dataGridEmployees)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Init()
		{
			m_regions = Registry.Instance.getFinder(typeof(Region)).findAll();
			comboBoxRegion.DataSource = m_regions;
			comboBoxRegion.DisplayMember = "Description";

			comboBoxTerritory.DataSource = m_regions;
			comboBoxTerritory.DisplayMember = "Territories.TerritoryDescription";

			dataGridEmployees.SetDataBinding(m_regions, "Territories.EmployeeTerritories");
			comboBoxTerritory_SelectedIndexChanged(null, null);

			m_allNames = Registry.Instance.getFinder(typeof(Employee)).findAll();
			cbAllNames.DataSource = m_allNames;
			cbAllNames.DisplayMember = "FullName";
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Init();
		}

		private void comboBoxTerritory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//CurrencyManager curMan = (CurrencyManager)BindingContext[m_regions, "Territories"];
			Territory territory = (Territory)comboBoxTerritory.SelectedItem;

			m_employees = new ArrayList();
			foreach(EmployeeTerritory empTer in territory.EmployeeTerritories)
			{
				m_employees.Add(empTer.Employee);
			}
			
			dataGridEmployees.SetDataBinding(m_employees, "");
			if(m_employees.Count > 0)
			{
				Employee emp = (Employee)m_employees[0];

				if(emp.ReportsTo != null)
				{
					textBoxChef.Text = emp.ReportsTo.FullName;
				}
				else
					textBoxChef.Text = "";
                
				if(emp.ReportedBy.Count > 0)
				{
					listBoxUntergebene.DataSource = m_employees;
					listBoxUntergebene.DisplayMember = "ReportedBy.LastName";
				}
				else
					listBoxUntergebene.DataSource = null;
			}
			else
			{
				listBoxUntergebene.DataSource = null;
				textBoxChef.Text = "";
			}

		}

		private void comboBoxRegion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxTerritory_SelectedIndexChanged(sender, e);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			try
			{
				UnitOfWork.Instance.commit();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception!");
			}
		}

		private void btnDeleteTerritory_Click(object sender, System.EventArgs e)
		{
			((Territory)comboBoxTerritory.SelectedItem).delete();
		}

		private void btAddPerson_Click(object sender, System.EventArgs e)
		{
			calBirthday.ShowToday = true;
			Employee newEmployee = (Employee)Registry.Instance.getFactory(typeof(Employee)).create();
			newEmployee.FirstName = tbFirstName.Text;
			newEmployee.LastName = tbLastName.Text;
			newEmployee.City = tbCity.Text;
			newEmployee.BirthDate = calBirthday.SelectionStart;

		}

		private void btnAddToTerritory_Click(object sender, System.EventArgs e)
		{
			EmployeeTerritory et = (EmployeeTerritory)Registry.Instance.getFactory(typeof(EmployeeTerritory)).create();
			et.Employee = (Employee)cbAllNames.SelectedItem;
			et.Territory = (Territory)comboBoxTerritory.SelectedItem;
			((Territory)comboBoxTerritory.SelectedItem).addTerritory(et);
		}

		private void dataGridEmployees_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if(m_employees.Count > 0)
			{
				Employee emp = (Employee)m_employees[dataGridEmployees.CurrentRowIndex];

				if(emp.ReportsTo != null)
				{
					textBoxChef.Text = emp.ReportsTo.FullName;
				}
				else
					textBoxChef.Text = "";
                
				if(emp.ReportedBy.Count > 0)
				{
					listBoxUntergebene.DataSource = emp.ReportedBy;
					listBoxUntergebene.DisplayMember = "LastName";
				}
				else
					listBoxUntergebene.DataSource = null;
			}
			else
			{
				listBoxUntergebene.DataSource = null;
				textBoxChef.Text = "";
			}		
		}

		private void btnAddTerritory_Click(object sender, System.EventArgs e)
		{
			if(tbTerritoryID.Text == "" || tbTerritoryName.Text == "") 
			{
				MessageBox.Show("Please fill in both values.", "Error!");
			}
			else if(m_regions == null)
			{
				MessageBox.Show("You should choose a Region first.", "Error!");
			}
			else
			{
				Territory t = (Territory)Registry.Instance.getFactory(typeof(Territory)).create();
				t.TerritoryId = tbTerritoryID.Text;
				tbTerritoryID.Text = "";
				t.TerritoryDescription = tbTerritoryName.Text;
				tbTerritoryName.Text = "";

				((Region)m_regions[comboBoxRegion.SelectedIndex]).addTerritory(t);
			}		
		}

		private void btnAddReportsTo_Click(object sender, System.EventArgs e)
		{
			Employee emp = (Employee)m_employees[dataGridEmployees.CurrentRowIndex];

			emp.addReportedBy((Employee)cbAllNames.SelectedItem);
		}

		private void btnDeleteEmployee_Click(object sender, System.EventArgs e)
		{
			((Employee)(cbAllNames.SelectedItem)).delete();
		}

	}
}
