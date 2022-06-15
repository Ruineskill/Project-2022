#nullable disable warnings
using Domain.Models.Enums;
using MaterialDesignThemes.Wpf;
using Presentation.Enums;
using Presentation.Validation;
using Presentation.ViewModels;
using Presentation.ViewModels.Bases;
using Presentation.ViewModels.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for DetailDialog.xaml
    /// </summary>
    public partial class DetailDialog : UserControl
    {
        private DetailDialogResult _result;

        private DetailDialogViewModel _context { get; }
        private DialogSession? _session { get; set; }
        private ValidatedViewModelBase? _originalContent;

        public DetailDialog()
        {
            InitializeComponent();
            _context = App.GetService<DetailDialogViewModel>();
            DataContext = _context;
            _context.ErrorChanged += ErrorCountChanged;


        }

        public ViewModelBase GetContent()
        {
            return _originalContent;
        }

        public void SetContent(ValidatedViewModelBase item, ValidatorBase? validator)
        {
            _context.Validator = validator;
            SetContent(item);
            if(HasErrors())
            {
                SaveButton.IsEnabled = false;
            }
        }


        public void SetContent(ValidatedViewModelBase item)
        {
            _originalContent = item;
            _context.Content = CreateShallowCopy(item);
        }

        public void Close()
        {
            if(_session != null)
            {
                _session.Close();
                _session = null;
            }
        }

        public async Task<DetailDialogResult> Show(DialogHosting parentName)
        {
            await DialogHost.Show(this, parentName.ToString(), new DialogOpenedEventHandler((sender, args) =>
            {
                _session = args.Session;
            }));

            return _result;
        }

        public bool HasErrors()
        {
            return _context.ErrorCount != 0;
        }

        private void Detail_Error()
        {
            if(HasErrors() && SaveButton.IsEnabled)
            {
                SaveButton.IsEnabled = false;
            }
            else
            {
                if(!SaveButton.IsEnabled) SaveButton.IsEnabled = true;
            }
        }

        private void CancelButtonHandler(object sender, RoutedEventArgs e)
        {
            _result = DetailDialogResult.Cancel;
            Close();
        }

        private void SaveButtonHandler(object sender, RoutedEventArgs e)
        {
            if(IsSame(_originalContent, _context.Content))
            {
                _result = DetailDialogResult.Save;
                _originalContent = _context.Content;
            }
            else
            {
                _result = DetailDialogResult.Cancel;
            }
            Close();
        }

        void ErrorCountChanged(int errors)
        {
            if(errors == 0 || !SaveButton.IsEnabled)
            {
                SaveButton.IsEnabled = true;
            }
            else if(SaveButton.IsEnabled)
            {
                SaveButton.IsEnabled = false;
            }

        }



        private static ValidatedViewModelBase CreateShallowCopy(ValidatedViewModelBase item)
        {
            if(item is CarViewModel car)
            {
                return car.ShallowCopy();
            }
            else if(item is PersonViewModel person)
            {
                return person.ShallowCopy();
            }
            else
            {
                var fuelCard = (FuelCardViewModel)item;

                var copy = ((FuelCardViewModel)item).ShallowCopy();
                copy.UsableFuelTypes = new List<FuelType>(fuelCard.UsableFuelTypes);

                return copy;
            }


        }

        private static bool IsSame(ValidatedViewModelBase item1, ValidatedViewModelBase item2)
        {
            if(item1 is CarViewModel lcar && item2 is CarViewModel rcar)
            {
                return lcar.Id == rcar.Id &&
                lcar.Brand == rcar.Brand &&
                lcar.Model == rcar.Model &&
                lcar.ChassisNumber == rcar.ChassisNumber &&
                lcar.LicensePlate == rcar.LicensePlate &&
                lcar.FuelType == rcar.FuelType &&
                lcar.Type == rcar.Type &&
                lcar.Person == rcar.Person &&
                lcar.Color == rcar.Color &&
                lcar.NumberOfDoors == rcar.NumberOfDoors &&
                lcar.RequiredLicence == rcar.RequiredLicence;
            }
            else if(item1 is PersonViewModel lperson && item2 is PersonViewModel rperson)
            {
                return lperson.Id == rperson.Id &&
                       lperson.FirstName == rperson.FirstName &&
                       lperson.LastName == rperson.LastName &&
                       lperson.DateOfBirth == rperson.DateOfBirth &&
                       lperson.NationalID == rperson.NationalID &&
                       lperson.DrivingLicenseType == rperson.DrivingLicenseType &&
                       lperson.City == rperson.City &&
                       lperson.Number == rperson.Number &&
                       lperson.ZipCode == rperson.ZipCode &&
                       lperson.Street == rperson.Street &&
                       lperson.Car == rperson.Car &&
                       lperson.FuelCard == rperson.FuelCard;
            }
            else if(item1 is FuelCardViewModel lfuelCard && item2 is FuelCardViewModel rfuelCard)
            {
                return lfuelCard.Id == rfuelCard.Id &&
                   lfuelCard.CardNumber == rfuelCard.CardNumber &&
                   lfuelCard.ExpirationDate == rfuelCard.ExpirationDate &&
                   lfuelCard.PinCode == rfuelCard.PinCode &&
                   lfuelCard.UsableFuelTypes == rfuelCard.UsableFuelTypes &&
                   lfuelCard.Person == rfuelCard.Person &&
                   lfuelCard.Blocked == rfuelCard.Blocked;
            }

            return false;
        }



    }
}
