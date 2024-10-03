

using BusinessLogic.core;
using System.ComponentModel;
using System.Data;

namespace Presentation.form
{
    public partial class Menu : Form
    {
        private CRUDFile _CRUDFile = new CRUDFile();
        private Entities.User _loggedUser;
        private Entities.File _file;
        private BindingList<Entities.File> _files = new();

        public Menu(ref Entities.User user)
        {
            InitializeComponent();
            _loggedUser = user;
            dataGridFile.DataSource = _files;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Hi " + _loggedUser.Nickname + "!";
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
            settings.Show();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _file = new Entities.File()
            {
                UserId = Convert.ToInt32(_loggedUser.UserId)
            };

            _CRUDFile.Create(ref _file);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            _file = new Entities.File()
            {
                FileId = Convert.ToInt32(txtFileId.Text),
            };

            _CRUDFile.GetById(ref _file);

            _files.Clear();
            _files.Add(_file);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _file = new Entities.File()
            {
                FileId = Convert.ToInt32(txtFileId.Text),

            };

            _CRUDFile.Update(ref _file);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _file = new Entities.File()
            {
                FileId = Convert.ToInt32(txtFileId.Text)
            };

            _CRUDFile.Delete(ref _file);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _file = new Entities.File();
            _CRUDFile.GetAll(ref _file); 

            foreach (DataRow row in _file.DataSetResultado.Rows)
            {
                Entities.File file = new Entities.File
                {
                    FileId = Convert.ToInt32(row["FileId"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    LastModifiedAt = Convert.ToDateTime(row["LastModifiedDate"]),
                    UserId = Convert.ToInt32(row["UserId"])
                };

                _files.Add(file);
            }

        }

    }
}
