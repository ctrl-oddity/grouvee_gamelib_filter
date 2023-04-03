using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grouvee_gamelib_filter
{
    public partial class UserControl1 : UserControl
    {
        int yearLabelOffset;
        public UserControl1()
        {
            InitializeComponent();

            yearLabelOffset = gameYearLabel.Location.X - (gameNameLabel.Location.X + gameNameLabel.Width);
        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            Point location = new Point(0, gameYearLabel.Location.Y);
            location.X = gameNameLabel.Location.X + gameNameLabel.Width + yearLabelOffset;
            gameYearLabel.Location = location;
        }
    }
}
