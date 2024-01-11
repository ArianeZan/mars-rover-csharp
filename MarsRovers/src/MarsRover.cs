using System.Collections;

namespace MarsRovers;

public class MarsRover
{
    public readonly string[,] Map = new string[5,5];
    public string Orientation = "E";
    public int[] Position = {0,0};
    public MarsRover()
    {
    }
    public string Execute(string commands)
    {
        if (commands.Equals("R"))
        {
            Orientation = "S";
            
        }
       return "";
    }
}