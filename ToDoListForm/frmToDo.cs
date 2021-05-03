using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListForm
{
    public partial class frmToDo : Form
    {
       
        public frmToDo()
        {
            InitializeComponent();
        }

        private void frmToDo_Load(object sender, EventArgs e)
        {
            ListUtil.toDoList = TextFileUtil.readFromFile();
            loadListBox();
        }

        private void loadListBox()
        {
            lstToDo.Items.Clear();
            foreach (ToDo t in ListUtil.toDoList.OrderByDescending(l => l.Priority))
            {
                lstToDo.Items.Add(t.ToString());
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string category = txbCategory.Text;
            string desc = txbItem.Text;

            DateTime dates = DateTime.Now;

            ToDo.Levels level;
            switch (cmbLevel.SelectedItem.ToString())
            {
                case "Not Important":
                    level = ToDo.Levels.NotImportant;
                    break;
                case "Important":
                    level = ToDo.Levels.Important;
                    break;
                default:
                    level = ToDo.Levels.Urgent;
                    break;
            }
            ToDo toDo = new ToDo(category, desc, dates, level);
            ListUtil.toDoList.Add(toDo);

            TextFileUtil.writeToFile(ListUtil.toDoList);
            loadListBox();
        }
    }
}
