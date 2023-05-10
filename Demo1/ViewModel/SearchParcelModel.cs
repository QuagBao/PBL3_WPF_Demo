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
    public class SearchParcelModel : SearchResultDTO
    {
        private string searchText;
        private ObservableCollection<SearchResultDTO> searchResults;

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

        public ObservableCollection<SearchResultDTO> SearchResults
        {
            get { return searchResults; }
            set
            {
                if (searchResults != value)
                {
                    searchResults = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SearchCommand { get; set; }

        public SearchParcelModel()
        {
            SearchCommand = new RelayCommand<object>((p) => { return !string.IsNullOrEmpty(SearchText); },
                (p) => { Search(SearchText); });
        }


        void Search(string _parcelID)
        {
            SearchResults = new ObservableCollection<SearchResultDTO>();
            using (var context = new PBL3_demoEntities())
            {
                try
                {
                    var parcel = context.Parcels.Where(x => x.parcelID == int.Parse(_parcelID)).FirstOrDefault();
                    if (parcel != null)
                    {
                        var searchResultDTO = new SearchResultDTO
                        {
                            ParcelName = parcel.parcelName,
                            ParcelType = ((bool)parcel.type) ? "Hàng dễ vỡ" : "Hàng bình thường",
                            ParcelValue = parcel.parcelValue.ToString(),
                        };
                    }
                    else
                    {
                        MessageBox.Show("Đơn hàng không tồn tại trong hệ thống! Xin vui lòng thử lại");
                    }
                }
                catch
                {
                    MessageBox.Show("Có lỗi trong lúc nhập ID, vui lòng thử lại");
                }

            }
        }
    }
}
