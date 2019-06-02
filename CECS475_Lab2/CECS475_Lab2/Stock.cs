using System;
using System.Threading;

namespace CECS475_Lab2
{
    /// <summary>
    /// Stock class.
    /// </summary>
    class Stock
    {
        // Eventhandler to check thresholds.
        public event EventHandler<ThresholdEventArgs> OnStockThreshold;

        //Name of our stock.
        private string _name;
        //Starting value of the stock.
        private int _initialValue;
        //Max change of the stock that is possible.
        private int _maxChange;
        //Threshold value where we notify subscribers to the event.
        private int _threshold;
        //Amount of changes the stock goes through.
        private int _changes;
        //Current value of the stock.
        private int _currentValue;

        /// <summary>
        /// Set and Get Methods for each private members
        /// </summary>
        public string Name { get => _name; set => _name = value; }
        public int InitialValue { get => _initialValue; set => _initialValue = value; }
        public int MaxChange { get => _maxChange; set => _maxChange = value; }
        public int Threshold { get => _threshold; set => _threshold = value; }
        public int Changes { get => _changes; set => _changes = value; }
        public int CurrentValue { get => _currentValue; set => _currentValue = value; }


        /// <summary>
        /// Initalizer for stock variables.
        /// </summary>
        /// <param name="name"> name of our stock.</param>
        /// <param name="startingValue"> Starting value of the stock.</param>
        /// <param name="maxchange">Max change of the stock allowed.</param>
        /// <param name="threshold">threshold value to notify subscribers.</param>
        public Stock(string name, int startingValue, int maxchange, int threshold)
        {
            _name = name;
            _initialValue = startingValue;
            _maxChange = maxchange;
            _threshold = threshold;
            _changes = 0;
            _currentValue = startingValue;

            ThreadStart childref = new ThreadStart(Activate);
            Thread childThread = new Thread(childref);
            childThread.Start();
        }

        /// <summary>
        /// Activate function for the threads where we sleep and change stock values.
        /// </summary>
        public void Activate()
        {
            //run for look 15 times
            for (int i = 0; i < 15; i++)
            {
                //sleep thread for 1/2 a second.
                Thread.Sleep(500);
                //call function to change stocks value.
                ChangeStockValue();
            }
        }

        /// <summary>
        /// Method to change a stock's value.
        /// </summary>
        private void ChangeStockValue()
        {
            // Random the stock value and increase the number of changes
            Random newRand = new Random();
            _currentValue += newRand.Next(0, MaxChange);
            _changes++;

            //Check the threshold
            //Greater than threshold then raise the event
            if ((CurrentValue - InitialValue) > Threshold)
            {
                OnStockThreshold?.Invoke(this, new ThresholdEventArgs(Name, InitialValue, CurrentValue, Changes));
            }
        }
    }
}

