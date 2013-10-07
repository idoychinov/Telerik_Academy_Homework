using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{

    // Problem 4. Create a class Path to hold a sequence of points in the 3D space. Create a static class PathStorage with static methods to save and load paths from a text file. 
    //Use a file format of your choice.

    public static class PathStorage
    {
        public static void SavePaths(Path path, string fileLocation)
        {
            StreamWriter writer = new StreamWriter(fileLocation, true);
            using (writer)
            {
                foreach (var item in path.Path)
                {
                    writer.WriteLine(item);
                }
            }
        }

        public static Path LoadPaths(string fileLocation)
        {
            StreamReader reader = new StreamReader(fileLocation);
            Path result = new Path();
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] clearLine = line.Split(new char[] {'{',' ','}',','} , StringSplitOptions.RemoveEmptyEntries);
                    int[] pointCoordinates = clearLine.Select(s => int.Parse(s)).ToArray();
                    result.Path.Add(new Point3D(pointCoordinates[0],pointCoordinates[1],pointCoordinates[2]));
                }

                if (result.Path == null)
                {
                    throw new InvalidDataException("The specified file doesn't contain any path information");
                }

                return result;

            }
        }

    }
}
