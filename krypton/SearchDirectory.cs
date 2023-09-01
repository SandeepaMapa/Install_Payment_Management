using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace krypton
{
    public partial class SearchDirectory : KryptonForm
    {
        public SearchDirectory()
        {
            InitializeComponent();
        }

        private void SearchDirectory_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            Home a = new Home();
            this.Hide();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchCards a = new SearchCards();
            this.Hide();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CompletedCards a = new CompletedCards();
            this.Hide();
            a.Show();
        }
    }
}
