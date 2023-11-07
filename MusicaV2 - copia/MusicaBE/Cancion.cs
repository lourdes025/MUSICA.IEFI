using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicaBE
{
    public class Cancion
    {
        public int Id { get; set; }
        public int Año { get; set; }
        public string Nombre { get; set; }
        public string Artista { get; set; }

        public void Cargar(string aAño,
                             string aNombre,
                             string aArtista)
        {
            Año = Convert.ToInt32(aAño);
            Nombre = aNombre;
            Artista = aArtista;
    
        }

       
    }

}
