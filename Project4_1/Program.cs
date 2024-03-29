using Project_4_1;

namespace HelloWorld
{
    class Hello {         
        static void Main(string[] args)
        {
            OneDimArray<int> intArray = new OneDimArray<int>();
            OneDimArray<string> stringArray = new OneDimArray<string>();
            
            intArray.AddElement(5);
            intArray.AddElement(4);
            intArray.AddElement(3);
            intArray.AddElement(2);
            intArray.AddElement(1);
            
            stringArray.AddElement("41");
            stringArray.AddElement("62");
            stringArray.AddElement("83");
            stringArray.AddElement("14");
            stringArray.AddElement("35");
            
            Console.WriteLine("Int Array:");
            foreach (var element in intArray)
            {
                Console.WriteLine(element);
            }
            
            Console.WriteLine("String Array:");
            foreach (var element in intArray)
            {
                Console.WriteLine(element);
            }
            
            intArray.Sort();
            stringArray.Sort();
            
            Console.WriteLine("Int Array after sort:");
            foreach (var element in intArray)
            {
                Console.WriteLine(element);
            }
            
            Console.WriteLine("String Array after sort:");
            foreach (var element in intArray)
            {
                Console.WriteLine(element);
            }

            intArray.GetMax();
            intArray.GetMin();

            stringArray.GetMax();
            stringArray.GetMin();
            
            // List<Int32> new_list = stringArray.Select(element => element is int).ToList(); - получение int элементов из string массива с помощью запроса LINQ
            // List<String> new_list2 = intArray.Select(element => element is string).ToList(); - получение string элементов из int массива с помощью запроса LINQ
            
            // stringArray.Select(element => Convert.ToInt32(element)).Max(); - поиск максимального элемента в string массиве по проекции в int с помощью запроса LINQ
            // stringArray.Select(element => Convert.ToInt32(element)).Min(); - поиск минимального элемента в string массиве по проекции в int с помощью запроса LINQ

            // intArray.Select(element => element.ToString()).Max(); - поиск максимального элемента в int массиве по проекции в string с помощью запроса LINQ
            // intArray.Select(element => element.ToString()).Min(); - поиск минимального элемента в int массиве по проекции в string с помощью запроса LINQ

            // intArray.Select(element => element.ToString()).ToList(); - проекция элементов int массива к string с помощью запроса LINQ
            // stringArray.Select(element => Convert.ToInt32(element)).ToList(); - проекция элементов string массива к int с помощью запроса LINQ
        }
    }
}
