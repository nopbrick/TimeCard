using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace TimeCard
{
    public partial class ViewTimeSheetForm : Form
    {
        private List<string> empl;
        private List<Employee_Activities> _activities;
        private string comboBoxText;
        async Task<List<string>> getEmployees()
        {
           using var context = new TimeCardEntityModel();
           return await context.Employees.Select(x => x.FirstName + " " +  x.LastName).ToListAsync();
        }

        async Task<List<Employee_Activities>> getEmployeeActivities()
        {
            using var context = new TimeCardEntityModel();
            try
            {
                /*return await from p in context.Employee_Activities
                    where p.Employee.FirstName + " " + p.Employee.LastName == comboBoxText
                    select new TempEmployeeActivities() { };*/

                /*return await context.Employee_Activities
                    .Where(x => x.Employee.FirstName + " " + x.Employee.LastName == comboBoxText)
                    .Select(c => new TempEmployeeActivities() { });*/
                /*return await (from ea in context.Set<Employee_Activities>()
                        where (ea.Employee.FirstName + " " + ea.Employee.LastName) == comboBoxText
                        select new { }).ToListAsync()
                    .Select(x => new Employee_Activities { });*/
                return await context.Employee_Activities
                    .Where(x => (x.Employee.FirstName + " " + x.Employee.LastName) == comboBoxText).ToListAsync();
                /*return await context.Employee_Activities
                    .Where(x => (x.Employee.FirstName + " " + x.Employee.LastName) == comboBoxText)
                    .Select(x => new {}).ToListAsync()
                    .Select(c => new Employee_Activities{});*/
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        
        public ViewTimeSheetForm()
        {
            InitializeComponent();
            Task.Run(getDataFromDb);
            Console.WriteLine();
        }

        private void getControlText()
        {
            if (comboBox1.InvokeRequired)
            {
                MethodInvoker AssignMethodControl = new MethodInvoker(getControlText);
                comboBox1.Invoke(AssignMethodControl);
            }
            else
            {
                comboBoxText = comboBox1.Text;
            }
        }

        private void SetComboBox()
        {
            if (comboBox1.InvokeRequired)
            {
                MethodInvoker AssignMethodControl = new MethodInvoker(SetComboBox);
                comboBox1.Invoke(AssignMethodControl);
            }
            else
            {
                foreach (var item in empl)
                {
                    comboBox1.Items.Add(item);
                }
            }
        }

        public async void getDataFromDb()
        {
            empl = await getEmployees();
            //await Task.Run(getEmployeeActivities);
            SetComboBox();
            //_activities = await getEmployeeActivities();
            
        }

        private void generateTimeSheet(TableLayoutPanel tableLayoutPanel, List<Employee_Activities> employeeActivities)
        {
            int numOfDays = DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnCount = numOfDays;
            tableLayoutPanel.RowCount = employeeActivities.Count;    //NEED TO IMPLEMENT IF ZERO CONDITION
            for (int x = 0; x < tableLayoutPanel.ColumnCount; x++)
            {
                //First add a column
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                for (int y = 0; y < tableLayoutPanel.RowCount; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }

                    //Create the control, in this case we will add a button
                    Button cmd = new Button();
                    cmd.Text = string.Format("({0}, {1})", x, y);         //Finally, add the control to the correct location in the table
                    tableLayoutPanel1.Controls.Add(cmd, x, y);
                }
            }
        }


        private void getTimeSheetButton_Click(object sender, EventArgs e)
        {
            Task.Run(getEmployeeActivities);
            generateTimeSheet(tableLayoutPanel1, _activities);
            tableLayoutPanel1.Show();
        }


        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getControlText();
            _activities = await getEmployeeActivities();
        }
    }
}