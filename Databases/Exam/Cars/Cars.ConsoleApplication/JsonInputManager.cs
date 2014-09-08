namespace Cars.ConsoleApplication
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using Cars.Data.Model;
    using Newtonsoft.Json;
    using Cars.Data;
    using Helpers.Contracts;
    using Newtonsoft.Json.Linq;

    class JsonInputManager
    {
        private string rootPath;
        private CarsContext db;
        private ILogger logger;

        public JsonInputManager(string path, CarsContext db, ILogger logger)
        {
            this.rootPath = path;
            this.db = db;
            this.logger = logger;
        }

        public void LoadData()
        {
            var files = Directory.EnumerateFiles(rootPath);
            foreach (var file in files)
            {
                logger.ProcessingMessage("Processing" +file.Substring(file.LastIndexOf('\\')+1));
                LoadDataFromFile(file);
                logger.SuccessMessage("Processing done");
            }
        }

        private void LoadDataFromFile(string file)
        {
            var data = File.ReadAllText(file);
            var listOfCars = JsonConvert.DeserializeObject<List<Car>>(data);
            var manufacurerNames = listOfCars.Select(x => x.ManufacturerName).Distinct();
            var cityNames = listOfCars.Select(x => x.Dealer.City).Distinct();

            var distinctManufacturernames = manufacurerNames.Where(x => !db.Manifacturers.Select(m => m.Name).Contains(x));
            foreach(var manufacturer in distinctManufacturernames)
            {
                db.Manifacturers.Add(new Manufacturer(){Name = manufacturer});
            }

            var distinctCitynames = cityNames.Where(x => !db.Cities.Select(c => c.Name).Contains(x));
            foreach(var city in distinctCitynames)
            {
                db.Cities.Add(new City(){Name = city});
            }

            foreach(var car  in listOfCars)
            {
               // car.Dealer.Id = db.Dealers.Where(x => x.Name == car.Dealer.Name).Select(x => x.Id).First();
               // car.ManufacturerId = db.Manifacturers.Where(x => x.Name == car.ManufacturerName).Select(x => x.Id).First();
                //car.Dealer.Id = db.Dealers.Where(x => x.Name == car.DealerName).Select(x => x.Id).First();
                db.Cars.Add(car);
            }
            db.SaveChanges();
        }
    }
}
