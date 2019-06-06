using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CECS475_Lab3.Command;
using System.Windows;

namespace CECS475_Lab3.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ICommand MyCommand { get; set; }
        public ICommand MyCommand2 { get; set; }
        public ICommand MyCommand3 { get; set; }
        public ICommand MyCommand4 { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private string _number1;
        public string Number1
        {
            get { return _number1; }
            set { _number1 = value; OnPropertyChanged("Number1"); }
        }


        private string _number2;
        public string Number2
        {
            get { return _number2; }
            set { _number2 = value; OnPropertyChanged("Number2"); }
        }


        private string _result;

        public string Result
        {
            get { return _result; }
            set { _result = value; OnPropertyChanged("Result"); }
        }


        public ViewModel()
        {
            MyCommand = new RelayCommand(sum, canexecute);
            MyCommand2 = new RelayCommand(substract, canexecute);
            MyCommand3 = new RelayCommand(multiply, canexecute);
            MyCommand4 = new RelayCommand(divide, canexecute);
        }

        private bool canexecute(object parameter)
        {
            if (!string.IsNullOrEmpty(Number1) && !string.IsNullOrEmpty(Number2))
            {
                return true;
            }
            return false;

        }


        private void sum(object parameter)
        {
            Result = (Convert.ToDouble(Number1) + Convert.ToDouble(Number2)).ToString();
        }
        private void substract(object parameter)
        {
            Result = (Convert.ToDouble(Number1) - Convert.ToDouble(Number2)).ToString();
        }
        private void multiply(object parameter)
        {
            Result = (Convert.ToDouble(Number1) * Convert.ToDouble(Number2)).ToString();
        }

        private void divide(object parameter)
        {
            if (Convert.ToDouble(Number2) != 0)
            {
                Result = (Convert.ToDouble(Number1) / Convert.ToDouble(Number2)).ToString();
            }
        }
    }
}
