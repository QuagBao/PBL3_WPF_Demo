using System;
using System.Globalization;
using System.Windows.Data;

namespace Demo1
{
    public class DateTimeToEmptyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? dateTime = value as DateTime?;
            if (dateTime.HasValue && dateTime.Value != DateTime.MinValue)
            {
                return dateTime.Value.ToString(); // Giữ nguyên giá trị datetime nếu không phải là DateTime.MinValue
            }
            else
            {
                return string.Empty; // Trả về chuỗi rỗng nếu giá trị datetime là null hoặc DateTime.MinValue
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Không cần triển khai phương thức này trong trường hợp chỉ đọc (OneWay) binding
            throw new NotImplementedException();
        }
    }
}
