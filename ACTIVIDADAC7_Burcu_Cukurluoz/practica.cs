// 1. Gestión de Pacientes en un Hospital
/*
using System;

struct Paciente
{
    public string Nombre;
    public int Edad;
    public string Diagnostico;
    public DateTime FechaIngreso;
}

class Program
{
    static Paciente[] pacientes = new Paciente[6];
    static int indicePacientes = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenú de Gestión de Pacientes");
            Console.WriteLine("1. Registrar un nuevo paciente");
            Console.WriteLine("2. Mostrar la lista completa de pacientes");
            Console.WriteLine("3. Buscar un paciente por nombre");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarPaciente();
                    break;
                case 2:
                    MostrarPacientes();
                    break;
                case 3:
                    BuscarPaciente();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void RegistrarPaciente()
    {
        if (indicePacientes < pacientes.Length)
        {
            Paciente paciente;
            
            Console.Write("Nombre: ");
            paciente.Nombre = Console.ReadLine();
            Console.Write("Edad: ");
            paciente.Edad = int.Parse(Console.ReadLine());
            Console.Write("Diagnóstico: ");
            paciente.Diagnostico = Console.ReadLine();
            paciente.FechaIngreso = DateTime.Now;

            pacientes[indicePacientes] = paciente;
            indicePacientes++;

            Console.WriteLine("Paciente registrado correctamente.");
        }
        else
        {
            Console.WriteLine("No hay espacio para más pacientes.");
        }
    }

    static void MostrarPacientes()
    {
        if (indicePacientes == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }

        foreach (var paciente in pacientes)
        {
            if (!string.IsNullOrEmpty(paciente.Nombre))
            {
                Console.WriteLine($"Nombre: {paciente.Nombre}, Edad: {paciente.Edad}, Diagnóstico: {paciente.Diagnostico}, Fecha de Ingreso: {paciente.FechaIngreso}");
            }
        }
    }

    static void BuscarPaciente()
    {
        Console.Write("Ingrese el nombre del paciente a buscar: ");
        string nombre = Console.ReadLine();

        foreach (var paciente in pacientes)
        {
            if (!string.IsNullOrEmpty(paciente.Nombre) && paciente.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Nombre: {paciente.Nombre}, Edad: {paciente.Edad}, Diagnóstico: {paciente.Diagnostico}, Fecha de Ingreso: {paciente.FechaIngreso}");
                return;
            }
        }
        Console.WriteLine("Paciente no encontrado.");
    }
}

// 2. Clasificación y Gestión de Películas por Género

using System;

struct Pelicula
{
    public string Titulo;
    public string Director;
    public string Genero;
    public int Duracion;
}

class Program
{
    static Pelicula[,] peliculas = new Pelicula[3, 4];
    static string[] generos = { "Acción", "Comedia", "Drama" };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenú de Gestión de Películas");
            Console.WriteLine("1. Agregar una nueva película");
            Console.WriteLine("2. Mostrar películas de un género");
            Console.WriteLine("3. Calcular el promedio de duración por género");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarPelicula();
                    break;
                case 2:
                    MostrarPeliculasPorGenero();
                    break;
                case 3:
                    CalcularPromedioDuracion();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void AgregarPelicula()
    {
        Console.WriteLine("Seleccione un género:");
        for (int i = 0; i < generos.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {generos[i]}");
        }
        int generoIndex = int.Parse(Console.ReadLine()) - 1;

        if (generoIndex < 0 || generoIndex >= generos.Length)
        {
            Console.WriteLine("Selección inválida.");
            return;
        }

        for (int j = 0; j < 4; j++)
        {
            if (string.IsNullOrEmpty(peliculas[generoIndex, j].Titulo))
            {
                Pelicula pelicula;
                
                Console.Write("Título: ");
                pelicula.Titulo = Console.ReadLine();
                Console.Write("Director: ");
                pelicula.Director = Console.ReadLine();
                pelicula.Genero = generos[generoIndex];
                Console.Write("Duración (minutos): ");
                pelicula.Duracion = int.Parse(Console.ReadLine());

                peliculas[generoIndex, j] = pelicula;
                Console.WriteLine("Película agregada correctamente.");
                return;
            }
        }
        Console.WriteLine("No hay espacio para más películas en esta categoría.");
    }

    static void MostrarPeliculasPorGenero()
    {
        Console.WriteLine("Seleccione un género para mostrar:");
        for (int i = 0; i < generos.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {generos[i]}");
        }
        int generoIndex = int.Parse(Console.ReadLine()) - 1;

        if (generoIndex < 0 || generoIndex >= generos.Length)
        {
            Console.WriteLine("Selección inválida.");
            return;
        }

        Console.WriteLine($"Películas en el género {generos[generoIndex]}:");
        for (int j = 0; j < 4; j++)
        {
            if (!string.IsNullOrEmpty(peliculas[generoIndex, j].Titulo))
            {
                Console.WriteLine($"Título: {peliculas[generoIndex, j].Titulo}, Director: {peliculas[generoIndex, j].Director}, Duración: {peliculas[generoIndex, j].Duracion} minutos");
            }
        }
    }

    static void CalcularPromedioDuracion()
    {
        for (int i = 0; i < generos.Length; i++)
        {
            int totalDuracion = 0, contador = 0;
            for (int j = 0; j < 4; j++)
            {
                if (!string.IsNullOrEmpty(peliculas[i, j].Titulo))
                {
                    totalDuracion += peliculas[i, j].Duracion;
                    contador++;
                }
            }
            if (contador > 0)
            {
                Console.WriteLine($"Promedio de duración en {generos[i]}: {totalDuracion / contador} minutos.");
            }
            else
            {
                Console.WriteLine($"No hay películas en la categoría {generos[i]}.");
            }
        }
    }
}

// 3. Organización de Eventos Deportivos

using System;

struct EventoDeportivo
{
    public string Nombre;
    public DateTime Fecha;
    public string Lugar;
    public int NumeroParticipantes;
}

class Program
{
    static EventoDeportivo[] eventos = new EventoDeportivo[5];
    static int indiceEventos = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenú de Gestión de Eventos Deportivos");
            Console.WriteLine("1. Agregar un nuevo evento deportivo");
            Console.WriteLine("2. Mostrar todos los eventos");
            Console.WriteLine("3. Buscar un evento por nombre");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarEvento();
                    break;
                case 2:
                    MostrarEventos();
                    break;
                case 3:
                    BuscarEvento();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void AgregarEvento()
    {
        if (indiceEventos < eventos.Length)
        {
            EventoDeportivo evento;
            
            Console.Write("Nombre del evento: ");
            evento.Nombre = Console.ReadLine();
            Console.Write("Fecha del evento (YYYY-MM-DD): ");
            evento.Fecha = DateTime.Parse(Console.ReadLine());
            Console.Write("Lugar: ");
            evento.Lugar = Console.ReadLine();
            Console.Write("Número de participantes: ");
            evento.NumeroParticipantes = int.Parse(Console.ReadLine());

            eventos[indiceEventos] = evento;
            indiceEventos++;

            Console.WriteLine("Evento agregado correctamente.");
        }
        else
        {
            Console.WriteLine("No hay espacio para más eventos.");
        }
    }

    static void MostrarEventos()
    {
        if (indiceEventos == 0)
        {
            Console.WriteLine("No hay eventos registrados.");
            return;
        }

        foreach (var evento in eventos)
        {
            if (!string.IsNullOrEmpty(evento.Nombre))
            {
                Console.WriteLine($"Nombre: {evento.Nombre}, Fecha: {evento.Fecha.ToShortDateString()}, Lugar: {evento.Lugar}, Participantes: {evento.NumeroParticipantes}");
            }
        }
    }

    static void BuscarEvento()
    {
        Console.Write("Ingrese el nombre del evento a buscar: ");
        string nombre = Console.ReadLine();

        foreach (var evento in eventos)
        {
            if (!string.IsNullOrEmpty(evento.Nombre) && evento.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Nombre: {evento.Nombre}, Fecha: {evento.Fecha.ToShortDateString()}, Lugar: {evento.Lugar}, Participantes: {evento.NumeroParticipantes}");
                return;
            }
        }
        Console.WriteLine("Evento no encontrado.");
    }
}

// 4. Gestión de Reservas de Libros en una Biblioteca
using System;

struct ReservaLibro
{
    public string TituloLibro;
    public string NombreUsuario;
    public DateTime FechaReserva;
    public DateTime FechaDevolucion;
}

class Program
{
    static ReservaLibro[] reservas = new ReservaLibro[7];
    static int indiceReservas = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenú de Gestión de Reservas de Libros");
            Console.WriteLine("1. Realizar una nueva reserva");
            Console.WriteLine("2. Mostrar todas las reservas");
            Console.WriteLine("3. Buscar reservas por usuario");
            Console.WriteLine("4. Mostrar libros pendientes de devolución");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RealizarReserva();
                    break;
                case 2:
                    MostrarReservas();
                    break;
                case 3:
                    BuscarReservasPorUsuario();
                    break;
                case 4:
                    MostrarPendientesDevolucion();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void RealizarReserva()
    {
        if (indiceReservas < reservas.Length)
        {
            ReservaLibro reserva;
            
            Console.Write("Título del libro: ");
            reserva.TituloLibro = Console.ReadLine();
            Console.Write("Nombre del usuario: ");
            reserva.NombreUsuario = Console.ReadLine();
            Console.Write("Fecha de reserva (YYYY-MM-DD): ");
            reserva.FechaReserva = DateTime.Parse(Console.ReadLine());
            Console.Write("Fecha de devolución (YYYY-MM-DD): ");
            reserva.FechaDevolucion = DateTime.Parse(Console.ReadLine());

            reservas[indiceReservas] = reserva;
            indiceReservas++;

            Console.WriteLine("Reserva realizada correctamente.");
        }
        else
        {
            Console.WriteLine("No hay espacio para más reservas.");
        }
    }

    static void MostrarReservas()
    {
        if (indiceReservas == 0)
        {
            Console.WriteLine("No hay reservas registradas.");
            return;
        }

        foreach (var reserva in reservas)
        {
            if (!string.IsNullOrEmpty(reserva.TituloLibro))
            {
                Console.WriteLine($"Título: {reserva.TituloLibro}, Usuario: {reserva.NombreUsuario}, Fecha de reserva: {reserva.FechaReserva.ToShortDateString()}, Fecha de devolución: {reserva.FechaDevolucion.ToShortDateString()}");
            }
        }
    }

    static void BuscarReservasPorUsuario()
    {
        Console.Write("Ingrese el nombre del usuario a buscar: ");
        string usuario = Console.ReadLine();

        bool encontrado = false;
        foreach (var reserva in reservas)
        {
            if (!string.IsNullOrEmpty(reserva.NombreUsuario) && reserva.NombreUsuario.Equals(usuario, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Título: {reserva.TituloLibro}, Fecha de reserva: {reserva.FechaReserva.ToShortDateString()}, Fecha de devolución: {reserva.FechaDevolucion.ToShortDateString()}");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron reservas para este usuario.");
        }
    }

    static void MostrarPendientesDevolucion()
    {
        int pendientes = 0;
        DateTime hoy = DateTime.Today;

        foreach (var reserva in reservas)
        {
            if (!string.IsNullOrEmpty(reserva.TituloLibro) && reserva.FechaDevolucion > hoy)
            {
                pendientes++;
            }
        }

        Console.WriteLine($"Libros pendientes de devolución: {pendientes}");
    }
}

*/