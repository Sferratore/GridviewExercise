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
            string filePath = "C:\\Users\\F.P.S\\Desktop\\Progetto Lavoro\\WebApplication1\\Data\\data.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(nome + "," + cognome + "," + numero + "," + DateTime.Now.ToShortDateString());
            }

            Response.Redirect("IndexGrid.aspx");
        }
    }
}