//using System.Data;
//using System.Threading.Tasks;

//using LearningBlazor.Models;

//using MySql.Data.MySqlClient;

//namespace LearningBlazor.Data {

//    public class DatabaseService {

//        private string ConnectionString { get; }

//        private MySqlConnection MySqlConnection => new MySqlConnection(ConnectionString);

//        public DatabaseService(string connectionString) {
//            ConnectionString = connectionString;
//        }

//        public async Task InsertTodoItemAsync(TodoItem todoItem) {
//            using var connection = MySqlConnection;

//            using var command = new MySqlCommand("InsertTodoItem", connection) {
//                CommandType = CommandType.StoredProcedure
//            };

//            command.Parameters.AddWithValue("@title", todoItem.Title);
//            command.Parameters.AddWithValue("@isDone", todoItem.IsDone);

//            //connection.Open();
//            await connection.OpenAsync();
//            //command.ExecuteNonQuery();
//            await command.ExecuteNonQueryAsync();
//            //connection.Close();
//            await connection.CloseAsync();
//        }
//    }
//}
