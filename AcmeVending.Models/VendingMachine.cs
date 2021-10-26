using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeVending.Models
{
    public class VendingMachine
    {
        private readonly List<int> _coinDenominations;
        private List<int> _coins;
        private decimal _dispenseAmount;
        private decimal _dispenseAmountCents;
        public List<int> CoinDenonimations => _coinDenominations;
        public List<int> Coins => _coins;
        public decimal DispenseAmountCents => _dispenseAmountCents;
        public VendingMachine(List<int> coinDenominations)
        {
            _coinDenominations = coinDenominations;
            _coins = new List<int>();
        }

        public List<int> DispenseChange(decimal purchaseAmount, decimal tenderAmount)
        {
            _dispenseAmount = tenderAmount - purchaseAmount;
            _dispenseAmountCents = _dispenseAmount * 100;
            decimal runningTotal = _dispenseAmountCents;
            var orderedCoinDenominations = _coinDenominations.OrderByDescending(c => c);

            foreach (var coin in orderedCoinDenominations)
            {
                decimal numberOfCoins = decimal.Floor(runningTotal / coin);
                if (numberOfCoins > 0)
                {
                    decimal numberOfCoinsSum = numberOfCoins * coin;
                    runningTotal = runningTotal - numberOfCoinsSum;
                    for (var d = 0; d < numberOfCoins; d++)
                    {
                        _coins.Add(coin);
                    }
                }
            }

            return _coins;
        }

        public decimal DispenseAmount => _dispenseAmount;
    }
}
