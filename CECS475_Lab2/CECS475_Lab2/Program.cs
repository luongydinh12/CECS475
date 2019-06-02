/* Name: Dinh Luong
 * CECS475
 * Professor Phuong Nguyen
 */

using System;
using System.IO;

/// <summary>
/// Program Description:
/// This program stimulates the ups and downs of a particular stock. Each stock will change
/// every 500 milliseconds. After a certain changes, if the stock goes over a specified threshold
/// the Stock generates an event to notify its broker(s). Once the broker receives the notification,
/// the broker outputs the stock information and also write it to stocks.txt
/// </summary>
namespace CECS475_Lab2
{
    class Program
    {
        /// <summary>
        /// Main method to start the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
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

            Stock stock1 = new Stock("Technology", 160, 5, 15);
            Stock stock2 = new Stock("Retail", 30, 2, 6);
            Stock stock3 = new Stock("Banking", 90, 4, 10);
            Stock stock4 = new Stock("Commodity", 500, 20, 50);

            StockBroker b1 = new StockBroker("Broker 1");
            b1.AddStock(stock1);
            b1.AddStock(stock2);

            StockBroker b2 = new StockBroker("Broker 2");
            b2.AddStock(stock1);
            b2.AddStock(stock3);
            b2.AddStock(stock4);

            StockBroker b3 = new StockBroker("Broker 3");
            b3.AddStock(stock1);
            b3.AddStock(stock3);

            StockBroker b4 = new StockBroker("Broker 4");
            b4.AddStock(stock1);
            b4.AddStock(stock2);
            b4.AddStock(stock3);
            b4.AddStock(stock4);
        }
    }
}
