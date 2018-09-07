using GildedRose;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void UpdateQuantity_SellInDatePassed_QualityDegradesTwiceAsFast()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20}
                }
            };

            var expectedValue = 18;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuantity_SellInDateNotPassed_QualityDegradesRegularly()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
                }
            };

            var expectedValue = 19;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuantity_QualityIsNeverNegative_QualityIsZero()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0}
                }
            };

            var expectedValue = 0;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuantity_AgedBrie_QualityIncreased()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}
                }
            };

            var expectedValue = 1;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuantity_AgedBrie_SellInDatePassed_QualityIncreased()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Aged Brie", SellIn = -2, Quality = 0}
                }
            };

            var expectedValue = 2;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuantity_Sulfuras_QualityDoesntChange()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 13, Quality = 80}
                }
            };

            var expectedQualityValue = 80;
            var expectedSellInValue = 13;

            app.UpdateQuality();

            Assert.Equal(expectedQualityValue, app.Items[0].Quality);
            Assert.Equal(expectedSellInValue, app.Items[0].SellIn);
        }

        [Fact]
        public void UpdateQuantity_BackstagePasses_SellInGreaterThanTen_QualityIncreasesByOne()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    }
                }
            };

            var expectedValue = 21;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuantity_BackstagePasses_SellInLessThanTenGreaterThanFive_QualityIncreasesByTwo()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 8,
                        Quality = 20
                    }
                }
            };

            var expectedValue = 22;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuantity_BackstagePasses_SellInLessThanFive_QualityIncreasedByThree()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 3,
                        Quality = 20
                    }
                }
            };

            var expectedValue = 23;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuantity_BackstagePasses_SellInDatePassed_QualityDecreasedToZero()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = -3,
                        Quality = 20
                    }
                }
            };

            var expectedValue = 0;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuantity_Conjured_SellInDateNotPassed_QualityDecreased()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Conjured Mana Cake",
                        SellIn = 3,
                        Quality = 20
                    }
                }
            };

            var expectedValue = 18;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }

        [Fact]
        public void UpdateQuantity_Conjured_SellInDatePassed_QualityDecreased()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Conjured Mana Cake",
                        SellIn = -3,
                        Quality = 20
                    }
                }
            };

            var expectedValue = 16;
            app.UpdateQuality();

            Assert.Equal(expectedValue, app.Items[0].Quality);
        }
    }
}
