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
    public class SearchParcel : BaseViewModel
    {
        private string searchText;
        private ObservableCollection<string> searchResults;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }

        public ObservableCollection<string> SearchResults
        {
            get { return searchResults; }
            set
            {
                if (searchResults != value)
                {
                    searchResults = value;
                    OnPropertyChanged(nameof(SearchResults));
                }
            }
        }

        public ICommand SearchCommand { get; set; }

        public SearchParcel()
        {
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return !string.IsNullOrEmpty(SearchText);
            }, (p) =>
            {
                Search(SearchText);
            });
        }

        void Search(string value)
        {
            /*if (value == "123")
            {
                SearchResults = new ObservableCollection<string>
                {
                    "Kết quả 1",
                    "Kết quả 2",
                    "Kết quả 3"
                };
            }
            else
            {
                MessageBox.Show("Hông có kết quả bé ơi");
            }*/
            using (var context = new Model.PBL3_demoEntities())
            {
                var customerIDCheck = context.Customers.Where(x => x.customerID == value);
                if (customerIDCheck.Any())
                {
                    SearchResults = new ObservableCollection<string>
                    {
                        customerIDCheck.ToString()
                    };
                }
                else
                {
                    MessageBox.Show("Không có đơn hàng này trong hệ thống");
                }
            }
        }
    }
}
