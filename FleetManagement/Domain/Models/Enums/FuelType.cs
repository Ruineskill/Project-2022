

namespace Domain.Models.Enums
{
    [Flags]
    public enum FuelType : int
    {
        Benzine,
        Diesel,
        Hydrogen,
        HybridBenzine,
        HybridDiesel,
        Electric,
        LiquidPetrolGas,
    }
} 