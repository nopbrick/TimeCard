using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeCard
{
    public partial class InsertHoursForm : Form
    {
        private List<Employee> empl;
        private int employeeID;


        async Task<List<Employee>> getEmployees()
        {
            using var context = new TimeCardEntityModel();
            return await context.Employees.ToListAsync();
        }
        
        
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
            ea.ActivityTime = Convert.ToDouble(getControlText(textBox2));
            ea.ActivityComment = getControlText(textBox1);

            return ea;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData(AssignObject());
        }
    }
}