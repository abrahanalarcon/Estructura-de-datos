using System;
using System.IO;
using System.Xml;

class Program
{
    static void Main()
    {
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
                    InsertarEstudiantes();
                    break;
                case 2:
                    ConsultarEstudiantes();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("❌ Opción no válida, intente de nuevo.");
                    break;
            }
        }
    }

    static void InsertarEstudiantes()
    {
        Console.Write("Ingrese la cantidad de estudiantes a registrar (Máximo 5): ");
        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad < 1 || cantidad > 5)
        {
            Console.WriteLine("❌ Solo se permiten entre 1 y 5 registros.");
            return;
        }

        string xmlFile = "notas.xml";

        // Verifica si el archivo XML ya existe, si no lo crea con la estructura inicial
        if (!File.Exists(xmlFile))
        {
            using (XmlWriter writer = XmlWriter.Create(xmlFile))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Estudiantes");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        // Agregar los estudiantes al archivo XML
        using (XmlWriter writer = XmlWriter.Create(xmlFile, new XmlWriterSettings { Indent = true }))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Estudiantes");

            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Ingrese Apellidos del estudiante {i + 1}: ");
                string apellidos = Console.ReadLine() ?? string.Empty;

                Console.Write($"Ingrese Nombres del estudiante {i + 1}: ");
                string nombres = Console.ReadLine() ?? string.Empty;

                Console.Write("Ingrese Nota Mes 1: ");
                int nota1 = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Ingrese Nota Mes 2: ");
                int nota2 = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Ingrese Nota Mes 3: ");
                int nota3 = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Ingrese Nota Mes 4: ");
                int nota4 = int.Parse(Console.ReadLine() ?? "0");

                double promedio = (nota1 + nota2 + nota3 + nota4) / 4.0;

                writer.WriteStartElement("Estudiante");
                writer.WriteElementString("Apellidos", apellidos);
                writer.WriteElementString("Nombres", nombres);
                writer.WriteElementString("Nota1", nota1.ToString());
                writer.WriteElementString("Nota2", nota2.ToString());
                writer.WriteElementString("Nota3", nota3.ToString());
                writer.WriteElementString("Nota4", nota4.ToString());
                writer.WriteElementString("Promedio", promedio.ToString("F2"));
                writer.WriteEndElement();

                Console.WriteLine($"✅ Estudiante {nombres} {apellidos} registrado con éxito.\n");
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }

    static void ConsultarEstudiantes()
    {
        string xmlFile = "notas.xml";

        if (!File.Exists(xmlFile))
        {
            Console.WriteLine("⚠️ No hay registros disponibles.");
            return;
        }

        Console.WriteLine("\nRegistros de estudiantes:");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("APELLIDOS          | NOMBRES          | NOTA1 | NOTA2 | NOTA3 | NOTA4 | PROMEDIO");
        Console.WriteLine("------------------------------------------------------");

        XmlDocument doc = new XmlDocument();
        doc.Load(xmlFile);

        XmlNodeList estudiantes = doc.SelectNodes("/Estudiantes/Estudiante");

        foreach (XmlNode estudiante in estudiantes)
        {
            string apellidos = estudiante["Apellidos"]?.InnerText ?? string.Empty;
            string nombres = estudiante["Nombres"]?.InnerText ?? string.Empty;
            string nota1 = estudiante["Nota1"]?.InnerText ?? "0";
            string nota2 = estudiante["Nota2"]?.InnerText ?? "0";
            string nota3 = estudiante["Nota3"]?.InnerText ?? "0";
            string nota4 = estudiante["Nota4"]?.InnerText ?? "0";
            string promedio = estudiante["Promedio"]?.InnerText ?? "0.00";

            Console.WriteLine($"{apellidos,-17} | {nombres,-15} | {nota1,-5} | {nota2,-5} | {nota3,-5} | {nota4,-5} | {promedio,-5}");
        }

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"📌 Total de registros encontrados: {estudiantes.Count}");
    }
}
