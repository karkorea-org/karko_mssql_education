using System;
using Microsoft.Data.SqlClient;
class Program
{
    static void Main()
    {
        // Windows 인증(로컬 SQLExpress) 예시
        var connStr =
        "Server=localhost\\SQLEXPRESS;" +
        "Database=TEST1;" +
        "Trusted_Connection=True;" +
        "TrustServerCertificate=True;";
        using var conn = new SqlConnection(connStr);
        conn.Open();
        var sql = "SELECT Id, Name, Email, Salary FROM dbo.Employees ORDER BY Id;";
        using var cmd = new SqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var name = reader.GetString(1);
            var email = reader.GetString(2);
            var salary = reader.GetInt32(3);
            Console.WriteLine($"{id} | {name} | {email} | {salary}");
        }
    }
}