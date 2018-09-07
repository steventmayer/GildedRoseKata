namespace GildedRose.Behaviors
{
    public class PostSellInBehavior
    {
        public virtual void Update(Item item)
        {
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}
