using System;

class Program
{
    static void Main()
    {
        // Definir los arreglos para 11 estudiantes
        string[] apellidos = new string[11];
        string[] nombres = new string[11];
        int[] nota1 = new int[11];
        int[] nota2 = new int[11];
        int[] nota3 = new int[11];
        int[] nota4 = new int[11];
        double[] promedio = new double[11];

        // Captura de datos
        for (int i = 0; i < 11; i++)
        {
            Console.Write($"Ingrese Apellidos del estudiante {i + 1}: ");
            apellidos[i] = Console.ReadLine();

            Console.Write($"Ingrese Nombres del estudiante {i + 1}: ");
            nombres[i] = Console.ReadLine();

            Console.Write("Ingrese Nota Mes 1: ");
            nota1[i] = int.Parse(Console.ReadLine());

            Console.Write("Ingrese Nota Mes 2: ");
            nota2[i] = int.Parse(Console.ReadLine());

            Console.Write("Ingrese Nota Mes 3: ");
            nota3[i] = int.Parse(Console.ReadLine());

            Console.Write("Ingrese Nota Mes 4: ");
            nota4[i] = int.Parse(Console.ReadLine());

            // Calcular el promedio
            promedio[i] = (nota1[i] + nota2[i] + nota3[i] + nota4[i]) / 4.0;
            Console.WriteLine();
        }

        // Mostrar los datos
        Console.WriteLine("Listado de Notas Promediadas");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("APELLIDOS         | NOMBRES          | NOTA1 | NOTA2 | NOTA3 | NOTA4 | PROMEDIO");
        Console.WriteLine("------------------------------------------------------");

        for (int i = 0; i < 11; i++)
        {
            Console.WriteLine($"{apellidos[i],-15} | {nombres[i],-15} | {nota1[i],-5} | {nota2[i],-5} | {nota3[i],-5} | {nota4[i],-5} | {promedio[i],-5:F2}");
        }
    }
}
