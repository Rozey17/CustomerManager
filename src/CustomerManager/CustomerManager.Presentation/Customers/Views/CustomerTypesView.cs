using CustomerManager.BusinessLogic;
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
        private readonly CustomerTypeEngine _engine;

        public CustomerTypesView()
        {
            _engine = new CustomerTypeEngine();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var view = new CreateCustomerTypeView();

            view.ShowDialog();

            RefreshItems();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void RefreshItems()
        {
            var items = _engine.GetAll();

            listView1.Items.Clear();

            foreach (var item in items)
            {
                var listItem = new ListViewItem(item.Id.ToString());

                listItem.SubItems.Add(item.Name);

                listView1.Items.Add(listItem);
            }
        }

        private void CustomerTypesView_Load(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
