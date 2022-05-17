

namespace Domain.Models.Enums
{
    [Flags]
    public enum FuelType : int
    {
        Benzine =0,
        Diesel = 1,
        Hydrogen = 2,
        HybridBenzine = 3,
        HybridDiesel = 4,
        Electric = 5,
        LiquidPetrolGas = 6,
    }
} 