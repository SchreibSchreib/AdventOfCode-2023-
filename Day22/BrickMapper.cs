namespace Day22
{
    internal class BrickMapper
    {
        List<Brick> GetSortedBricks { get; }

        public BrickMapper(List<Brick> allFlyingBricks)
        {
            GetSortedBricks = MapAndSort(allFlyingBricks);
        }

        private List<Brick> MapAndSort(List<Brick> allFlyingBricks)
        {
            List<Brick> result = Sort(allFlyingBricks);
            FindAndInsertCavities(result);
            result = FillCavitiesWithFallingBricks(result);
            return result;
        }



        private List<Brick> Sort(List<Brick> allFlyingBricks) => allFlyingBricks
            .OrderBy(x => x.CoordinatesZ[1])
            .ToList();

        private void FindAndInsertCavities(List<Brick> bricklistWithoutCavities)
        {
            int maxHeight = bricklistWithoutCavities.Last().CoordinatesZ[1];

            for (int index = 0; index < maxHeight; index++)
            {
                if (index == 0)
                {
                    bricklistWithoutCavities.Insert(index, new Brick());
                    continue;
                }
                if (bricklistWithoutCavities[index].CoordinatesZ[0] != index)
                {
                    bricklistWithoutCavities.Insert(index, new Brick());
                }
            }
        }

        private List<Brick> FillCavitiesWithFallingBricks(List<Brick> bricklistWithCavities)
        {
            int indexBrickBeforeCavity;
            int indexBrickAfterCavity;
            int gap;

            for (int index = 1; index < bricklistWithCavities.Count; index++)
            {
                if (bricklistWithCavities[index].CoordinatesZ != null) continue;
                indexBrickBeforeCavity = index - 1;
                indexBrickAfterCavity = GetNextBrick(index, bricklistWithCavities);
                gap = indexBrickAfterCavity - indexBrickBeforeCavity;
                if (LandsOnBrickBeforeCavity(bricklistWithCavities[indexBrickBeforeCavity],
                    bricklistWithCavities[indexBrickAfterCavity]))
                {
                    bricklistWithCavities.Insert(index, bricklistWithCavities[indexBrickAfterCavity]);
                    bricklistWithCavities.RemoveRange(indexBrickBeforeCavity + 2, gap);
                }
            }
            return bricklistWithCavities;
        }

        private int GetNextBrick(int index, List<Brick> brickListWithCavities)
        {
            do
            {
                index++;
            }
            while (brickListWithCavities[index].CoordinatesZ == null);

            return index;
        }

        private bool LandsOnBrickBeforeCavity(Brick brick1, Brick brick2)
        {
            bool overLapX = false;
            bool overLapY = false;

            for (int xCoordBrick1 = brick1.CoordinatesX[0]; xCoordBrick1 < brick1.CoordinatesX[1] + 1; xCoordBrick1++)
            {
                if (overLapX) break;
                for (int xCoordBrick2 = brick2.CoordinatesX[0]; xCoordBrick2 < brick2.CoordinatesX[1] + 1; xCoordBrick2++)
                {
                    if (xCoordBrick1 == xCoordBrick2) overLapX = true;
                }
            }
            for (int yCoordBrick1 = brick1.CoordinatesY[0]; yCoordBrick1 < brick1.CoordinatesY[1] + 1; yCoordBrick1++)
            {
                if (overLapY) break;
                for (int yCoordBrick2 = brick2.CoordinatesY[0]; yCoordBrick2 < brick2.CoordinatesY[1] + 1; yCoordBrick2++)
                {
                    if (yCoordBrick1 == yCoordBrick2) overLapY = true;
                }
            }
            return overLapX && overLapY;
        }
    }
}