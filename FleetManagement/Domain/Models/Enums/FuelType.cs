

namespace Domain.Models.Enums
{
    /// <summary>
    /// Specifies type of fuel, used as combination of flags.
    /// Used for Car's fuel type and FuelCard's refuel support
    /// </summary>
    [Flags]
    public enum FuelType : int
    {
        Benzine = 0,
        Diesel = 1,
        Hydrogen = 2,
        HybridBenzine = 3,
        HybridDiesel = 4,
        Electric = 5,
        LiquidPetrolGas = 6,
    }
}