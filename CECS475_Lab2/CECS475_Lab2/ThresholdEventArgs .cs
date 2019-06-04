using System;
using System.IO;

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
        // Boolean to check if header has been printed
        private static bool _header = false;

        /// <summary>
        /// Set and Get methods for each private members
        /// </summary>
        public string StockName { get => _stockName; set => _stockName = value; }
        public int InitialValue { get => _initialValue; set => _initialValue = value; }
        public int CurrentValue { get => _currentValue; set => _currentValue = value; }
        public int Changes { get => _changes; set => _changes = value; }
        public static bool Header { get => _header; set => _header = value; }

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

            // If there is no header printed, then print the header
            if (_header == false)
            {
                printHeader();
            }
            // Set the header to true once the header has been printed
            _header = true;
        }

        /// <summary>
        /// Method to print out the header to console and the txt file
        /// </summary>
        private void printHeader()
        {
            // Get the path for the txt file to be saved to
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the title for each columns to the console and txt file
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "stocks.txt"), true))
            {
                outputFile.WriteLine("Date and Time".PadRight(25)
                            + "Broker".PadRight(15)
                            + "Stock".PadRight(15)
                            + "Initial Value".PadRight(15)
                            + "Current Value".PadRight(15)
                            + "Changes".PadRight(15));
            }
            Console.WriteLine("Date and Time".PadRight(25)
                            + "Broker".PadRight(15)
                            + "Stock".PadRight(15)
                            + "Initial Value".PadRight(15)
                            + "Current Value".PadRight(15)
                            + "Changes".PadRight(15));
        }
    }
}

