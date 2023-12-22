using Day22;

var input = new Content().Get;
var bricks = new List<Brick>();

foreach (var item in input)
{
    bricks.Add(new Brick(item));
}

var sortedBricks = new BrickMapper(bricks);

Console.WriteLine();