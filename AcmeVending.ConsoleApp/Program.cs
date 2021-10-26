using AcmeVending.Models;
using System;
using System.Collections.Generic;

namespace AcmeVending.ConsoleApp
{
    internal class Program
    {
        private static readonly List<int> usdCoins = new List<int> { 1,5, 10, 25 };
        private static readonly List<int> gbpCoins = new List<int> { 1, 2, 5, 10, 20, 50 };
        static void Main(string[] args)
        {
            DisplayAndHandleInput();
        }

        private static void DisplayAndHandleInput()
        {
            Console.WriteLine("Select currency (1) for GPB (2) for USD");
            var currencyOption = Console.ReadLine();
            Console.WriteLine("Purchase Amount:");
            var purchaseAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Tender Amount:");
            var tenderAmount = decimal.Parse(Console.ReadLine());

            VendingMachine vendingMachine = null;
            if(currencyOption == "1")
            {
                vendingMachine = new VendingMachine(gbpCoins);
            }
            else if(currencyOption == "2")
            {
                vendingMachine = new VendingMachine(usdCoins);
            }
            vendingMachine.DispenseChange(purchaseAmount, tenderAmount);
            foreach(var c in vendingMachine.Coins)
            {
                Console.WriteLine($"[{c}]");
            }
            DisplayAndHandleInput();
        }
    }
}
