using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Constants
{
    public static class HttpPaths
    {
        public const string Base = "http://localhost:5239/api/";

        // Cars
        public const string GetAllCars = "Car";
        public const string GetCarById = "Car";
        public const string UpdateCar = "Car";
        public const string CreateCar = "Car";
        public const string DeleteCar = "Car";

        // Persons
        public const string GetAllPersons = "Person";
        public const string GetPersonById = "Person";
        public const string UpdatePerson = "Person";
        public const string CreatePerson = "Person";
        public const string DeletePerson = "Person";

        //FuelCards
        public const string GetAllFuelCards = "FuelCard";
        public const string GetFuelCardById = "FuelCard";
        public const string UpdateFuelCard = "FuelCard";
        public const string CreateFuelCard = "FuelCard";
        public const string DeleteFuelCard = "FuelCard";

        //Security
        public const string SignIn = "User/SignIn";
        public const string SignOut = "User/Invalidate";
        public const string RefreshToken = "User/Refresh";
    }
}
