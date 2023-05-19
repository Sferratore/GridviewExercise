using System;
using System.IO;

namespace WebApplication1.Pages
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = "~/Allegati/" + Request.QueryString["file"]; // Aggiungo al path virtuale il nome del file dalla query string get
            string physicalPath = Server.MapPath(filePath);  // Creo path fisico da utilizzare con File.Exists (non supporta path virtuale)

            if (File.Exists(physicalPath))
            {
                string fileName = System.IO.Path.GetFileName(filePath);
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.TransmitFile(Server.MapPath(filePath));
                Response.End();
            }
            Response.Redirect("IndexGrid.aspx"); //Rimando all'indice se non è stato scaricato il file. Se esso è stato scaricato, si ferma a riga 19.
        }
    }
}