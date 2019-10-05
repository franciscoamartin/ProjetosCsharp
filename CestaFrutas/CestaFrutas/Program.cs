using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FruitBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LoadingMyBasket
            var fruitsBasket = new List<Fruit>();
            fruitsBasket.Add(new Fruit(0, "Tomato", 212, "Red")); // Constructor

            fruitsBasket.Add(new Fruit(1, "Guava", 95, "Green"));// Constructor

            fruitsBasket.Add(new Fruit(2, "Strawberry", 20, "Red"));// Constructor
            #endregion
            #region lists:

            #region list1
            fruitsBasket.OrderByDescending(x => x.Id).ToList<Fruit>().
                ForEach(i =>
                Console.WriteLine($"Id {i.Id} . Name: {i.Name} . Weight: {i.Weight}"));
            #endregion
            #region list2
            Console.WriteLine("-------------------------");
            fruitsBasket.OrderBy(x => x.Id).ToList<Fruit>().
                ForEach(i =>
                Console.WriteLine($"Id {i.Id} . Name: {i.Name} . Weight: {i.Weight}"));
            #endregion
            #region list3
            Console.WriteLine("-------------------------");
            fruitsBasket.OrderBy(x => x.Name).ToList<Fruit>().
                ForEach(i =>
                Console.WriteLine($"Id {i.Id} . Name: {i.Name} . Weight: {i.Weight}"));
            #endregion
            #region list4
            Console.WriteLine("------------------------- Weight Filter");

            var basketFilter = fruitsBasket.Where(x => x.Weight > 100).OrderBy(x => x.Name);
            basketFilter.ToList<Fruit>().
                    ForEach(i =>//for each information at the list, write with those informations that i required
                    Console.WriteLine($"Id {i.Id} . Name: {i.Name} . Weight: {i.Weight}"));
            #endregion
            #region list5
            Console.WriteLine("------------------------- Weight Filter");
            //or:
            (from fruitttt in fruitsBasket
             where fruitttt.Weight > 100
             select fruitttt).ToList<Fruit>().ForEach
             (i => Console.WriteLine($"Choosed fruit: {i.Name} "));
            #endregion
            #endregion
            Console.WriteLine("------------------------- Color filter");
            Console.WriteLine("Using find:\n");
            var showFind = fruitsBasket.Find
                (x => x.Color == "Red" || x.Color == "Green");
            Console.WriteLine($"Id: {showFind.Id} . Name: {showFind.Name}");

            Console.WriteLine("\nUsing find All:\n");
            var showFindAll = fruitsBasket.FindAll(x => x.Color == "Red" || x.Color == "Green");
            showFindAll.ForEach(i => Console.WriteLine
                ($"Id: {i.Id} . Name: {i.Name}"));

            Console.WriteLine("\nUsing  another way:\n");
            var sortedList = showFindAll.OrderBy(x => x.Name);
            foreach (var item in sortedList)
            {
                Console.WriteLine($"Id {item.Id} Name {item.Name}");
            }


            Console.WriteLine("\nUsing order by\n");
            var FindOrderBasket = fruitsBasket.OrderBy(x => x.Name).ToList<Fruit>().Find
                (x => x.Color == "Green" || x.Color == "Red");
            //gets the first who response the condition and break
            Console.WriteLine($"Id: {FindOrderBasket.Id} Name: {FindOrderBasket.Name}");


            Console.ReadKey();
        }
    }
}