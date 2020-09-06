using System;
using System.Windows.Forms;

namespace TimeCard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var viewTimeSheets = new ViewTimeSheetForm();
            viewTimeSheets.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var insertHours = new InsertHoursForm();
            insertHours.Show();
        }
    }
}