using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

class Program
{
    private static readonly string ConnectionString =
        Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION")
        ?? "Server=FLENER\\SQLEXPRESS;Database=PracticeDB;Trusted_Connection=True;TrustServerCertificate=True;";

    static async Task Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("Выберите задание для запуска:");
            Console.WriteLine("1. Задание 28: SELECT (Список сотрудников)");
            Console.WriteLine("2. Задание 29: INSERT (Добавить сотрудников)");
            Console.WriteLine("3. Задание 30: Отчёт по отделам");
            Console.WriteLine("0. Выход");
            Console.WriteLine("========================================");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();       

            Console.WriteLine(); 

            switch (choice)
            {
                case "1":
                    await RunTask28Async();
                    break;
                case "2":
                    await RunTask29Async();
                    break;
                case "3":
                    await RunTask30Async();
                    break;
                case "0":
                    Console.WriteLine("Выход из программы...");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    // ==========================================
    // ЗАДАНИЕ 28: SELECT
    // ==========================================
    static async Task RunTask28Async()
    {
        Console.WriteLine("--- Задание 28: Список сотрудников ---");
        string query = "SELECT EmployeeName, Salary FROM Employees";

        try
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                string name = reader.GetString(0);
                decimal salary = reader.GetDecimal(1);
                Console.WriteLine($"- {name} (ЗП: {salary:C})");
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Ошибка SQL: {ex.Message}");
        }
    }

    // ==========================================
    // ЗАДАНИЕ 29: INSERT
    // ==========================================
    static async Task RunTask29Async()
    {
        Console.WriteLine("--- Задание 29: Добавление сотрудников ---");

       
        await AddEmployeeAsync("Новый Сотрудник", 60000, 1);
        await AddEmployeeAsync("Ещё Один", 45000, 3);
    }

    static async Task AddEmployeeAsync(string name, decimal salary, int deptId)
    {
        string insertQuery = @"INSERT INTO Employees (EmployeeName, Salary, HireDate, DepartmentId) 
                               VALUES (@name, @salary, GETDATE(), @deptId);
                               SELECT SCOPE_IDENTITY();";

        try
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(insertQuery, connection);

           
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@salary", salary);
            command.Parameters.AddWithValue("@deptId", deptId);

            object newId = await command.ExecuteScalarAsync();
            Console.WriteLine($"[Успех] Добавлен сотрудник '{name}' с ID = {newId}");
        }
        catch (SqlException ex)
        {
            
            Console.WriteLine($"[Ошибка БД] Не удалось добавить '{name}': {ex.Message}");
        }
    }

    // ==========================================
    // ЗАДАНИЕ 30: Отчёт по отделам
    // ==========================================
    static async Task RunTask30Async()
    {
        Console.WriteLine("--- Задание 30: Отчёт по отделам ---");

        string query = @"
            SELECT 
                d.DepartmentName, 
                COUNT(e.EmployeeId) AS EmpCount, 
                AVG(e.Salary) AS AvgSalary 
            FROM Departments d 
            LEFT JOIN Employees e ON d.DepartmentId = e.DepartmentId 
            GROUP BY d.DepartmentName";

        try
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            Console.WriteLine("┌─────────────────┬────────────┬────────────────┐");
            Console.WriteLine("│ Отдел           │ Сотрудники │ Ср. зарплата   │");
            Console.WriteLine("├─────────────────┼────────────┼────────────────┤");

            bool hasRows = false;
            while (await reader.ReadAsync())
            {
                hasRows = true;
                string deptName = reader.IsDBNull(0) ? "N/A" : reader.GetString(0);
                int empCount = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);

                string avgSalaryStr = reader.IsDBNull(2)
                    ? "0.00"
                    : reader.GetDecimal(2).ToString("F2");

                Console.WriteLine($"│ {deptName,-15} │ {empCount,10} │ {avgSalaryStr,14} │");
            }

            Console.WriteLine("└─────────────────┴────────────┴────────────────┘");

            if (!hasRows)
            {
                Console.WriteLine("Результат пуст. Отделы не найдены.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
