using GildedRose.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Factory
{
    public static class ItemFactory
    {
        public static Product Create(Item item)
        {
            switch(item?.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return new Product(
                        item,
                        new NeverChangeQualityBehavior(),
                        new NeverChangeSellInBehavior(),
                        new NoPostSellInBehavior());
                case "Aged Brie":
                    return new Product(
                        item,
                        new IncreaseQualityBehavior(),
                        new SellInBehavior(),
                        new IncreasePostSellInBehavior());
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new Product(
                        item,
                        new IncreaseQualityBehavior(),
                        new SellInBehavior(),
                        new BackstagePassPostSellInBehavior());
                case "Conjured":
                    return new Product(
                        item,
                        new DecreaseQualityTwiceAsFastQualityBehavior(),
                        new SellInBehavior(),
                        new DecreaseQualityTwiceAsFastPostSellInBehavior());
                default:
                    return new Product(
                        item,
                        new QualityBehavior(),
                        new SellInBehavior(),
                        new PostSellInBehavior());
            }
        }
    }
}
