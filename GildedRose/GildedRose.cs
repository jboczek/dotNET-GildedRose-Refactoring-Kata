using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GildedRose
{
    public class GildedRose
    {
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Aged = "Aged Brie";
        private const string Concert = "Backstage passes to a TAFKAL80ETC concert";
        public IList<Item> Items;
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                UpdateItemQuality(item);
            }
        }
        private void UpdateItemQuality(Item item)
        {
            if (IsItemTypeCustom(item) == false)
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
            }
            else if (item.Quality < 50)
            {
                item.Quality++;
                if (item.Name == Concert)
                {
                    if (item.SellIn < 11 && item.Quality < 50)
                    {
                        item.Quality++;
                    }
                    if (item.SellIn < 6 && item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
            }
            if (item.Name != Sulfuras)
            {
                item.SellIn--;
            }
            if (item.SellIn >= 0)
            {
                return;
            }
            if (IsItemTypeCustom(item) == false && item.Quality > 0)
            {
                item.Quality--;
            }
            if (item.Name == Concert)
            {
                item.Quality -= item.Quality;
            }
            if (item.Quality < 50 && item.Name == Aged)
            {
                item.Quality++;
            }
        }
        private bool IsItemTypeCustom(Item item)
        {
            return item.Name == Sulfuras || item.Name == Aged || item.Name == Concert;
        }
    }
}