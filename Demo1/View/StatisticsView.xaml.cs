using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts.Definitions.Charts;

namespace Demo1.View
{
    /// <summary>
    /// Interaction logic for StatisticsView.xaml
    /// </summary>
    public partial class StatisticsView : UserControl
    {

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public StatisticsView()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Doanh thu",
                    StrokeThickness = 3,
                    Stroke = Brushes.Blue,
                    Values = new ChartValues<double> { 4000, 6000, 5000, 2000 , 4000, 5000, 2000, 7000, 4000 , 30000, 40000, 60000 },
                    ScalesYAt = 0, // hiển thị trên trục Y chính (0-b
    
                },
                new ColumnSeries
                {
                    Title = "Tổng đơn hàng",
                    StrokeThickness = 0,
                    Stroke = Brushes.Blue,
                    Fill = Brushes.DarkSlateBlue,
                    Values = new ChartValues<double> { 5000, 2000, 7000, 4000 , 3000, 4000, 6000, 5000, 2000 , 4000, 3000, 2000 },
                    ScalesYAt = 1 // hiển thị trên trục Y thứ cấp (0-based index)
                },
            };
            Labels = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };

            DataContext = this;

        }
    }
}
