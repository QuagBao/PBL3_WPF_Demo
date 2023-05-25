using Demo1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo1.UserInfo
{
    public class ParcelInfo
    {
        private static ParcelInfo instance;

        private ParcelInfo() { }
        public static ParcelInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ParcelInfo();
                }
                return instance;
            }
        }
        public Parcel GetParcelRecord(int parcelID)
        {
            using (var context = new PBL3_demoEntities())
            {
                var thisParcel = context.Parcels.Where(x => x.parcelID == parcelID).FirstOrDefault();
                if (thisParcel != null)
                {
                    return thisParcel;
                }
                return null;

            }
        }
        public bool IsParcelExist(int parcelID)
        {
            using (var context = new PBL3_demoEntities())
            {
                var thisParcel = context.Parcels.Where(x => x.parcelID == parcelID).FirstOrDefault();
                if (thisParcel != null)
                {
                    return true;
                }
                return false;

            }
        }
        public string GetParcelName(int parcelID)
        {
            Parcel thisParcel = GetParcelRecord(parcelID);
            if (thisParcel != null) return thisParcel.parcelName;
            return "";
        }
        public double GetParcelMass(int parcelID)
        {

            Parcel thisParcel = GetParcelRecord(parcelID);
            if (thisParcel != null) return thisParcel.parcelMass;
            return -1;
        }
        public string GetParcelCurrentWH(int parcelID)
        {
            Parcel thisParcel = GetParcelRecord(parcelID);
            if (thisParcel != null) return thisParcel.currentWarehouseID;
            return "";
        }
        public double GetParcelValue(int parcelID)
        {
            Parcel thisParcel = GetParcelRecord(parcelID);
            if (thisParcel != null) return (double)thisParcel.parcelValue;
            return -1;
        }
        public string GetSCustomerID(int parcelID)
        {
            Parcel thisParcel = GetParcelRecord(parcelID);
            if (thisParcel != null) return thisParcel.SCustomerID;
            return "";
        }
        public string GetRCustomerID(int parcelID)
        {
            Parcel thisParcel = GetParcelRecord(parcelID);
            if (thisParcel != null) return thisParcel.RCustomerID;
            return "";
        }
        public string GetSCustomerCity(int iParcelID)
        {
            using (var context = new PBL3_demoEntities())
            {
                var result = context.Customers
                    .Join(context.Parcels,
                        customer => customer.customerID,
                        parcel => parcel.SCustomerID,
                        (customer, parcel) => new { Customer = customer, Parcel = parcel })
                    .Where(joinResult => joinResult.Parcel.SCustomerID == joinResult.Customer.customerID && joinResult.Parcel.parcelID == iParcelID)
                    .Select(joinResult => new
                    {
                        SCustomerLocation = joinResult.Customer.customerLocation,

                    })
                    .FirstOrDefault(); // hoặc SingleOrDefault()

                if (result != null)
                {
                    string scustomerlocation = result.SCustomerLocation;
                    string[] scustomercity = scustomerlocation.Split(',');
                    string res = scustomercity.LastOrDefault()?.Trim();
                    return res;
                }
                return "";

            }
        }
        public string GetRCustomerCity(int iParcelID)
        {

            using (var context = new PBL3_demoEntities())
            {
                var result = context.Customers
                    .Join(context.Parcels,
                        customer => customer.customerID,
                        parcel => parcel.RCustomerID,
                        (customer, parcel) => new { Customer = customer, Parcel = parcel })
                    .Where(joinResult => joinResult.Parcel.RCustomerID == joinResult.Customer.customerID && joinResult.Parcel.parcelID == iParcelID)
                    .Select(joinResult => new
                    {
                        RCustomerLocation = joinResult.Customer.customerLocation,

                    })
                    .FirstOrDefault(); // hoặc SingleOrDefault()

                if (result != null)
                {
                    string rcustomerlocation = result.RCustomerLocation;
                    string[] rcustomercity = rcustomerlocation.Split(',');

                    return rcustomercity.LastOrDefault()?.Trim();
                }
                return "";

            }
        }


    }
}