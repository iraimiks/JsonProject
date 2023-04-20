using System.Text.Json;

namespace JsonProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker worker1 = new Worker("Raimonds", 32, false);
            Worker worker2 = new Worker("Anna", 31, true);
            Worker worker3 = new Worker("Toms", 25, true);

            string jsonStringWorker1 = JsonSerializer.Serialize(worker1);
            Console.WriteLine(jsonStringWorker1);

            File.WriteAllText("ThisIsWroker1.json", jsonStringWorker1);

            Worker sameObjecWorker = JsonSerializer.Deserialize<Worker>(jsonStringWorker1);

            Console.WriteLine($"Worker name: {sameObjecWorker.Name}");
            Console.WriteLine($"Worker age: {sameObjecWorker.Age}");
            Console.WriteLine($"Is worker have car: {sameObjecWorker.Car}");

            List<Worker> workers = new List<Worker>();

            workers.Add(worker1);
            workers.Add(worker2);
            workers.Add(worker3);

            var jsonDataWorker = JsonSerializer.Serialize(workers);

            Console.WriteLine(jsonDataWorker);

            var listFromJson = JsonSerializer.Deserialize<List<Worker>>(jsonDataWorker);

            var getLinq = from item in listFromJson
                          select item;

            ShowListValues(getLinq);
        }
        static void ShowListValues(IEnumerable<Worker> list)
        {
            foreach (Worker elementData in list)
            {
                Console.WriteLine($"Worker name: {elementData.Name}");
                Console.WriteLine($"Worker age: {elementData.Age}");
                Console.WriteLine($"Is worker have car: {elementData.Car}");
            }
        }
    }
}