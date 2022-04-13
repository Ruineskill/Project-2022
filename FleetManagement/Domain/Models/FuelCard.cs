using Domain.Exceptions;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FuelCard
    {
        private int _id;
        private long _cardNumber;
        private DateOnly _expirationDate;
        private int _pinCode;
        private ICollection<FuelType> _usableFuelTypes;
        private Person? _person;
        private bool _blocked = false;
        private bool _delete = false;

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

        public Person? Person { get => _person; set => _person = value; }

        public bool Blocked { get => _blocked; set => _blocked = value; }
        public bool Delete { get => _delete; set => _delete = value; }

        public FuelCard(long cardNumber, DateOnly expirationDate, int pinCode, ICollection<FuelType> usableFuelTypes) :
            this(0,cardNumber, expirationDate, pinCode, usableFuelTypes, null)
        { }

        public FuelCard(long cardNumber, DateOnly expirationDate, int pinCode, ICollection<FuelType> usableFuelTypes, Person? person)
            : this(0, cardNumber, expirationDate, pinCode, usableFuelTypes, person) { }

        [JsonConstructor]
        public FuelCard(int id, long cardNumber, DateOnly expirationDate, int pinCode, ICollection<FuelType> usableFuelTypes, Person? person)
        {

            if(cardNumber <= 0) throw new ArgumentOutOfRangeException(nameof(cardNumber));
            if(!IsValidExpirationDate(expirationDate)) throw new InvalidFuelCardExpirationDateException();
            if(pinCode <= 0) throw new ArgumentOutOfRangeException(nameof(pinCode));

            _id = id;
            _cardNumber = cardNumber;
            _expirationDate = expirationDate;
            _pinCode = pinCode;
            _usableFuelTypes = usableFuelTypes;
            _person = person;
        }

        public static bool IsValidExpirationDate(DateOnly expirationDate)
        {
            var localDate = expirationDate.ToDateTime(TimeOnly.MinValue);

            return DateTime.Now.Date < localDate.Date;
        }
    }
}
