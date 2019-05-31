using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CECS475_Lab2
{
    /// <summary>
    /// Stock class.
    /// </summary>
    class Stock
    {
        // Eventhandler to check thresholds.

        //Name of our stock.
        private string Name;
        //Starting value of the stock.
        private int InitialValue;
        //Max change of the stock that is possible.
        private int maxChange;
        //Threshold value where we notify subscribers to the event.
        private int threshold;
        //Amount of changes the stock goes through.
        private int changes;
        //Current value of the stock.
        private int currentValue;

        /// <summary>
        /// Initalizer for stock variables.
        /// </summary>
        /// <param name="name"> name of our stock.</param>
        /// <param name="startingValue"> Starting value of the stock.</param>
        /// <param name="maxchange">Max change of the stock allowed.</param>
        /// <param name="threshold">threshold value to notify subscribers.</param>
        /// 
        public string NameMethod
        {
            get { return Name; }
            set { Name = value; }
        }
        public int InitialValueMethod
        {
            get { return InitialValue; }
            set { InitialValue = value; }
        }
        public int maxChangeMethod
        {
            get { return maxChange; }
            set { maxChange = value; }
        }
        public int thresholdMethod
        {
            get { return threshold; }
            set { threshold = value; }
        }
        public int changesMethod
        {
            get { return changes; }
            set { changes = value; }
        }
        public int currentValueMethod
        {
            get { return currentValue; }
            set { currentValue = value; }
        }
        public Stock(string name, int startingValue, int maxchange, int threshold)
        {


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
            }
        }

        /// <summary>
        /// Method to change a stock's value.
        /// </summary>
        private void ChangeStockValue()
        {      // Random the stock value
               //Check the threshold
               //Greater than Threshold then raise the event

        }
    }
}
}
