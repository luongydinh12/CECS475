using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CECS475_Lab3.Command;


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

        private decimal _number1;
        public decimal Number1
        {
            get { return _number1; }
            set { _number1 = value; OnPropertyChanged("Number1"); }
        }


        private decimal _number2;
        public decimal Number2
        {
            get { return _number2; }
            set { _number2 = value; OnPropertyChanged("Number2"); }
        }


        private decimal _result;

        public decimal Result
        {
            get { return _result; }
            set { _result = value; OnPropertyChanged("Result"); }
        }


        public ViewModel()
        {
            Console.WriteLine(Number1);
            Console.WriteLine(Number2);
            MyCommand = new RelayCommand(sum, canexecute);
            MyCommand2 = new RelayCommand(substract, canexecute);
            MyCommand3 = new RelayCommand(multiply, canexecute);
            MyCommand4 = new RelayCommand(divide, canexecute);
        }

        private bool canexecute(object parameter)
        {
            if (!string.IsNullOrEmpty(Number1.ToString()) && !string.IsNullOrEmpty(Number2.ToString()))
            {
                return true;
            }
            return false;
        }


        private void sum(object parameter)
        {
            Result = Number1 + Number2;
        }
        private void substract(object parameter)
        {
            Result = Number1 - Number2;
        }
        private void multiply(object parameter)
        {
            Result = Number1 * Number2;
        }
        private void divide(object parameter)
        {
            if (Number2 != 0)
            {
                Result = Number1 / Number2;
            }

        }


    }
}
