using LV4;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace LV4;
internal class Program
{
    static void Main(string[] args)
    {
        Dog.RunSimpleDemo();
        double[][] data =
        {
            new double[] {1.0, 2.0, 3.0},
            new double[] {4.0, 5.0, 6.0},
            new double[] {7.0, 8.0, 9.0}
        };
        Image img = new Image(data, 1000, 2000);

        img.Process();
        for (int i = 0; i < img.data.Length; i++)
        {
            for (int j = 0; j < img.data[i].Length; j++)
            {
                Console.Write($"{img.data[i][j]:F2} ");
            }
            Console.WriteLine();
        }
    }

}

public interface IProcessable
{
    public int Width { get; set; }
    public int Height { get; set; }

    public void Process();
}

public class Image : IProcessable
{
    public double[][] data;

    public Image(double[][] data, int width, int height)
    {
        this.data = data;
        Width = width;
        Height = height;
    }

    public int Width { get; set; }
    public int Height { get; set; }

    public void Process()
    {
        for(int i = 0; i < data.Length; i++)
        {
            for(int j = 0; j < data[i].Length; j++)
            {
                data[i][j] = 1 / data[i][j];
            }
        }
    }
}