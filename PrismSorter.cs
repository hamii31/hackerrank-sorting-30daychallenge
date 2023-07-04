namespace PrismSorter
{
    using System.Diagnostics;
    internal class Program
    { 
        public static List<int> keys = new List<int>();
        public static List<int> sides = new List<int>();
        public static Dictionary<int, int> KeyToSide = new Dictionary<int, int>();
        public static Dictionary<int, Dictionary<int, HashSet<Item>>> prismSorter = new Dictionary<int, Dictionary<int, HashSet<Item>>>();
        static void Main(string[] args)
        {
            // Creates a new side of the prism when a new collection of data needs to be made
            // Create new collection of data based on indexing of sides of the prism
            // Indexing of sides is based on the total object stored in the collection of the current side
            // Type of collection = HashSet
            // Type of PrismSorter = Resembles an Ordered Dictionary with keys to each side of the prism containing a HashSets of different values\
            // + CRUD operations 

            long totalTicks = 0;
            int key = -1;
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Choose action: ");
                Console.WriteLine("Check collection -> Input == A");
                Console.WriteLine("Add new collection -> Input == S");
                Console.WriteLine("Edit existing collection -> Input == D");
                Console.WriteLine("Exit -> Input == X");
                Console.Write("Input: ");
                string input = Console.ReadLine();
                Console.WriteLine("--------------------------------------");

                if (input?.ToUpper() == "A")
                {
                    Console.WriteLine("Enter key: ");
                    int keyToCheck = int.Parse(Console.ReadLine());

                    Stopwatch sw = Stopwatch.StartNew();

                    if (!keys.Contains(keyToCheck))
                    {
                        Console.WriteLine($"{keyToCheck} is not a valid key!");
                        continue;
                    }

                    ShowPrismSide(keyToCheck);

                    sw.Stop();
                    totalTicks += sw.ElapsedTicks;
                    Console.WriteLine($"The algorithm took {sw.ElapsedTicks} ticks to complete your request!");
                    Console.WriteLine();
                }
                if (input?.ToUpper() == "S")
                {
                    Console.WriteLine("Size of collection: ");
                    int n = int.Parse(Console.ReadLine());
                    if(n <= 0)
                    {
                        Console.WriteLine("The size of the collection cannot be 0 or less!");
                        Console.WriteLine();
                        continue;
                    }

                    Console.WriteLine("Create collection: ");
                    HashSet<Item> set = new HashSet<Item>();

                    for (int i = 0; i < n; i++)
                    {
                        var item = Console.ReadLine();
                        set.Add(item);
                    }

                    Stopwatch sw = Stopwatch.StartNew();

                    key++;
                    keys.Add(key);
                    PrismSorter(key, set);

                    sw.Stop();
                    totalTicks += sw.ElapsedTicks;
                    Console.WriteLine($"The algorithm took {sw.ElapsedTicks} ticks to complete your request!");
                    Console.WriteLine();;
                }
                if (input?.ToUpper() == "D")
                {
                    Console.WriteLine("Enter key: ");
                    int keyToCheck = int.Parse(Console.ReadLine());

                    Stopwatch sw = Stopwatch.StartNew();

                    if (!keys.Contains(keyToCheck))
                    {
                        Console.WriteLine($"{keyToCheck} is not a valid key!");
                        continue;
                    }
                    EditPrismSideCollection(keyToCheck, sw);

                    sw.Stop();
                    totalTicks += sw.ElapsedTicks;
                    Console.WriteLine($"The algorithm took {sw.ElapsedTicks} ticks to complete your request!");
                    Console.WriteLine();
                }
                if (input?.ToUpper() == "X")
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    if (keys.Count() != 0)
                    {
                        Console.WriteLine($"You created a {sides.Count}-side prism !");
                        Console.WriteLine();
                        PrintAllContents(sides.Count());
                    }

                    sw.Stop();
                    totalTicks += sw.ElapsedTicks;
                    Console.WriteLine($"The algorithm took {sw.ElapsedTicks} ticks to complete your request!");
                    Console.WriteLine();

                    Console.WriteLine($"The algorithm took a total of {totalTicks} ticks to complete!");
                    break;
                }
            }
        }
        public static void PrismSorter(int key, HashSet<Item> Set)
        {
            // Create

            var side = sides.Count() + 1;
            if (!prismSorter.ContainsKey(key))
            {
                prismSorter[key] = new Dictionary<int, HashSet<Item>>
                {
                    { key, Set }
                };
            }
            sides.Add(side);
            if (!KeyToSide.ContainsKey(key))
            {
                KeyToSide.Add(key, side);
            }
            Console.WriteLine($"New collection added on the {side}{OrdinalChecker(side)} side of the {side}-side prism!");
            Console.WriteLine($"You can access it with {key} key!");
            Console.WriteLine();
        }
        public static void PrintAllContents(int sides)
        {
            // Read All

            foreach (var item in prismSorter)
            {
                if (KeyToSide.ContainsKey(item.Key))
                {
                    var side = KeyToSide[item.Key];
                    Console.Write($"{side}{OrdinalChecker(side)} side contents: ");
                }
                foreach (var items in item.Value)
                {
                    Console.WriteLine(string.Join(", ", items.Value));
                }
                Console.WriteLine();
            }
        }
        public static void ShowPrismSide(int key)
        {
            // Read Specific

            foreach (var item in prismSorter)
            {
                if (item.Key == key)
                {
                    foreach (var items in item.Value)
                    {
                        Console.WriteLine(string.Join(", ", items.Value));
                    }
                }
            }
            Console.WriteLine();
        }
        public static void EditPrismSideCollection(int key, Stopwatch sw)
        {
            // Edit and Delete

            HashSet<Item> itemsSet = new HashSet<Item>();
            foreach (var item in prismSorter)
            {
                if (item.Key == key)
                {
                    foreach (var items in item.Value)
                    {
                        itemsSet = items.Value;
                    }
                }
            }
            Console.Write("You requested the following collection: ");
            Console.WriteLine(string.Join(", ", itemsSet));

            Console.WriteLine("Add more elements to the collection, change an element at a certain index or delete an item from the collection!");

            Console.WriteLine($"Type in Add, Change or Delete");

            sw.Stop();

            string command = Console.ReadLine();

            sw.Start();

            if (command.ToLower() == "add")
            {
                Console.Write("Write a new element you'd like to add: ");

                sw.Stop();

                var element = Console.ReadLine();

                sw.Start();

                itemsSet.Add(element);
            }
            if (command.ToLower() == "change")
            {
                Console.WriteLine($"Choose element index from 0 to {itemsSet.Count() - 1}");

                sw.Stop();

                int index = int.Parse(Console.ReadLine());

                sw.Start();

                var element = itemsSet.ElementAt(index);
                Console.WriteLine($"You chose to edit {element} at {index} position!");

                Console.WriteLine("Replace the element with a new one");

                sw.Stop();

                var replaceWith = Console.ReadLine();

                sw.Start();

                itemsSet.Remove(element);
                itemsSet.Add(replaceWith);
                Console.WriteLine("Item successfully changed!");
            }
            if (command.ToLower() == "delete")
            {
                Console.WriteLine($"Choose element index from 0 to {itemsSet.Count() - 1}");

                sw.Stop();

                int index = int.Parse(Console.ReadLine());

                sw.Start();

                var element = itemsSet.ElementAt(index);

                Console.WriteLine($"You chose to delete {element} at {index} position!");

                Console.WriteLine($"Are you sure you want to remove {element}? Y/N");

                sw.Stop();

                string answer = Console.ReadLine();

                sw.Start();

                if (answer.ToUpper() == "Y")
                {
                    itemsSet.Remove(element);
                    Console.WriteLine("Item is removed!");
                }
                else
                {
                    Console.WriteLine("Item is not removed!");
                }
            }

        }
        public static string OrdinalChecker(int side)
        {
            switch (side % 10)
            {
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                default:
                    return "th";
            }
        }
    }
    enum Kind
    {
        Int,
        String,
        DateTime,
        Char
    }

    class Item
    {
        int intValue;
        string stringValue;
        DateTime dateTimeValue;
        char charValue;
        Kind kind;

        public object Value
        {
            get
            {
                switch (kind)
                {
                    case Kind.Int:
                        return intValue;
                    case Kind.String:
                        return stringValue;
                    case Kind.DateTime:
                        return dateTimeValue;
                    case Kind.Char:
                        return charValue;
                    default:
                        return null;
                }

            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        // Implicit construction
        public static implicit operator Item(int i)
        {
            return new Item { intValue = i, kind = Kind.Int };
        }
        public static implicit operator Item(string s)
        {
            return new Item { stringValue = s, kind = Kind.String };
        }
        public static implicit operator Item(DateTime dt)
        {
            return new Item { dateTimeValue = dt, kind = Kind.DateTime };
        }
        public static implicit operator Item(char c)
        {
            return new Item { charValue = c, kind = Kind.Char };
        }

        // Implicit value reference
        public static implicit operator int(Item item)
        {
            if (item.kind != Kind.Int) // Optionally, you could validate the usage
            {
                throw new InvalidCastException("Trying to use a " + item.kind + " as an int");
            }
            return item.intValue;
        }
        public static implicit operator string(Item item)
        {
            return item.stringValue;
        }
        public static implicit operator DateTime(Item item)
        {
            return item.dateTimeValue;
        }
        public static implicit operator char(Item item)
        {
            return item.charValue;
        }
    }
}
