

namespace DataAccess
{
    internal class Person
    {
        public string Name { get;  set; } = "Mark";
        public int YearOfBirth { get; init; }
        //sadece object-creationda bu proeprteis e deger atanmasina izin verir object-creation olduktan sonra artik direk olarak person1.YearOfBirth=1982; seklinde deger atamasina izin vermeyecektir

        public Person(string name, int yearOfBirth)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
        }


        public void Test()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; ++i)
            {
                Console.WriteLine($"Loop number {i}");
            }

            stopwatch.Stop();
            Console.WriteLine("Time in ms: " + stopwatch.ElapsedMilliseconds);
        }

    }
}
