namespace GildedRose
{
    public class QualityBehavior
    {
        public virtual void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}