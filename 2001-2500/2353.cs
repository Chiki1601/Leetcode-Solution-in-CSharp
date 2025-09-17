using System;
using System.Collections.Generic;

public class Food
{
    public string name;
    public string cuisine;
    public int rating;
    public Food(string n, string c, int r) {
        name = n;
        cuisine = c;
        rating = r;
    }
}

public class FoodRatings
{
    private Dictionary<string, Food> foodToFood;
    private Dictionary<string, SortedSet<Food>> cuisineToFoods;

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings) {
        foodToFood = new Dictionary<string, Food>();
        cuisineToFoods = new Dictionary<string, SortedSet<Food>>();
        foreach (var i in Enumerable.Range(0, foods.Length)) {
            var f = new Food(foods[i], cuisines[i], ratings[i]);
            foodToFood[foods[i]] = f;
            if (!cuisineToFoods.ContainsKey(cuisines[i])) {
                cuisineToFoods[cuisines[i]] = new SortedSet<Food>(new FoodComparer());
            }
            cuisineToFoods[cuisines[i]].Add(f);
        }
    }

    public void ChangeRating(string food, int newRating) {
        Food f = foodToFood[food];
        var set = cuisineToFoods[f.cuisine];
        set.Remove(f);
        f.rating = newRating;
        set.Add(f);
    }

    public string HighestRated(string cuisine) {
        return cuisineToFoods[cuisine].Min.name;
    }

    private class FoodComparer : IComparer<Food> {
        public int Compare(Food a, Food b) {
            if (a.rating != b.rating) {
                return b.rating.CompareTo(a.rating);
            }
            return a.name.CompareTo(b.name);
        }
    }
}
