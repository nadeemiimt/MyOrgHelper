using Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyHelper.Helper
{
    public class EnumCombobox<T>
    {
        public EnumCombobox(ComboBox comboBox)
        {
            comboBox.DataSource = EnumWithName<T>.ParseEnum();
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Value";
        }
    }
}
