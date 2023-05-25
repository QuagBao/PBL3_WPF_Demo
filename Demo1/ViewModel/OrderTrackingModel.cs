using Demo1.Model;
using Demo1.UserInfo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace Demo1.ViewModel
{
    public class OrderTrackingModel : BaseViewModel
    {
        private string _ParcelID;
        public string ParcelID
        {
            get { return _ParcelID; }
            set
            {
                _ParcelID = value;
                OnPropertyChanged();
                ValidateParcelID();
            }
        }
        /*       private List<string> _routeInfoList;
               public List <string> RouteInfoList
               {
                   get { return _routeInfoList; }
                   set
                   {
                       _routeInfoList = value;
                       OnPropertyChanged(nameof(RouteInfoList));
                   }
               }*/



        private ObservableCollection<string> _routeInfoList;
        public ObservableCollection<string> RouteInfoList
        {
            get { return _routeInfoList; }
            set
            {
                _routeInfoList = value;
                OnPropertyChanged();
            }
        }


        public ICommand ParcelTrackingCommand { get; set; }
        public OrderTrackingModel()
        {
            ParcelTrackingCommand =
               new RelayCommand<object>((p) =>
               {
                   return true;
               }, (p) => GetParcelRoute());


        }





        void ValidateParcelID()
        {
            int parcelID;
            if (int.TryParse(ParcelID, out parcelID))
            {
                // Chuỗi chứa số nguyên hợp lệ
                using (var context = new PBL3_demoEntities())
                {
                    var thisParcel = context.Parcels.Where(x => x.parcelID == parcelID).FirstOrDefault();
                    if (thisParcel == null)
                    {
                        MessageBox.Show("Đơn này không tồn tại trong hệ thống");
                    }
                }
            }
            else
            {
                // Chuỗi không chứa số nguyên hợp lệ
                MessageBox.Show("Mã đơn hàng vừa nhập không hợp lệ");
            }
        }



        void GetParcelRoute()
        {
            int iParcelID;
            RouteInfoList = new ObservableCollection<string>();
            if (int.TryParse(ParcelID, out iParcelID))
            {
                // Chuỗi chứa số nguyên hợp lệ
                using (var context = new PBL3_demoEntities())
                {
                    var parcelRoute = context.Routes.Where(x => x.parcelID == iParcelID).OrderBy(s => s.routeID);
                    if (parcelRoute.Any())
                    {
                        foreach (var route in parcelRoute)
                        {
                            string tempRoute = route.details + " vào lúc " + route.time.ToString("dd/MM/yyyy HH:mm:ss") +
                                               "\n";
                            RouteInfoList.Add(tempRoute);
                        }

                        var checkWarehouseNull = context.Parcels.Where(x => x.parcelID == iParcelID)
                            .Select(x => x.currentWarehouseID).FirstOrDefault() == null;
                        // if you after Delivery your Parcel Success , 
                        if (checkWarehouseNull)
                        {
                            RouteInfoList.Add("Đang vận chuyển " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n");
                        }
                    }
                    else
                    {
                        RouteInfoList.Add("Đơn hàng này chưa có lộ trình");
                    }
                }
            }
            else
            {
                MessageBox.Show("Mã đơn hàng vừa nhập không hợp lệ");
            }

        }
    }
}
