using Day22;

var input = new Content().Get;
var bricks = new List<Brick>();

foreach (var item in input)
{
    bricks.Add(new Brick(item));
}

var result = new BrickMapper(bricks).GetSortedBricks.Where(x => x.HasBrickOnIt == false).Count();



Console.WriteLine();