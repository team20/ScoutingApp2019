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

        private void SandRock1THatchMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1THatchTotal.Text);
            temp--;
            if (temp >= 0)
                sandRock1THatchTotal.Text = temp.ToString();
        }

        private void SandRock1THatchPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1THatchTotal.Text);
            temp++;
            if (temp <= 8)
                sandRock1THatchTotal.Text = temp.ToString();
        }

        private void SandRock1MCargoMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1MCargoTotal.Text);
            temp--;
            if (temp >= 0)
                sandRock1MCargoTotal.Text = temp.ToString();
        }

        private void SandRock1MCargoPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1MCargoTotal.Text);
            temp++;
            if (temp <= 8)
                sandRock1MCargoTotal.Text = temp.ToString();
        }

        private void SandRock1MHatchMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1MHatchTotal.Text);
            temp--;
            if (temp >= 0)
                sandRock1MHatchTotal.Text = temp.ToString();
        }

        private void SandRock1MHatchPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1MHatchTotal.Text);
            temp++;
            if (temp <= 8)
                sandRock1MHatchTotal.Text = temp.ToString();
        }

        private void SandRock1BCargoMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1BCargoTotal.Text);
            temp--;
            if (temp >= 0)
                sandRock1BCargoTotal.Text = temp.ToString();
        }

        private void SandRock1BCargoPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1BCargoTotal.Text);
            temp++;
            if (temp <= 8)
                sandRock1BCargoTotal.Text = temp.ToString();
        }

        private void SandRock1BHatchMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1BHatchTotal.Text);
            temp--;
            if (temp >= 0)
                sandRock1BHatchTotal.Text = temp.ToString();
        }

        private void SandRock1BHatchPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandRock1BHatchTotal.Text);
            temp++;
            if (temp <= 8)
                sandRock1BHatchTotal.Text = temp.ToString();
        }
    }
}
