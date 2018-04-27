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
    public partial class CustomerTypesView : Form
    {
        public CustomerTypesView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var view = new CreateCustomerTypeView();

            view.ShowDialog();
        }
    }
}
