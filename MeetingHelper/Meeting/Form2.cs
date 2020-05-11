using System.Windows.Forms;

namespace DailyHelper
{
    public partial class Form2 : Form
    {
        public Form2(string text)
        {
            this.Name = "Meeting Body";
            InitializeComponent();
            textBox1.Text = text;
        }
    }
}
