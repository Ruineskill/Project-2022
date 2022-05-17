using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using Presentation.ViewModels.Bases;
using Presentation.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation.ViewModels
{
    public class DetailDialogService : IDetailDialogService
    {
        private readonly IDetailNavigationService _detailNavigationService;
        private readonly Window _dialogOwner;
        private DetailViewModelBase? _content;
        private Window? _currentDialog;

        public DetailDialogService(IDetailNavigationService detailNavigationService, MainWindow owner)
        {
            _detailNavigationService = detailNavigationService;
            _dialogOwner = owner;

        }


        public void SetContent(DetailViewModelBase content)
        {
            _content = content;
            _currentDialog = new DetailWindow
            {
                Owner = _dialogOwner
                
            };
        }

        public void Show()
        {
            if(_content != null && _currentDialog != null)
            {
                _detailNavigationService.Navigate(_content);
                _currentDialog?.ShowDialog();
            }

        }

        public void Close()
        {
            _content?.Save();
            _currentDialog?.Close();
            _currentDialog = null;
        }
    }
}
