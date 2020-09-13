using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
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
        private DateTime datepickerdate;
        
        async Task<List<string>> getEmployees()
        {
           using var context = new TimeCardEntityModel();
           return await context.Employees.Select(x => x.FirstName + " " +  x.LastName).ToListAsync();
        }

        async Task<List<Employee_Activities>> getEmployeeActivities(DateTime dateTime)
        {
            using var context = new TimeCardEntityModel();
            try
            {
                return await context.Employee_Activities
                    .Where(x => (x.Employee.FirstName + " " + x.Employee.LastName) == comboBoxText && x.ActivityDate.Day == dateTime.Day).ToListAsync();
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
        
        private DateTime getDateFromDatePicker()
        {
            if (dateTimePicker1.InvokeRequired)
            {
                MethodInvoker AssignMethodControl = new MethodInvoker(getControlText);
                comboBox1.Invoke(AssignMethodControl);
                return DateTime.Today;
            }
            else
            {
                return dateTimePicker1.Value;
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
            SetComboBox();
        }

        private void generateTimeSheet(List<Employee_Activities> employeeActivities)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Activity", typeof(string));
            tbl.Columns.Add("Date", typeof(DateTime));
            tbl.Columns.Add("Duration", typeof(double));

            foreach (var item in employeeActivities)
            {
                tbl.Rows.Add(item.ActivityComment, item.ActivityDate, item.ActivityTime);
            }
            dataGridView1.DataSource = tbl;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private async void getTimeSheetButton_Click(object sender, EventArgs e)
        {
            datepickerdate = getDateFromDatePicker();
            _activities = await getEmployeeActivities(datepickerdate);
            generateTimeSheet(_activities);
        }


        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getControlText();
        }
    }
}