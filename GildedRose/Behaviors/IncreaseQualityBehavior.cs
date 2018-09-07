namespace GildedRose.Behaviors
{
    public class IncreaseQualityBehavior : QualityBehavior
    {
        public override void Update(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }
}
