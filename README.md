Based on my analysis of the repository, here's a comprehensive README for the Guess-Game project:

---

# 🎮 Guess Game

A console-based number guessing game developed in C# with user management, scoring system, and persistent data storage. Challenge yourself to guess the random number before running out of chances!

## 📋 Table of Contents

- [Features](#-features)
- [Technologies Used](#-technologies-used)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [How to Play](#-how-to-play)
- [Game Mechanics](#-game-mechanics)
- [Project Structure](#-project-structure)
- [Commands](#-commands)
- [Data Storage](#-data-storage)
- [Contributing](#-contributing)
- [License](#-license)

## ✨ Features

### 🎯 Core Gameplay
- **Number Guessing**: Guess the randomly generated number
- **Two Difficulty Levels**:
  - Easy Mode: Numbers between 1-100
  - Hard Mode: Numbers between 1-1000
- **Limited Chances**: 4 attempts per number
- **Real-time Feedback**: Get hints (higher/lower) after each guess

### 📊 Scoring System
- Dynamic score calculation based on remaining chances
- Easy mode: 10 points per remaining chance
- Hard mode: 50 points per remaining chance
- Best score tracking for each player

### 👥 User Management
- User registration with name, gender, and age
- Persistent user data storage
- Search users by name
- Filter users by age range
- View all registered players

### 🏆 Leaderboard
- Top 5 best players display
- Individual best record tracking
- Game statistics (total games, correct guesses)

### 💡 Help System
- In-game hints available
- Costs 5 points to use
- Shows number range (±5 from actual number)

### 💾 Data Persistence
- Automatic save/load functionality
- Stores all player data in text file
- Maintains game history and statistics

## 🛠 Technologies Used

| Technology | Purpose |
|------------|---------|
| C# | Programming language |
| .NET Framework | Runtime environment |
| Console Application | User interface |
| File I/O | Data persistence |

## 📦 Prerequisites

Before running this project, ensure you have:

- [Visual Studio](https://visualstudio.microsoft.com/) (2019 or later) OR
- [.NET Framework](https://dotnet.microsoft.com/download) (4.0 or higher)
- Windows Operating System

## 🚀 Installation

### 1. Clone the Repository

```bash
git clone https://github.com/Kowsari1382/Guess-Game.git
cd Guess-Game
```

### 2. Open in Visual Studio

1. Open Visual Studio
2. Click on "Open a project or solution"
3. Navigate to the cloned repository
4. Select `GuessGame.sln`
5. Click "Open"

### 3. Build and Run

- Press `F5` or click "Start" button
- Or build the project first (`Ctrl+Shift+B`) then run

### Alternative: Command Line

```bash
# Navigate to project directory
cd GuessGame/GuessGame

# Build the project
csc Program.cs Game.cs GuessGame.cs

# Run the executable
GuessGame.exe
```

## 🎮 How to Play

### 1. Registration

When you start the game, you'll be prompted to enter:
- **Name**: Your username
- **Sex**: `m` for male, `w` for female
- **Age**: Your age (numeric)
- **Difficulty**: `0` for Easy, `1` for Hard

### 2. Main Menu

After registration, you'll see the main menu with options 0-7:

```
if you want to start game, input 0
else, input a number between 1 to 6
if you want to see guide, input 7
```

### 3. Playing the Game

1. Enter `0` to start a new game
2. The game generates a random number
3. Enter your guess
4. Receive feedback:
   - "Enter a bigger number" - your guess is too low
   - "Enter a smaller number" - your guess is too high
   - "Correct!" - you guessed right!
5. You have 4 chances per number
6. If you fail, the game ends and shows your score

### 4. Using Help

During gameplay, type `help` to get a hint:
- Costs 5 points from your score
- Shows the range: (number - 5) to (number + 5)
- Only available if you have at least 5 points

## ⚙️ Game Mechanics

### Difficulty Levels

| Level | Number Range | Points per Chance |
|-------|--------------|-------------------|
| Easy (0) | 1 - 100 | 10 points |
| Hard (1) | 1 - 1000 | 50 points |

### Scoring Formula

```
Score = Remaining Chances × Points per Chance
```

**Example (Easy Mode):**
- If you guess correctly with 3 chances remaining: 3 × 10 = 30 points
- If you guess correctly with 1 chance remaining: 1 × 10 = 10 points

### Chances System

- Each number gives you **4 chances**
- After each wrong guess, chances decrease by 1
- When chances reach 0, the game ends
- Correct guess resets chances to 4 for the next number

### Continuous Play

- After each round, you can choose to play again
- Your score accumulates across rounds
- Statistics are tracked (total games, correct guesses)

## 📁 Project Structure

```
Guess-Game/
├── GuessGame/
│   ├── GuessGame/
│   │   ├── Properties/          # Assembly info and resources
│   │   ├── bin/Debug/           # Compiled binaries
│   │   ├── obj/Debug/           # Build objects
│   │   ├── App.config           # Application configuration
│   │   ├── Game.cs              # Abstract base class
│   │   ├── GuessGame.cs         # Main game logic
│   │   ├── GuessGame.csproj     # Project file
│   │   └── Program.cs           # Entry point
│   └── GuessGame.sln            # Solution file
└── README.md
```

### File Descriptions

| File | Description |
|------|-------------|
| `Program.cs` | Main entry point, handles user input and menu navigation |
| `Game.cs` | Abstract base class defining game structure |
| `GuessGame.cs` | Concrete implementation with game logic and user management |
| `GuessGame.sln` | Visual Studio solution file |
| `GuessGame.csproj` | Project configuration file |

## 🎯 Commands

### Main Menu Commands

| Command | Action |
|---------|--------|
| `0` | Start/Play game |
| `1` | Print all users |
| `2` | Search users by name |
| `3` | Print top 5 best players |
| `4` | Search users by age range |
| `5` | Print best record for a specific user |
| `6` | Exit game |
| `7` | Show help/guide |

### In-Game Commands

| Command | Action |
|---------|--------|
| `help` | Get a hint (costs 5 points) |
| `y` | Play another round after game over |
| `n` | Return to main menu |
| Number | Your guess |

## 💾 Data Storage

### File Location

The game saves data to: `C:\New folder\GuessGame.txt`

**Note**: Make sure this directory exists, or modify the path in `GuessGame.cs`

### Data Format

Each line in the file represents one user with comma-separated values:

```
difficulty,number_of_true_guesses,score,name,sex,age,number_of_games,best_score
```

**Example:**
```
0,15,250,John,m,25,10,250
1,8,400,Jane,w,22,5,400
```

### Data Fields

| Field | Description |
|-------|-------------|
| difficulty | 0 (Easy) or 1 (Hard) |
| number_of_true_guesses | Total correct guesses |
| score | Current total score |
| name | Username |
| sex | Gender (m/w) |
| age | User's age |
| number_of_games | Total games played |
| best_score | Highest score achieved |

## 🔧 Configuration

### Changing Data File Path

To change where game data is saved, modify these methods in `GuessGame.cs`:

**SaveFile() method:**
```csharp
StreamWriter sw = new StreamWriter("YOUR_PATH_HERE\\GuessGame.txt");
```

**LoadFile() method:**
```csharp
StreamReader sr = new StreamReader("YOUR_PATH_HERE\\GuessGame.txt");
```

### Adjusting Difficulty

To change the number ranges, modify `GenerateRandomNumber()` in `GuessGame.cs`:

```csharp
public void GenerateRandomNumber(int dificulty)
{
    Random rn = new Random();
    if (dificulty == 0)
    {
        rndNumber = rn.Next(100);  // Change this value
    }
    else
    {
        rndNumber = rn.Next(1000); // Change this value
    }
}
```

### Changing Chances

To adjust the number of attempts, modify the constructor in `GuessGame.cs`:

```csharp
chances = 4;  // Change this value
```

## 🐛 Troubleshooting

### Issue: "Error in loading file!"

**Solution**: 
- Ensure the directory `C:\New folder\` exists
- Or change the file path in the code (see Configuration section)

### Issue: Game won't start

**Solution**:
- Make sure .NET Framework is installed
- Try rebuilding the solution in Visual Studio

### Issue: Data not saving

**Solution**:
- Check if you have write permissions to the directory
- Verify the file path is correct

## 🤝 Contributing

Contributions are welcome! Here's how you can help:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Ideas for Contributions

- Add more difficulty levels
- Implement a GUI version
- Add multiplayer mode
- Create a web-based version
- Add more statistics and analytics
- Implement achievements system
- Add sound effects
- Create a timer-based challenge mode

## 📝 License

This project is open source and available for educational purposes.

## 👨‍💻 Author

**Sajjad Kowsari**

- GitHub: [@Kowsari1382](https://github.com/Kowsari1382)

## 📞 Support

If you encounter any issues or have questions:

1. Check the [Troubleshooting](#-troubleshooting) section
2. Open an issue on GitHub
3. Contact the author

## 🎓 Learning Outcomes

This project demonstrates:

- Object-Oriented Programming (OOP) concepts
- Abstract classes and inheritance
- File I/O operations
- Console application development
- Data structures (Lists, Arrays)
- Exception handling
- User input validation
- Game logic implementation

## 🙏 Acknowledgments

- Built with C# and .NET Framework
- Inspired by classic number guessing games

---

<div align="center">

**Enjoy the game and happy guessing! 🎲**

**If you like this project, please consider giving it a ⭐!**

</div>

---

This README provides comprehensive documentation for the Guess-Game project, making it easy for anyone to understand, install, and play the game. The structured format with clear sections, tables, and code examples ensures a smooth experience for both players and developers.
