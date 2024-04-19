
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Efox.LeadManager.Helper
{
    public class DatabaseHelper
    {
        private IConfiguration _configuration;
        private string _databaseConnectionString;
        public DatabaseHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _databaseConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public string getDatabaseName(HttpContext _context)
        {
            var dbName = "";
            /*if (_context != null && _context.User != null)
            {
                dbName = "LeadsManager_" + _context.User.GetCompanyId();
                CreateDatabaseIfNotExists(_databaseConnectionString.Replace("{}", ""), dbName);
            }*/
            return dbName;

        }
        public string getNewConnectionString(HttpContext _context)
        {
            var dbName = getDatabaseName(_context);
            return _databaseConnectionString.Replace("{}", "Database=" + dbName + ";");
        }
        private string ReadFileContent(string fileName)
        {
            string filePath = fileName;
            try
            {
                // Read the file content
                string fileContent = File.ReadAllText(filePath);
                return fileContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //check for database existance here;
        public void CreateDatabaseIfNotExists(string connectionString, string databaseName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Check if the database exists using T-SQL
                    string checkDatabaseQuery = $"IF (DB_ID(N'{databaseName}') IS NULL) BEGIN CREATE DATABASE [{databaseName}] END;";
                    using (SqlCommand command = new SqlCommand(checkDatabaseQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {

                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString + "Database=" + databaseName + ";"))
            {
                try
                {
                    connection.Open();
                    var rawQuery = ReadFileContent("wwwroot/DBScripts/leads_scripts.sql");

                    using (SqlCommand command = new SqlCommand(rawQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
