using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.form
{
    public partial class Menu : Form
    {

        private Entities.User _loggedUser;

        public Menu(ref Entities.User user)
        {
            InitializeComponent();
            _loggedUser = user;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Hi " + _loggedUser.Nickname + "!";
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSignOut_Click(object sender, EventArgs e)
        {
            _loggedUser = null;

            this.Hide();

            // Opcional: Mostrar nuevamente el formulario de inicio de sesión
            Login login = new Login();
            login.Show();
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(ref _loggedUser);
            this.Hide();
            settings.Show();
            
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
