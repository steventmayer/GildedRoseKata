using GildedRose.Factory;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GildedRose.Tests")]
namespace GildedRose
{
    class Program
    {
        public IList<Item> Items;

        IList<Rule> Rules;
        Rule DefaultRule;
        Rule LegendaryRule;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program();

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        private void PopulateRules()
        {
            Rules = new List<Rule>
            {
                new AgedRule(),
                new PassRule(),
                new ConjuredRule()
            };

            DefaultRule = new DefaultRule();
            LegendaryRule = new LegendaryRule();
        }

        private void PopulateItems()
        {
            Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        public void UpdateQuality()
        {
            //PopulateItems();
            PopulateRules();

            foreach (Item item in Items)
            {
                if (!LegendaryRule.CheckName(item))
                {
                    UpdateItemQualityWithRules(item);
                    UpdateItemSellIn(item);
                    if (item.SellIn < 0)
                    {
                        UpdateItemQualityWithRules(item);
                    }
                }
            }
        }

        private void UpdateItemSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private void UpdateItemQualityWithRules(Item item)
        {
            int newQuality = item.Quality;
            bool qualityNotChanged = true;
            foreach (Rule rule in Rules)
            {
                if (rule.CheckName(item))
                {
                    qualityNotChanged = false;
                    newQuality += rule.QualityChange(item);
                }
            }
            if (qualityNotChanged)
            {
                newQuality += DefaultRule.QualityChange(item);
            }

            item.Quality = CapQuality(newQuality);
        }

        private int CapQuality(int newQuality)
        {
            if (newQuality < 0)
            {
                newQuality = 0;
            }
            if (newQuality > 50)
            {
                newQuality = 50;
            }
            return newQuality;
        }
    }


    /* Rule Definitions */

    abstract class Rule
    {
        public virtual string NameFilter
        {
            get
            {
                return string.Empty;
            }
        }

        public abstract int QualityChange(Item item);
        public virtual bool CheckName(Item item)
        {
            string name = item.Name.ToLower();
            return name.Contains(NameFilter.ToLower());
        }
    }

    class DefaultRule : Rule
    {
        public override int QualityChange(Item item)
        {
            return -1;
        }
    }

    class AgedRule : Rule
    {
        public override string NameFilter
        {
            get
            {
                return "aged";
            }
        }

        public override int QualityChange(Item item)
        {
            return 1;
        }
    }

    class ConjuredRule : Rule
    {
        public override string NameFilter
        {
            get
            {
                return "conjured";
            }
        }

        public override int QualityChange(Item item)
        {
            return -2;
        }
    }

    class LegendaryRule : Rule
    {
        public override string NameFilter
        {
            get
            {
                return "Sulfuras";
            }
        }

        public override int QualityChange(Item item)
        {
            return 0;
        }
    }

    class PassRule : Rule
    {
        public override string NameFilter
        {
            get
            {
                return "pass";
            }
        }

        public override int QualityChange(Item item)
        {
            if (item.SellIn < 0)
                return -item.Quality;

            if (item.SellIn < 6)
                return 3;

            if (item.SellIn < 11)
                return 2;

            return 1;
        }
    }
}
