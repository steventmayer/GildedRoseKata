using GildedRose.Behaviors;

namespace GildedRose
{
    public class Product
    {
        private readonly Item item;
        private readonly QualityBehavior qualityBehavior;
        private readonly SellInBehavior sellInBehavior;
        private readonly PostSellInBehavior postSellInBehavior;

        public Product(
            Item item,
            QualityBehavior qualityBehavior,
            SellInBehavior sellInBehavior,
            PostSellInBehavior postSellInBehavior)
        {
            this.item = item;
            this.qualityBehavior = qualityBehavior;
            this.sellInBehavior = sellInBehavior;
            this.postSellInBehavior = postSellInBehavior;
        }

        public void UpdateQuality()
        {
            qualityBehavior.Update(this.item);
            sellInBehavior.Update(this.item);
            postSellInBehavior.Update(this.item);
        }
    }
}
