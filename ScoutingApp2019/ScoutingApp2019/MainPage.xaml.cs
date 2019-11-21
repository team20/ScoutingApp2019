using Android.Content;
using System;
using System.IO;
using Xamarin.Forms;

namespace ScoutingApp2019 {
	public partial class MainPage : TabbedPage {
		#region Main
		private readonly DataHandler _data;

		private readonly string[] _teams;

		public MainPage() {
			InitializeComponent();

			_data = new DataHandler("/storage/emulated/0/Download/ScoutingData/", "2019_rumble");
			StreamReader streamReader = new StreamReader(Android.App.Application.Context.Assets.Open("2019_rumble_teams.txt"));
			_teams = streamReader.ReadLine().Split(',');
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
					SandFoulsTotal.Text = _data.Fouls.ToString();
					BarBackgroundColor = new Color(0.5, 0.3, 0.0);
					break;
				case 2:
					TeleFoulsTotal.Text = _data.Fouls.ToString();
					BarBackgroundColor = new Color(0.7, 0.0, 0.0);
					break;
				case 3:
					BarBackgroundColor = new Color(0.0, 0.0, 0.6);
					break;
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
			SandFoulsTotal.Text = "0";
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
			TeleFoulsTotal.Text = "0";
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
			BreakdownPicker.SelectedIndex = 0;
			//data variables
			_data.SandCargoShip = 0;
			_data.SandCargoRocket1 = 0;
			_data.SandCargoRocket2 = 0;
			_data.SandCargoRocket3 = 0;
			_data.SandCargoDrop = 0;
			_data.SandPanelShip = 0;
			_data.SandPanelRocket1 = 0;
			_data.SandPanelRocket2 = 0;
			_data.SandPanelRocket3 = 0;
			_data.SandPanelDrop = 0;
			_data.TeleCargoShip = 0;
			_data.TeleCargoRocket1 = 0;
			_data.TeleCargoRocket2 = 0;
			_data.TeleCargoRocket3 = 0;
			_data.TeleCargoDrop = 0;
			_data.TelePanelShip = 0;
			_data.TelePanelRocket1 = 0;
			_data.TelePanelRocket2 = 0;
			_data.TelePanelRocket3 = 0;
			_data.TelePanelDrop = 0;
			_data.Breakdown = "";
			_data.Fouls = 0;
			//this is last to prevent the warning from appearing after hitting the submit button
			CrossHabLineSwitch.IsToggled = false;
		}
		#endregion

		#region Start
		private void RobotNumEntry_Unfocused(object sender, FocusEventArgs e) {
			bool valid = false;
			foreach (string team in _teams)
				if (RobotNumEntry.Text == team || RobotNumEntry.Text == "") {
					valid = true;
					break;
				}
			if (!valid) {
				DisplayAlert("Invalid Team Number", "The team number you entered does not match any of the teams at this event", "OK");
				RobotNumEntry.Focus();
			}
		}
		#endregion

		#region Sandstorm
		private async void CrossHabLineSwitch_Toggled(object sender, ToggledEventArgs e) {
			if (!CrossHabLineSwitch.IsToggled) {
				if (_data.SandCargoShip > 0 ||
					_data.SandCargoRocket1 > 0 ||
					_data.SandCargoRocket2 > 0 ||
					_data.SandCargoRocket3 > 0 ||
					_data.SandPanelShip > 0 ||
					_data.SandPanelRocket1 > 0 ||
					_data.SandPanelRocket1 > 0 ||
					_data.SandPanelRocket3 > 0) {
					if (await DisplayAlert("Warning", "All values on the Sandstorm page will be reset to zero because nothing can be scored if the robot hasn't crossed the HAB Line. Do you want to continue?", "Yes", "No")) {
						sandRocketBCargoTotal.Text = "0";
						sandRocketBHatchTotal.Text = "0";
						sandRocketMCargoTotal.Text = "0";
						sandRocketMHatchTotal.Text = "0";
						sandRocketTCargoTotal.Text = "0";
						sandRocketTHatchTotal.Text = "0";
						SandCargoShipTotal.Text = "0";
						sandShipHatchTotal.Text = "0";
						_data.SandCargoShip = 0;
						_data.SandCargoRocket1 = 0;
						_data.SandCargoRocket2 = 0;
						_data.SandCargoRocket3 = 0;
						_data.SandPanelShip = 0;
						_data.SandPanelRocket1 = 0;
						_data.SandPanelRocket2 = 0;
						_data.SandPanelRocket3 = 0;
					} else
						CrossHabLineSwitch.IsToggled = true;
				}
			}
		}

		private void SandCargoShipPlus_Clicked(object sender, EventArgs e) {
			if (_data.SandCargoShip < 8 && CrossHabLineSwitch.IsToggled)
				SandCargoShipTotal.Text = (++_data.SandCargoShip).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandCargoShipMinus_Clicked(object sender, EventArgs e) {
			if (_data.SandCargoShip > 0 && CrossHabLineSwitch.IsToggled)
				SandCargoShipTotal.Text = (--_data.SandCargoShip).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandShipHatchMinus_Clicked(object sender, EventArgs e) {
			if (_data.SandPanelShip > 0 && CrossHabLineSwitch.IsToggled)
				sandShipHatchTotal.Text = (--_data.SandPanelShip).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandShipHatchPlus_Clicked(object sender, EventArgs e) {
			if (_data.SandPanelShip < 8 && CrossHabLineSwitch.IsToggled)
				sandShipHatchTotal.Text = (++_data.SandPanelShip).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketTCargoMinus_Clicked(object sender, EventArgs e) {
			if (_data.SandCargoRocket3 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketTCargoTotal.Text = (--_data.SandCargoRocket3).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketTCargoPlus_Clicked(object sender, EventArgs e) {
			if (_data.SandCargoRocket3 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketTCargoTotal.Text = (++_data.SandCargoRocket3).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketTHatchMinus_Clicked(object sender, EventArgs e) {
			if (_data.SandPanelRocket3 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketTHatchTotal.Text = (--_data.SandPanelRocket3).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketTHatchPlus_Clicked(object sender, EventArgs e) {
			if (_data.SandPanelRocket3 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketTHatchTotal.Text = (++_data.SandPanelRocket3).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketMCargoMinus_Clicked(object sender, EventArgs e) {
			if (_data.SandCargoRocket2 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketMCargoTotal.Text = (--_data.SandCargoRocket2).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketMCargoPlus_Clicked(object sender, EventArgs e) {
			if (_data.SandCargoRocket2 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketMCargoTotal.Text = (++_data.SandCargoRocket2).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketMHatchMinus_Clicked(object sender, EventArgs e) {
			if (_data.SandPanelRocket2 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketMHatchTotal.Text = (--_data.SandPanelRocket2).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketMHatchPlus_Clicked(object sender, EventArgs e) {
			if (_data.SandPanelRocket2 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketMHatchTotal.Text = (++_data.SandPanelRocket2).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketBCargoMinus_Clicked(object sender, EventArgs e) {
			if (_data.SandCargoRocket1 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketBCargoTotal.Text = (--_data.SandCargoRocket1).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketBCargoPlus_Clicked(object sender, EventArgs e) {
			if (_data.SandCargoRocket1 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketBCargoTotal.Text = (++_data.SandCargoRocket1).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketBHatchMinus_Clicked(object sender, EventArgs e) {
			if (_data.SandPanelRocket1 > 0 && CrossHabLineSwitch.IsToggled)
				sandRocketBHatchTotal.Text = (--_data.SandPanelRocket1).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandRocketBHatchPlus_Clicked(object sender, EventArgs e) {
			if (_data.SandPanelRocket1 < 4 && CrossHabLineSwitch.IsToggled)
				sandRocketBHatchTotal.Text = (++_data.SandPanelRocket1).ToString();
			else if (!CrossHabLineSwitch.IsToggled)
				DisplayAlert("Error", "Game pieces cannot be scored without crossing the HAB LINE", "OK");
		}

		private void SandFailsHatchMinus_Clicked(object sender, EventArgs e) {
			if (_data.SandPanelDrop > 0)
				sandFailsHatchTotal.Text = (--_data.SandPanelDrop).ToString();
		}

		private void SandFailsHatchPlus_Clicked(object sender, EventArgs e) {
			if (_data.SandPanelDrop < 99)
				sandFailsHatchTotal.Text = (++_data.SandPanelDrop).ToString();
		}

		private void SandFailsCargoMinus_Clicked(object sender, EventArgs e) {
			if (_data.SandCargoDrop > 0)
				sandFailsCargoTotal.Text = (--_data.SandCargoDrop).ToString();
		}

		private void SandFailsCargoPlus_Clicked(object sender, EventArgs e) {
			if (_data.SandCargoDrop < 99)
				sandFailsCargoTotal.Text = (++_data.SandCargoDrop).ToString();
		}

		private void SandFoulsMinus_Clicked(object sender, EventArgs e) {
			if (_data.Fouls > 0)
				SandFoulsTotal.Text = (--_data.Fouls).ToString();
		}

		private void SandFoulsPlus_Clicked(object sender, EventArgs e) {
			if (_data.Fouls < 99)
				SandFoulsTotal.Text = (++_data.Fouls).ToString();
		}
		#endregion

		#region Teleop
		private void TeleCargoShipPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCargoShip < 8)
				teleShipCargoTotal.Text = (++_data.TeleCargoShip).ToString();
		}

		private void Tele_ShipCargoMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCargoShip > 0)
				teleShipCargoTotal.Text = (--_data.TeleCargoShip).ToString();
		}

		private void TeleShipHatchMinus_Clicked(object sender, EventArgs e) {
			if (_data.TelePanelShip > 0)
				teleShipHatchTotal.Text = (--_data.TelePanelShip).ToString();
		}

		private void TeleShipHatchPlus_Clicked(object sender, EventArgs e) {
			if (_data.TelePanelShip < 8)
				teleShipHatchTotal.Text = (++_data.TelePanelShip).ToString();
		}

		private void TeleRocketTCargoMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCargoRocket3 > 0)
				teleRocketTCargoTotal.Text = (--_data.TeleCargoRocket3).ToString();
		}

		private void TeleRocketTCargoPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCargoRocket3 < 4)
				teleRocketTCargoTotal.Text = (++_data.TeleCargoRocket3).ToString();
		}

		private void TeleRocketTHatchMinus_Clicked(object sender, EventArgs e) {
			if (_data.TelePanelRocket3 > 0)
				teleRocketTHatchTotal.Text = (--_data.TelePanelRocket3).ToString();
		}

		private void TeleRocketTHatchPlus_Clicked(object sender, EventArgs e) {
			if (_data.TelePanelRocket3 < 4)
				teleRocketTHatchTotal.Text = (++_data.TelePanelRocket3).ToString();
		}

		private void TeleRocketMCargoMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCargoRocket2 > 0)
				teleRocketMCargoTotal.Text = (--_data.TeleCargoRocket2).ToString();
		}

		private void TeleRocketMCargoPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCargoRocket2 < 4)
				teleRocketMCargoTotal.Text = (++_data.TeleCargoRocket2).ToString();
		}

		private void TeleRocketMHatchMinus_Clicked(object sender, EventArgs e) {
			if (_data.TelePanelRocket2 > 0)
				teleRocketMHatchTotal.Text = (--_data.TelePanelRocket2).ToString();
		}

		private void TeleRocketMHatchPlus_Clicked(object sender, EventArgs e) {
			if (_data.TelePanelRocket2 < 4)
				teleRocketMHatchTotal.Text = (++_data.TelePanelRocket2).ToString();
		}

		private void TeleRocketBCargoMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCargoRocket1 > 0)
				teleRocketBCargoTotal.Text = (--_data.TeleCargoRocket1).ToString();
		}

		private void TeleRocketBCargoPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCargoRocket1 < 4)
				teleRocketBCargoTotal.Text = (++_data.TeleCargoRocket1).ToString();
		}

		private void TeleRocketBHatchMinus_Clicked(object sender, EventArgs e) {
			if (_data.TelePanelRocket1 > 0)
				teleRocketBHatchTotal.Text = (--_data.TelePanelRocket1).ToString();
		}

		private void TeleRocketBHatchPlus_Clicked(object sender, EventArgs e) {
			if (_data.TelePanelRocket1 < 4)
				teleRocketBHatchTotal.Text = (++_data.TelePanelRocket1).ToString();
		}

		private void TeleFailsHatchMinus_Clicked(object sender, EventArgs e) {
			if (_data.TelePanelDrop > 0)
				teleFailsHatchTotal.Text = (--_data.TelePanelDrop).ToString();
		}

		private void TeleFailsHatchPlus_Clicked(object sender, EventArgs e) {
			if (_data.TelePanelDrop < 99)
				teleFailsHatchTotal.Text = (++_data.TelePanelDrop).ToString();
		}

		private void TeleFailsCargoMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCargoDrop > 0)
				teleFailsCargoTotal.Text = (--_data.TeleCargoDrop).ToString();
		}

		private void TeleFailsCargoPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCargoDrop < 99)
				teleFailsCargoTotal.Text = (++_data.TeleCargoDrop).ToString();
		}

		private void TeleFoulsMinus_Clicked(object sender, EventArgs e) {
			if (_data.Fouls > 0)
				TeleFoulsTotal.Text = (--_data.Fouls).ToString();
		}

		private void TeleFoulsPlus_Clicked(object sender, EventArgs e) {
			if (_data.Fouls < 99)
				TeleFoulsTotal.Text = (++_data.Fouls).ToString();
		}
		#endregion

		#region Endgame
		private void HabLevelAttemptedPicker_Unfocused(object sender, FocusEventArgs e) {
			if (HabLevelAttemptedPicker.SelectedIndex < HabLevelAchievedPicker.SelectedIndex)
				HabLevelAchievedPicker.SelectedIndex = HabLevelAttemptedPicker.SelectedIndex;
		}

		private void HabLevelAchievedPicker_Unfocused(object sender, FocusEventArgs e) {
			if (HabLevelAttemptedPicker.SelectedIndex < HabLevelAchievedPicker.SelectedIndex)
				HabLevelAttemptedPicker.SelectedIndex = HabLevelAchievedPicker.SelectedIndex;
		}

		private async void DefenseAmountPicker_Unfocused(object sender, FocusEventArgs e) {
			if (DefenseAmountPicker.SelectedIndex == 0 && DefenseSkillPicker.SelectedIndex != 0) {
				if (DefenseSkillPicker.SelectedIndex == -1)
					DefenseSkillPicker.SelectedIndex = 0;
				else {
					await DisplayAlert("Error", "If no defense is played, strength cannot be measured", "OK");
					DefenseAmountPicker.Focus();
				}
			} else if (DefenseAmountPicker.SelectedIndex != 0 && DefenseSkillPicker.SelectedIndex == 0) {
				if (DefenseAmountPicker.SelectedIndex == -1)
					DefenseAmountPicker.SelectedIndex = 0;
				else {
					await DisplayAlert("Error", "If defense is played, its strength must be specified", "OK");
					DefenseSkillPicker.Focus();
				}
			}
		}

		private async void DefenseSkillPicker_Unfocused(object sender, FocusEventArgs e) {
			if (DefenseAmountPicker.SelectedIndex == 0 && DefenseSkillPicker.SelectedIndex != 0) {
				if (DefenseSkillPicker.SelectedIndex == -1)
					DefenseSkillPicker.SelectedIndex = 0;
				else {
					await DisplayAlert("Error", "If no defense is played, strength cannot be measured", "OK");
					DefenseAmountPicker.Focus();
				}
			} else if (DefenseAmountPicker.SelectedIndex != 0 && DefenseSkillPicker.SelectedIndex == 0) {
				if (DefenseAmountPicker.SelectedIndex == -1)
					DefenseAmountPicker.SelectedIndex = 0;
				else {
					await DisplayAlert("Error", "If defense is played, its strength must be specified", "OK");
					DefenseSkillPicker.Focus();
				}
			}
		}

		private async void DefendedAmountPicker_Unfocused(object sender, FocusEventArgs e) {
			if (DefendedAmountPicker.SelectedIndex == 0 && DefendedSkillPicker.SelectedIndex != 0) {
				if (DefendedSkillPicker.SelectedIndex == -1)
					DefendedSkillPicker.SelectedIndex = 0;
				else {
					await DisplayAlert("Error", "If no defense is played, strength cannot be measured", "OK");
					DefendedAmountPicker.Focus();
				}
			} else if (DefendedAmountPicker.SelectedIndex != 0 && DefendedSkillPicker.SelectedIndex == 0) {
				if (DefendedAmountPicker.SelectedIndex == -1)
					DefendedAmountPicker.SelectedIndex = 0;
				else {
					await DisplayAlert("Error", "If defense is played, its strength must be specified", "OK");
					DefendedSkillPicker.Focus();
				}
			}
		}

		private async void DefendedSkillPicker_Unfocused(object sender, FocusEventArgs e) {
			if (DefendedAmountPicker.SelectedIndex == 0 && DefendedSkillPicker.SelectedIndex != 0) {
				if (DefendedSkillPicker.SelectedIndex == -1)
					DefendedSkillPicker.SelectedIndex = 0;
				else {
					await DisplayAlert("Error", "If no defense is played, strength cannot be measured", "OK");
					DefendedAmountPicker.Focus();
				}
			} else if (DefendedAmountPicker.SelectedIndex != 0 && DefendedSkillPicker.SelectedIndex == 0) {
				if (DefendedAmountPicker.SelectedIndex == -1)
					DefendedAmountPicker.SelectedIndex = 0;
				else {
					await DisplayAlert("Error", "If defense is played, its strength must be specified", "OK");
					DefendedSkillPicker.Focus();
				}
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
				DefendedSkillPicker.SelectedIndex == -1 ||
				BreakdownPicker.SelectedIndex == -1)
				await DisplayAlert("Error", "Not all data entries are filled", "OK");
			else {
				_data.ScoutName = NameEntry.Text;
				_data.MatchNumber = int.Parse(MatchEntry.Text);
				_data.ReplayMatch = ReplaySwitch.IsToggled ? 1 : 0;
				_data.TeamNumber = int.Parse(RobotNumEntry.Text);
				_data.AllianceColor = (string)AllianceColorPicker.SelectedItem;
				_data.StartPosition = int.Parse(StartPositionEntry.Text);
				_data.PreloadedItem = PreloadedItemPicker.SelectedIndex;
				_data.CrossHabLine = CrossHabLineSwitch.IsToggled ? 1 : 0;
				_data.HabLevelAchieved = HabLevelAttemptedPicker.SelectedIndex;
				_data.HadAssistance = EndHelped.IsToggled ? 1 : 0;
				_data.AssistedOthers = EndAssist.IsToggled ? 1 : 0;
				_data.HabLevelAttempted = HabLevelAttemptedPicker.SelectedIndex;
				_data.HabLevelAchieved = HabLevelAchievedPicker.SelectedIndex;
				_data.DefenseAmount = DefenseAmountPicker.SelectedIndex;
				_data.DefenseSkill = DefenseSkillPicker.SelectedIndex;
				_data.DefendedAmount = DefendedAmountPicker.SelectedIndex;
				_data.DefendedSkill = DefendedSkillPicker.SelectedIndex;
				_data.Breakdown = BreakdownPicker.SelectedItem.ToString();
				_data.Comments = CommentsEntry.Text;
				_data.BuildString("\t");
				_data.BuildQuery();
				try {
					_data.WriteToTextFile(NewFilePicker.SelectedIndex == 0);
					_data.WriteToDatabase();
					ResetAll();
					CurrentPage = new MainPage();
					await DisplayAlert("Saved", "The data you entered has been saved to a file", "OK");
				} catch (UnauthorizedAccessException) {
					if (await DisplayAlert("Error", "App does not have permission to access device storage. To fix this, go to \"Settings > Apps > ScoutingApp2019.Android > Permissions\" and turn on the switch for \"Storage\".", "Settings", "Cancel"))
						Android.App.Application.Context.StartActivity(new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings, Android.Net.Uri.Parse("package:" + Android.App.Application.Context.PackageName)));
				}
			}
		}
		#endregion
	}
}
