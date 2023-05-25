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
using Demo1.View;
using MaterialDesignThemes.Wpf;

namespace Demo1.ViewModel
{
    public class SearchParcelModel : BaseViewModel
    {
        private string searchText;
        
        private string parcelName;
        private string parcelType;
        private string parcelValue;
        private string senderCustomerInfo;
        private string receiverCustomerInfo;

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

        public string SenderCustomerInfo
        {
            get { return senderCustomerInfo; }
            set
            {
                if (senderCustomerInfo != value)
                {
                    senderCustomerInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ReceiverCustomerInfo
        {
            get { return receiverCustomerInfo; }
            set
            {
                if (receiverCustomerInfo != value)
                {
                    receiverCustomerInfo = value;
                    OnPropertyChanged();
                }
            }
        }




        public ICommand SearchCommand { get; set; }
        public ICommand ParcelNameClickCommand { get; set; }

        public ICommand SenderCustomerCommand { get; set; }

        public ICommand ReceiverCustomerCommand { get; set; }
        public SearchParcelModel()
        {

            SearchCommand = new RelayCommand<object>((p) => { return true; },
                (p) => { Search(SearchText); });
            /*            SearchCommand = new RelayCommand<object>((p) => { return !string.IsNullOrEmpty(SearchText); },
                (p) => { Search(SearchText); });*/

            ParcelNameClickCommand = new RelayCommand<object>((p) => { return true; },
    (p) => { OpenResultOfSerchWindow(SearchText); });
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

        // Xử lý sự kiện click chuột vào TextBlock ParcelName
        void OpenResultOfSerchWindow(string _parcelID)
        {
            ResultOfSearch ros = new ResultOfSearch(_parcelID);
            ros.ShowDialog();
           
        }


        string GetSenderCustomerInfo (string _parcelID)
        {
            using (var context = new PBL3_demoEntities())
            {
                int num_parcelID = int.Parse(_parcelID);
                var parcelRCustomerID = context.Parcels.Where(x => x.parcelID == num_parcelID).Select(x=> x.RCustomerID).FirstOrDefault();
                if (parcelRCustomerID != null)
                {
                    var RCustomer = context.Customers.Where(x => x.customerID == parcelRCustomerID).FirstOrDefault();
                    string RCustomerInfo = RCustomer.customerName +"\n" + RCustomer.customerLocation+"\n"+ RCustomer.customerPhoneNumber;
                }
                else
                {
                    MessageBox.Show("Đơn hàng không tồn tại trong hệ thống! Xin vui lòng thử lại");
                }
            }
            return "a";
        }

    }
        
}
