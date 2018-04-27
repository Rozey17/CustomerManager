using CustomerManager.BusinessLogic;
using CustomerManager.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManager.Presentation.Customers.Views
{
    public partial class CreateCustomerTypeView : Form
    {
        private readonly CustomerTypeEngine _engine;

        public CreateCustomerTypeView()
        {
            _engine = new CustomerTypeEngine();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var model = new CustomerTypeModel(Guid.NewGuid(), name);

            if(_engine.Insert(model))
            {
                MessageBox.Show($"Le type de customer '{model.Name}' a été enregistré avec succès", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
