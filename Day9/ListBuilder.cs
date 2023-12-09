internal class ListBuilder
{
    public List<int> Get { get; }

    public ListBuilder(string line)
    {
        Get = GetList(line);
    }

    // Part 1
    //private List<int> GetList(string line) => line.Split(" ").Select(x => int.Parse(x)).ToList();

    // Part 2
    private List<int> GetList(string line) => line.Split(" ").Select(x => int.Parse(x)).Reverse().ToList();
    
}