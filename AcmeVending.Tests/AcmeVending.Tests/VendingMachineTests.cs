using AcmeVending.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AcmeVending.Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void VendingMachine_GBP_Tests()
        {
            var vendingMachine = new VendingMachine(new List<int> { 1, 2, 5, 10, 20, 50 });
            vendingMachine.DispenseChange(103.77m, 104.20m);

            Assert.True(vendingMachine.DispenseAmount > 0);
            Assert.True(vendingMachine.DispenseAmountCents > 0);
            //note: used a dictionary initially
            //Assert.Equal(vendingMachine.DispenseAmountCents, vendingMachine.Coins.Sum(x => x.Key * x.Value));
        }

        [Fact]
        public void VendingMachine_USD_Tests()
        {
            var vendingMachine = new VendingMachine(new List<int> { 1,5, 10, 25 });
            vendingMachine.DispenseChange(1.35m, 2.00m);

            Assert.True(vendingMachine.DispenseAmount > 0);
            Assert.True(vendingMachine.DispenseAmountCents > 0);
            //note: used a dictionary initially
            //Assert.Equal(vendingMachine.DispenseAmountCents, vendingMachine.Coins.Sum(x => x.Key * x.Value));
        }

        [Fact]
        public void VendingMachine_Tests()
        {
            var vendingMachine = new VendingMachine(new List<int> { 1, 2, 5, 10 });
            vendingMachine.DispenseChange(103.77m, 104.20m);

            Assert.True(vendingMachine.DispenseAmount > 0);
            Assert.True(vendingMachine.DispenseAmountCents > 0);
            //note: used a dictionary initially
            //Assert.Equal(vendingMachine.DispenseAmountCents, vendingMachine.Coins.Sum(x => x.Key * x.Value));
        }
    }
}
