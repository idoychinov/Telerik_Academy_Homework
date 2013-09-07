using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03Laser
{
    class P03Laser
    {
        class Cuboid
        {
            private bool[, ,] burned;
            private int width, height, depth;

            public bool CubeState(int w, int h, int d, bool set=false)
            {
                if (burned[w, h, d])
                {
                    return true;
                }
                else
                {
                    if (set)
                    {
                        burned[w , h , d ] = true;
                    }
                    return false;
                }
            }

            public Cuboid(string[] dimensions)
            {
                this.width = int.Parse(dimensions[0]);
                this.height = int.Parse(dimensions[1]);
                this.depth = int.Parse(dimensions[2]);
                burned = new bool[width, height, depth];
                for (int i = 0; i < width; i++)
                {
                    burned[i, 0, 0] = true;
                    burned[i, height - 1, 0] = true;
                    burned[i, 0, depth - 1] = true;
                    burned[i, height - 1, depth - 1] = true;
                }
                for (int i = 1; i < height - 1; i++)
                {
                    burned[0, i, 0] = true;
                    burned[width - 1, i, 0] = true;
                    burned[0, i, depth - 1] = true;
                    burned[width - 1, i, depth - 1] = true;
                }
                for (int i = 1; i < depth - 1; i++)
                {
                    burned[0, 0, i] = true;
                    burned[width - 1, 0, i] = true;
                    burned[0, height - 1, i] = true;
                    burned[width - 1, height - 1, i] = true;
                }
            }

            public bool Traverse(Laser laser)
            {

                int moveX = laser.Width + laser.VectorX;
                int moveY = laser.Height + laser.VectorY;
                int moveZ = laser.Depth + laser.VectorZ;

                

                if (this.CubeState(moveX, moveY, moveZ))
                {
                    //checks if burned
                    return false;
                }
                else
                {
                    laser.Width = moveX;
                    laser.Height = moveY;
                    laser.Depth = moveZ;
                    this.CubeState(laser.Width, laser.Height, laser.Depth, true);
                    return true;
                }
                
            }         

            internal void CheckReflect(Laser laser)
            {
                if ((laser.Width + laser.VectorX > this.width - 1) || (laser.Width + laser.VectorX < 0))
                {
                    laser.VectorX = laser.VectorX * (-1);
                }
                else if ((laser.Height + laser.VectorY > this.height - 1) || (laser.Height + laser.VectorY < 0))
                {
                    laser.VectorY = laser.VectorY * (-1);
                }
                else if ((laser.Depth + laser.VectorZ > this.depth - 1) || (laser.Depth + laser.VectorZ < 0))
                {
                    laser.VectorZ = laser.VectorZ * (-1);
                }
            }
        }

        class Laser
        {

            public int Width { get; set; }
            public int Height { get; set; }
            public int Depth { get; set; }
            public int VectorX { get; set; }
            public int VectorY { get; set; }
            public int VectorZ { get; set; }
            

            public Laser(string[] start, string[] vector)
            {
                this.Width = int.Parse(start[0])-1;
                this.Height = int.Parse(start[1])-1;
                this.Depth = int.Parse(start[2])-1;
                this.VectorX = int.Parse(vector[0]);
                this.VectorY = int.Parse(vector[1]);
                this.VectorZ = int.Parse(vector[2]);
            }
        }

        static void Main()
        {
            Cuboid cube = new Cuboid(ParseInputLine());
            Laser laser = new Laser(ParseInputLine(), ParseInputLine());

            cube.CubeState(laser.Width, laser.Height, laser.Depth, true);
            while (cube.Traverse(laser))
            {
                cube.CheckReflect(laser);
            }
            Console.WriteLine("{0} {1} {2}", laser.Width + 1, laser.Height + 1, laser.Depth + 1);
        }

        static string[] ParseInputLine()
        {
            return Console.ReadLine().Split();
        }
    }
}
