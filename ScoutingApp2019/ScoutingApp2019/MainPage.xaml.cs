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

        private void SandFailsHatchMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandFailsHatchTotal.Text);
            temp--;
                sandFailsHatchTotal.Text = temp.ToString();
        }

        private void SandFailsHatchPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandFailsHatchTotal.Text);
            temp++;
                sandFailsHatchTotal.Text = temp.ToString();
        }

        private void SandFailsCargoMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandFailsCargoTotal.Text);
            temp--;
                sandFailsCargoTotal.Text = temp.ToString();
        }

        private void SandFailsCargoPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(sandFailsCargoTotal.Text);
            temp++;
                sandFailsCargoTotal.Text = temp.ToString();
        }
        //TELEOP

        private void TeleShipCargoPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleShipCargoTotal.Text);
            temp++;
            if (temp <= 8)
                teleShipCargoTotal.Text = temp.ToString();

        }

        private void Tele_ShipCargoMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleShipCargoTotal.Text);
            temp--;
            if (temp >= 0)
                teleShipCargoTotal.Text = temp.ToString();
        }

        private void TeleShipHatchMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleShipHatchTotal.Text);
            temp--;
            if (temp >= 0)
                teleShipHatchTotal.Text = temp.ToString();
        }

        private void TeleShipHatchPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleShipHatchTotal.Text);
            temp++;
            if (temp <= 8)
                teleShipHatchTotal.Text = temp.ToString();
        }

        private void TeleRock1TCargoMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1TCargoTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1TCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1TCargoPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1TCargoTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1TCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1THatchMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1THatchTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1THatchTotal.Text = temp.ToString();
        }

        private void TeleRock1THatchPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1THatchTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1THatchTotal.Text = temp.ToString();
        }

        private void TeleRock1MCargoMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1MCargoTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1MCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1MCargoPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1MCargoTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1MCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1MHatchMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1MHatchTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1MHatchTotal.Text = temp.ToString();
        }

        private void TeleRock1MHatchPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1MHatchTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1MHatchTotal.Text = temp.ToString();
        }

        private void TeleRock1BCargoMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1BCargoTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1BCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1BCargoPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1BCargoTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1BCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1BHatchMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1BHatchTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1BHatchTotal.Text = temp.ToString();
        }

        private void TeleRock1BHatchPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleRock1BHatchTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1BHatchTotal.Text = temp.ToString();
        }

        private void TeleFailsHatchMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleFailsHatchTotal.Text);
            temp--;
            teleFailsHatchTotal.Text = temp.ToString();
        }

        private void TeleFailsHatchPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleFailsHatchTotal.Text);
            temp++;
            teleFailsHatchTotal.Text = temp.ToString();
        }

        private void TeleFailsCargoMinus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleFailsCargoTotal.Text);
            temp--;
            teleFailsCargoTotal.Text = temp.ToString();
        }

        private void TeleFailsCargoPlus_Clicked(object sender, EventArgs e)
        {
            int temp = int.Parse(teleFailsCargoTotal.Text);
            temp++;
            teleFailsCargoTotal.Text = temp.ToString();
        }
    }
}
