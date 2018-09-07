namespace GildedRose.Behaviors
{
    public class BackstagePassPostSellInBehavior : PostSellInBehavior
    {
        public override void Update(Item item)
        {
            if (item.SellIn < 11)
            {
                item.Quality++;
            }

            if (item.SellIn < 6)
            {
                item.Quality++;
            }

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
