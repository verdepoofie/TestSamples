using System;
using System.Collections.Generic;
using System.Linq;

namespace TestSamples {
    public class Group {
        public string Name { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
    }
    public class Meal {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public static class Helper {
        // Без использования LINQ реализуйте метод GetFilteredMeals, возвращающий IEnumerable<Meal>,
        // где Meal.Price выше или равна minPrice
        public static IEnumerable<Meal> GetFilteredMeals(IEnumerable<Group> categories, decimal minPrice) 
        {
            List<Meal> meals = new List<Meal>();
            foreach (var category in categories)
            {
                if (category.Meals != null)
                {
                    foreach (var meal in category.Meals)
                    {
                        if (meal.Price >= minPrice)
                            meals.Add(meal);
                    }
                }
            }
            return meals;
        }
        // То же самое, но с использованием LINQ
        public static IEnumerable<Meal> GetFilteredMealsLINQ(IEnumerable<Group> categories, decimal minPrice) => 
            categories.SelectMany(c => c.Meals != null ? c.Meals : new List<Meal>()).Where(m => m.Price >= minPrice);
        // Переработайте метод GetFilteredMeals так, чтобы в нем можно было использовать любое условие
        public static IEnumerable<Meal> GetFilteredMealsLINQ(IEnumerable<Group> categories, Func<Meal, bool> predicate) =>
            categories.SelectMany(c => c.Meals != null ? c.Meals : new List<Meal>()).Where(predicate);
    }
}