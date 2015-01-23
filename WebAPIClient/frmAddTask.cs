using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ObjectLibrary;
using WebAPI;

namespace WebAPIClient
{
    public partial class frmAddTask : Form
    {
        private readonly SDK _sdk;
        public string TaskId { get; private set; }

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
            var task = new Task
            {
                Description = txtDescription.Text,
                Note = txtNote.Text,
                DueDate = dtpDueDate.Value,
                Origin = (TaskOrigin) cboOrigin.SelectedItem,
                Priority = (TaskPriority) cboPriority.SelectedValue,
                Status = (TaskStatus) cboStatus.SelectedItem,
                Type = (TaskType) cboTaskType.SelectedItem
            };

            TaskId =_sdk.AddTask(task);

            DialogResult = DialogResult.OK;
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

            var statuses = _sdk.GetTaskStatuses();
            cboStatus.DataSource = statuses;
            cboStatus.DisplayMember = "Name";
            cboStatus.ValueMember = "Id";

            cboOrigin.DataSource = _sdk.GetTaskOrigins(); ;
            cboOrigin.DisplayMember = "Name";
            cboOrigin.ValueMember = "Id";

            dtpDueDate.Value = DateTime.Today.AddDays(7);
        }

        private struct Priority
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
