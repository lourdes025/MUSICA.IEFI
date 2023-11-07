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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MusicaFE
{
    public partial class FormFE : Form
    {

        public Playlist ListaCanciones = new Playlist();  // que hice aca? ya deje que sacara cosa de la clase playlist?
        
        public Cancion cancion = new Cancion();
       
        public FormFE()
        {
            InitializeComponent();
        }
      
        private void btnCargar_Click(object sender, EventArgs e)
        {
           
            cancion.Cargar(txtCodigo.Text,
                           txtNombre.Text,
                            txtArtist.Text);

            ListaCanciones.InsertCancion(cancion);

            limpiarpantalla();

        }

        private void limpiar()
        {
            txtId.Text = "";
        }

        private void limpiarpantalla()
        {
            txtNombre.Text = "";
            txtCodigo.Text = "";
            txtArtist.Text = "";

        }

        /// ////////////////////////////////////////

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtArtist.Focus();

            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtNombre.Focus();
            }
        }

        private void txtArtist_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnCargar.PerformClick();
                txtCodigo.Focus();

            }
        }

        private void VerPlaylist_Click(object sender, EventArgs e)
        {
            Form2 Playlist = new Form2();

            Playlist.ListaCanciones = this.ListaCanciones;
            Playlist.cancion = this.cancion;

            Playlist.Show();

            this.Hide();
            //aca deberia agregar algo?
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ESTA SEGURO DE QUE QUIERE SALIR?", "EXIT APPLICATION", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Cancion can = ListaCanciones.Buscar(txtId.Text);

            if (can.Id != 0)
            {
                txtCodigo.Text = can.Año.ToString();
                txtNombre.Text = can.Nombre;
                txtArtist.Text = can.Artista;

                txtNombre.Focus();
            }
            else
            {
                txtId.Text = "no existe";
                txtId.SelectAll();
                txtId.Focus();
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
           ListaCanciones.Borrar(txtId.Text);
           limpiarpantalla();
            limpiar();


        }
    }

}

