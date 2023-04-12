using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Reactor_Interface.Classes.Weigher;

namespace Reactor_Interface.Forms.Journal
{
    public partial class Fill_mass_field_menu : Form
    {
        private Dictionary<string, List<RichTextBox>> pages;
        private WeigherReader _weigherReader;

        private const string listViewName = "listView";

        public Fill_mass_field_menu(Dictionary<string, List<RichTextBox>> massboxes, WeigherReader weigherReader)
        {
            InitializeComponent();
            pages = massboxes;
            _weigherReader = weigherReader;

            fill_view();
        }


        private void fill_view()
        {
            foreach(string page_name in pages.Keys)
            {
                create_new_page(page_name, pages[page_name]);
            }
        }

        private void create_new_page(string name, List<RichTextBox> richTextBoxes)
        {
            TabPage page = new TabPage();

            page.Text = name;

            ListView listView = new ListView()
            {
                Name = listViewName,
                View = View.List,
                CheckBoxes = true,
                Dock = DockStyle.Fill,
            };

            foreach(var richTextBox in richTextBoxes)
            {
                listView.Items.Add(richTextBox.Tag.ToString());
                listView.Items[listView.Items.Count - 1].Tag = richTextBox;
            }

            page.Controls.Add(listView);
            fields_control.TabPages.Add(page);
        }

        private void get_mass_btn_Click(object sender, EventArgs e)
        {
            string mass = _weigherReader.GetMass();

            bool HasbeenChosenAtLeastOne = false;

            if(mass == null)
            {
                MessageBox.Show("Проблема с подключением. Проверьте соединение с портом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach(TabPage page in fields_control.TabPages)
            {
                ListView listView = (ListView)page.Controls.Find(listViewName, false)[0];

                foreach(ListViewItem item in listView.Items) 
                { 
                    RichTextBox richTextBox = (RichTextBox)item.Tag;
                    HasbeenChosenAtLeastOne |= item.Checked;
                    if(item.Checked)
                        richTextBox.Text = mass + " г";
                }
            }

            if(HasbeenChosenAtLeastOne)
                MessageBox.Show("Масса внесена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
