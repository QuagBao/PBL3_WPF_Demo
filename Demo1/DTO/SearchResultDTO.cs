using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo1.ViewModel;

namespace Demo1.DTO
{
    public class SearchResultDTO : BaseViewModel
    {
        private string parcelName;
        private string parcelType;
        private string parcelValue;


        public string ParcelName
        {
            get { return parcelName; }
            set
            {
                if (parcelName != value)
                {
                    parcelName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ParcelType
        {
            get { return parcelType; }
            set
            {
                if (parcelType != value)
                {
                    parcelType = value;
                    OnPropertyChanged();
                }
            }
        }


        public string ParcelValue
        {
            get { return parcelValue; }
            set
            {
                if (parcelValue != value)
                {
                    parcelValue = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
