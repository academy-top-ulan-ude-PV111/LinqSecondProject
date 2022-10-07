namespace LinqSecondProject
{
    class City
    {
        public string? Title { set; get; }
        public List<Company>? Companies { set; get; }
    }
    class Company
    {
        public string? Title { set; get; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create collection
            var cities = new List<City>
            {
                new City{Title = "Moscow", 
                    Companies = new List<Company>
                    { 
                        new Company{Title = "Yandex"},
                        new Company{Title = "Mail Group"},
                        new Company{Title = "Kaspersky"},
                        new Company{Title = "Moskvich"},
                    } 
                },
                new City{Title = "St Peterburg",
                    Companies = new List<Company>
                    {
                        new Company{Title = "Ermitag"},
                        new Company{Title = "Neva Prod"},
                        new Company{Title = "PeterSoft"},
                    }
                },
                new City{Title = "Kazan",
                    Companies = new List<Company>
                    {
                        new Company{Title = "HyperLaserSoft"},
                        new Company{Title = "KazanGAZ"},
                    }
                },
            };


            // SELECT MANY
            //var companies = from city in cities
            //                from comp in city.Companies!
            //                select comp;

            //var companiesSM = cities.SelectMany(city => city.Companies!);

            //foreach (var item in companies)
            //    Console.WriteLine($"{item.Title}");
            //Console.WriteLine($"---------------------");
            //foreach (var item in companiesSM)
            //    Console.WriteLine($"{item.Title}");
            //Console.WriteLine($"---------------------");


            var compCityOne = from city in cities
                              from comp in city.Companies!
                              select new
                              {
                                  CompanyName = comp.Title,
                                  CityName = city.Title
                              };

            var compCityTwo = cities.SelectMany(
                city => city.Companies!,
                (city, comp) => new 
                {
                    CompanyName = comp.Title,
                    CityName = city.Title
                }
               );


            foreach (var item in compCityOne)
                Console.WriteLine($"{item.CompanyName} {item.CityName}");
            Console.WriteLine($"---------------------");
            foreach (var item in compCityTwo)
                Console.WriteLine($"{item.CompanyName} {item.CityName}");
            Console.WriteLine($"---------------------");

        }
    }
}