using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace WebApplication1.Pages
{
    public partial class IndexGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ottengo i dati dal file
            string filePath = "~/Data/data.txt";
            string physicalPath = Server.MapPath(filePath);

            if (File.Exists(physicalPath))
            {

                GridView1.DataSource = GetDataSource(physicalPath); //ottengo un oggetto DataTable che funge da origine dati
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
                    list.RemoveAt(4);

                    //Aggiunta del file 

                    string attachedFileName = list[4];
                    if (list[3] != "Nessun file caricato")
                    {
                        string attachedFilePath = "~/Allegati/" + attachedFileName;
                        string physicalAttachedFilePath = Server.MapPath(attachedFilePath);
                    }
                    dataTable.Rows.Add(list.ToArray());

                }
            }

            return dataTable; //restituisco la tabella
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewRecord.aspx");
        }

        protected void ElencoGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {

            if (e.Row.Cells[3].Text == "Nessun file caricato")
            {
                e.Row.Cells[4].Text = "";
            }

        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if(e.CommandName == "ModificaRecord")
            {
                GridViewRow row = GridView1.Rows[rowIndex];
                string rowId = row.Cells[0].Text;
                Session["rowId"] = rowId;

                Response.Redirect("UpdateRecord.aspx");
            }
            if(e.CommandName == "EliminaRecord")
            {
                string filePath = "~/Data/data.txt";
                string physicalPath = Server.MapPath(filePath);

                if (File.Exists(physicalPath))
                {
                    string[] lines = File.ReadAllLines(physicalPath);
                    File.WriteAllText(physicalPath, string.Empty);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] values = lines[i].Split(',');
                        if (values[0] == GridView1.Rows[rowIndex].Cells[0].Text)
                        {
                            break;
                        }
                        using (StreamWriter writer = new StreamWriter(physicalPath, true))
                        {
                            writer.WriteLine(lines[i]);
                        }
                    }
                    Response.Redirect("IndexGrid.aspx");
                }
                else
                {
                    lblErrorMessage.Text = "Il file data.txt non esiste.";
                }
            }
        }
    }
}