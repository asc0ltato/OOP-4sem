using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.Add
{
    public class AddElementViewModel : INotifyPropertyChanged
    {
        public ICommand BackCommand { get; }
        public ICommand AddPlaneCommand { get; }
        public ICommand AddCrewCommand { get; }

        public AddElementViewModel()
        {
            BackCommand = new RelayCommand(Back);
            AddPlaneCommand = new RelayCommand(AddPlane);
            AddCrewCommand = new RelayCommand(AddCrew);
        }

        private void Back(object parameter)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MainWindow element = new MainWindow();
                element.Show();
                Application.Current.Windows.OfType<AddElementForm>().FirstOrDefault()?.Close();
            });
        }

        private void AddPlane(object parameter)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var mainWindow = Application.Current.Windows.OfType<AddElementForm>().FirstOrDefault();
                if (mainWindow != null)
                {
                    mainWindow.AddElementField.Children.Clear();
                    mainWindow.AddElementField.Children.Add(new PlaneElement());
                }
            });
        }

        private void AddCrew(object parameter)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var mainWindow = Application.Current.Windows.OfType<AddElementForm>().FirstOrDefault();
                if (mainWindow != null)
                {
                    mainWindow.AddElementField.Children.Clear();
                    mainWindow.AddElementField.Children.Add(new CrewElement());
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
