using Android.Content;
using System;
using System.IO;
using Xamarin.Forms;

namespace ScoutingApp2019 {
	public partial class MainPage : TabbedPage {
		private DataHandler data;

		private string[] teams;

		public MainPage() {
			InitializeComponent();

			data = new DataHandler("/storage/emulated/0/Download/", "2019_champs_full_data", "2019_champs_partial_data_");
			StreamReader streamReader = new StreamReader(Android.App.Application.Context.Assets.Open("2019_champs_curie_teams.txt"));
			teams = streamReader.ReadLine().ToString().Split(',');
			streamReader.Close();
			streamReader.Dispose();
			ResetAll();
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
			}
		}

		private async void SubmitButton_Clicked(object sender, EventArgs e) {
			if (NameEntry.Text == "" ||
				MatchEntry.Text == "" ||
				RobotNumEntry.Text == "" ||
				AllianceColorPicker.SelectedIndex == -1 ||
				StartPositionEntry.Text == "" ||
				PreloadedItemPicker.SelectedIndex == -1 ||
				HabLevelAttemptedPicker.SelectedIndex == -1 ||
				HabLevelAchievedPicker.SelectedIndex == -1 ||
				NewFilePicker.SelectedIndex == -1 ||
				DefenseAmountPicker.SelectedIndex == -1 ||
				DefenseSkillPicker.SelectedIndex == -1 ||
				DefendedAmountPicker.SelectedIndex == -1 ||
				DefendedSkillPicker.SelectedIndex == -1)
				await DisplayAlert("Error", "Not all data entries are filled", "OK");
			else {
				data.ScoutName = NameEntry.Text;
				data.MatchNumber = int.Parse(MatchEntry.Text);
				data.ReplayMatch = ReplaySwitch.IsToggled ? 1 : 0;
				data.TeamNumber = int.Parse(RobotNumEntry.Text);
				data.AllianceColor = (string)AllianceColorPicker.SelectedItem;
				data.StartPosition = int.Parse(StartPositionEntry.Text);
				data.PreloadedItem = PreloadedItemPicker.SelectedIndex;
				data.CrossHabLine = CrossHabLineSwitch.IsToggled ? 1 : 0;
				data.HabLevelAchieved = HabLevelAttemptedPicker.SelectedIndex;
				data.HadAssistance = EndHelped.IsToggled ? 1 : 0;
				data.AssistedOthers = EndAssist.IsToggled ? 1 : 0;
				data.HabLevelAttempted = HabLevelAttemptedPicker.SelectedIndex;
				data.HabLevelAchieved = HabLevelAchievedPicker.SelectedIndex;
				data.DefenseAmount = DefenseAmountPicker.SelectedIndex;
				data.DefenseSkill = DefenseSkillPicker.SelectedIndex;
				data.DefendedAmount = DefendedAmountPicker.SelectedIndex;
				data.DefendedSkill = DefendedSkillPicker.SelectedIndex;
				data.Comments = CommentsEntry.Text;
				data.BuildString("\t");
				try {
					data.WriteToTextFile(NewFilePicker.SelectedIndex == 0);
					await DisplayAlert("Saved", "The data you entered has been saved to a file", "OK");
					ResetAll();
					CurrentPage = new MainPage();
				} catch (UnauthorizedAccessException) {
					if (await DisplayAlert("Error", "App does not have permission to access device storage. To fix this, go to \"Settings > Apps > ScoutingApp2019.Android > Permissions\" and turn on the switch for \"Storage\".", "Settings", "Cancel"))
						Android.App.Application.Context.StartActivity(new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings, Android.Net.Uri.Parse("package:" + Android.App.Application.Context.PackageName)));
				}
			}
		}

		private void RobotNumEntry_Unfocused(object sender, FocusEventArgs e) {
			bool valid = false;
			foreach (string team in teams)
				if (RobotNumEntry.Text == team || RobotNumEntry.Text == "") {
					valid = true;
					break;
				}
			if (!valid) {
				DisplayAlert("Invalid Team Number", "The team number you entered does not match any of the teams at this event", "OK");
				RobotNumEntry.Focus();
			}
		}

		private void ResetAll() {
			//page 1
			NameEntry.Text = "";
			MatchEntry.Text = "";
			ReplaySwitch.IsToggled = false;
			RobotNumEntry.Text = "";
			AllianceColorPicker.SelectedIndex = -1;
			StartPositionEntry.Text = "";
			PreloadedItemPicker.SelectedIndex = -1;
			//page 2
			sandRocketBCargoTotal.Text = "0";
			sandRocketBHatchTotal.Text = "0";
			sandRocketMCargoTotal.Text = "0";
			sandRocketMHatchTotal.Text = "0";
			sandRocketTCargoTotal.Text = "0";
			sandRocketTHatchTotal.Text = "0";
			SandCargoShipTotal.Text = "0";
			sandShipHatchTotal.Text = "0";
			sandFailsCargoTotal.Text = "0";
			sandFailsHatchTotal.Text = "0";
			//page 3
			teleRocketBCargoTotal.Text = "0";
			teleRocketBHatchTotal.Text = "0";
			teleRocketMCargoTotal.Text = "0";
			teleRocketMHatchTotal.Text = "0";
			teleRocketTCargoTotal.Text = "0";
			teleRocketTHatchTotal.Text = "0";
			teleShipCargoTotal.Text = "0";
			teleShipHatchTotal.Text = "0";
			teleFailsCargoTotal.Text = "0";
			teleFailsHatchTotal.Text = "0";
			//page 4
			HabLevelAttemptedPicker.SelectedIndex = -1;
			HabLevelAchievedPicker.SelectedIndex = -1;
			EndHelped.IsToggled = false;
			EndAssist.IsToggled = false;
			CommentsEntry.Text = "";
			NewFilePicker.SelectedIndex = 1;
			DefenseAmountPicker.SelectedIndex = -1;
			DefenseSkillPicker.SelectedIndex = -1;
			DefendedAmountPicker.SelectedIndex = -1;
			DefendedSkillPicker.SelectedIndex = -1;
			//data variables
			data.SandCargoShip = 0;
			data.SandCargoRocket1 = 0;
			data.SandCargoRocket2 = 0;
			data.SandCargoRocket3 = 0;
			data.SandCargoDrop = 0;
			data.SandPanelShip = 0;
			data.SandPanelRocket1 = 0;
			data.SandPanelRocket2 = 0;
			data.SandPanelRocket3 = 0;
			data.SandPanelDrop = 0;
			data.TeleCargoShip = 0;
			data.TeleCargoRocket1 = 0;
			data.TeleCargoRocket2 = 0;
			data.TeleCargoRocket3 = 0;
			data.TeleCargoDrop = 0;
			data.TelePanelShip = 0;
			data.TelePanelRocket1 = 0;
			data.TelePanelRocket2 = 0;
			data.TelePanelRocket3 = 0;
			data.TelePanelDrop = 0;
			//this is last to prevent the warning from appearing after hitting the submit button
			CrossHabLineSwitch.IsToggled = false;
		}

		private async void CrossHabLineSwitch_Toggled(object sender, ToggledEventArgs e) {
			if (!CrossHabLineSwitch.IsToggled) {
				if (data.SandCargoShip > 0 ||
					data.SandCargoRocket1 > 0 ||
					data.SandCargoRocket2 > 0 ||
					data.SandCargoRocket3 > 0 ||
					data.SandPanelShip > 0 ||
					data.SandPanelRocket1 > 0 ||
					data.SandPanelRocket1 > 0 ||
					data.SandPanelRocket3 > 0) {
					if (await DisplayAlert("Warning", "All values on the Sandstorm page will be reset to zero because nothing can be scored if the robot hasn't crossed the HAB Line. Do you want to continue?", "Yes", "No")) {
						sandRocketBCargoTotal.Text = "0";
						sandRocketBHatchTotal.Text = "0";
						sandRocketMCargoTotal.Text = "0";
						sandRocketMHatchTotal.Text = "0";
						sandRocketTCargoTotal.Text = "0";
						sandRocketTHatchTotal.Text = "0";
						SandCargoShipTotal.Text = "0";
						sandShipHatchTotal.Text = "0";
						data.SandCargoShip = 0;
						data.SandCargoRocket1 = 0;
						data.SandCargoRocket2 = 0;
						data.SandCargoRocket3 = 0;
						data.SandPanelShip = 0;
						data.SandPanelRocket1 = 0;
						data.SandPanelRocket2 = 0;
						data.SandPanelRocket3 = 0;
					} else
						CrossHabLineSwitch.IsToggled = true;
				}
			}
		}

		//button click events
		private void SandCargoShipPlus_Clicked(object sender, EventArgs e) {
			if (data.SandCargoShip < 8 && CrossHabLineSwitch.IsToggled)
				SandCargoShipTotal.Text = (++data.SandCargoShip).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandCargoShipMinus_Clicked(object sender, EventArgs e) {
			if (data.SandCargoShip > 0 && CrossHabLineSwitch.IsToggled)
				SandCargoShipTotal.Text = (--data.SandCargoShip).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandShipHatchMinus_Clicked(object sender, EventArgs e) {
			if (data.SandPanelShip > 0 && CrossHabLineSwitch.IsToggled)
				sandShipHatchTotal.Text = (--data.SandPanelShip).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandShipHatchPlus_Clicked(object sender, EventArgs e) {
			if (data.SandPanelShip < 8 && CrossHabLineSwitch.IsToggled)
				sandShipHatchTotal.Text = (++data.SandPanelShip).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketTCargoMinus_Clicked(object sender, EventArgs e) {
			if (data.SandCargoRocket3 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketTCargoTotal.Text = (--data.SandCargoRocket3).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketTCargoPlus_Clicked(object sender, EventArgs e) {
			if (data.SandCargoRocket3 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketTCargoTotal.Text = (++data.SandCargoRocket3).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketTHatchMinus_Clicked(object sender, EventArgs e) {
			if (data.SandPanelRocket3 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketTHatchTotal.Text = (--data.SandPanelRocket3).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketTHatchPlus_Clicked(object sender, EventArgs e) {
			if (data.SandPanelRocket3 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketTHatchTotal.Text = (++data.SandPanelRocket3).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketMCargoMinus_Clicked(object sender, EventArgs e) {
			if (data.SandCargoRocket2 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketMCargoTotal.Text = (--data.SandCargoRocket2).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketMCargoPlus_Clicked(object sender, EventArgs e) {
			if (data.SandCargoRocket2 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketMCargoTotal.Text = (++data.SandCargoRocket2).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketMHatchMinus_Clicked(object sender, EventArgs e) {
			if (data.SandPanelRocket2 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketMHatchTotal.Text = (--data.SandPanelRocket2).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketMHatchPlus_Clicked(object sender, EventArgs e) {
			if (data.SandPanelRocket2 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketMHatchTotal.Text = (++data.SandPanelRocket2).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketBCargoMinus_Clicked(object sender, EventArgs e) {
			if (data.SandCargoRocket1 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketBCargoTotal.Text = (--data.SandCargoRocket1).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketBCargoPlus_Clicked(object sender, EventArgs e) {
			if (data.SandCargoRocket1 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketBCargoTotal.Text = (++data.SandCargoRocket1).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketBHatchMinus_Clicked(object sender, EventArgs e) {
			if (data.SandPanelRocket1 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketBHatchTotal.Text = (--data.SandPanelRocket1).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketBHatchPlus_Clicked(object sender, EventArgs e) {
			if (data.SandPanelRocket1 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketBHatchTotal.Text = (++data.SandPanelRocket1).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
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
