using System;
using Xamarin.Forms;

namespace ScoutingApp2019 {
    public partial class MainPage : TabbedPage {
        public DataHandler data;

        public MainPage() {
            InitializeComponent();

            data = new DataHandler("/storage/emulated/0/Android/data/com.companyname.ScoutingApp2019.Android/files/testfile.txt");
            //data = new DataHandler("/storage/sdcard0/testfile.txt");
        }

        private void MainTabbedPage_CurrentPageChanged(object sender, EventArgs e) {
            switch (MainTabbedPage.CurrentPage.TabIndex) {
                case 0:
                    BarBackgroundColor = new Color(0.0, 0.6, 0.0);
                    break;
                case 1:
                    BarBackgroundColor = new Color(0.5, 0.3, 0.0);
                    break;
                case 2:
                    BarBackgroundColor = new Color(0.7, 0.0, 0.0);
                    break;
                case 3:
                    BarBackgroundColor = new Color(0.0, 0.0, 0.6);
                    break;
                default:
                    BarBackgroundColor = new Color(0.0, 0.0, 0.0);
                    break;
            }
        }

        private void SubmitButton_Clicked(object sender, EventArgs e) {
            if (NameEntry.Text == "" || MatchEntry.Text == "" || RobotNumEntry.Text == "" || AllianceColorPicker.SelectedIndex == -1 || StartPositionEntry.Text == "" || PreloadedItemPicker.SelectedIndex == -1)
                DisplayAlert("Error", "Not all data entries are filled", "OK");
            else {
                data.ScoutName = NameEntry.Text;
                data.MatchNumber = int.Parse(MatchEntry.Text);
                data.ReplayMatch = ReplaySwitch.IsToggled ? 1 : 0;
                data.TeamNumber = int.Parse(RobotNumEntry.Text);
                data.AllianceColor = (string)AllianceColorPicker.SelectedItem;
                data.StartPosition = int.Parse(StartPositionEntry.Text);
                data.PreloadedItem = PreloadedItemPicker.SelectedIndex;
                data.HabLevel = HabLevelPicker.SelectedIndex;
                data.CrossHabLine = CrossHabLineSwitch.IsToggled ? 1 : 0;
                data.HadAssistance = EndHelped.IsToggled ? 1 : 0;
                data.AssistedOthers = EndAssist.IsToggled ? 1 : 0;
                data.BuildString("\t");
                data.WriteToFile();
                DisplayAlert("Saved", "The data you entered has been saved to a file", "OK");
                CurrentPage = new MainPage();
            }
        }

        private void SandCargoShipPlus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoShip < 8)
                SandCargoShipTotal.Text = (++data.SandCargoShip).ToString();
        }

        private void SandCargoShipMinus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoShip > 0)
                SandCargoShipTotal.Text = (--data.SandCargoShip).ToString();
        }

        private void SandShipHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelShip > 0)
                sandShipHatchTotal.Text = (--data.SandPanelShip).ToString();
        }

        private void SandShipHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelShip < 8)
                sandShipHatchTotal.Text = (++data.SandPanelShip).ToString();
        }

        private void SandRocketTCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoRocket3 > 0)
                sandRocketTCargoTotal.Text = (--data.SandCargoRocket3).ToString();
        }

        private void SandRocketTCargoPlus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoRocket3 < 4)
                sandRocketTCargoTotal.Text = (++data.SandCargoRocket3).ToString();
        }

        private void SandRocketTHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelRocket3 > 0)
                sandRocketTHatchTotal.Text = (--data.SandPanelRocket3).ToString();
        }

        private void SandRocketTHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelRocket3 < 4)
                sandRocketTHatchTotal.Text = (++data.SandPanelRocket3).ToString();
        }

        private void SandRocketMCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoRocket2 > 0)
                sandRocketMCargoTotal.Text = (--data.SandCargoRocket2).ToString();
        }

        private void SandRocketMCargoPlus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoRocket2 < 4)
                sandRocketMCargoTotal.Text = (++data.SandCargoRocket2).ToString();
        }

        private void SandRocketMHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelRocket2 > 0)
                sandRocketMHatchTotal.Text = (--data.SandPanelRocket2).ToString();
        }

        private void SandRocketMHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelRocket2 < 4)
                sandRocketMHatchTotal.Text = (++data.SandPanelRocket2).ToString();
        }

        private void SandRocketBCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoRocket1 > 0)
                sandRocketBCargoTotal.Text = (--data.SandCargoRocket1).ToString();
        }

        private void SandRocketBCargoPlus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoRocket1 < 4)
                sandRocketBCargoTotal.Text = (++data.SandCargoRocket1).ToString();
        }

        private void SandRocketBHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelRocket1 > 0)
                sandRocketBHatchTotal.Text = (--data.SandPanelRocket1).ToString();
        }

        private void SandRocketBHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelRocket1 < 4)
                sandRocketBHatchTotal.Text = (++data.SandPanelRocket1).ToString();
        }

        private void SandFailsHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelDrop > 0)
                sandFailsHatchTotal.Text = (--data.SandPanelDrop).ToString();
        }

        private void SandFailsHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.SandPanelDrop < 99)
                sandFailsHatchTotal.Text = (++data.SandPanelDrop).ToString();
        }

        private void SandFailsCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoDrop > 0)
                sandFailsCargoTotal.Text = (--data.SandCargoDrop).ToString();
        }

        private void SandFailsCargoPlus_Clicked(object sender, EventArgs e) {
            if (data.SandCargoDrop < 99)
                sandFailsCargoTotal.Text = (++data.SandCargoDrop).ToString();
        }

        //TELEOP
        private void TeleCargoShipPlus_Clicked(object sender, EventArgs e) {
            if (data.TeleCargoShip < 8)
                teleShipCargoTotal.Text = (++data.TeleCargoShip).ToString();
        }

        private void Tele_ShipCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.TeleCargoShip > 0)
                teleShipCargoTotal.Text = (--data.TeleCargoShip).ToString();
        }

        private void TeleShipHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.TelePanelShip > 0)
                teleShipHatchTotal.Text = (--data.TelePanelShip).ToString();
        }

        private void TeleShipHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.TelePanelShip < 8)
                teleShipHatchTotal.Text = (++data.TelePanelShip).ToString();
        }

        private void TeleRocketTCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.TeleCargoRocket3 > 0)
                teleRocketTCargoTotal.Text = (--data.TeleCargoRocket3).ToString();
        }

        private void TeleRocketTCargoPlus_Clicked(object sender, EventArgs e) {
            if (data.TeleCargoRocket3 < 4)
                teleRocketTCargoTotal.Text = (++data.TeleCargoRocket3).ToString();
        }

        private void TeleRocketTHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.TelePanelRocket3 > 0)
                teleRocketTHatchTotal.Text = (--data.TelePanelRocket3).ToString();
        }

        private void TeleRocketTHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.TelePanelRocket3 < 4)
                teleRocketTHatchTotal.Text = (++data.TelePanelRocket3).ToString();
        }

        private void TeleRocketMCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.TeleCargoRocket2 > 0)
                teleRocketMCargoTotal.Text = (--data.TeleCargoRocket2).ToString();
        }

        private void TeleRocketMCargoPlus_Clicked(object sender, EventArgs e) {
            if (data.TeleCargoRocket2 < 4)
                teleRocketMCargoTotal.Text = (++data.TeleCargoRocket2).ToString();
        }

        private void TeleRocketMHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.TelePanelRocket2 > 0)
                teleRocketMHatchTotal.Text = (--data.TelePanelRocket2).ToString();
        }

        private void TeleRocketMHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.TelePanelRocket2 < 4)
                teleRocketMHatchTotal.Text = (++data.TelePanelRocket2).ToString();
        }

        private void TeleRocketBCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.TeleCargoRocket1 > 0)
                teleRocketBCargoTotal.Text = (--data.TeleCargoRocket1).ToString();
        }

        private void TeleRocketBCargoPlus_Clicked(object sender, EventArgs e) {
            if (data.TeleCargoRocket1 < 4)
                teleRocketBCargoTotal.Text = (++data.TeleCargoRocket1).ToString();
        }

        private void TeleRocketBHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.TelePanelRocket1 > 0)
                teleRocketBHatchTotal.Text = (--data.TelePanelRocket1).ToString();
        }

        private void TeleRocketBHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.TelePanelRocket1 < 4)
                teleRocketBHatchTotal.Text = (++data.TelePanelRocket1).ToString();
        }

        private void TeleFailsHatchMinus_Clicked(object sender, EventArgs e) {
            if (data.TelePanelDrop > 0)
                teleFailsHatchTotal.Text = (--data.TelePanelDrop).ToString();
        }

        private void TeleFailsHatchPlus_Clicked(object sender, EventArgs e) {
            if (data.TelePanelDrop < 99)
                teleFailsHatchTotal.Text = (++data.TelePanelDrop).ToString();
        }

        private void TeleFailsCargoMinus_Clicked(object sender, EventArgs e) {
            if (data.TeleCargoDrop > 0)
                teleFailsCargoTotal.Text = (--data.TeleCargoDrop).ToString();
        }

        private void TeleFailsCargoPlus_Clicked(object sender, EventArgs e) {
            if (data.TeleCargoDrop < 99)
                teleFailsCargoTotal.Text = (++data.TeleCargoDrop).ToString();
        }
    }
}
