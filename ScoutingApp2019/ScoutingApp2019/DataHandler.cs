using System.IO;

namespace ScoutingApp2019 {
	public class DataHandler {
		public string ScoutName { get; set; }
		public int MatchNumber { get; set; }
		public int ReplayMatch { get; set; }
		public int TeamNumber { get; set; }
		public string AllianceColor { get; set; }
		public int StartPosition { get; set; }
		public int PreloadedItem { get; set; }
		//SANDSTORM
		public int CrossHabLine { get; set; }
		public int SandCargoShip { get; set; } = 0;
		public int SandCargoRocket1 { get; set; } = 0;
		public int SandCargoRocket2 { get; set; } = 0;
		public int SandCargoRocket3 { get; set; } = 0;
		public int SandCargoDrop { get; set; } = 0;
		public int SandPanelShip { get; set; } = 0;
		public int SandPanelRocket1 { get; set; } = 0;
		public int SandPanelRocket2 { get; set; } = 0;
		public int SandPanelRocket3 { get; set; } = 0;
		public int SandPanelDrop { get; set; } = 0;
		//Teleop
		public int TeleCargoShip { get; set; } = 0;
		public int TeleCargoRocket1 { get; set; } = 0;
		public int TeleCargoRocket2 { get; set; } = 0;
		public int TeleCargoRocket3 { get; set; } = 0;
		public int TeleCargoDrop { get; set; } = 0;
		public int TelePanelShip { get; set; } = 0;
		public int TelePanelRocket1 { get; set; } = 0;
		public int TelePanelRocket2 { get; set; } = 0;
		public int TelePanelRocket3 { get; set; } = 0;
		public int TelePanelDrop { get; set; } = 0;
		//END
		public int HabLevelAchieved { get; set; }
		public int HabLevelAttempted { get; set; }
		public int HadAssistance { get; set; }
		public int AssistedOthers { get; set; }
		public int DefenseAmount { get; set; }
		public int DefenseSkill { get; set; }
		public int DefendedAmount { get; set; }
		public int DefendedSkill { get; set; }
		public string Comments { get; set; }
		
		private readonly string filePath;
		private readonly string fullDataName;
		private readonly string partialDataPrefix;

		private int partialDataNum;
		private string dataString;

		public DataHandler(string filePath, string fullDataName, string partialDataPrefix) {
			this.filePath = filePath;
			this.fullDataName = fullDataName;
			this.partialDataPrefix = partialDataPrefix;
		}

		public void BuildString(string separator) {
			dataString =
				ScoutName + separator +
				MatchNumber + separator +
				ReplayMatch + separator +
				TeamNumber + separator +
				AllianceColor + separator +
				StartPosition + separator +
				PreloadedItem + separator +
				CrossHabLine + separator +
				SandCargoShip + separator +
				SandCargoRocket1 + separator +
				SandCargoRocket2 + separator +
				SandCargoRocket3 + separator +
				SandCargoDrop + separator +
				SandPanelShip + separator +
				SandPanelRocket1 + separator +
				SandPanelRocket2 + separator +
				SandPanelRocket3 + separator +
				SandPanelDrop + separator +
				TeleCargoShip + separator +
				TeleCargoRocket1 + separator +
				TeleCargoRocket2 + separator +
				TeleCargoRocket3 + separator +
				TeleCargoDrop + separator +
				TelePanelShip + separator +
				TelePanelRocket1 + separator +
				TelePanelRocket2 + separator +
				TelePanelRocket3 + separator +
				TelePanelDrop + separator +
				HabLevelAchieved + separator +
				HabLevelAttempted + separator +
				HadAssistance + separator +
				AssistedOthers + separator +
				DefenseAmount + separator +
				DefenseSkill + separator +
				DefendedAmount + separator +
				DefendedSkill + separator +
				Comments;
		}

		public void WriteToTextFile(bool newFile) {
			bool hasNumber = false;
			for (int i = 0; !hasNumber; i++)
				if (!File.Exists(filePath + partialDataPrefix + i + ".txt")) {
					if (newFile || (!newFile && i == 0))
						partialDataNum = i;
					else
						partialDataNum = i - 1;
					hasNumber = true;
				}
			StreamWriter fullDataStreamWriter = new StreamWriter(filePath + fullDataName + ".txt", true);
			StreamWriter partialDataStreamWriter = new StreamWriter(filePath + partialDataPrefix + partialDataNum + ".txt", true);
			fullDataStreamWriter.WriteLineAsync(dataString);
			partialDataStreamWriter.WriteLineAsync(dataString);
			fullDataStreamWriter.Close();
			partialDataStreamWriter.Close();
			fullDataStreamWriter.Dispose();
			partialDataStreamWriter.Dispose();
		}
	}
}
