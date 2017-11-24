using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity; // NEED this to use Include()
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooER.DAL;
using ZooER.Models;
using System.Xml;
using System.Data.Entity.Infrastructure;

namespace ZooER
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            CreateDesignModel();
        }

        // Derive the model from the context!
        //
        public void CreateDesignModel()
        {
            using (var context = new ZooContext())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(@"Model.edmx", settings))
                {
                    EdmxWriter.WriteEdmx(context, writer);
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {

            Form frm = new CRUDPanel();
            frm.Show();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            Form frm = new BookingPanel();
            frm.Show();
        }

        private void btnCancelBook_Click(object sender, EventArgs e)
        {
            Form frm = new CancelBookingPanel();
            frm.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}