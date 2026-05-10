using System;
using System.Net.Http;
using System.Windows.Forms;

namespace StudentDesktopClient
{
    public partial class main : Form
    {
        public static readonly HttpClient Client = new HttpClient();
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            Client.BaseAddress = new Uri(@"http://localhost:5254/api/Students/");
        }

        private void tbStudentsList_Click(object sender, EventArgs e)
        {
            var response = Client.Get
        }
    }
}
