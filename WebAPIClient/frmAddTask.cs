using System.Collections.Generic;
using System.Windows.Forms;
using WebApi;

namespace WebAPIClient
{
    public partial class frmAddTask : Form
    {
        private readonly SDK _sdk;

        public frmAddTask(SDK sdk)
        {
            InitializeComponent();
            _sdk = sdk;
        }
        public frmAddTask()
        {
            InitializeComponent();
        }

        private void frmAddTask_Load(object sender, System.EventArgs e)
        {
            LoadRefData();
        }

        private void btnAddTask_Click(object sender, System.EventArgs e)
        {

        }

        private void LoadRefData()
        {
            var taskTypes = _sdk.GetTaskTypes();
            cboTaskType.DataSource = taskTypes;
            cboTaskType.DisplayMember = "Name";
            cboTaskType.ValueMember = "Id";

            var priorities = new List<Priority>
            {
                new Priority() {Id = 1, Name = "Low"},
                new Priority() {Id = 2, Name = "Medium"},
                new Priority() {Id = 3, Name = "High"}
            };
            cboPriority.DataSource = priorities;
            cboPriority.DisplayMember = "Name";
            cboPriority.ValueMember = "Id";



            //load task types
            //load task origins
        }

        private void cboTaskType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int i = 0;
        }

        private struct Priority
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
