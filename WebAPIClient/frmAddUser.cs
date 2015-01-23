using System;
using System.Windows.Forms;
using ObjectLibrary;
using WebAPI;

namespace WebAPIClient
{
    public partial class frmAddUser : Form
    {
        private readonly SDK _sdk;
        public string UserId { get; private set; }

        public frmAddUser(SDK sdk)
        {
            InitializeComponent();
            _sdk = sdk;
        }
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var user = new User();
            user.EMail = txtEmail.Text;
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;

            user.Password = txtPassword.Text;

            UserId = _sdk.AddUser(user);

            DialogResult = DialogResult.OK;
        }

    }
}
