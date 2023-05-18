using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace WebApplication1.Pages
{
    public partial class IndexGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ottengo i dati dal file
            string filePath = "C:\\Users\\F.P.S\\Desktop\\Progetto Lavoro\\WebApplication1\\Data\\data.txt";

            if (File.Exists(filePath))
            {

                GridView1.DataSource = GetDataSource(filePath); //ottengo un oggetto DataTable che funge da origine dati
                GridView1.DataBind(); //Collego la parte visuale all'origine dati
            }
            else
            {
                lblErrorMessage.Text = "Il file data.txt non esiste.";
            }
        }

        private DataTable GetDataSource(string filePath)  //Datatable è una classe di System.Data che rappresenta una tabella di dati in memoria. Essa è composta da una raccolta di oggetti DataRow, che rappresentano le righe dei dati, e da una raccolta di oggetti DataColumn, che rappresentano le colonne della tabella.
        {
            DataTable dataTable = new DataTable();  //Creazione oggetto
            string[] lines = File.ReadAllLines(filePath);  //ReadAllLines divide i dati in una matrice di righe

            if (lines.Length > 0)  //Aggiungo gli header del file come colonne
            {
                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    if (header != "DataInserimento")   //Aggiungo tutti gli header tranne la data inserimento
                        dataTable.Columns.Add(header);
                }

                for (int i = 1; i < lines.Length; i++)  //Aggiungo i dati rimanenti
                {
                    string[] values = lines[i].Split(',');
                    List<string> list = new List<string>(values); //Converto in stringa per rimuovere totalmente la data inserimento
                    list.RemoveAt(3);

                    dataTable.Rows.Add(list.ToArray());

                }
            }

            return dataTable; //restituisco la tabella
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewRecord.aspx");
        }
    }
}