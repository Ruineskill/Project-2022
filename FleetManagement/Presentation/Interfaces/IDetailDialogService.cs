using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IDetailDialogService
    {
        void SetContent(DetailViewModelBase dtail);

        void Show();

        void Close();

    }
}
