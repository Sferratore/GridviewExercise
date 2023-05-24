using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Pages
{
    public partial class UpdateRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string filePath = "~/Data/data.txt";
                string physicalPath = Server.MapPath(filePath);
                string[] lines = File.ReadAllLines(physicalPath);

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    if (values[0] == Session["rowId"].ToString())
                    {
                        NomeTextBox2.Text = values[1];
                        CognomeTextBox2.Text = values[2];
                        NumTextBox2.Text = values[3];
                    }
                }
            }
        }

        public void SubmitButton_Click(object sender, EventArgs e)
        {
            string filePath = "~/Data/data.txt";
            string physicalPath = Server.MapPath(filePath);
            string uploadFilePath = "~/Allegati/";
            string physicalUploadFilePath = Server.MapPath(uploadFilePath);
            string savePath;

            if (File.Exists(physicalPath))
            {
                string[] lines = File.ReadAllLines(physicalPath);
                File.WriteAllText(physicalPath, string.Empty);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    if (values[0] == Session["rowId"].ToString())
                    {
                        values[1] = NomeTextBox2.Text;
                        values[2] = CognomeTextBox2.Text;
                        values[3] = NumTextBox2.Text;
                        values[4] = DateTime.Now.ToShortDateString();
                        if (FileUpload.PostedFile != null)
                        {
                            values[5] = values[1] + "_" + Guid.NewGuid().ToString();
                            savePath = physicalUploadFilePath + "\\" + values[5];
                            FileUpload.PostedFile.SaveAs(savePath);
                        }
                        lines[i] = values[0] + ',' + values[1] + ',' + values[2] + "," + values[3] + "," + values[4] + ',' + values[5];  
                    }
                    using (StreamWriter writer = new StreamWriter(physicalPath, true))
                    {
                        writer.WriteLine(lines[i]);
                    }
                }
            }
            else
            {
                lblErrorMessage.Text = "Il file data.txt non esiste.";
            }

            Response.Redirect("IndexGrid.aspx");
        }

    }
}