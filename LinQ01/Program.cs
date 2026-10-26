using LINQ.DataSources;
using LINQ.Models;

namespace LinQ01
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //// ---------- 1. Seafood products: name + price ----------
            //Console.WriteLine("=== 1. Seafood products ===");
            //var seafood = Source.ProductList.Where(p => p.Category == "Seafood");
            //foreach (var p in seafood)
            //    Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C2}");

            //// ---------- 2. Product names only ----------
            //Console.WriteLine("\n=== 2. Product names ===");
            //var names = Source.ProductList.Select(p => p.ProductName);
            //foreach (var n in names)
            //    Console.WriteLine(n);

            //// ---------- 3. Sort by UnitPrice ascending ----------
            //Console.WriteLine("\n=== 3. Sorted by UnitPrice (asc) ===");
            //var byPrice = Source.ProductList.OrderBy(p => p.UnitPrice);
            //foreach (var p in byPrice)
            //    Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C2}");

            //// ---------- 4. UnitPrice between 10 and 30 ----------
            //Console.WriteLine("\n=== 4. UnitPrice between 10 and 30 ===");

            //var productsInRange = from p in Source.ProductList
            //                      where p.UnitPrice >= 10 && p.UnitPrice <= 30
            //                      select new { p.ProductName, p.UnitPrice };

            //foreach (var item in productsInRange)
            //    Console.WriteLine($"{item.ProductName}: {item.UnitPrice:C}");

            //// ---------- 5. In stock + Condiments ----------
            //// Note: in our data the category name is "Spices & Condiments"
            //Console.WriteLine(" \n === 5. that are in stock (UnitsInStock > 0) and category. ===");

            //var condiments = from p in Source.ProductList
            //                 where p.UnitsInStock > 0 &&
            //                       p.Category.Contains("Condiments")
            //                 select new { p.ProductName, p.UnitPrice };

            //foreach (var p in condiments)
            //    Console.WriteLine($"{p.ProductName}: {p.UnitPrice:C}");

            //// ---------- 6. Anonymous type with StockStatus ----------
            //Console.WriteLine("\n=== 6. Anonymous type ===");
            //var anon = Source.ProductList.Select(p => new
            //{
            //    Name = p.ProductName,
            //    Price = p.UnitPrice,
            //    StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            //});
            //foreach (var a in anon)
            //    Console.WriteLine($"{a.Name} | {a.Price:C2} | {a.StockStatus}");

            //// ---------- 7. Name with 1-based position ----------
            //Console.WriteLine("\n=== 7. Name with position ===");
            //var indexed = Source.ProductList.Select((p, i) => $"{i + 1}. {p.ProductName}");
            //foreach (var s in indexed)
            //    Console.WriteLine(s);

            //// ---------- 8. Category asc, then UnitPrice desc ----------

            //Console.WriteLine("\n=== 8. Sort by Category and Price ===");

            //var byCategoryThenPrice =
            //    from p in Source.ProductList
            //    orderby p.Category ascending, p.UnitPrice descending
            //    select p;

            //foreach (var product in byCategoryThenPrice)
            //{
            //    Console.WriteLine(
            //        $"{product.Category}: {product.ProductName} - {product.UnitPrice:C}");
            //}

            //// ---------- 9. Beverages sorted by UnitsInStock desc ----------
            //Console.WriteLine("\n=== 9. Beverages by stock (desc) ===");
            //var beverages = Source.ProductList
            //    .Where(p => p.Category == "Beverages")
            //    .OrderByDescending(p => p.UnitsInStock);
            //foreach (var p in beverages)
            //    Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");

            //// ---------- 10. Query syntax, compound from: orders in 1997 or later ----------
            //Console.WriteLine("\n=== 10. Orders from 1997 or later ===");
            //var orders =
            //    from c in Source.CustomerList
            //    from o in c.Orders
            //    where o.OrderDate.Year >= 1997
            //    select new { c.CustomerID, o.OrderDate };
            //foreach (var o in orders)
            //    Console.WriteLine($"{o.CustomerID} - {o.OrderDate:d}");

            //// ---------- 11. Position number alongside ProductName ----------
            //Console.WriteLine("\n=== 11. Position + ProductName ===");
            //var withIndex = Source.ProductList.Select((p, i) => new { Position = i + 1, p.ProductName });
            //foreach (var x in withIndex)
            //    Console.WriteLine($"{x.Position} - {x.ProductName}");

            //// ---------- 12. Sort by length, then case-insensitive alphabetical ----------
            //Console.WriteLine("\n=== 12. Words: length then case-insensitive ===");
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var words = Arr
            //    .OrderBy(w => w.Length)
            //    .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            //foreach (var w in words)
            //    Console.WriteLine(w);

            //// ---------- 13. Digits whose 2nd letter is 'i', in reverse order ----------
            //// (The assignment's Arr has no word with 'i' as 2nd letter,
            ////  so this uses the classic digits array this question comes from.)
            //Console.WriteLine("\n=== 13. Digits with 2nd letter 'i' (reversed) ===");
            //string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var result = digits
            //    .Where(d => d.Length > 1 && d[1] == 'i')
            //    .Reverse();
            //foreach (var d in result)
            //    Console.WriteLine(d);



            //---------------------Assignment LINQ02 ---------------------------------


            Run();
        }

        public static void Run()
        {
            var products = Source.ProductList;
            var customers = Source.CustomerList;

            // ---------- 1. Top 3 most expensive products ----------
            Console.WriteLine("=== 1. Top 3 most expensive products ===");
            var top3 = products.OrderByDescending(p => p.UnitPrice).Take(3);
            foreach (var p in top3)
                Console.WriteLine(p);

            // ---------- 2. Page 2 of products, page size = 5 ----------
            Console.WriteLine("\n=== 2. Page 2 (page size = 5) ===");
            int pageNumber = 2, pageSize = 5;
            var page = products.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            foreach (var p in page)
                Console.WriteLine(p);

            // ---------- 3. Take products while UnitPrice < 25 (ordered by price) ----------
            Console.WriteLine("\n=== 3. TakeWhile UnitPrice < 25 ===");
            var cheap = products.OrderBy(p => p.UnitPrice).TakeWhile(p => p.UnitPrice < 25);
            foreach (var p in cheap)
                Console.WriteLine(p);

            // ---------- 4. Are ALL Seafood products in stock? ----------
            Console.WriteLine("\n=== 4. All Seafood in stock? ===");
            bool allSeafoodInStock = products
                .Where(p => p.Category == "Seafood")
                .All(p => p.UnitsInStock > 0);
            Console.WriteLine(allSeafoodInStock);

            // ---------- 5. Does the ID list contain 9? ----------
            Console.WriteLine("\n=== 5. ids contains 9? ===");
            int[] ids = { 3, 9, 13, 18 };
            Console.WriteLine(ids.Contains(9));

            // ---------- 6. Group by Category, print each group with its product count ----------
            Console.WriteLine("\n=== 6. Group by Category with count ===");
            var groups = products.GroupBy(p => p.Category);
            foreach (var g in groups)
                Console.WriteLine($"{g.Key}: {g.Count()} products");

            // ---------- 7. Group by Category, project only product names per group ----------
            Console.WriteLine("\n=== 7. Product names per Category ===");
            var namesPerCategory = products
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Names = g.Select(p => p.ProductName) });
            foreach (var g in namesPerCategory)
            {
                Console.WriteLine(g.Category);
                foreach (var name in g.Names)
                    Console.WriteLine($"   {name}");
            }

            // ---------- 8. Categories with MORE THAN 3 products ----------
            Console.WriteLine("\n=== 8. Categories with more than 3 products ===");
            var bigCategories = products
                .GroupBy(p => p.Category)
                .Where(g => g.Count() > 3)
                .Select(g => g.Key);
            foreach (var c in bigCategories)
                Console.WriteLine(c);

            // ---------- 9. (Query syntax) Group customers by Country -> { Country, Count, TotalOrderValue } ----------
            Console.WriteLine("\n=== 9. Customers grouped by Country ===");
            var byCountry =
                from c in customers
                group c by c.Country into g
                select new
                {
                    Country = g.Key,
                    Count = g.Count(),
                    TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
                };
            foreach (var x in byCountry)
                Console.WriteLine($"{x.Country} | Count = {x.Count} | TotalOrderValue = {x.TotalOrderValue:C2}");

            // ---------- 10. Total number of units in stock across all products ----------
            Console.WriteLine("\n=== 10. Total units in stock ===");
            Console.WriteLine(products.Sum(p => p.UnitsInStock));

            // ---------- 11. CHEAPEST and MOST EXPENSIVE product prices ----------
            Console.WriteLine("\n=== 11. Cheapest & most expensive prices ===");
            Console.WriteLine($"Cheapest: {products.Min(p => p.UnitPrice):C2}");
            Console.WriteLine($"Most expensive: {products.Max(p => p.UnitPrice):C2}");

            // ---------- 12. Distinct list of all product categories ----------
            Console.WriteLine("\n=== 12. Distinct categories ===");
            var categories = products.Select(p => p.Category).Distinct();
            foreach (var c in categories)
                Console.WriteLine(c);

            // ---------- 13. IDs in setA but NOT in setB ----------
            Console.WriteLine("\n=== 13. setA except setB ===");
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };
            foreach (var id in setA.Except(setB))
                Console.WriteLine(id);

            // ---------- 14. Countries in list1 but NOT in list2 (case-insensitive) ----------
            Console.WriteLine("\n=== 14. list1 except list2 (ignore case) ===");
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };
            foreach (var country in list1.Except(list2, StringComparer.OrdinalIgnoreCase))
                Console.WriteLine(country);

            // ---------- 15. Dictionary<int, Product> keyed by ProductID, then print product with ID = 18 ----------
            Console.WriteLine("\n=== 15. Dictionary lookup (ID = 18) ===");
            Dictionary<int, Product> productDict = products.ToDictionary(p => p.ProductID);
            Console.WriteLine(productDict[18]);

            // ---------- 16. First product whose price is greater than $50 ----------
            Console.WriteLine("\n=== 16. First product with price > 50 ===");
            Console.WriteLine(products.First(p => p.UnitPrice > 50));

            // ---------- 17. First product with price > $500 (returns null instead of throwing) ----------
            Console.WriteLine("\n=== 17. FirstOrDefault price > 500 ===");
            var expensive = products.FirstOrDefault(p => p.UnitPrice > 500);
            Console.WriteLine(expensive?.ToString() ?? "null");

            // ---------- 18. Multiplication table row for 7 ----------
            Console.WriteLine("\n=== 18. Multiplication table of 7 ===");
            var row = Enumerable.Range(1, 10).Select(i => $"7 x {i} = {7 * i}");
            foreach (var line in row)
                Console.WriteLine(line);

            // ---------- 19. Even numbers between 1 and 30 ----------
            Console.WriteLine("\n=== 19. Even numbers between 1 and 30 ===");
            var evens = Enumerable.Range(1, 30).Where(n => n % 2 == 0);
            Console.WriteLine(string.Join(", ", evens));

            // ---------- 20. Concat first 3 product names with first 3 customer names ----------
            Console.WriteLine("\n=== 20. Concat product names + customer names ===");
            var combined = products.Take(3).Select(p => p.ProductName)
                .Concat(customers.Take(3).Select(c => c.CustomerName));
            foreach (var item in combined)
                Console.WriteLine(item);

            // ---------- 21. Pair each product with a customer (by position) -> "ProductName sold to CompanyName" ----------
            Console.WriteLine("\n=== 21. Zip products with customers ===");
            var sold = products.Zip(customers, (p, c) => $"{p.ProductName} sold to {c.CustomerName}");
            foreach (var s in sold)
                Console.WriteLine(s);

        }
    }
}
          



