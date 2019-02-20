using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScoutingApp2019
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SandShipCargoPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandShipCargoTotal.Text);
            temp++;
            if (temp <= 8)
                sandShipCargoTotal.Text = temp.ToString();

        }

        private void Sand_ShipCargoMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandShipCargoTotal.Text);
            temp--;
            if (temp >= 0)
                sandShipCargoTotal.Text = temp.ToString();
        }

        private void SandShipHatchMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandShipHatchTotal.Text);
            temp--;
            if (temp >= 0)
                sandShipHatchTotal.Text = temp.ToString();
        }

        private void SandShipHatchPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandShipHatchTotal.Text);
            temp++;
            if (temp <= 8)
                sandShipHatchTotal.Text = temp.ToString();
        }

        private void SandRock1TCargoMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1TCargoTotal.Text);
            temp--;
            if (temp >= 0)
                sandRock1TCargoTotal.Text = temp.ToString();
        }

        private void SandRock1TCargoPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1TCargoTotal.Text);
            temp++;
            if (temp <= 8)
                sandRock1TCargoTotal.Text = temp.ToString();
        }
    }
}
