using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace CECS475_Lab2
{
    /// <summary>
    /// StockBroker class
    /// </summary>
    class StockBroker
    {
        // Name of the broker
        private string _brokerName;
        // A list to store the stock added to a specific broker
        List<Stock> stockList;
        // Variable to store the current time
        DateTime now = DateTime.Now;

        // Get the path for the txt file to be saved to
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        // Create a lock to handle synchronization
        public static ReaderWriterLockSlim newlock = new ReaderWriterLockSlim();

        /// <summary>
        /// Set and Get method for _brokerName
        /// </summary>
        public string BrokerName { get => _brokerName; set => _brokerName = value; }

        /// <summary>
        /// Constructor for StockBroker
        /// </summary>
        /// <param name="name"> name of the broker</param>
        public StockBroker(string name)
        {
            _brokerName = name;
            stockList = new List<Stock>();
        }

        /// <summary>
        /// Method to add a specific stock to a specific broker. 
        /// The broker becomes a subscriber of the event
        /// </summary>
        /// <param name="stock"> stock </param>
        public void AddStock(Stock stock)
        {
            stock.OnStockThreshold += Notify;
            stockList.Add(stock);
        }

        /// <summary>
        /// Method to write the stock information to the console and txt file
        /// </summary>
        /// <param name="sender"> the stock that raises the event </param>
        /// <param name="e"> the event </param>
        public void Notify(object sender, ThresholdEventArgs e)
        {
            // Enable the lock to begin writing to console and txt file
            newlock.EnterWriteLock();
            Console.WriteLine(now.ToString().PadRight(25)
                              + _brokerName.PadRight(15)
                              + e.StockName.PadRight(15)
                              + e.InitialValue.ToString().PadRight(15)
                              + e.CurrentValue.ToString().PadRight(15)
                              + e.Changes.ToString().PadRight(15));
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "stocks.txt"), true))
            {
                outputFile.WriteLine(now.ToString().PadRight(25)
                              + _brokerName.PadRight(15)
                              + e.StockName.PadRight(15)
                              + e.InitialValue.ToString().PadRight(15)
                              + e.CurrentValue.ToString().PadRight(15)
                              + e.Changes.ToString().PadRight(15));
            }
            // Release the lock
            newlock.ExitWriteLock();
        }
    }

}
