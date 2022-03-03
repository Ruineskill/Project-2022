Console.WriteLine("Hello, Fleet Manager !");

Console.WriteLine("Give your NationRegistrationNumber:");

string nrn = Console.ReadLine();

if (Domain.Models.User.IsNationRegistrationNumber(nrn))
{
    Console.WriteLine("Is valid!");
}






Console.WriteLine("End of Management!");