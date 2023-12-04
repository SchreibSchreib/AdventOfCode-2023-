using Day3;

Content input = new Content();
Dictionary<int, int[]> indicesOfSymbols = new Dictionary<int, int[]>();
Dictionary<int, Dictionary<int, int>> indicesAndValueOfNumbers = new Dictionary<int, Dictionary<int, int>>();

for (int i = 0; i < input.Get.Length; i++)
{
    SignIndexer indicesSigns = new SignIndexer(input.Get[i], i);
    NumberIndexer indicesNumbers = new NumberIndexer(input.Get[i], i);

    indicesOfSymbols.Add(indicesSigns.Get.Item1, indicesSigns.Get.Item2);
    indicesAndValueOfNumbers.Add(indicesNumbers.Get.Item1, indicesNumbers.Get.Item2);
}

//still buggy (indexes string and not chars)
SearchMatrix searchMatrix = new SearchMatrix(indicesOfSymbols, indicesAndValueOfNumbers);
int result = searchMatrix.GetAvailableNumbers.Sum(x => x);

foreach (int i in searchMatrix.GetAvailableNumbers)
{
    Console.WriteLine(i);
}

Console.ReadLine();