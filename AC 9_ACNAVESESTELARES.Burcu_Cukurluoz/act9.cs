using System;
using System.Collections.Generic;

internal class Program
{
    static string[] nombresBase = { "HALCONMILENARIO", "CAZAESTELAR", "SUPERDESTRUCTOR", "YWING", "XWING" };
    static List<string> naves = new List<string>();
    static Stack<string> pilaNaves = new Stack<string>();
    static Random random = new Random();
    
    static void Main()
    {
        string opcion = "";
        while (opcion != "9")
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Crear nave");
            Console.WriteLine("2. Crear bloque de 10 naves");
            Console.WriteLine("3. Cambiar nombre");
            Console.WriteLine("4. Ver naves");
            Console.WriteLine("5. Eliminar todas");
            Console.WriteLine("6. Eliminar por índice");
            Console.WriteLine("7. Pasar a pila");
            Console.WriteLine("8. Mostrar pila");
            Console.WriteLine("9. Salir");
            
            opcion = Console.ReadLine();
            
            if (opcion == "1") CrearNave();
            if (opcion == "2") for (var i = 0; i < 10; i++) CrearNave();
            if (opcion == "3") CambiarNombre();
            if (opcion == "4") ListarNaves();
            if (opcion == "5") EliminarTodas();
            if (opcion == "6") EliminarPorIndex();
            if (opcion == "7") PasarAPila();
            if (opcion == "8") MostrarPila();
        }
    }

    static void CrearNave()
    {
        string nombre;
        do
        {
            nombre = nombresBase[random.Next(nombresBase.Length)] + "-" + random.Next(10, 100);
        } while (naves.Contains(nombre));

        naves.Add(nombre);
        Console.WriteLine("Nave creada: " + nombre);
    }

    static void CambiarNombre()
    {
        Console.WriteLine("Ingrese el índice de la nave a renombrar:");
        string input = Console.ReadLine();
        
        var index = ObtenerNumero(input, naves.Count);
        if (index != -1)
        {
            string nuevoNombre;
            do
            {
                nuevoNombre = nombresBase[random.Next(nombresBase.Length)] + "-" + random.Next(10, 100);
            } while (naves.Contains(nuevoNombre));
            
            naves[index] = nuevoNombre;
            Console.WriteLine("Nombre cambiado a: " + nuevoNombre);
        }
        else Console.WriteLine("Índice no válido.");
    }

    static void ListarNaves()
    {
        if (naves.Count == 0)
        {
            Console.WriteLine("No hay naves registradas.");
        }
        else
        {
            foreach (var nave in naves) Console.WriteLine(nave);
        }
    }

    static void EliminarTodas()
    {
        naves.Clear();
        Console.WriteLine("Todas las naves han sido eliminadas.");
    }

    static void EliminarPorIndex()
    {
        Console.WriteLine("Ingrese el índice de la nave a eliminar:");
        string input = Console.ReadLine();
        
        var index = ObtenerNumero(input, naves.Count);
        if (index != -1)
        {
            Console.WriteLine("Nave eliminada: " + naves[index]);
            naves.RemoveAt(index);
        }
        else Console.WriteLine("Índice no válido.");
    }

    static void PasarAPila()
    {
        pilaNaves.Clear();
        foreach (var nave in naves) pilaNaves.Push(nave);
        Console.WriteLine("Todas las naves se han pasado a la pila.");
    }

    static void MostrarPila()
    {
        if (pilaNaves.Count == 0)
        {
            Console.WriteLine("La pila está vacía.");
        }
        else
        {
            foreach (var nave in pilaNaves) Console.WriteLine(nave);
        }
    }

    static int ObtenerNumero(string input, int max)
    {
        int numero = 0;
        foreach (var c in input)
        {
            if (c < '0' || c > '9') return -1;
            numero = numero * 10 + (c - '0');
        }
        if (numero >= 0 && numero < max) return numero;
        return -1;
    }
}
