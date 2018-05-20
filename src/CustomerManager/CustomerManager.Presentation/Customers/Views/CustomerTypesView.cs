﻿using CustomerManager.BusinessLogic;
using CustomerManager.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CustomerManager.Presentation.Customers.Views
{
    public partial class CustomerTypesView : Form
    {
        private readonly CustomerTypeEngine _engine;

        private List<CustomerTypeModel> _items;


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

        private async void button3_Click(object sender, EventArgs e)
        {
            await Task.Delay(5000); // every task is awaitable
            RefreshItems();
        }

        private async void RefreshItems()
        {
            _items = (await _engine.GetAllAsync()).ToList();

            listView1.Items.Clear();
            
            foreach (var item in _items)
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

        private async void button2_Click(object sender, EventArgs e)
        {
            var selectedIndex = listView1.SelectedIndices[0];

            var selectCustomerType = _items.ElementAt(selectedIndex);

            if (MessageBox.Show($"Voulez vous vraiment supprimer l'élément '{selectCustomerType.Name}' ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (await _engine.DeleteAsync(selectCustomerType.Id))
                {
                    MessageBox.Show($"Le type de customer '{selectCustomerType.Name}' a été effacé avec succès", "DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshItems();
                }
            }          
        }
    }
}
