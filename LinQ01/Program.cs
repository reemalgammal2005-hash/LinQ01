using LINQ.DataSources;

namespace LinQ01
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // ---------- 1. Seafood products: name + price ----------
            Console.WriteLine("=== 1. Seafood products ===");
            var seafood = Source.ProductList.Where(p => p.Category == "Seafood");
            foreach (var p in seafood)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C2}");

            // ---------- 2. Product names only ----------
            Console.WriteLine("\n=== 2. Product names ===");
            var names = Source.ProductList.Select(p => p.ProductName);
            foreach (var n in names)
                Console.WriteLine(n);

            // ---------- 3. Sort by UnitPrice ascending ----------
            Console.WriteLine("\n=== 3. Sorted by UnitPrice (asc) ===");
            var byPrice = Source.ProductList.OrderBy(p => p.UnitPrice);
            foreach (var p in byPrice)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C2}");

            // ---------- 4. UnitPrice between 10 and 30 ----------
            Console.WriteLine("\n=== 4. UnitPrice between 10 and 30 ===");
            
            var productsInRange = from p in Source.ProductList
                                  where p.UnitPrice >= 10 && p.UnitPrice <= 30
                                  select new { p.ProductName, p.UnitPrice };

            foreach (var item in productsInRange)
                Console.WriteLine($"{item.ProductName}: {item.UnitPrice:C}");

            // ---------- 5. In stock + Condiments ----------
            // Note: in our data the category name is "Spices & Condiments"
            Console.WriteLine(" \n === 5. that are in stock (UnitsInStock > 0) and category. ===");

            var condiments = from p in Source.ProductList
                             where p.UnitsInStock > 0 &&
                                   p.Category.Contains("Condiments")
                             select new { p.ProductName, p.UnitPrice };

            foreach (var p in condiments)
                Console.WriteLine($"{p.ProductName}: {p.UnitPrice:C}");

            // ---------- 6. Anonymous type with StockStatus ----------
            Console.WriteLine("\n=== 6. Anonymous type ===");
            var anon = Source.ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var a in anon)
                Console.WriteLine($"{a.Name} | {a.Price:C2} | {a.StockStatus}");

            // ---------- 7. Name with 1-based position ----------
            Console.WriteLine("\n=== 7. Name with position ===");
            var indexed = Source.ProductList.Select((p, i) => $"{i + 1}. {p.ProductName}");
            foreach (var s in indexed)
                Console.WriteLine(s);

            // ---------- 8. Category asc, then UnitPrice desc ----------
            
            Console.WriteLine("\n=== 8. Sort by Category and Price ===");

            var byCategoryThenPrice =
                from p in Source.ProductList
                orderby p.Category ascending, p.UnitPrice descending
                select p;

            foreach (var product in byCategoryThenPrice)
            {
                Console.WriteLine(
                    $"{product.Category}: {product.ProductName} - {product.UnitPrice:C}");
            }

            // ---------- 9. Beverages sorted by UnitsInStock desc ----------
            Console.WriteLine("\n=== 9. Beverages by stock (desc) ===");
            var beverages = Source.ProductList
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);
            foreach (var p in beverages)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");

            // ---------- 10. Query syntax, compound from: orders in 1997 or later ----------
            Console.WriteLine("\n=== 10. Orders from 1997 or later ===");
            var orders =
                from c in Source.CustomerList
                from o in c.Orders
                where o.OrderDate.Year >= 1997
                select new { c.CustomerID, o.OrderDate };
            foreach (var o in orders)
                Console.WriteLine($"{o.CustomerID} - {o.OrderDate:d}");

            // ---------- 11. Position number alongside ProductName ----------
            Console.WriteLine("\n=== 11. Position + ProductName ===");
            var withIndex = Source.ProductList.Select((p, i) => new { Position = i + 1, p.ProductName });
            foreach (var x in withIndex)
                Console.WriteLine($"{x.Position} - {x.ProductName}");

            // ---------- 12. Sort by length, then case-insensitive alphabetical ----------
            Console.WriteLine("\n=== 12. Words: length then case-insensitive ===");
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var words = Arr
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in words)
                Console.WriteLine(w);

            // ---------- 13. Digits whose 2nd letter is 'i', in reverse order ----------
            // (The assignment's Arr has no word with 'i' as 2nd letter,
            //  so this uses the classic digits array this question comes from.)
            Console.WriteLine("\n=== 13. Digits with 2nd letter 'i' (reversed) ===");
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var result = digits
                .Where(d => d.Length > 1 && d[1] == 'i')
                .Reverse();
            foreach (var d in result)
                Console.WriteLine(d);
        }
    }
}
