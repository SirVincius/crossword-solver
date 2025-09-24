using System.Runtime.InteropServices;

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

public class Cell
{
    public char Letter { get; set; }
    public bool Used { get; set; } = false;
}

public class Grid
{
    public Cell[,] Cells { get; set; }
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
        this.Cells = new Cell[GridHeight, GridWidth];
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
            {
                Cell cell = new Cell();
                cell.Letter = lineToArray[c];
                Cells[i, c] = cell;
            }
        }
    }

    public void printGrid()
    {
        Console.WriteLine("Grid\n\n");
        for (int i = 0; i < GridHeight; i++)
        {
            for (int j = 0; j < GridWidth; j++)
            {
                Console.Write(Cells[i, j].Letter);
            }
            Console.WriteLine("");
        }
    }
}

public class Game
{
    public Grid Grid { get; set; }
    public List<string> ListOfWords { get; set; }
    public string Solution { get; set; }

    public List<string> setListOfWords(string[] data)
    {
        List<string> listOfWords = new List<string>();
        bool isWord = false;
        for (int i = 0; i < data.Length; i++)
        {
            if (isWord)
                listOfWords.Add(data[i]);
            if (data[i] == "")
                isWord = true;
        }
        return listOfWords;
    }

    public void printGame()
    {
        Grid.printGrid();
        Console.WriteLine("\n\nList of words\n\n");
        foreach(string s in ListOfWords)
        {
            Console.WriteLine(s);
        }
    }

    public Game(string[] data)
    {
        this.Grid = new Grid(data);
        this.ListOfWords = setListOfWords(data);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Extractor extractor = new Extractor();
        string[] data = extractor.getFileContent("filename.txt");

        Game game = new Game(data);
        game.printGame();
    }
}