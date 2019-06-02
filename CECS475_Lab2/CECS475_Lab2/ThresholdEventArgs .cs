using System;

namespace CECS475_Lab2
{
    /// <summary>
    /// Our threshold event arg class that extends the event args class.
    /// </summary>
    class ThresholdEventArgs : EventArgs
    {
        // Name of the stock
        private string _stockName;
        // Starting value of the stock
        private int _initialValue;
        // Current value of the stock
        private int _currentValue;
        // Number of changes of the stock
        private int _changes;

        /// <summary>
        /// Set and Get methods for each private members
        /// </summary>
        public string StockName { get => _stockName; set => _stockName = value; }
        public int InitialValue { get => _initialValue; set => _initialValue = value; }
        public int CurrentValue { get => _currentValue; set => _currentValue = value; }
        public int Changes { get => _changes; set => _changes = value; }

        /// <summary>
        /// Changes the values of the event notification
        /// </summary>
        /// <param name="stockName"> name of the stock</param>
        /// <param name="initialValue"> starting value of the stock </param>
        /// <param name="currentValue"> current value of the stock </param>
        /// <param name="changes"> number of changes of the stock </param>
        public ThresholdEventArgs(string stockName, int initialValue, int currentValue, int changes)
        {
            _stockName = stockName;
            _initialValue = initialValue;
            _currentValue = currentValue;
            _changes = changes;
        }
    }
}

