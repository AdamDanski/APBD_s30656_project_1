namespace project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship ship = new Ship("Neptune", 25, 5);
            bool running = true;
            
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Dodaj kontener");
                Console.WriteLine("2. Usuń kontener");
                Console.WriteLine("3. Wyświetl listę kontenerów");
                Console.WriteLine("4. Załaduj kontener");
                Console.WriteLine("5. Rozładuj kontener");
                Console.WriteLine("6. Wyjście");
                Console.Write("Wybierz opcję: ");
                
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddContainer(ship);
                        break;
                    case "2":
                        RemoveContainer(ship);
                        break;
                    case "3":
                        DisplayContainers(ship);
                        break;
                    case "4":
                        LoadContainer(ship);
                        break;
                    case "5":
                        UnloadContainer(ship);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
                        break;
                }
            }
        }

        static void AddContainer(Ship ship)
        {
            Console.WriteLine("Wybierz typ kontenera (1 - Gazowy, 2 - Ciekły, 3 - Chłodniczy): ");
            string type = Console.ReadLine();
            Contener container = null;
            
            switch (type)
            {
                case "1":
                    container = new GasContainer(0, 200, 50, 100, 1000, 5);
                    break;
                case "2":
                    container = new LiquidContainer(0, 200, 50, 100, 1000, true);
                    break;
                case "3":
                    Console.Write("Podaj typ produktu: ");
                    string productType = Console.ReadLine();
                    container = new RefrigeratedContainer(0, 200, 50, 100, 1000, productType, 5);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    return;
            }
            
            ship.LoadContainer(container);
            Console.WriteLine("Dodano kontener: " + container.SerialNumber);
        }

        static void RemoveContainer(Ship ship)
        {
            Console.Write("Podaj numer seryjny kontenera do usunięcia: ");
            string serial = Console.ReadLine();
            ship.RemoveContainer(serial);
            Console.WriteLine("Usunięto kontener: " + serial);
        }

        static void DisplayContainers(Ship ship)
        {
            Console.WriteLine("Lista kontenerów na statku:");
            foreach (var container in ship.GetContainers())
            {
                Console.WriteLine(container.GetContainerInfo());
            }
        }

        static void LoadContainer(Ship ship)
        {
            Console.Write("Podaj numer seryjny kontenera: ");
            string serial = Console.ReadLine();
            Console.Write("Podaj wagę ładunku: ");
            double weight = double.Parse(Console.ReadLine());
            
            var container = ship.FindContainer(serial);
            if (container != null)
            {
                container.LoadCharge(weight);
                Console.WriteLine("Załadowano " + weight + " kg do " + serial);
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera.");
            }
        }

        static void UnloadContainer(Ship ship)
        {
            Console.Write("Podaj numer seryjny kontenera: ");
            string serial = Console.ReadLine();
            Console.Write("Podaj wagę do rozładunku: ");
            double weight = double.Parse(Console.ReadLine());
            
            var container = ship.FindContainer(serial);
            if (container != null)
            {
                container.UnloadCharge(weight);
                Console.WriteLine("Rozładowano " + weight + " kg z " + serial);
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera.");
            }
        }
    }
}
