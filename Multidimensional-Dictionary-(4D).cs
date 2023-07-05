namespace MultidimensionalMatrix
{
    internal class MultiDimDict
    {
        public static void Create()
        {
          //<summary>
          // Multidimensional Dictionary with CRUD operations implemented (Update and Delete operations in progress)
          //<summary>
            var multiDimDict = new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, HashSet<string>>>>>();
            Dictionary<int, List<int>> keys = new Dictionary<int, List<int>>();
            var totalKeys = 0;

            while (true)
            {

                Console.WriteLine("To create new data in the 4d dict, enter E");
                Console.WriteLine("To read already existing data in the 4d dict, enter R");
                Console.WriteLine("To exit the program, enter T");
                string command = Console.ReadLine();

                if (command.ToUpper() == "E")
                {
                    List<string> data = new List<string>();

                    Console.Write("Enter size of list of data: ");
                    int n = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter data: ");
                    for (int i = 0; i < n; i++)
                    {
                        string inputData = Console.ReadLine();
                        data.Add(inputData);
                    }

                    totalKeys = PoppulateMultiDimDict(totalKeys, multiDimDict, keys, data);
                }
                if (command.ToUpper() == "R")
                {
                    Console.WriteLine("Available keys: ");
                    Console.WriteLine(string.Join(", ", keys.Keys));

                    Console.WriteLine("Enter key: ");
                    int key = int.Parse(Console.ReadLine());

                    if (keys.ContainsKey(key))
                    {
                        foreach (var item in keys)
                        {
                            if (item.Key == key)
                            {
                                foreach (var items in multiDimDict[item.Value[0]][item.Value[1]][item.Value[2]][item.Value[3]])
                                {
                                    Console.WriteLine(string.Join(", ", items));
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Key doesn't exist!");
                        continue;
                    }
                }
                if (command.ToUpper() == "T")
                {
                    break;
                }
            }
        }

        private static int PoppulateMultiDimDict(int totalKeys, Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, HashSet<string>>>>> multiDimDict, Dictionary<int, List<int>> keys, List<string> data)
        {
            Console.Write("Enter first key: ");
            int key = int.Parse(Console.ReadLine());
            // create new list in the nested dict

            if (!multiDimDict.ContainsKey(key) || multiDimDict.ContainsKey(key))
            {
                multiDimDict[key] = new Dictionary<int, Dictionary<int, Dictionary<int, HashSet<string>>>>();

                Console.Write("Enter second key: ");
                int secondKey = int.Parse(Console.ReadLine());

                if (!multiDimDict[key].ContainsKey(secondKey))
                {
                    multiDimDict[key][secondKey] = new Dictionary<int, Dictionary<int, HashSet<string>>>();

                    Console.Write("Enter third key: ");
                    int thirdKey = int.Parse(Console.ReadLine());

                    if (!multiDimDict[key][secondKey].ContainsKey(thirdKey))
                    {
                        multiDimDict[key][secondKey][thirdKey] = new Dictionary<int, HashSet<string>>();
                        Console.Write("Enter fourth key: ");
                        int fourthKey = int.Parse(Console.ReadLine());

                        if (!multiDimDict[key][secondKey][thirdKey].ContainsKey(fourthKey))
                        {
                            multiDimDict[key][secondKey][thirdKey][fourthKey] = new HashSet<string>(data);

                            if (!keys.ContainsKey(totalKeys))
                            {
                                keys[totalKeys] = new List<int>
                                        {
                                            key,
                                            secondKey,
                                            thirdKey,
                                            fourthKey
                                        };

                                Console.WriteLine("Successfuly created a Multidimensional Dictionary!");
                                Console.WriteLine($"Number of keys: {keys[totalKeys].Count()}");
                                Console.WriteLine($"Count of data in the inner list of the inner dict: {multiDimDict[key][secondKey][thirdKey][fourthKey].Count()}");
                            }
                            else
                            {
                                Console.WriteLine("Key already exists!");
                            }

                            totalKeys++;
                        }
                    }
                }
            }
            return totalKeys;
        }
    }
}
