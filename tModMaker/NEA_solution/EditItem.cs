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
        private string code;
        public Item theItem;

        public EditItem(Item loadedItem)
        {
            theItem = loadedItem;
            InitializeComponent();
            InitWebview();
        }

        async void InitWebview()
        {
            await webViewCode.EnsureCoreWebView2Async();
        }

        public async void requestData()
        {
            await webViewCode.ExecuteScriptAsync("sendDataToWinForm()");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            requestData();
            theItem.set_code(code);
        }

        private void webViewCode_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            code = e.TryGetWebMessageAsString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
