using Presentation.DTO;
using Presentation.Interfaces;
using Presentation.ViewModels;
using Presentation.ViewModels.Bases;

namespace Presentation.Mediators
{
    public class FleetMediator:IFleetMediator
    {

        private readonly PersonMediator _person;
        private readonly CarMediator _car;
        private readonly FuelCardMediator _fuelCard;


        public FleetMediator(PersonMediator person, CarMediator car, FuelCardMediator fuelCard)
        {
            _person = person;
            _car = car;
            _fuelCard = fuelCard;
        }

        public void Create(ViewModelBase obj)
        {
            switch(obj)
            {
                case CarViewModel car:
                    _car.Create(car);
                    break;
                case FuelCardViewModel fuelCard:
                    _fuelCard.Create(fuelCard);
                    break;
                case PersonViewModel person:
                    _person.Create(person);
                    break;
            }
        }

        public void Delete(ViewModelBase obj)
        {
            switch(obj)
            {
                case CarViewModel car:
                    _car.Delete(car);
                    break;
                case FuelCardViewModel fuelCard:
                    _fuelCard.Delete(fuelCard);
                    break;
                case PersonViewModel person:
                    _person.Delete(person);
                    break;
            }
        }

        public void Update(ViewModelBase obj)
        {
            switch(obj)
            {
                case CarViewModel car:
                    _car.Update(car);
                    break;
                case FuelCardViewModel fuelCard:
                    _fuelCard.Update(fuelCard);
                    break;
                case PersonViewModel person:
                    _person.Update(person);
                    break;
            }
        }
    }
}
