using System.Data.SQLite;
using System.IO;

namespace ScoutingApp2019 {
    public class DBClient {
        private readonly string FILE_PATH;

        private SQLiteConnection connection;

        public DBClient(string filePath) {
            FILE_PATH = filePath;
            //if the file doesn't exist...
            while (!File.Exists(FILE_PATH)) {
                //MessageBox.Show("Database file at location \"" + filePath + "\" does not exist.\n\nPlease manually locate the file.", "File not found", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //OpenFileDialog openFileDialog = new OpenFileDialog {
                //    InitialDirectory = "C:\\",
                //    Filter = "SQLite database files (*.db; *.db3; *.sqlite; *.sqlite3)|*.db; *.db3; *.sqlite; *.sqlite3 | All files (*.*)|*.*",
                //    FilterIndex = 1
                //};
                //if (openFileDialog.ShowDialog() == true) {
                //    FILE_PATH = openFileDialog.FileName;
                //}
            }
            //connect to database
            connection = new SQLiteConnection("Data Source=" + FILE_PATH + "; Version=3");
        }
    }
}
