using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject
{
    public class DatabaseService
    {
        private readonly string path = "hypoteka.db";

        public void EnsureCreated()
        {
            if (!System.IO.File.Exists(path))
            {
                using (var connection = new SqliteConnection($"Data Source={path}"))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = "CREATE TABLE Hypoteka (Id INTEGER PRIMARY KEY AUTOINCREMENT, LoanAmount DOUBLE, InterestRate DOUBLE, LoanTerm int)";
                
                    int count = command.ExecuteNonQuery();
                }
            }
        }

        public void Insert(Model model)
        {
            using (var connection = new SqliteConnection($"Data Source={path}"))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO Hypoteka VALUES (@LoanAmount, @InterestRate, @LoanTerm)";
                command.Parameters.Add($"@LoanAmount", SqliteType.Real).Value = model.LoanAmount;
                command.Parameters.Add($"@InterestRate", SqliteType.Real).Value = model.InterestRate;
                command.Parameters.Add($"@LoanTerm", SqliteType.Real).Value = model.LoanTerm;

                int count = command.ExecuteNonQuery();
            }
        }

        public void Update(Model model) 
        {
            throw new NotImplementedException();
        }

        public Model Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
