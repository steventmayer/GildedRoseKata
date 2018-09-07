# GildedRoseKata
Kata for GildedRose

This is my attempt at the Gilded Rose Kata.  I began by creating the first 10 tests that you see to ensure base functions worked.  I needed to make Items public so I would be able to assert its values from the Test project.

After I felt comfortable with the solution, I started with my refactoring.  In the beginning, I was pulling out the increasing and decreasing of the quality to a separate function to make it easier to read, and see how often this was done. 
After I had done that, I looked at what changes between the items: 
* Behavior when updating the quality -- Default behavior was to degrade by 1; however, the Aged Brie and Backstage Passes increased in quality
* The SellIn date, but Sulfuras' never needed to change.
* The Quality changed when past the Sell In date. For most items, it reduced by 1 until it hit 0. However, Backstage pass decreased at a different rate.

Due to this, I wanted to try my attempt at the strategy pattern, using a factory to build the Products that wrapped Item with a behavior, and a couple null object pattern when the behavior was to do nothing.

Things I'd Like to Do:
* There are common checks - Quality cannot be less than 0 nor greater than 50, and the PostSellIn only kicked in when past Sell Date, so I would like to build that into base functionality of that behavior