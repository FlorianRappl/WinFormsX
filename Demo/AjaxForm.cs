using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.WebX;
using System.Windows.FormsX;

namespace WFX.Showcase
{
    public partial class AjaxForm : Form
    {
        public AjaxForm()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Enum.GetNames(typeof(AjaxRequestType)));
            comboBox1.SelectedIndex = 0;
        }

        //Possibility to query (documentation): http://www.random.org/clients/http/
        private void button1_Click(object sender, EventArgs e)
        {
            var panel = this.Notify("Please wait...", -1, 0.3, Color.Green, Color.Black, Color.White);
            var options = new AjaxRequestOptions
            {
                //You can also delete the Data object and add this to the URL:
                //?min=1&max=52&col=1&format=plain&rnd=new
                //It will behave identical, butshow that both options (Data and URL) are possible.
                Data = new {
                    min = 1,
                    max = 52,
                    col = 1,
                    format = "plain",
                    rnd = "new"
                },
                Url = textBox2.Text,
                Type = (AjaxRequestType)Enum.Parse(typeof(AjaxRequestType), comboBox1.SelectedItem.ToString()),
                Complete = (s, ev) =>
                {
                    Controls.Remove(panel);
                    panel.Dispose();
                },
                Success = (s, ev) =>
                {
                    textBox1.Text = ev.ResponseText.Replace("\n", "\r\n");
                    textBox3.Text = MakeHeaders(s);
                }
            };
            options.AddStatusCodeHandler(System.Net.HttpStatusCode.OK, (s, ev) =>
            {
                MessageBox.Show("I received something with StatusCode 200!");
            });
            AjaxRequest.Create(options);
        }

        private string MakeHeaders(AjaxRequest s)
        {
            var sb = new StringBuilder();
            sb.Append("StatusCode: ").AppendLine(((int)s.StatusCode).ToString());
            sb.Append("StatusText: ").AppendLine(s.StatusText);
            sb.Append("ResponseUrl: ").AppendLine(s.ResponseUrl.ToString());
            sb.Append("ResponseType: ").AppendLine(s.ResponseType);
            sb.Append("ResponseDataType: ").AppendLine(s.ResponseDataType.ToString());
            sb.Append("LastModified: ").AppendLine(s.LastModified.ToString());
            sb.AppendLine("Headers:");

            foreach (var key in s.ReponseHeader.Keys)
                sb.Append("\t").Append(key).Append(": ").AppendLine(s.ReponseHeader[key]);

            return sb.ToString();
        }
    }
}
