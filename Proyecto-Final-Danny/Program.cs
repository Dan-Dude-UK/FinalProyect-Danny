using Control_Gastos;

var context = new gastosContext();
context.Database.EnsureCreated();
List<Gasto> gastos = context.Gastos.ToList();

bool running = true;
int choosenOption = 0;

while (running)
{
    Console.WriteLine("\n=== Control de Gastos Diarios ===");
    Console.WriteLine("1. Agregar gasto");
    Console.WriteLine("2. Listar gastos");
    Console.WriteLine("3. Buscar gasto");
    Console.WriteLine("4. Eliminar gasto");
    Console.WriteLine("5. Ver total de gastos");
    Console.WriteLine("6. Salir");
    Console.WriteLine("---------------------------------");

    try
    {
        choosenOption = Convert.ToInt32(Console.ReadLine());

        switch (choosenOption)
        {
            case 1:
                {
                    Console.WriteLine("Escribe la descripción del gasto:");
                    string descripcion = Console.ReadLine();

                    Console.WriteLine("Escribe el monto (RD$):");
                    decimal monto = decimal.Parse(Console.ReadLine());

                    using (var db = new gastosContext())
                    {
                        db.Gastos.Add(new Gasto
                        {
                            Descripcion = descripcion,
                            Monto = monto,
                            Fecha = DateTime.Now
                        });

                        db.SaveChanges();
                        Console.WriteLine("Gasto agregado correctamente.");
                    }

                    gastos = context.Gastos.ToList();
                }
                break;

            case 2:
                {
                    using (var db = new gastosContext())
                    {
                        var lista = db.Gastos.ToList();

                        if (lista.Count == 0)
                        {
                            Console.WriteLine("No hay gastos registrados.");
                            break;
                        }

                        Console.WriteLine("\n--- Lista de Gastos ---");
                        foreach (var gasto in lista)
                        {
                            Console.WriteLine(gasto.ToString());
                        }
                    }
                }
                break;

            case 3:
                {
                    Console.WriteLine("Escribe la descripción a buscar:");
                    string busqueda = Console.ReadLine();

                    using (var db = new gastosContext())
                    {
                        var lista = db.Gastos.ToList();
                        bool encontrado = false;

                        for (int i = 0; i < lista.Count; i++)
                        {
                            if (lista[i].Descripcion.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(lista[i].ToString());
                                encontrado = true;
                            }
                        }

                        if (!encontrado)
                            Console.WriteLine("No se encontró ningún gasto con esa descripción.");
                    }
                }
                break;

            case 4:
                {
                    Console.WriteLine("Escribe el ID del gasto a eliminar:");
                    int idEliminar = Convert.ToInt32(Console.ReadLine());

                    using (var db = new gastosContext())
                    {
                        var gasto = db.Gastos.FirstOrDefault(g => g.Id == idEliminar);

                        if (gasto != null)
                        {
                            db.Gastos.Remove(gasto);
                            db.SaveChanges();
                            Console.WriteLine("Gasto eliminado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un gasto con ese ID.");
                        }
                    }

                    gastos = context.Gastos.ToList();
                }
                break;

            case 5:
                {
                    using (var db = new gastosContext())
                    {
                        var lista = db.Gastos.ToList();
                        decimal total = 0;

                        foreach (var gasto in lista)
                        {
                            total += gasto.Monto;
                        }

                        Console.WriteLine($"\nTotal de gastos registrados: RD${total}");
                    }
                }
                break;

            case 6:
                {
                    running = false;
                }
                break;

            default:
                Console.WriteLine("Por favor elige una opción del 1 al 6.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocurrió un error: {ex.Message}");
    }
}

Console.WriteLine("Cerrando el sistema...");