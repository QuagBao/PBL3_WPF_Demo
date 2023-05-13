using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Demo1.DTO;
using Demo1.Model;


namespace Demo1.ViewModel
{
    public class SearchParcelModel : BaseViewModel
    {
        private string searchText;
        
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
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged();
                }
            }
        }

        
        

        public ICommand SearchCommand { get; set; }

        public SearchParcelModel()
        {

            SearchCommand = new RelayCommand<object>((p) => { return true; },
                (p) => { Search(SearchText); });
/*            SearchCommand = new RelayCommand<object>((p) => { return !string.IsNullOrEmpty(SearchText); },
    (p) => { Search(SearchText); });*/
        }

        void Search(string _parcelID)
        { 
            using (var context = new PBL3_demoEntities())
            {
            int num_parcelID = int.Parse(_parcelID);
                var parcel = context.Parcels.FirstOrDefault(x => x.parcelID == num_parcelID);
                    if (parcel != null)
                    {

                        ParcelName = parcel.parcelName;
                        ParcelType = ((bool)parcel.type) ? "Hàng dễ vỡ" : "Hàng bình thường";
                        ParcelValue = parcel.parcelValue.ToString();
                           
                    }
                    else
                    {
                        MessageBox.Show("Đơn hàng không tồn tại trong hệ thống! Xin vui lòng thử lại");
                    }
            }
                  
        }
    }
        
}
