namespace GildedRose.Behaviors
{
    internal class DecreaseQualityTwiceAsFastQualityBehavior : QualityBehavior
    {
        public override void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }

            base.Update(item);
        }
    }
}