using System;
using System.Windows.Forms;

namespace MiniMusic
{
    public partial class AddServiceForm : Form
    {
        public string ServiceName => textBoxServiceName.Text;
        public string ServiceUrl => textBoxServiceUrl.Text;

        public AddServiceForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ServiceName) || string.IsNullOrWhiteSpace(ServiceUrl))
            {
                MessageBox.Show("Please provide both service name and URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
