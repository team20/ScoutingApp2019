using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ScoutingApp2019 {
    public partial class MainPage : TabbedPage {
        public DataHandler data;

        public MainPage() {
            InitializeComponent();

            data = new DataHandler("/storage/emulated/0/Android/data/com.companyname.ScoutingApp2019.Android/files/testfile.txt");
        }

        private void SubmitButton_Clicked(object sender, EventArgs e) {
            data.BuildString("\t");
            data.WriteToFile();
        }

        private void SandCargoShipPlus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoShip < 8) {
                data.SandCargoShip++;
                SandCargoShipTotal.Text = data.SandCargoShip.ToString();
            }
        }

        private void SandCargoShipMinus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoShip > 0) {
                data.SandCargoShip--;
                SandCargoShipTotal.Text = data.SandCargoShip.ToString();
            }
        }

        private void SandShipHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelShip > 0) {
                data.SandPanelShip--;
                SandCargoShipTotal.Text = data.SandPanelShip.ToString();
            }
        }

        private void SandShipHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelShip < 8) {
                data.SandPanelShip++;
                SandCargoShipTotal.Text = data.SandPanelShip.ToString();
            }
        }

        private void SandRock1TCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoRocket3 > 0) {
                data.SandCargoRocket3--;
                sandRock1TCargoTotal.Text = data.SandCargoRocket3.ToString();
            }
        }

        private void SandRock1TCargoPlus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoRocket3 < 8) {
                data.SandCargoRocket3++;
                sandRock1TCargoTotal.Text = data.SandCargoRocket3.ToString();
            }
        }
        
        private void SandRock1THatchMinus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelRocket3 > 0) {
                data.SandPanelRocket3--;
                sandRock1THatchTotal.Text = data.SandPanelRocket3.ToString();
            }
        }

        private void SandRock1THatchPlus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelRocket3 < 8) {
                data.SandPanelRocket3++;
                sandRock1THatchTotal.Text = data.SandPanelRocket3.ToString();
            }
        }
        //TODO: finish this!!!!!!!!!
        private void SandRock1MCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoRocket2 > 0) {

            }
        }

        private void SandRock1MCargoPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandRock1MCargoTotal.Text);
            temp++;
            if (temp <= 8)
                sandRock1MCargoTotal.Text = temp.ToString();
        }

        private void SandRock1MHatchMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandRock1MHatchTotal.Text);
            temp--;
            if (temp >= 0)
                sandRock1MHatchTotal.Text = temp.ToString();
        }

        private void SandRock1MHatchPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandRock1MHatchTotal.Text);
            temp++;
            if (temp <= 8)
                sandRock1MHatchTotal.Text = temp.ToString();
        }

        private void SandRock1BCargoMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandRock1BCargoTotal.Text);
            temp--;
            if (temp >= 0)
                sandRock1BCargoTotal.Text = temp.ToString();
        }

        private void SandRock1BCargoPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandRock1BCargoTotal.Text);
            temp++;
            if (temp <= 8)
                sandRock1BCargoTotal.Text = temp.ToString();
        }

        private void SandRock1BHatchMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandRock1BHatchTotal.Text);
            temp--;
            if (temp >= 0)
                sandRock1BHatchTotal.Text = temp.ToString();
        }

        private void SandRock1BHatchPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandRock1BHatchTotal.Text);
            temp++;
            if (temp <= 8)
                sandRock1BHatchTotal.Text = temp.ToString();
        }

        private void SandFailsHatchMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandFailsHatchTotal.Text);
            temp--;
            sandFailsHatchTotal.Text = temp.ToString();
        }

        private void SandFailsHatchPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandFailsHatchTotal.Text);
            temp++;
            sandFailsHatchTotal.Text = temp.ToString();
        }

        private void SandFailsCargoMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandFailsCargoTotal.Text);
            temp--;
            sandFailsCargoTotal.Text = temp.ToString();
        }

        private void SandFailsCargoPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(sandFailsCargoTotal.Text);
            temp++;
            sandFailsCargoTotal.Text = temp.ToString();
        }
        //TELEOP

        private void TeleCargoShipPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleShipCargoTotal.Text);
            temp++;
            if (temp <= 8)
                teleShipCargoTotal.Text = temp.ToString();

        }

        private void Tele_ShipCargoMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleShipCargoTotal.Text);
            temp--;
            if (temp >= 0)
                teleShipCargoTotal.Text = temp.ToString();
        }

        private void TeleShipHatchMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleShipHatchTotal.Text);
            temp--;
            if (temp >= 0)
                teleShipHatchTotal.Text = temp.ToString();
        }

        private void TeleShipHatchPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleShipHatchTotal.Text);
            temp++;
            if (temp <= 8)
                teleShipHatchTotal.Text = temp.ToString();
        }

        private void TeleRock1TCargoMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1TCargoTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1TCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1TCargoPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1TCargoTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1TCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1THatchMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1THatchTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1THatchTotal.Text = temp.ToString();
        }

        private void TeleRock1THatchPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1THatchTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1THatchTotal.Text = temp.ToString();
        }

        private void TeleRock1MCargoMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1MCargoTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1MCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1MCargoPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1MCargoTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1MCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1MHatchMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1MHatchTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1MHatchTotal.Text = temp.ToString();
        }

        private void TeleRock1MHatchPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1MHatchTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1MHatchTotal.Text = temp.ToString();
        }

        private void TeleRock1BCargoMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1BCargoTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1BCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1BCargoPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1BCargoTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1BCargoTotal.Text = temp.ToString();
        }

        private void TeleRock1BHatchMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1BHatchTotal.Text);
            temp--;
            if (temp >= 0)
                teleRock1BHatchTotal.Text = temp.ToString();
        }

        private void TeleRock1BHatchPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleRock1BHatchTotal.Text);
            temp++;
            if (temp <= 8)
                teleRock1BHatchTotal.Text = temp.ToString();
        }

        private void TeleFailsHatchMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleFailsHatchTotal.Text);
            temp--;
            teleFailsHatchTotal.Text = temp.ToString();
        }

        private void TeleFailsHatchPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleFailsHatchTotal.Text);
            temp++;
            teleFailsHatchTotal.Text = temp.ToString();
        }

        private void TeleFailsCargoMinus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleFailsCargoTotal.Text);
            temp--;
            teleFailsCargoTotal.Text = temp.ToString();
        }

        private void TeleFailsCargoPlus_Clicked(object sender, EventArgs e) {
            int temp = int.Parse(teleFailsCargoTotal.Text);
            temp++;
            teleFailsCargoTotal.Text = temp.ToString();
        }
    }
}
