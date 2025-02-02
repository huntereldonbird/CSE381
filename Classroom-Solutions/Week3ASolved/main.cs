// CSE 381 REPL 3A Solution
// Selection Sort

public static class SelectionSort
{
    public static void Sort<T>(List<T> data) where T : IComparable
    {
        for (var start = 0; start < data.Count-1; start++)
        {
            var smallest = start;
            for (var compare = start + 1; compare < data.Count; compare++)
            {
                if (data[compare].CompareTo(data[smallest]) < 0)
                {
                    smallest = compare;
                }            
            }

            (data[start], data[smallest]) = (data[smallest], data[start]);
        }
    }
}

public static class InsertionSort
{
    public static void Sort<T>(List<T> data) where T : IComparable
    {
        for (var start = 1; start < data.Count; start++)
        {
            var item = data[start];
            var insert = start - 1;
            while (insert > -1 && data[insert].CompareTo(item) > 0)
            {
                data[insert + 1] = data[insert];
                insert -= 1;
            }
            data[insert + 1] = item;
        }
    }
}

public static class Program 
{
    public static void Main (string[] args) 
    {    
        var data1 = new List<int>() {
            3, 5, 2, 6, 1, 4};
        SelectionSort.Sort(data1);
        Console.WriteLine(String.Join(", ", data1));

        var data2 = new List<int>() {
            1, 2, 3, 4, 5, 6};
        SelectionSort.Sort(data2);
        Console.WriteLine(String.Join(", ", data2));

        var data3 = new List<String>() {
            "cow", "dog", "pig", "cat", "deer"};
        SelectionSort.Sort(data3);
        Console.WriteLine(String.Join(", ", data3));

        Console.WriteLine("----");

        var data4 = new List<int>() {
            3, 5, 2, 6, 1, 4};
        SelectionSort.Sort(data4);
        Console.WriteLine(String.Join(", ", data4));

        var data5 = new List<int>() {
            1, 2, 3, 4, 5, 6};
        SelectionSort.Sort(data5);
        Console.WriteLine(String.Join(", ", data5));

        var data6 = new List<String>() {
            "cow", "dog", "pig", "cat", "deer"};
        SelectionSort.Sort(data6);
        Console.WriteLine(String.Join(", ", data6));
    }
}



