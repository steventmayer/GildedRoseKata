using GildedRose.Behaviors;

namespace GildedRose.Behaviors
{
    public class DecreaseQualityTwiceAsFastPostSellInBehavior : PostSellInBehavior
    {
        public override void Update(Item item)
        {
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }

            base.Update(item);
        }
    }
}