public class Extractor
{
    public string[] getFileContent(string filename)
    {
        string[] data = File.ReadAllLines(filename);
        string[] parsedData = new string[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            parsedData[i] = data[i].Replace(" ", "");
        }
        return parsedData;
    }
}

public class Grid
{
    public char[,] Cells { get; set; }
    public int GridWidth { get; set; }
    public int GridHeight { get; set; }

    public int getGridWidth(string[] data)
    {
        return data[0].Length;
    }

    public int getGridHeight(string[] data)
    {
        int numberOfRows = 0;
        while (data[numberOfRows] != "")
        {
            numberOfRows++;
        }
        return numberOfRows;
    }

    public Grid(string[] data)
    {
        this.GridWidth = getGridWidth(data);
        this.GridHeight = getGridHeight(data);
        this.Cells = new char[GridHeight, GridWidth];
        setGridLines(data);
    }

    public void setGridLines(string[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] == "")
                break;
            char[] lineToArray = data[i].ToCharArray();
            for (int c = 0; c < lineToArray.Length; c++)
                Cells[i, c] = lineToArray[c];
        }
    }

    public void printGrid()
    {
        for (int i = 0; i < GridHeight; i++)
        {
            for (int j = 0; j < GridWidth; j++)
            {
                Console.Write(Cells[i, j]);
            }
            Console.WriteLine("");
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Extractor extractor = new Extractor();
        string[] data = extractor.getFileContent("filename.txt");

        Grid grid = new Grid(data);
        Console.WriteLine($"Grid width = {grid.GridWidth}");
        Console.WriteLine($"Grid height = {grid.GridHeight}");
        grid.printGrid();
    }
}