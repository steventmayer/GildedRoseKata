using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Behaviors
{
    public class IncreasePostSellInBehavior : PostSellInBehavior
    {
        public override void Update(Item item)
        {
            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }
}
