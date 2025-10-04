# CrossWord Solver

### 1. Description

This program takes a well-formatted `.txt` file containing a crossword grid and a list of words, solves the crossword, and returns the word formed by the remaining letters.

### 2. Installation Setup

**Linux**

```
sudo apt update
sudo apt install -y dotnet-sdk-8.0
```

**Windows**

https://dotnet.microsoft.com/en-us/download/visual-studio-sdks

### 3. Usage

1. Place a properly formatted `.txt` file in the `crossword-solver/grids` folder.
   **Requirements for the `.txt` file:**
   - The grid must be at the very top of the file.
   - Each line of the grid must have the same number of characters.
   - There must be a blank line between the grid and the list of words.
   - Each word in the list should be on its own line.
   - Only use letters [a-zA-Z].
   - No extra content after the last word.
   - Example grids are provided in the folder.
2. Navigate to the project directory :

```
crossword-solver/crossworld-solver
```

3. Run the following command :

```
dotnet run "filename"
```

**Example**

```
dotnet run  grid1.txt
```

### 4. Contributing

This entire project was made by SirVincius

### 5. License

The content of this project may be used or modified by anyone for any purpose.
