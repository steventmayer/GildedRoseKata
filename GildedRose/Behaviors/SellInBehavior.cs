namespace GildedRose
{
    public class SellInBehavior
    {
        public virtual void Update(Item item)
        {
            item.SellIn--;
        }
    }
}