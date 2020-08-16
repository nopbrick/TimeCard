using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeCard
{
    public partial class InsertHoursForm : Form
    {
        private List<Employee> empl;
        private List<Employee_Activities> _activities;
        private string comboBoxText;
        private int employeeID;
        //private Employee_Activities _activity;
        private (int, DateTime, int, string) t;
        
        /*async Task<List<string>> getEmployees()
        {
            using var context = new TimeCardEntityModel();
            return await context.Employees.Select(x => x.FirstName + " " +  x.LastName).ToListAsync();
        }*/

        async Task<List<Employee>> getEmployees()
        {
            using var context = new TimeCardEntityModel();
            return await context.Employees.ToListAsync();
        }

        /*async Task<List<Employee_Activities>> getEmployeeActivities()
        {
            using var context = new TimeCardEntityModel();
            try
            {
                return await context.Employee_Activities
                    .Where(x => (x.Employee.FirstName + " " + x.Employee.LastName) == comboBoxText).ToListAsync();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }*/
        
        #region GETTING DATA FROM CONTROLS
        private delegate int getIDofEmployeeDelegate();
        private int getEmployeeIDFromComboBox()
        {
            if (comboBox1.InvokeRequired)
            {
                comboBox1.Invoke(new getIDofEmployeeDelegate(getEmployeeIDFromComboBox), new object[] {comboBox1.Text});
            }
            else
            {
                employeeID = Convert.ToInt32(comboBox1.SelectedValue);
            }

            return employeeID;
        }
        
        private delegate string ControlDelegate(Control control);
        private string getControlText(Control control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new ControlDelegate(getControlText), new object[] {control.Text});
                /*MethodInvoker AssignMethodControl = new MethodInvoker(getControlText);
                comboBox1.Invoke(AssignMethodControl);*/
            }
            else
            {
                return control.Text;
            }

            return control.Text;
        }

        private delegate DateTime GetDateTimePickerValueDelegate(DateTimePicker picker);

        private DateTime GetDateTimePickerValue(DateTimePicker picker)
        {
            if (picker.InvokeRequired)
            {
                picker.Invoke(new GetDateTimePickerValueDelegate(GetDateTimePickerValue), new object[] {picker.Value});
            }
            else
            {
                return picker.Value;
            }
            
            return picker.Value;
        }
        
        #endregion

        private void InsertData(Employee_Activities activities)
        {
            using var context = new TimeCardEntityModel();
            var act = context.Set<Employee_Activities>();
            act.Add(activities);
            //context.Employee_Activities.Add(activities);
            context.SaveChanges();
            Console.WriteLine();
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
                comboBox1.DataSource = empl;
                comboBox1.ValueMember = "EmployeeID";
                comboBox1.DisplayMember =  "FullName";
                
            }
        }

        public async void getDataFromDb()
        {
            empl = await getEmployees();
            SetComboBox();
        }
        
        public InsertHoursForm()
        {
            InitializeComponent();
            Task.Run(getDataFromDb);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            getControlText(textBox1);
        }
        
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            GetDateTimePickerValue(dateTimePicker2);
        }

        public Employee_Activities AssignObject()
        {
            var ea = new Employee_Activities();
            ea.EmployeeID = getEmployeeIDFromComboBox();
            ea.ActivityDate = GetDateTimePickerValue(dateTimePicker2);
            ea.ActivityTime = Convert.ToInt32(getControlText(textBox2));
            ea.ActivityComment = getControlText(textBox1);

            return ea;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData(AssignObject());
        }
    }
}