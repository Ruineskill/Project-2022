#nullable disable warnings
using Domain.Exceptions;
using Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    /// <summary>
    /// Models domains FuelCard
    /// </summary>
    public class FuelCard
    {
        private int _id;
        private long _cardNumber;
        private DateOnly _expirationDate;
        private int _pinCode;
        private ICollection<FuelType> _usableFuelTypes;
        private Person? _person;
        private bool _blocked = false;

        public int Id { get => _id; private set => _id = value; }
        public long CardNumber
        {
            get => _cardNumber;
            set
            {
                if(value <= 0) throw new ArgumentOutOfRangeException(nameof(CardNumber));
                _cardNumber = value;
            }
        }
        public DateOnly ExpirationDate
        {
            get => _expirationDate;
            set => _expirationDate = IsValidExpirationDate(value) ? value : throw new InvalidFuelCardExpirationDateException();
        }
        public int PinCode
        {
            get => _pinCode;
            set
            {
                if(value <= 0) throw new ArgumentOutOfRangeException(nameof(PinCode));
                _pinCode = value;
            }
        }
        public ICollection<FuelType> UsableFuelTypes { get => _usableFuelTypes; set => _usableFuelTypes = value; }

        public Person? Person 
        { 
            get => _person; 
            set
            {
                if(value != null)
                {
                    AssignPerson(value);
                }
                else
                {
                    _person = null;
                }
            }
        }

        public bool Blocked { get => _blocked; set => _blocked = value; }
   


        public FuelCard(long cardNumber, DateOnly expirationDate, int pinCode, ICollection<FuelType> usableFuelTypes)
            : this(0, cardNumber, expirationDate, pinCode, usableFuelTypes) {}

        [JsonConstructor]
        public FuelCard(int id, long cardNumber, DateOnly expirationDate, int pinCode, ICollection<FuelType> usableFuelTypes)
        {
            _id = id;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            PinCode = pinCode;
            UsableFuelTypes = usableFuelTypes;
        }

        public static bool CanFuelCardRefuel(FuelCard fuelCard,Car? car)
        {
            if(car != null)
            {
                if(!fuelCard.UsableFuelTypes.Contains(car.FuelType))
                {
                    return false;
                }
            }

            return true;
        }


        private void AssignPerson(Person person)
        {
            if(_person != null) throw new InvalidFuelCardException("This fuel card already belongs to someone else!");
            if(person.FuelCard != this) person.FuelCard = this;
            _person = person;
        }

        public static bool IsValidExpirationDate(DateOnly expirationDate)
        {
            var localDate = expirationDate.ToDateTime(TimeOnly.MinValue);

            return DateTime.Now.Date < localDate.Date;
        }
    }
}
