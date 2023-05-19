using System;
using System.IO;

namespace WebApplication1.Pages
{
    public partial class NewRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SubmitButton_Click(object sender, EventArgs e)
        {
            string nome = NomeTextBox.Text;
            string cognome = CognomeTextBox.Text;
            string numero = NumTextBox.Text;
            string dataFilePath = "~/Data/data.txt";
            string uploadFilePath = "~/Allegati/";
            string physicalDataFilePath = Server.MapPath(dataFilePath);
            string physicalUploadFilePath = Server.MapPath(uploadFilePath);
            string savePath;

            using (StreamWriter writer = new StreamWriter(physicalDataFilePath, true))
            {
                writer.WriteLine(nome + "," + cognome + "," + numero + "," + DateTime.Now.ToShortDateString());
            }

            if (FileUpload.PostedFile != null)
            {
                savePath = physicalUploadFilePath + "\\" + numero;
                FileUpload.PostedFile.SaveAs(savePath);
            }

            Response.Redirect("IndexGrid.aspx");
        }
    }
}