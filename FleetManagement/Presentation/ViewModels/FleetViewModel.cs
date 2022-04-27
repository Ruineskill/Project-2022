using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class FleetViewModel : ViewModelBase
    {
 
        private string _search= string.Empty;

        public string Search 
        {
            get=> _search; 
            set
            {
                _search = value;

                OnPropertyChanged(nameof(Search));
                
            }
        }
    
    }
}
