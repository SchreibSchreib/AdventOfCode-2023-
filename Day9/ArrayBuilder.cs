internal class ArrayBuilder
{
    public List<int> Get { get; }

    public ArrayBuilder(string line)
    {
        Get = GetArray(line);
    }

    private List<int> GetArray(string line) => line.Split(" ").Select(x => int.Parse(x)).ToList();
    
}