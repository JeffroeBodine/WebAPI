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

            var statuses = new List<Status>
            {
                new Status() {Id = 1, Name = "Assigned"},
                new Status() {Id = 2, Name = "In Progress"},
                new Status() {Id = 3, Name = "Complete"}
            };
            cboStatus.DataSource = statuses;
            cboStatus.DisplayMember = "Name";
            cboStatus.ValueMember = "Id";

            var origins = new List<Origin>
            {
                new Origin() {Id = 1, Name = "Fax"},
                new Origin() {Id = 2, Name = "Capture Scan"},
                new Origin() {Id = 3, Name = "Phone Call"},
                new Origin() {Id = 3, Name = "Email"},
                new Origin() {Id = 3, Name = "Mail"},
                new Origin() {Id = 3, Name = "Inactive"},
                new Origin() {Id = 3, Name = "Walk In Request"}
            };
            cboOrigin.DataSource = origins;
            cboOrigin.DisplayMember = "Name";
            cboOrigin.ValueMember = "Id";
        }

        private struct Priority
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private struct Status
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private struct Origin
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
