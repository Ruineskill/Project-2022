using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DBInitializers
{
    public class CarInitializer
    {
        /// <summary>
        /// DB data initializer for car
        /// </summary>
        public static readonly List<Car> _cars = new()
        {
            new Car("BMW", "X1", "5GZCZ43D13S812715", "1-FMG-000", FuelType.Diesel, CarType.Jeep),
            new Car("BMW", "X2", "WDBJF82J92X066093", "1-FMG-001", FuelType.Diesel, CarType.Jeep),
            new Car("BMW", "X3", "JN1AZ36A35M756212", "1-FMG-002", FuelType.Diesel, CarType.Jeep),
            new Car("BMW", "X4", "2LMHJ5AT8ABJ28122", "1-FMG-003", FuelType.Diesel, CarType.Jeep),
            new Car("BMW", "X5", "3A8FY489X9T501824", "1-FMG-004", FuelType.Diesel, CarType.Jeep),
            new Car("BMW", "X6", "1J4NF1GBXBD176528", "1-FMG-005", FuelType.Diesel, CarType.Jeep),
            new Car("BMW", "130d", "1B4GP24301B250903", "1-FMG-006", FuelType.Diesel, CarType.Car),
            new Car("BMW", "225d", "1C3CCBBG2DN702067", "1-FMG-007", FuelType.Diesel, CarType.Car),
            new Car("BMW", "330i", "1GKKVRKD0EJ265649", "1-FMG-008", FuelType.Diesel, CarType.Car),
            new Car("BMW", "430i", "1FTRX12W56FA39649", "1-FMG-009", FuelType.Diesel, CarType.Car),
            new Car("BMW", "540i", "2HGFG4A56FH700988", "1-FMG-010", FuelType.Diesel, CarType.Car),
            new Car("BMW", "640i", "1GKKVTKD9FJ181523", "1-FMG-011", FuelType.Diesel, CarType.Car),
            new Car("BMW", "750i", "1B3CB4HA6AD662379", "1-FMG-012", FuelType.Diesel, CarType.Car),
            new Car("Mercedes", "Class C", "1J8GS48K37C588452", "1-FMG-013", FuelType.Electric, CarType.Car),
            new Car("Mercedes", "Class C", "1GCGK29U3YE291330", "1-FMG-014", FuelType.Electric, CarType.Car),
            new Car("Mercedes", "Class C", "3N1CB51D24L854344", "1-FMG-015", FuelType.Electric, CarType.Car),
            new Car("Mercedes", "Class S", "2T3RFREV8DW088568", "1-FMG-016", FuelType.Electric, CarType.Car),
            new Car("Mercedes", "Class S", "JH4CU2F64DC010638", "1-FMG-017", FuelType.Electric, CarType.Car),
            new Car("Mercedes", "Class S", "3D7MU48CX4G168490", "1-FMG-018", FuelType.Electric, CarType.Car),
            new Car("Mercedes", "Class S", "JN8AS5MV5EW710151", "1-FMG-019", FuelType.Electric, CarType.Car),
            new Car("Mercedes", "Class F", "2G2WP522051278513", "1-FMG-020", FuelType.Electric, CarType.Car),
            new Car("Mercedes", "Class F", "JF1GV8J62DL033173", "1-FMG-021", FuelType.Electric, CarType.Car),
            new Car("Mercedes", "Class F", "1G4HJ5EM5BU142277", "1-FMG-022", FuelType.Electric, CarType.Car),
            new Car("Audi", "A5", "1FBHP26W39G222740", "1-FMG-023", FuelType.Benzine, CarType.Convertible),
            new Car("Audi", "A6", "WVWRP61J23W519467", "1-FMG-024", FuelType.Benzine, CarType.Convertible),
            new Car("Audi", "A4", "2FAHP71W17X107778", "1-FMG-025", FuelType.Diesel, CarType.Convertible),
            new Car("Audi", "A5", "5NPDH4AE2DH232099", "1-FMG-026", FuelType.Diesel, CarType.Car),
            new Car("Audi", "A2", "2FMGK5BC6ABA47297", "1-FMG-027", FuelType.Diesel, CarType.Car),
            new Car("Audi", "A1", "JTHBF5C28C5166628", "1-FMG-028", FuelType.Diesel, CarType.Car),
            new Car("Audi", "S3", "1FTFW1EV7AFC48991", "1-FMG-029", FuelType.Diesel, CarType.Car),
            new Car("Audi", "S4", "1G11C5SL6FF244346", "1-FMG-030", FuelType.Diesel, CarType.Car),
            new Car("Audi", "S5", "1G4HD57206U219369", "1-FMG-031", FuelType.Diesel, CarType.Car),
            new Car("Audi", "RS3", "4T1BK3DB7CU453914", "1-FMG-032", FuelType.Diesel, CarType.Car),
            new Car("Audi", "RS4", "2G1WF55K129341988", "1-FMG-033", FuelType.Diesel, CarType.Car),
            new Car("Audi", "RS5", "1HGCR2F55EA136922", "1-FMG-034", FuelType.Diesel, CarType.Car),
            new Car("Audi", "Q3", "3VWSF29M4YM025515", "1-FMG-035", FuelType.Diesel, CarType.Jeep),
            new Car("Audi", "Q4", "JTJGF10U930151507", "1-FMG-036", FuelType.Diesel, CarType.Jeep),
            new Car("Audi", "Q5", "1FMZU35P5XZA85048", "1-FMG-037", FuelType.Diesel, CarType.Jeep),
            new Car("Audi", "Q6", "1B3LC46K08N628032", "1-FMG-038", FuelType.Electric, CarType.Jeep),
            new Car("Audi", "Q7", "1GNCS13W7V2148338", "1-FMG-039", FuelType.Electric, CarType.Jeep),
            new Car("Opel", "Vivaro", "2GCEC19X531207821", "1-FMG-040", FuelType.Electric, CarType.Jeep),
            new Car("Opel", "Vivaro", "1GCEC14X29Z201563", "1-FMG-041", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1N4AL2AP7BN446273", "1-FMG-042", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1ZVFT82H575339964", "1-FMG-043", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "3C4PDCBG4ET177868", "1-FMG-044", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "JTKDE167080259282", "1-FMG-045", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1FTRW08L03KC13446", "1-FMG-046", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1C6RR7FT1ES394215", "1-FMG-047", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "5TDZA22C04S212570", "1-FMG-048", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "WBAVD13556KV10412", "1-FMG-049", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "5J6RM4H79EL083738", "1-FMG-050", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1FTDF15YXPLA71459", "1-FMG-051", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1FAHP56S13G100484", "1-FMG-052", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1FT7W2BTXEEB34282", "1-FMG-053", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "WA19FAFL0DA211111", "1-FMG-054", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1FTFX1EF9BFA29585", "1-FMG-055", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1G1AL55F267614725", "1-FMG-066", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1GT12ZE89FF100119", "1-FMG-067", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "5J6RE4H7XAL019957", "1-FMG-068", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "3N1AB7AP3DL607248", "1-FMG-069", FuelType.Diesel, CarType.Jeep),
            new Car("Opel", "Vivaro", "1FDKF37G7VEB88730", "1-FMG-070", FuelType.Diesel, CarType.Jeep),
            new Car("Seat", "Ibiza", "1YVHP80D945N83283", "1-FMG-071", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "5TFCY5F19DX015645", "1-FMG-072", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "WBA5A5C56ED506744", "1-FMG-073", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "2G1FB1E3XD9211689", "1-FMG-074", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "1GNFC13C68R175736", "1-FMG-075", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "1GYEE637240150064", "1-FMG-076", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "1GCHK34FXWZ255398", "1-FMG-077", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "JN8AF5MR3BT006194", "1-FMG-078", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "5N1AN08W97C530289", "1-FMG-079", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "1FTNW20S52EC18068", "1-FMG-080", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "KNDPBCAC8F7686856", "1-FMG-081", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "5N1AA0ND4CN621449", "1-FMG-082", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "1GTGK29R4TE549939", "1-FMG-083", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "JS1GR7HA522101580", "1-FMG-084", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "5GZDV23L35D178634", "1-FMG-085", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "5TDZK23C88S168531", "1-FMG-086", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "3N1BC1AP3AL363529", "1-FMG-087", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "3B7HC13Y1SM187749", "1-FMG-088", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "2T3DF4DV8BW098870", "1-FMG-089", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "3LNHL2GC6BR776511", "1-FMG-090", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "1XP5DB9X43D588017", "1-FMG-091", FuelType.Electric, CarType.Car),
            new Car("Seat", "Ibiza", "KNDUP131326268211", "1-FMG-092", FuelType.Electric, CarType.Car),
            new Car("Renault", "T", "2GCEK13J881273343", "1-FMG-093", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "5XXGN4A79FG413481", "1-FMG-094", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "1GAZG1FG2B1123155", "1-FMG-095", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "1FALP5216VG213454", "1-FMG-096", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "1J4RR4GG1BC555476", "1-FMG-097", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "5N1ED28T34C651630", "1-FMG-098", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "2HJYK16367H512013", "1-FMG-099", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "1G1GZ11GXHP134273", "1-FMG-100", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "5NMSG13D97H054657", "1-FMG-101", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "5LMFU28R74LJ11543", "1-FMG-102", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "JACDH58W1R7927561", "1-FMG-103", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "5FNYF4H50DB035637", "1-FMG-104", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "WVWHN7AN7BE715340", "1-FMG-105", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "1ZVBP8EM5C5204585", "1-FMG-106", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "3B7KF23C6TM192230", "1-FMG-107", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "3D4PG3FG9BT506273", "1-FMG-108", FuelType.Diesel, CarType.Truck),
            new Car("Renault", "T", "5NPEB4AC4CH455280", "1-FMG-109", FuelType.Diesel, CarType.Truck)
        };

        public static void SeedData(Contexts.Context context)
        {
            context.Database.EnsureCreated();


            foreach(var c in _cars)
            {
                var result = context.Cars.Where(b => b.ChassisNumber == c.ChassisNumber || b.LicensePlate == c.LicensePlate).FirstOrDefault();
                if(result == null)
                {
                    context.Cars.Add(c);
                }

            }
            context.SaveChanges();

        }
    }
}
