using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=DESKTOP-81LONTD;Database=Escuela;Trusted_Connection=True;";

        while (true)
        {
            Console.WriteLine("\nMenú de Opciones:");
            Console.WriteLine("1. Insertar estudiantes");
            Console.WriteLine("2. Consultar registros");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("❌ Opción no válida, intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    InsertarEstudiantes(connectionString);
                    break;
                case 2:
                    ConsultarEstudiantes(connectionString);
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("❌ Opción no válida, intente de nuevo.");
                    break;
            }
        }
    }

    static void InsertarEstudiantes(string connectionString)
    {
        Console.Write("Ingrese la cantidad de estudiantes a registrar (Máximo 5): ");
        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad < 1 || cantidad > 5)
        {
            Console.WriteLine("❌ Solo se permiten entre 1 y 5 registros.");
            return;
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Ingrese Apellidos del estudiante {i + 1}: ");
                string apellidos = Console.ReadLine() ?? string.Empty;

                Console.Write($"Ingrese Nombres del estudiante {i + 1}: ");
                string nombres = Console.ReadLine() ?? string.Empty;

                Console.Write("Ingrese Nota Mes 1: ");
                if (!int.TryParse(Console.ReadLine(), out int nota1))
                {
                    Console.WriteLine("❌ Nota no válida.");
                    continue;
                }

                Console.Write("Ingrese Nota Mes 2: ");
                if (!int.TryParse(Console.ReadLine(), out int nota2))
                {
                    Console.WriteLine("❌ Nota no válida.");
                    continue;
                }

                Console.Write("Ingrese Nota Mes 3: ");
                if (!int.TryParse(Console.ReadLine(), out int nota3))
                {
                    Console.WriteLine("❌ Nota no válida.");
                    continue;
                }

                Console.Write("Ingrese Nota Mes 4: ");
                if (!int.TryParse(Console.ReadLine(), out int nota4))
                {
                    Console.WriteLine("❌ Nota no válida.");
                    continue;
                }

                double promedio = (nota1 + nota2 + nota3 + nota4) / 4.0;

                string query = "INSERT INTO NotasEstudiantes (Apellidos, Nombres, Nota1, Nota2, Nota3, Nota4, Promedio) " +
                               "VALUES (@Apellidos, @Nombres, @Nota1, @Nota2, @Nota3, @Nota4, @Promedio)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                    cmd.Parameters.AddWithValue("@Nombres", nombres);
                    cmd.Parameters.AddWithValue("@Nota1", nota1);
                    cmd.Parameters.AddWithValue("@Nota2", nota2);
                    cmd.Parameters.AddWithValue("@Nota3", nota3);
                    cmd.Parameters.AddWithValue("@Nota4", nota4);
                    cmd.Parameters.AddWithValue("@Promedio", promedio);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine($"✅ Estudiante {nombres} {apellidos} registrado con éxito.\n");
            }
        }
    }

    static void ConsultarEstudiantes(string connectionString)
    {
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Ver registros por rango de ID");
        Console.WriteLine("2. Usar una condición personalizada (Ej: promedio > 90)");
        Console.Write("Ingrese su opción: ");
        if (!int.TryParse(Console.ReadLine(), out int opcion))
        {
            Console.WriteLine("❌ Opción no válida.");
            return;
        }

        string query = "";

        if (opcion == 1)
        {
            Console.Write("Ingrese el ID inicial: ");
            if (!int.TryParse(Console.ReadLine(), out int idInicio))
            {
                Console.WriteLine("❌ ID no válido.");
                return;
            }

            Console.Write("Ingrese el ID final: ");
            if (!int.TryParse(Console.ReadLine(), out int idFinal))
            {
                Console.WriteLine("❌ ID no válido.");
                return;
            }

            query = $"SELECT * FROM NotasEstudiantes WHERE Id BETWEEN {idInicio} AND {idFinal} ORDER BY Id";
        }
        else if (opcion == 2)
        {
            Console.Write("Ingrese la condición SQL (Ejemplo: Promedio >= 90): ");
            string condicion = Console.ReadLine() ?? string.Empty;

            query = $"SELECT * FROM NotasEstudiantes WHERE {condicion}";
        }
        else
        {
            Console.WriteLine("❌ Opción inválida.");
            return;
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("ID | APELLIDOS       | NOMBRES          | NOTA1 | NOTA2 | NOTA3 | NOTA4 | PROMEDIO");
                    Console.WriteLine("------------------------------------------------------");

                    int count = 0;
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"],-2} | {reader["Apellidos"],-15} | {reader["Nombres"],-15} | {reader["Nota1"],-5} | {reader["Nota2"],-5} | {reader["Nota3"],-5} | {reader["Nota4"],-5} | {reader["Promedio"],-5:F2}");
                        count++;
                    }

                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine($"📌 Total de registros encontrados: {count}");
                }
            }
        }
    }
}
