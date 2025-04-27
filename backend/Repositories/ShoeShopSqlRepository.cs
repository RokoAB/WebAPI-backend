using Microsoft.Data.Sqlite;
using System.Data;
using System.Transactions;
using System.Windows.Input;
using test.Models;
using Microsoft.Extensions.Options;
using test.Configuration;


namespace test.Repositories
{
    public class ShoeShopSqlRepository : IShoeShopRepository
    {
       // private readonly string _connectionString = "Data Source=\"C:\\Users\\rokob\\Desktop\\RokoAB-lab-071\\RokoAB-lab\\Shoes.db\""; /// <summary>
        private readonly string? _connectionString;
        public ShoeShopSqlRepository(IOptions<DBConfiguration> configuration)
        {
            _connectionString = configuration.Value.ConnectionString;
        }

        public IEnumerable<ShoeShop> AddShoes(ShoeShop shoes)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            // string sql = $"INSERT INTO Emails(ID, Sender) VALUES (" + email.Id + ", " + email.Sender + ")";
            command.CommandText =
            @"
                INSERT INTO Shoes (BrandName, Size, Color, SizeUS, Gender)
                VALUES ($brandname, $size, $color, $sizeus, $gender)";

            command.Parameters.AddWithValue("$brandname", shoes.BrandName);
            command.Parameters.AddWithValue("$size", shoes.Size);
            command.Parameters.AddWithValue("$color", shoes.Color);
            command.Parameters.AddWithValue("$sizeus", shoes.SizeUS);
            command.Parameters.AddWithValue("$gender", shoes.Gender);

            _ = command.ExecuteNonQuery();


            // Only because it returns a list of emails
            return GetShoes();
        }

        public IEnumerable<ShoeShop> DeleteShoes(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            // using var transaction = connection.BeginTransaction(); // Begin transaction

            var command = connection.CreateCommand();

            command.CommandText =" DELETE FROM Shoes WHERE ID = $id";

            command.Parameters.AddWithValue("$id", id);

            var rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 0)
            {
                throw new KeyNotFoundException($"Shoe with ID {id} not found.");
            }
            // transaction.Commit();
            // Return the updated list of shoes
            return GetShoes();
        }

        public ShoeShop GetShoe(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, BrandName, Size, Color, SizeUS, Gender FROM Shoes WHERE Id = $id";
            command.Parameters.AddWithValue("id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new ShoeShop(
                    id: reader.GetInt64(0), // Int64 because Id is LONG
                    brandName: reader.GetString(1),
                    size: reader.GetInt32(2),
                    color: reader.GetString(3),
                    sizeus: reader.GetInt32(4),
                    gender: reader.GetString(5)

                );
            }
            return null;
        }

        public IEnumerable<ShoeShop> GetShoes()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, BrandName, Size, Color, SizeUS, Gender FROM Shoes";

            using var reader = command.ExecuteReader();

            var results = new List<ShoeShop>();
            while (reader.Read())
            {
                var row = new ShoeShop(
                    id: reader.GetInt64(0), // Int64 because Id is LONG
                    brandName: reader.GetString(1),
                    size: reader.GetInt32(2),
                    color: reader.GetString(3),
                    sizeus: reader.GetInt32(4),
                    gender: reader.GetString(5)

                );

                results.Add(row);
            }

            return results;
        }

        public IEnumerable<ShoeShop> UpdateShoes(long id, ShoeShop shoes)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
                UPDATE Shoes
                SET
                    BrandName = $brandname,
                    Size = $size,
                    Color = $color,
                    SizeUS = $sizeus,
                    Gender = $gender

                WHERE
                    ID = $id;";

            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("$brandname", shoes.BrandName);
            command.Parameters.AddWithValue("$size", shoes.Size);
            command.Parameters.AddWithValue("$color", shoes.Color);
            command.Parameters.AddWithValue("$sizeus", shoes.SizeUS);
            command.Parameters.AddWithValue("$gender", shoes.Gender);

            _ = command.ExecuteNonQuery();


            // Only because it returns a list of shoes
            return GetShoes();
        }

    }
}
