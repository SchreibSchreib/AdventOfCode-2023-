internal class ListBuilder
{
    public List<int> Get { get; }

    public ListBuilder(string line)
    {
        Get = GetList(line);
    }

    

    private List<int> GetList(string line) => line.Split(" ").Select(x => int.Parse(x)).Reverse().ToList();
    
}