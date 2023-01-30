using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        GildedRoseTestsFixture _fixture = new GildedRoseTestsFixture();

        [TestCase]
        public void UpdateQuantity_ForEachIteration_ShouldHaveTheSameItems()
        {
            for (int i = 0; i < 100; i++)
            {
                _fixture.UpdateQuantity();

                _fixture.CompareItems(i);
            }
        }

        private class GildedRoseTestsFixture
        {
            private GildedRose _sut;
            private GildedRoseBase _base;

            private List<Item> Items = new List<Item>
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

            private List<Item> Items2 = new List<Item>
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

            public GildedRoseTestsFixture()
            {
                _sut = new GildedRose
                {
                    Items = Items
                };

                _base = new GildedRoseBase
                {
                    Items = Items2
                };
            }

            public void UpdateQuantity()
            {
                _sut.UpdateQuality();
                _base.UpdateQuality();
            }

            public void CompareItems(int iteration)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine($@"
Iteration: {i} 
Name1: {_sut.Items[i].Name}
Quality: {_sut.Items[i].Quality}
Sellin: {_sut.Items[i].SellIn}
");

                    _sut.Items[i].Name.Should().Be(_base.Items[i].Name);
                    _sut.Items[i].Quality.Should().Be(_base.Items[i].Quality);
                    _sut.Items[i].SellIn.Should().Be(_base.Items[i].SellIn);
                }
            }


        }
    }
}