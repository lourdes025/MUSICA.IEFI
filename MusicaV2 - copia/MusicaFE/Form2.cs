using MusicaBE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicaFE
{
    public partial class Form2 : Form
    {
        // private string dato;
        public Playlist ListaCanciones = new Playlist();
        public Cancion cancion = new Cancion();

      
        public Form2()
        {
            InitializeComponent();
            dg.DataSource = ListaCanciones.ListaDT;
        }
        /// tengo que vincular los form  
       
        //la idea es sacar el este boton ver y usar directo el del form1
       

        


        private void btnSEGUIR_Click(object sender, EventArgs e)
        {
            FormFE CARGAR = new FormFE();
            CARGAR.Show();

            this.Hide();
        }

       
    }
}


// Luego, puedes llamar al método MostrarLista() de Form1 desde Form2
//          {
//         FormFE.ListaCanciones.Listar();
//      }
//      }
//     }

//public void LlamarMostrarLista()






// private void btnVer_Click(object sender, EventArgs e)
//     {
//       lblListaF2.Text = dato;

//     }
//  public string setdato(string dato)
//     {
//        this.dato = dato;
//    lblListaF2.Text = (dato);
//       return dato;

// }
// }

// }

