using System.Runtime.ConstrainedExecution;
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

    public bool IsLeftToRight(string word, int row, int col)
    {
        if (word.Length + col > Grid.GridWidth)
            return false;
        for (int i = 0; i < word.Length; i++)
        {
            char letter = Grid.Cells[row, col + i].Letter;
            if (word[i] != letter)
                return false;
        }
        Console.WriteLine("Left-Right : " + word + " -- " + row + ", " + col);
        return true;
    }
    public bool IsRightToLeft(string word, int row, int col)
    {
        if (col - word.Length < 0)
            return false;
        if (word[0] != Grid.Cells[row, col].Letter)
            return false;
        string stringToCompare = new string("");
        for (int i = col; i > col - word.Length; i--)
        {
            stringToCompare += Grid.Cells[row, i].Letter;
        }
        if (!stringToCompare.Equals(word))
            return false;
        Console.WriteLine("Right-Left : " + word + " -- " + row + ", " + col);
        return true;
    }
    public bool IsTopToDown(string word, int row, int col)
    {
        if (word.Length + row > Grid.GridHeight)
            return false;
        for (int i = 0; i < word.Length; i++)
        {
            char letter = Grid.Cells[row + i, col].Letter;
            if (word[i] != letter)
                return false;
        }
        Console.WriteLine("Top-Down : " + word + " -- " + row + ", " + col);
        return true;
    }

        public bool IsDownToTop(string word, int row, int col)
    {
        if (row - word.Length + 1 < 0)
            return false;
        if (word[0] != Grid.Cells[row, col].Letter)
            return false;
        string stringToCompare = new string("");
        for (int i = row; i > row - word.Length; i--)
        {
            stringToCompare += Grid.Cells[i, col].Letter;
        }
        if (!stringToCompare.Equals(word))
            return false;
        Console.WriteLine("Down-Top : " + word + " -- " + row + ", " + col);
        return true;
    }

    public bool IsDownToLeft(string word, int row, int col)
    {
        if (row + word.Length > Grid.GridHeight || col + word.Length > Grid.GridWidth)
            return false;
        if (word[0] != Grid.Cells[row, col].Letter)
            return false;
        string stringToCompare = new string("");
        for (int i = 0; i < word.Length; i++)
        {
            stringToCompare += Grid.Cells[row, col].Letter;
            row++;
            col++;
        }
        if (!stringToCompare.Equals(word))
            return false;
        Console.WriteLine("Down-Left: " + word + " -- " + row + ", " + col);
        return true;
    }
        public bool IsTopToLeft(string word, int row, int col)
    {
        if (row - word.Length + 1 < 0 || col + word.Length > Grid.GridWidth)
            return false;
        if (word[0] != Grid.Cells[row, col].Letter)
            return false;
        string stringToCompare = new string("");
        for (int i = 0; i < word.Length; i++)
        {
            stringToCompare += Grid.Cells[row, col].Letter;
            row--;
            col++;
        }
        if (!stringToCompare.Equals(word))
            return false;
        Console.WriteLine("Top-Left: " + word + " -- " + row + ", " + col);
        return true;
    }

    public bool IsDownToRight(string word, int row, int col)
    {
        if (row + word.Length > Grid.GridHeight || col - word.Length + 1 < 0)
            return false;
        if (word[0] != Grid.Cells[row, col].Letter)
            return false;
        string stringToCompare = new string("");
        for (int i = 0; i < word.Length; i++)
        {
            stringToCompare += Grid.Cells[row, col].Letter;
            row++;
            col--;
        }
        if (!stringToCompare.Equals(word))
            return false;
        Console.WriteLine("Down-Right: " + word + " -- " + row + ", " + col);
        return true;
    }

        public bool IsTopToRight(string word, int row, int col)
    {
        if (row - word.Length + 1 < 0 || col - word.Length + 1 < 0)
            return false;
        if (word[0] != Grid.Cells[row, col].Letter)
            return false;
        string stringToCompare = new string("");
        for (int i = 0; i < word.Length; i++)
        {
            stringToCompare += Grid.Cells[row, col].Letter;
            row--;
            col--;
        }
        if (!stringToCompare.Equals(word))
            return false;
        Console.WriteLine("Top-Right: " + word + " -- " + row + ", " + col);
        return true;
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
        for (int i = 0; i < game.ListOfWords.Count; i++)
        {
            for (int j = 0; j < game.Grid.GridHeight; j++)
            {
                for (int k = 0; k < game.Grid.GridWidth; k++)
                {
                    game.IsLeftToRight(game.ListOfWords[i], j, k);
                    game.IsRightToLeft(game.ListOfWords[i], j, k);
                    game.IsTopToDown(game.ListOfWords[i], j, k);
                    game.IsDownToTop(game.ListOfWords[i], j, k);
                    game.IsDownToLeft(game.ListOfWords[i], j, k);
                    game.IsTopToLeft(game.ListOfWords[i], j, k);
                    game.IsDownToRight(game.ListOfWords[i], j, k);
                    game.IsTopToRight(game.ListOfWords[i], j, k);

                }
            }
        }
    }
}