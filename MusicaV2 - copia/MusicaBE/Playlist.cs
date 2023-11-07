using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicaBE
{
    public class Playlist
    {
        public DataTable ListaDT { get; set; } = new DataTable();

        public Playlist()
        {
            ListaDT.TableName = "PLAYLIST";
            ListaDT.Columns.Add("Id", typeof(int));
            ListaDT.Columns.Add("Año", typeof(int));
            ListaDT.Columns.Add("Nombre");
            ListaDT.Columns.Add("Artista");
            LeerArchivo();
        }
        public void LeerArchivo()
        {
            if (System.IO.File.Exists("Playlist.xml"))
            {
                ListaDT.ReadXml("Playlist.xml");
            }
        }
        public void InsertCancion(Cancion acancion)
        {
            int id = NuevoId();

            ListaDT.Rows.Add(); //agrego renglon vacio
            int NuevoRenglon = ListaDT.Rows.Count - 1;
            ListaDT.Rows[NuevoRenglon]["Id"] = id;
            ListaDT.Rows[NuevoRenglon]["Año"] = acancion.Año;
            ListaDT.Rows[NuevoRenglon]["Nombre"] = acancion.Nombre;
            ListaDT.Rows[NuevoRenglon]["Artista"] = acancion.Artista;

            ListaDT.WriteXml("Playlist.xml");
        }
        private int NuevoId()
        {
            int NuevoId = 0;

            foreach (DataRow fila in ListaDT.Rows)
            {
                if (NuevoId < Convert.ToInt32(fila["Id"]))
                {
                    NuevoId = Convert.ToInt32(fila["Id"]);
                }
            }

            NuevoId++;
            return NuevoId;
        }
        public Cancion Buscar(string aId)
        {
            int id = Convert.ToInt32(aId);

            Cancion cancion = new Cancion();

           
            foreach (DataRow fila in ListaDT.Rows)
            {
                if (Convert.ToInt32(fila["Id"]) == id)
                {
                    cancion.Id = Convert.ToInt32(fila["Id"]);
                    cancion.Año = Convert.ToInt32(fila["Año"]);
                    cancion.Nombre = fila["Nombre"].ToString();
                    cancion.Artista = fila["Artista"].ToString(); ;
                    break;
                }
            }


            return cancion;
           


        }
        public void Borrar(string aId)
        {
            int id = Convert.ToInt32(aId);


            foreach (DataRow fila in ListaDT.Rows)
            {
                if (Convert.ToInt32(fila["Id"]) == id)
                {

                    ListaDT.Rows.Remove(fila);
                    ListaDT.WriteXml("Playlist.xml");
                    break;
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////





    }
}
