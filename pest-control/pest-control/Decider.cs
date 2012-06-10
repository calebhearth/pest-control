using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pest_control
{
    public class Decider
    {
        private static Random rand = new Random();
        private enum Concern { food, water, sex, fear, agression };
        public Direction decide(Attributes attributes, List<Thing> nearbyThings, BoundingBox location)
        {
            switch (MostImportantConcern(attributes, nearbyThings))
            {
                case Concern.food:
                    foreach (Thing thing in nearbyThings)
                        if (thing is Terrain)
                            if ((thing as Terrain).terrainType == TerrainType.Tree)
                                return GetNearestDirection(location, thing.BoundingBox);
                    return (Direction)0;
                case Concern.water:
                    break;
                case Concern.sex:
                    break;
                case Concern.fear:
                    break;
                case Concern.agression:
                    break;
            }

            return (Direction)rand.Next(8) + 1;
        }

        private Direction GetNearestDirection(BoundingBox from, BoundingBox to)
        {
            // Negate X and Y values
            double deltaX = to.TopLeft.X - from.TopLeft.X;
            double deltaY = to.TopLeft.Y - from.TopLeft.Y;
            double angle = 0.0;

            // Calculate the angle
            if (deltaX == 0.0)
            {
                if (deltaY == 0.0)
                    angle = 0.0;
                else if (deltaY > 0.0) 
                    angle = System.Math.PI / 2.0;
                else
                    angle = System.Math.PI * 3.0 / 2.0;
            }
            else if (deltaY == 0.0)
            {
                if (deltaX > 0.0)
                    angle = 0.0;
                else
                    angle = System.Math.PI;
            }
            else
            {
                if (deltaX < 0.0)
                    angle = System.Math.Atan(deltaY / deltaX) + System.Math.PI;
                else if (deltaY < 0.0)
                    angle = System.Math.Atan(deltaY / deltaX) + (2 * System.Math.PI);
                else
                    angle = System.Math.Atan(deltaY / deltaX);
            }
            if (angle == 2 * Math.PI)
                return Direction.Up;
            else
                return (Direction)(int)(angle / (0.25 * Math.PI));
        }

        private Concern MostImportantConcern(Attributes attributes, List<Thing> nearbyThings)
        {
            return Concern.food;
        }

        private static double LargestOf(params double[] values)
        {
            double currentValue = 0;
            foreach (double value in values)
            {
                if (value > currentValue)
                    currentValue = value;
            }
            return currentValue;
        }


        private double Normalize(int value, int maxValue)
        {
            return Clamp(value / maxValue);
        }

        private double Clamp(double value)
        {
            if (value < 0)
                return 0;
            else if (value > 1)
                return 1;
            else
                return value;
        }
    }
}
