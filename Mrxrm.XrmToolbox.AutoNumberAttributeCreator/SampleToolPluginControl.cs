using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Crm.Sdk.Messages;
using XrmToolBox.Extensibility;

namespace Mrxrm.XrmToolbox.AutoNumberAttributeCreator
{
    public partial class SampleToolPluginControl : PluginControlBase
    {
        public SampleToolPluginControl()
        {
            InitializeComponent();
        }

        public void ProcessWhoAmI()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving your user id...",
                Work = (w, e) =>
                {
                    var request = new WhoAmIRequest();
                    var response = (WhoAmIResponse)Service.Execute(request);

                    e.Result = response.UserId;
                },
                ProgressChanged = e =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage("Message to display");
                },
                PostWorkCallBack = e =>
                {
                    MessageBox.Show(string.Format("You are {0}", (Guid)e.Result));
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseTool(); // PluginBaseControl method that notifies the XrmToolBox that the user wants to close the plugin
            // Override the ClosingPlugin method to allow for any plugin specific closing logic to be performed (saving configs, canceling close, etc...)
        }

        private void btnWhoAmI_Click(object sender, EventArgs e)
        {
            ExecuteMethod(ProcessWhoAmI); // ExecuteMethod ensures that the user has connected to CRM, before calling the call back method
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancelled");
        }
    }
}
