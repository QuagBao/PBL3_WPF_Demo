using Demo1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Demo1.ViewModel
{
    public class AddFunctionModel:BaseViewModel
    {
        public ICommand AddRCCommand { get; set; }
        public ICommand ShowAnotherControl { get; set; }
        private UserControl _currentControl;
        public UserControl CurrentControl
        {
            get { return _currentControl; }
            set
            {
                _currentControl = value;
                OnPropertyChanged("CurrentControl");
            }
        }
        int isValid = 0;
        //SCustomer
        private string _SCustomerName;
        private string _SCustomerID;
        private string _SCustomerAddress;
        private string _SCustomerPhoneNumber;
        private string _SCustomerDistrict;
        private string _SCustomerCity;
        //RCustomer
        private string _RCustomerName;
        private string _RCustomerID;
        private string _RCustomerAddress;
        private string _RCustomerPhoneNumber;
        private string _RCustomerDistrict;
        private string _RCustomerCity;
        //Parcel
        private string _ParcelName;
        private double _ParcelValue;
        private double _ParcelMass;
        private string _ParcelSize;
        private string _ParcelType;
        public string SCustomerName
        {
            get
            {
                return _SCustomerName;
            }
            set
            {
                _SCustomerName = value;
                OnPropertyChanged();
            }
        }
        public string SCustomerID
        {
            get
            {
                return _SCustomerID;
            }
            set
            {
                _SCustomerID = value;
                OnPropertyChanged();
            }
        }
        public string SCustomerAddress
        {
            get
            {
                return _SCustomerAddress;
            }
            set
            {
                _SCustomerAddress = value;
                OnPropertyChanged();
            }
        }
        public string SCustomerPhoneNumber
        {
            get
            {
                return _SCustomerPhoneNumber;
            }
            set
            {
                _SCustomerPhoneNumber = value;
                OnPropertyChanged();
            }
        }
        public string SCustomerDistrict
        {
            get
            {
                return _SCustomerDistrict;
            }
            set
            {
                _SCustomerDistrict = value;
                OnPropertyChanged();
            }
        }
        public string SCustomerCity
        {
            get
            {
                return _SCustomerCity;
            }
            set
            {
                _SCustomerCity = value;
                OnPropertyChanged();
            }
        }
        //
        public string RCustomerName
        {
            get
            {
                return _RCustomerName;
            }
            set
            {
                _RCustomerName = value;
                OnPropertyChanged();
            }
        }
        public string RCustomerID
        {
            get
            {
                return _RCustomerID;
            }
            set
            {
                _RCustomerID = value;
                OnPropertyChanged();
            }
        }
        public string RCustomerAddress
        {
            get
            {
                return _RCustomerAddress;
            }
            set
            {
                _RCustomerAddress = value;
                OnPropertyChanged();
            }
        }
        public string RCustomerPhoneNumber
        {
            get
            {
                return _RCustomerPhoneNumber;
            }
            set
            {
                _RCustomerPhoneNumber = value;
                OnPropertyChanged();
            }
        }
        public string RCustomerDistrict
        {
            get
            {
                return _RCustomerDistrict;
            }
            set
            {
                _RCustomerDistrict = value;
                OnPropertyChanged();
            }
        }
        public string RCustomerCity
        {
            get
            {
                return _RCustomerCity;
            }
            set
            {
                _RCustomerCity = value;
                OnPropertyChanged();
            }
        }
        public string ParcelName
        {
            get
            {
                return _ParcelName;
            }
            set
            {
                _ParcelName = value;
                OnPropertyChanged();
            }
        }
        public double ParcelValue
        {
            get
            {
                return _ParcelValue;
            }
            set
            {
                _ParcelValue = value;
                OnPropertyChanged();
            }
        }
        public string ParcelSize 
        {
            get
            {
                return _ParcelSize;
            }
            set
            {
                _ParcelSize = value;
                OnPropertyChanged();
            }
        }
        public string ParcelType
        {
            get
            {
                return _ParcelType;
            }
            set
            {
                _ParcelType = value;
                OnPropertyChanged();
            }
        }
       
        public double ParcelMass
        {
            get
            {
                return _ParcelMass;
            }
            set
            {
                 _ParcelMass = value;
                OnPropertyChanged();
            }
        }

        public AddFunctionModel()
        {
            //AddRCCommand = new RelayCommand<object>((p) =>
            //{
            //    using (var context = new Model.PBL3_demoEntities())
            //    {

            //        var customerIDCheck = context.Customers.Where(x => x.customerID == CustomerID);
            //        if (customerIDCheck == null || customerIDCheck.Count() != 0)
            //        {
            //            isValid = 0;
            //        }
            //        else isValid = 1;
            //    }

            //    if (string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(CustomerID) || string.IsNullOrEmpty(CustomerAddress) || string.IsNullOrEmpty(CustomerPhoneNumber) || string.IsNullOrEmpty(CustomerDistrict) || string.IsNullOrEmpty(CustomerCity))
            //        isValid = 0;
            //    if (isValid == 0) return false;
            //    else return true;


            //}, (p) =>
            //{
            //    using (var context = new Model.PBL3_demoEntities())
            //    {

            //        var newCustomer = new Customer { customerID = CustomerID, customerLocation = CustomerAddress + "," + CustomerDistrict + "," + CustomerCity, customerPhoneNumber = CustomerPhoneNumber, customerName = CustomerName };
            //        context.Customers.Add(newCustomer);
            //        context.SaveChanges();
            //    }

            //});

        }
            }
}
