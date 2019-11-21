using Android.Bluetooth;
using Mono.Data.Sqlite;
using System.IO;

namespace ScoutingApp2019 {
	public class DataHandler {
		//START
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
		//SANDSTORM & TELEOP
		public int Fouls { get; set; } = 0;
		//TELEOP
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
		//ENDGAME
		public int HabLevelAchieved { get; set; }
		public int HabLevelAttempted { get; set; }
		public int HadAssistance { get; set; }
		public int AssistedOthers { get; set; }
		public int DefenseAmount { get; set; }
		public int DefenseSkill { get; set; }
		public int DefendedAmount { get; set; }
		public int DefendedSkill { get; set; }
		public string Breakdown { get; set; }
		public string Comments { get; set; }

		private readonly string _filePath;
		private readonly string _fileName;

		private int _partialDataNum;
		private string _dataString;
		private string _query;

		/// <summary>
		/// Initializes a new instance of the DataHandler class.
		/// </summary>
		/// <param name="filePath">Folder to store files in.</param>
		/// <param name="fullDataName">Name of Full Data text file.</param>
		/// <param name="partialDataPrefix">Name of Partial Data text files.</param>
		/// <param name="dbName">Name of SQLite file.</param>
		public DataHandler(string filePath, string fileName) {
			_filePath = filePath;
			_fileName = BluetoothAdapter.DefaultAdapter.Name + " " + fileName;
			if (!Directory.Exists("/storage/emulated/0/Download/ScoutingData"))
				Directory.CreateDirectory("/storage/emulated/0/Download/ScoutingData");
			if (!File.Exists(_filePath + _fileName + ".sqlite")) {
				File.Create(_filePath + _fileName + ".sqlite");
				SqliteConnection connection = new SqliteConnection("Data Source = " + _filePath + _fileName + ".sqlite");
				connection.Open();
				StreamReader streamReader = new StreamReader(Android.App.Application.Context.Assets.Open("CreateStatement.txt"));
				string createStatement = streamReader.ReadToEnd();
				streamReader.Close();
				streamReader.Dispose();
				SqliteCommand command = new SqliteCommand(createStatement, connection);
				command.ExecuteNonQuery();
				command.Dispose();
				connection.Close();
				connection.Dispose();
			}
		}

		/// <summary>
		/// Builds string to be apended to text file.
		/// </summary>
		/// <param name="separator">String to separate fields with (comma, tab, space, etc.).</param>
		public void BuildString(string separator) {
			_dataString =
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
				Fouls + separator +
				Breakdown + separator +
				Comments;
		}

		/// <summary>
		/// Writes data to a text file.
		/// </summary>
		/// <param name="newFile">True if a new Partial Data file should be created.</param>
		public void WriteToTextFile(bool newFile) {
			bool hasNumber = false;
			for (int i = 0; !hasNumber; i++)
				if (!File.Exists(_filePath + _fileName + "_" + i + ".txt")) {
					if (newFile || (!newFile && i == 0))
						_partialDataNum = i;
					else
						_partialDataNum = i - 1;
					hasNumber = true;
				}
			StreamWriter fullDataStreamWriter = new StreamWriter(_filePath + _fileName + ".txt", true);
			StreamWriter partialDataStreamWriter = new StreamWriter(_filePath + _fileName + "_" + _partialDataNum + ".txt", true);
			fullDataStreamWriter.WriteLineAsync(_dataString);
			partialDataStreamWriter.WriteLineAsync(_dataString);
			fullDataStreamWriter.Close();
			partialDataStreamWriter.Close();
			fullDataStreamWriter.Dispose();
			partialDataStreamWriter.Dispose();
		}

		/// <summary>
		/// Builds query for inserting data into SQLite database.
		/// </summary>
		public void BuildQuery() {
			_query = "INSERT INTO RawData(" +
				"ScoutName, " +
				"MatchNumber," +
				"ReplayMatch, " +
				"TeamNumber, " +
				"AllianceColor, " +
				"StartPosition, " +
				"PreloadedItem, " +
				"CrossHabLine, " +
				"SandCargoShip, " +
				"SandCargoRocket1, " +
				"SandCargoRocket2, " +
				"SandCargoRocket3, " +
				"SandCargoDrop, " +
				"SandPanelShip, " +
				"SandPanelRocket1, " +
				"SandPanelRocket2, " +
				"SandPanelRocket3, " +
				"SandPanelDrop, " +
				"TeleCargoShip, " +
				"TeleCargoRocket1, " +
				"TeleCargoRocket2, " +
				"TeleCargoRocket3, " +
				"TeleCargoDrop, " +
				"TelePanelShip, " +
				"TelePanelRocket1, " +
				"TelePanelRocket2, " +
				"TelePanelRocket3, " +
				"TelePanelDrop, " +
				"HabLevelAchieved, " +
				"HabLevelAttempted, " +
				"HadAssistance, " +
				"AssistedOthers, " +
				"DefenseAmount, " +
				"DefenseSkill, " +
				"DefendedAmount, " +
				"DefendedSkill, " +
				"Fouls, " +
				"Breakdown, " +
				"Comments" +
			") " +
			"VALUES (" +
				"'" + ScoutName + "', " +
				MatchNumber + ", " +
				ReplayMatch + ", " +
				TeamNumber + ", " +
				"'" + AllianceColor + "', " +
				StartPosition + ", " +
				PreloadedItem + ", " +
				CrossHabLine + ", " +
				SandCargoShip + ", " +
				SandCargoRocket1 + ", " +
				SandCargoRocket2 + ", " +
				SandCargoRocket3 + ", " +
				SandCargoDrop + ", " +
				SandPanelShip + ", " +
				SandPanelRocket1 + ", " +
				SandPanelRocket2 + ", " +
				SandPanelRocket3 + ", " +
				SandPanelDrop + ", " +
				TeleCargoShip + ", " +
				TeleCargoRocket1 + ", " +
				TeleCargoRocket2 + ", " +
				TeleCargoRocket3 + ", " +
				TeleCargoDrop + ", " +
				TelePanelShip + ", " +
				TelePanelRocket1 + ", " +
				TelePanelRocket2 + ", " +
				TelePanelRocket3 + ", " +
				TelePanelDrop + ", " +
				HabLevelAchieved + ", " +
				HabLevelAttempted + ", " +
				HadAssistance + ", " +
				AssistedOthers + ", " +
				DefenseAmount + ", " +
				DefenseSkill + ", " +
				DefendedAmount + ", " +
				DefendedSkill + ", " +
				Fouls + ", " +
				"'" + Breakdown + "', " +
				"'" + Comments + "'" +
			");";
		}

		/// <summary>
		/// Inserts data into SQLite database.
		/// </summary>
		public void WriteToDatabase() {
			SqliteConnection connection = new SqliteConnection("Data Source = " + _filePath + _fileName + ".sqlite");
			connection.Open();
			SqliteCommand command = new SqliteCommand(_query, connection);
			command.ExecuteNonQuery();
			connection.Close();
			connection.Dispose();
		}
	}
}
