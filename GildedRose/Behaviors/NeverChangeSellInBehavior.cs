namespace GildedRose.Behaviors
{
    public class NeverChangeSellInBehavior : SellInBehavior
    {
        public override void Update(Item item)
        {
            // Do not change sell-in
        }
    }
}
