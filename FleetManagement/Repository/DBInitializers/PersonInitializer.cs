using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DBInitializers
{
    public class PersonInitializer
    {
        public static readonly List<Person> _persons = new()
        {
            new Person("Padmé", "Amidala", new(1960, 06, 18), "60061812456", DrivingLicenseType.B) { Address = new("Skystreet", 08, "Brussel", 1000) },
            new Person("Boba", "Fett", new(1986, 02, 24), "86022402508", DrivingLicenseType.D) { Address = new("Fettstreet", 322, "Brugge", 8000) },
            new Person("Luke", "Skywalker", new(1981, 05, 03), "81050312962", DrivingLicenseType.B) { Address = new("Amidalastreet", 255, "Mechelen", 2500) },
            new Person("Sheev", "Palpatine", new(1977, 09, 03), "77090381596", DrivingLicenseType.C1E) { Address = new("Palpatinestreet", 12, "Leuven", 3000) },
            new Person("Shmi", "Skywalker", new(1950, 01, 01), "50010129256", DrivingLicenseType.B) { Address = new("Graaf Arnulfstreet", 11, "Gent", 9000) },
            new Person("Anakin", "Skywalker", new(1960, 01, 03), "60010319512", DrivingLicenseType.B) { Address = new("Skystreet", 01, "Brussel", 1000) },
            new Person("Leia", "Organa", new(1951, 12, 13), "51121319684", DrivingLicenseType.B) { Address = new("Skystreet", 11, "Brussel", 1000) },
            new Person("Han", "Solo", new(1963, 04, 04), "63040429266", DrivingLicenseType.B) { Address = new("Skystreet", 131, "Brussel", 1000) },
            new Person("Ben", "Solo", new(1955, 05, 15), "55051529260", DrivingLicenseType.B) { Address = new("Graaf Arnulfstreet", 1, "Gent", 9000) },
            new Person("Jobal", "Naberrie", new(1980, 09, 09), "80090938917", DrivingLicenseType.B) { Address = new("Graaf Arnulfstreet", 3, "Gent", 9000) },
            new Person("Pooja", "Naberrie", new(1983, 10, 04), "83100439042", DrivingLicenseType.B) { Address = new("Graaf Arnulfstreet", 7, "Gent", 9000) },
            new Person("Ruwee", "Naberrie", new(1990, 10, 04), "90100400292", DrivingLicenseType.B) { Address = new("Graaf Arnulfstreet", 8, "Gent", 9000) },
            new Person("Ryoo", "Naberrie", new(1960, 08, 06), "60080600168", DrivingLicenseType.BE) { Address = new("Graaf Arnulfstreet", 9, "Gent", 9000) },
            new Person("Sola", "Naberrie", new(1998, 06, 08), "98060800215", DrivingLicenseType.BE) { Address = new("Graaf Arnulfstreet", 12, "Gent", 9000) },
            new Person("Beru Whitesun", "Lars", new(1977, 04, 12), "77041200123", DrivingLicenseType.BE) { Address = new("Kortijksesteenstreet", 11, "Brugge", 8000) },
            new Person("Cliego", "Lars", new(1962, 04, 08), "62040800122", DrivingLicenseType.BE) { Address = new("Kortijksesteenstreet", 151, "Brugge", 8000) },
            new Person("Owen", "Lars", new(1965, 02, 04), "65020400194", DrivingLicenseType.BE) { Address = new("Kortijksesteenstreet", 161, "Brugge", 8000) },
            new Person("Aika", "Lars", new(1982, 02, 22), "82022200207", DrivingLicenseType.BE) { Address = new("Kortijksesteenstreet", 126, "Brugge", 8000) },
            new Person("Bail", "Organa", new(1992, 03, 12), "92031200140", DrivingLicenseType.BE) { Address = new("Kortijksesteenstreet", 110, "Brugge", 8000) },
            new Person("Queen Breha", "Organa", new(1956, 11, 11), "56111100248", DrivingLicenseType.BE) { Address = new("Kortijksesteenstreet", 11, "Brugge", 8000) },
            new Person("Avar", "Kriss", new(1960, 12, 12), "60121200113", DrivingLicenseType.BE) { Address = new("Kortijksesteenstreet", 21, "Brugge", 8000) },
            new Person("Depa", "Billaba", new(1965, 06, 05), "65060548791", DrivingLicenseType.BE) { Address = new("Kortijksesteenstreet", 31, "Brugge", 8000) },
            new Person("Ezra", "Bridger", new(1966, 05, 06), "66050648676", DrivingLicenseType.BE) { Address = new("Kortijksesteenstreet", 41, "Brugge", 8000) },
            new Person("Eno", "Cordova", new(1987, 10, 02), "87100219590", DrivingLicenseType.BE) { Address = new("Kortijksesteenstreet", 15, "Brugge", 8000) },
            new Person("Cin", "Drallig", new(1986, 09, 09), "86090929345", DrivingLicenseType.BE) { Address = new("Brusselsestreet", 121, "Leuven", 3000) },
            new Person("Sifo-Dyas", "Skywalker", new(1984, 08, 04), "84080400150", DrivingLicenseType.BE) { Address = new("Brusselsestreet", 161, "Leuven", 3000) },
            new Person("Kanan", "Jarrus", new(1982, 09, 01), "82090100108", DrivingLicenseType.BE) { Address = new("Brusselsestreet", 181, "Leuven", 3000) },
            new Person("Caleb", "Dume", new(1983, 01, 22), "83012200122", DrivingLicenseType.BE) { Address = new("Brusselsestreet", 12, "Leuven", 3000) },
            new Person("Qui-Gon", "Jinn", new(1985, 10, 07), "85100748692", DrivingLicenseType.C) { Address = new("Brusselsestreet", 15, "Leuven", 3000) },
            new Person("Cere", "Junda", new(1987, 07, 01), "87070109901", DrivingLicenseType.C) { Address = new("Brusselsestreet", 17, "Leuven", 3000) },
            new Person("Obi-Wan", "Kenobi", new(1989, 09, 09), "89090909812", DrivingLicenseType.C) { Address = new("straat", 31, "Leuven", 3000) },
            new Person("Cal", "Kestis", new(1988, 07, 10), "88071048644", DrivingLicenseType.C) { Address = new("Pechelstreet", 37, "Mechelen", 2500) },
            new Person("Jocasta", "Nu", new(1999, 05, 07), "99050709959", DrivingLicenseType.C) { Address = new("Pechelstreet", 36, "Mechelen", 2500) },
            new Person("Rey", "Ridley", new(1977, 10, 01), "77100109807", DrivingLicenseType.C) { Address = new("Pechelstreet", 11, "Mechelen", 2500) },
            new Person("Mace", "Windu", new(1966, 09, 22), "66092200211", DrivingLicenseType.C) { Address = new("Pechelstreet", 15, "Mechelen", 2500) },
            new Person("Darth", "Bane", new(1955, 01, 07), "55010700178", DrivingLicenseType.C) { Address = new("Pechelstreet", 17, "Mechelen", 2500) },
            new Person("Count", "Dooku", new(1955, 07, 01), "55070100109", DrivingLicenseType.C) { Address = new("Pechelstreet", 1, "Mechelen", 2500) },
            new Person("Taron", "Malicos", new(1965, 09, 01), "65090100139", DrivingLicenseType.C) { Address = new("Pechelstreet", 8, "Mechelen", 2500) },
            new Person("Ren", "Stater", new(1967, 10, 10), "67101000112", DrivingLicenseType.C) { Address = new("Staterstreet", 1, "Brussel", 1000) },
            new Person("Trilla", "Suduri", new(1968, 05, 02), "68050200243", DrivingLicenseType.C) { Address = new("Staterstreet", 5, "Brussel", 1000) },
            new Person("Reva", "Suduri", new(1969, 01, 09), "69010909920", DrivingLicenseType.C) { Address = new("Staterstreet", 11, "Brussel", 1000) },
            new Person("Faro", "Argyus", new(1972, 07, 01), "72070100175", DrivingLicenseType.C1) { Address = new("Staterstreet", 15, "Brussel", 1000) },
            new Person("Lux", "Bonteri", new(1974, 01, 07), "74010709889", DrivingLicenseType.C1) { Address = new("Staterstreet", 17, "Brussel", 1000) },
            new Person("Captain", "Colton", new(1976, 08, 01), "76080100169", DrivingLicenseType.C1) { Address = new("Staterstreet", 18, "Brussel", 1000) },
            new Person("Tan", "Divo", new(1949, 05, 22), "49052200115", DrivingLicenseType.C1) { Address = new("Staterstreet", 21, "Brussel", 1000) },
            new Person("Silman", "Divo", new(1948, 10, 01), "48100100177", DrivingLicenseType.C1) { Address = new("Staterstreet", 31, "Brussel", 1000) },
            new Person("Finis", "Valorum", new(1947, 01, 04), "47010400197", DrivingLicenseType.C1) { Address = new("Staterstreet", 35, "Brussel", 1000) },
            new Person("Mina", "Bonteri", new(1946, 02, 11), "46021109966", DrivingLicenseType.C1) { Address = new("Staterstreet", 37, "Brussel", 1000) },
            new Person("Rush", "Clovis", new(1945, 07, 01), "45070100190", DrivingLicenseType.C1) { Address = new("Staterstreet", 51, "Brussel", 1000) },
            new Person("Raymus", "Antilles", new(1940, 05, 01), "40050100168", DrivingLicenseType.C1) { Address = new("Florbertusstreet", 1, "Gent", 9000) },
            new Person("Lando", "Calrissian", new(1951, 08, 10), "51081000150", DrivingLicenseType.C1) { Address = new("Florbertusstreet", 3, "Gent", 9000) },
            new Person("Bren", "Derlin", new(1952, 09, 01), "52090109857", DrivingLicenseType.C1) { Address = new("Florbertusstreet", 5, "Gent", 9000) },
            new Person("Jan", "Dodonna", new(1953, 01, 07), "53010700136", DrivingLicenseType.C1) { Address = new("Florbertusstreet", 7, "Gent", 9000) },
            new Person("Agenta", "Kallus", new(1954, 01, 01), "54010100242", DrivingLicenseType.C1) { Address = new("Florbertusstreet", 9, "Gent", 9000) },
            new Person("Crix", "Madine", new(1955, 11, 10), "55111000158", DrivingLicenseType.C1) { Address = new("Florbertusstreet", 11, "Gent", 9000) },
            new Person("Phari", "McQuarrie", new(1956, 01, 01), "56010100284", DrivingLicenseType.C1) { Address = new("Florbertusstreet", 13, "Gent", 9000) },
            new Person("Mon", "Mothma", new(1957, 05, 22), "57052200186", DrivingLicenseType.C1) { Address = new("Florbertusstreet", 15, "Gent", 9000) },
            new Person("Eneb", "Rey", new(1958, 01, 01), "58010100229", DrivingLicenseType.C1) { Address = new("Florbertusstreet", 17, "Gent", 9000) },
            new Person("Carlist", "Rieekan", new(1959, 10, 09), "59100909868", DrivingLicenseType.C1) { Address = new("Florbertusstreet", 19, "Gent", 9000) },
            new Person("Jun", "Sato", new(1960, 04, 03), "60040300232", DrivingLicenseType.C1) { Address = new("Rue du pond", 71, "Brugge", 8000) },
            new Person("Zev", "Senesca", new(1960, 07, 01), "60070100117", DrivingLicenseType.CE) { Address = new("Rue du pond", 61, "Brugge", 8000) },
            new Person("Berch", "Teller", new(1961, 05, 01), "61050100124", DrivingLicenseType.CE) { Address = new("Rue du pond", 51, "Brugge", 8000) },
            new Person("Willard", "Vanden", new(1962, 01, 11), "62011109808", DrivingLicenseType.CE) { Address = new("Rue du pond", 41, "Brugge", 8000) },
            new Person("Wedge", "Antilles", new(1963, 09, 27), "63092700289", DrivingLicenseType.CE) { Address = new("Rue du pond", 31, "Brugge", 8000) },
            new Person("Arvel", "Crynyd", new(1964, 01, 28), "64012800125", DrivingLicenseType.CE) { Address = new("Rue du pond", 21, "Brugge", 8000) },
            new Person("Biggs", "Darklighter", new(1965, 11, 10), "65111000174", DrivingLicenseType.CE) { Address = new("Rue du pond", 11, "Brugge", 8000) },
            new Person("Garven", "Dreis", new(1966, 04, 23), "66042300144", DrivingLicenseType.CE) { Address = new("Louvainsstreet", 9, "Leuven", 3000) },
            new Person("Wes", "Janson", new(1967, 09, 01), "67090100181", DrivingLicenseType.CE) { Address = new("Louvainsstreet", 8, "Leuven", 3000) },
            new Person("Derek", "Klivian", new(1968, 01, 22), "68012200195", DrivingLicenseType.CE) { Address = new("Louvainsstreet", 7, "Leuven", 3000) },
            new Person("Thane", "Kyrell", new(1969, 05, 01), "69050100195", DrivingLicenseType.CE) { Address = new("Louvainsstreet", 6, "Leuven", 3000) },
            new Person("Jek", "Porkins", new(1970, 01, 07), "70010709805", DrivingLicenseType.CE) { Address = new("Louvainsstreet", 5, "Leuven", 3000) },
            new Person("Dark", "Ratter", new(1971, 11, 09), "71110909836", DrivingLicenseType.CE) { Address = new("Louvainsstreet", 4, "Leuven", 3000) },
            new Person("Evaan", "Verlaine", new(1972, 10, 29), "72102929232", DrivingLicenseType.CE) { Address = new("Louvainsstreet", 3, "Leuven", 3000) },
            new Person("Idryssa", "Barruck", new(1973, 08, 11), "73081129393", DrivingLicenseType.CE) { Address = new("Louvainsstreet", 2, "Leuven", 3000) },
            new Person("Maia", "Bonteri", new(1974, 04, 25), "74042500254", DrivingLicenseType.CE) { Address = new("Louvainsstreet", 1, "Leuven", 3000) },
            new Person("Cassian", "Andor", new(1975, 07, 01), "75070100240", DrivingLicenseType.D) { Address = new("Jedistreet", 11, "Mechelen", 2500) },
            new Person("Bodhi", "Rook", new(1976, 10, 10), "76101009807", DrivingLicenseType.D) { Address = new("Jedistreet", 22, "Mechelen", 2500) },
            new Person("Chirrut", "Imwe", new(1977, 11, 08), "77110819595", DrivingLicenseType.D) { Address = new("Jedistreet", 33, "Mechelen", 2500) },
            new Person("Baze", "Malbus", new(1978, 01, 01), "78010129262", DrivingLicenseType.D) { Address = new("Jedistreet", 44, "Mechelen", 2500) },
            new Person("Galen", "Erso", new(1979, 05, 10), "79051038935", DrivingLicenseType.D) { Address = new("Jedistreet", 55, "Mechelen", 2500) },
            new Person("Lyra", "Erso", new(1980, 10, 08), "80100839053", DrivingLicenseType.D) { Address = new("Jedistreet", 66, "Mechelen", 2500) },
            new Person("Jyn", "Erso", new(1981, 01, 01), "81010109927", DrivingLicenseType.D) { Address = new("Jedistreet", 77, "Mechelen", 2500) },
            new Person("Saw", "Gerrera", new(1982, 11, 04), "82110419529", DrivingLicenseType.D) { Address = new("Koekkoekstreet", 1, "Melle", 9090) },
            new Person("Steela", "Gerrera", new(1983, 10, 22), "83102200284", DrivingLicenseType.D) { Address = new("Koekkoekstreet", 97, "Melle", 9090) },
            new Person("Sim", "Aloo", new(1984, 01, 01), "84010100290", DrivingLicenseType.D) { Address = new("Koekkoekstreet", 3, "Melle", 9090) },
            new Person("Moradmin", "Bast", new(1985, 07, 10), "85071000178", DrivingLicenseType.D) { Address = new("Koekkoekstreet", 95, "Melle", 9090) },
            new Person("Alecia", "Beck", new(1986, 08, 01), "86080100284", DrivingLicenseType.D) { Address = new("Koekkoekstreet", 7, "Melle", 9090) },
            new Person("Morgan", "Elsbeth", new(1987, 10, 01), "87100100123", DrivingLicenseType.D) { Address = new("Koekkoekstreet", 91, "Melle", 9090) },
            new Person("Karyn", "Faro", new(1988, 01, 01), "88010100178", DrivingLicenseType.D) { Address = new("Koekkoekstreet", 11, "Melle", 9090) },
            new Person("Janus", "Greejatus", new(1989, 01, 08), "89010800183", DrivingLicenseType.D) { Address = new("Koekkoekstreet", 87, "Melle", 9090) },
            new Person("Valin", "Hess", new(1991, 04, 11), "91041100156", DrivingLicenseType.D) { Address = new("Koekkoekstreet", 77, "Melle", 9090) },
            new Person("Tiaan", "Jerjerrod", new(1992, 08, 01), "92080100117", DrivingLicenseType.D) { Address = new("Koekkoekstreet", 55, "Melle", 9090) },
            new Person("Kassius", "Konstantine", new(1993, 07, 10), "93071000152", DrivingLicenseType.D1E) { Address = new("'T Zand", 1, "Kortrijk", 8500) },
            new Person("Orson", "Krennic", new(1994, 05, 01), "94050100138", DrivingLicenseType.D1E) { Address = new("'T Zand", 3, "Kortrijk", 8500) },
            new Person("Xamuel", "Lennox", new(1995, 01, 22), "95012200180", DrivingLicenseType.D1E) { Address = new("'T Zand", 5, "Kortrijk", 8500) },
            new Person("Delian", "Mors", new(1996, 01, 01), "96010100152", DrivingLicenseType.D1E) { Address = new("'T Zand", 7, "Kortrijk", 8500) },
            new Person("Conan", "Motti", new(1997, 10, 01), "97100100139", DrivingLicenseType.D1E) { Address = new("'T Zand", 9, "Kortrijk", 8500) },
            new Person("Lorth", "Needa", new(1998, 09, 01), "98090100153", DrivingLicenseType.D1E) { Address = new("'T Zand", 11, "Kortrijk", 8500) },
            new Person("Kendal", "Ozzel", new(1999, 08, 11), "99081100158", DrivingLicenseType.D1E) { Address = new("'T Zand", 13, "Kortrijk", 8500) },
            new Person("Firmus", "Piet", new(2000, 04, 01), "00040100126", DrivingLicenseType.NONE) { Address = new("'T Zand", 15, "Kortrijk", 8500) },
            new Person("Nahdonnis", "Praji", new(1999, 08, 10), "99081000188", DrivingLicenseType.DE) { Address = new("'T Zand", 17, "Kortrijk", 8500) },
            new Person("Terrinald", "Screed", new(1998, 05, 01), "98050100125", DrivingLicenseType.DE) { Address = new("'T Zand", 19, "Kortrijk", 8500) },
            new Person("Rae", "Sloane", new(1997, 10, 04), "97100400245", DrivingLicenseType.DE) { Address = new("'T Zand", 21, "Kortrijk", 8500) },
            new Person("Lucka", "Solange", new(1996, 07, 04), "96070400203", DrivingLicenseType.DE) { Address = new("'T Zand", 23, "Kortrijk", 8500) },
            new Person("Wilhuff", "Tarkin", new(1995, 09, 01), "95090100187", DrivingLicenseType.DE) { Address = new("'T Zand", 25, "Kortrijk", 8500) },
            new Person("Eli", "Vanto", new(1994, 04, 07), "94040700145", DrivingLicenseType.DE) { Address = new("'T Zand", 27, "Kortrijk", 8500) },
            new Person("Maximilian", "Veers", new(1993, 05, 22), "93052200166", DrivingLicenseType.DE) { Address = new("'T Zand", 29, "Kortrijk", 8500) },
            new Person("Wullif", "Yularen", new(1992, 08, 10), "92081000138", DrivingLicenseType.DE) { Address = new("'T Zand", 31, "Kortrijk", 8500) },
            new Person("Tulon", "Voidgazer", new(1990, 01, 08), "90010800107", DrivingLicenseType.DE) { Address = new("'T Zand", 33, "Kortrijk", 8500) },
            new Person("Poe", "Dameron", new(1990, 11, 01), "90110100193", DrivingLicenseType.DE) { Address = new("'T Zand", 35, "Kortrijk", 8500) },
            new Person("Caluan", "Ematt", new(1990, 10, 11), "90101100177", DrivingLicenseType.DE) { Address = new("'T Zand", 37, "Kortrijk", 8500) }
        };
        public static void SeedData(Contexts.Context context)
        {
            context.Database.EnsureCreated();

            foreach(var p in _persons)
            {
                var result = context.Persons.Where(b => b.NationalRegistrationNumber == p.NationalRegistrationNumber).FirstOrDefault();
                if(result == null)
                {
                    context.Persons.Add(p);
                }

            }

            context.SaveChanges();
        }
    }
}
