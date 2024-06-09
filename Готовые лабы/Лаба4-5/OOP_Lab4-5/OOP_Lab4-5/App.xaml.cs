using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Windows;

namespace OOP_Lab4_5
{
    public partial class App : Application
    {
        private static List<CultureInfo> m_Languages = new List<CultureInfo>();
        public static event EventHandler LanguageChanged;

        public static List<CultureInfo> SupportedLanguages
        {
            get { return m_Languages; }
        }

        public App()
        {
            m_Languages.Clear();
            m_Languages.Add(new CultureInfo("en-US"));
            m_Languages.Add(new CultureInfo("ru-RU")); 
        }

        public static CultureInfo Language
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                //Меняем язык приложения
                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                //Создаём ResourceDictionary для новой культуры
                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name)
                {
                    case "ru-RU":
                        dict.Source = new Uri(String.Format("Dictionaries/RussianDictionary.xaml", value.Name), UriKind.Relative);
                        break;
                    default:
                        dict.Source = new Uri("Dictionaries/EnglishDictionary.xaml", UriKind.Relative);
                        break;
                }

                //Находим старую ResourceDictionary и удаляем его и добавляем новую ResourceDictionary
                ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                              where d.Source != null
                                              select d).First();
                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }

                //Вызываем евент для оповещения всех окон
                LanguageChanged(Application.Current, new EventArgs());
            }
        }
    }
}