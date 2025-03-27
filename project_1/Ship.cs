namespace project_1
{
    public class Ship
    {
        public string Name { get; set; }
        public int MaxContainers { get; set; }
        public double MaxWeight { get; set; }
        public List<Contener> Containers { get; set; }

        public Ship(string name, int maxContainers, double maxWeight)
        {
            Name = name;
            MaxContainers = maxContainers;
            MaxWeight = maxWeight;
            Containers = new List<Contener>();
        }

        public void LoadContainer(Contener container)
        {
            if (Containers.Count < MaxContainers)
            {
                double sum = 0.0;
               foreach (Contener child in Containers)
                   sum+=child.OwnWeight+child.Weight;
               if (sum+container.OwnWeight+container.Weight > MaxWeight)
                    throw new Exception("Za duza waga");
                Containers.Add(container);
            }
            else
            {
                Console.WriteLine("Za dużo kontenerów na statku.");
            }
        }

        public void RemoveContainer(string serialNumber)
        {
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                Containers.Remove(container);
            }
            else
            {
                Console.WriteLine("Kontener o podanym numerze seryjnym nie został znaleziony.");
            }
        }
        
        public List<Contener> GetContainers()
        {
            return Containers;
        }

        public Contener FindContainer(string serialNumber)
        {
            return Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        }
    }

}