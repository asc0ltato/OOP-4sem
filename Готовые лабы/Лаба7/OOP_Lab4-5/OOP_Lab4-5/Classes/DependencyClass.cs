using System.ComponentModel;
using System.Windows;

namespace OOP_Lab4_5.Classes
{
    public class DependencyClass : DependencyObject
    {
        public static readonly DependencyProperty TitleProperty;
        public static readonly DependencyProperty NumberProperty;

        static DependencyClass()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(DependencyClass));
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            NumberProperty = DependencyProperty.Register("Number", typeof(int?), typeof(DependencyClass), metadata,
                new ValidateValueCallback(ValidateValue));
        }

        private static bool ValidateValue(object value)
        {
            int? currentValue = (int?)value;
            return currentValue >= 0 || currentValue == null;
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            int? currentValue = (int?)baseValue;
            return currentValue > 10 ? 10 : currentValue;
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public int? Number
        {
            get { return (int?)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
    }
}