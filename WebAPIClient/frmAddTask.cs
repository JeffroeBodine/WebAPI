using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ObjectLibrary;
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
            var task = new Task();
            task.Description = txtDescription.Text;
            task.Note = txtNote.Text;
            task.DueDate = dtpDueDate.Value;
            ////task.Origin = (TaskOrigin)cboOrigin.SelectedItem;
            //task.Priority = (TaskPriority) cboPriority.SelectedValue;
            //task.Status = (TaskStatus) cboStatus.SelectedItem;
            //task.TaskType = (TaskType) cboTaskType.SelectedItem;

            _sdk.AddTask(task);

            int i = 0;
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
