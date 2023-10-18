using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_solution
{
    public partial class EditItem : Form
    {
        public EditItem(Item loadedItem)
        {
            InitializeComponent();
            InitWebview();
        }

        async void InitWebview()
        {
            await webViewCode.EnsureCoreWebView2Async();
        }

        private void webView21_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            txtName.Text = e.TryGetWebMessageAsString();
        }

        public async void requestData()
        {
            await webViewCode.ExecuteScriptAsync("sendDataToWinForm()");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            requestData();
        }
    }
}
