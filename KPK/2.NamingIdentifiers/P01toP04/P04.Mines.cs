using System;
using System.Collections.Generic;
using System.Linq;

namespace Mines
{
	public class Mines
	{
		public class Score
		{
			string name;
			int score;

			public string Name
			{
				get { return this.name; }
				set { this.name = value; }
			}

			public int Score
			{
				get { return this.score; }
				set { this.score = value; }
			}

			public Score() { }

			public Score(string name, int score)
			{
				this.name = name;
				this.score = score;
			}
		}

		static void Main(string[] arguments)
		{
			string command = string.Empty;
			char[,] field = CreatePlayField();
			char[,] bombs = PlaceBombs();
			int currentScore = 0;
			bool isDestroyedFlag = false;
			List<Score> champions = new List<Score>(6);
			int row = 0;
			int col = 0;
			bool newGameFlag = true;
			const int MAXIMUM_BLOCKS = 35;
			bool maximumBlocksReachedFlag = false;

			do
			{
				if (newGameFlag)
				{
					Console.WriteLine("Lets play \"Mines\". Try your luck with finding the blocks with no mines under them." +
					"Command 'top' shows the high scores, 'restart' starts a new game, 'exit' quits the game!");
					DrawField(field);
					newGameFlag = false;
				}
				Console.Write("Daj red i kolona : ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out col) &&
						row <= field.GetLength(0) && col <= field.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						HighScores(champions);
						break;
					case "restart":
						field = CreatePlayField();
						bombs = PlaceBombs();
						DrawField(field);
						isDestroyedFlag = false;
						newGameFlag = false;
						break;
					case "exit":
						Console.WriteLine("Bye, Bye!");
						break;
					case "turn":
						if (bombs[row, col] != '*')
						{
							if (bombs[row, col] == '-')
							{
								PlayerTurn(field, bombs, row, col);
								currentScore++;
							}
							if (MAXIMUM_BLOCKS == currentScore)
							{
								maximumBlocksReachedFlag = true;
							}
							else
							{
								DrawField(field);
							}
						}
						else
						{
							isDestroyedFlag = true;
						}
						break;
					default:
						Console.WriteLine("\nError. Invalid command\n");
						break;
				}
				if (isDestroyedFlag)
				{
					DrawField(bombs);
					Console.Write("\n Sorry! You have died with {0} points. " +
						"Please enter nickname: ", currentScore);
					string niknejm = Console.ReadLine();
					Score t = new Score(niknejm, currentScore);
					if (champions.Count < 5)
					{
						champions.Add(t);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].Score < t.Score)
							{
								champions.Insert(i, t);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}
					champions.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
					champions.Sort((Score r1, Score r2) => r2.Score.CompareTo(r1.Score));
					HighScores(champions);

					field = CreatePlayField();
					bombs = PlaceBombs();
					currentScore = 0;
					isDestroyedFlag = false;
					newGameFlag = true;
				}
				if (maximumBlocksReachedFlag)
				{
					Console.WriteLine("\nGood job! You passed "+MAXIMUM_BLOCKS+" 35 without stepping on a mine.");
					DrawField(bombs);
					Console.WriteLine("Enter your nickname: ");
					string name = Console.ReadLine();
					Score score = new Score(name, currentScore);
					champions.Add(score);
					HighScores(champions);
					field = CreatePlayField();
					bombs = PlaceBombs();
					currentScore = 0;
					maximumBlocksReachedFlag = false;
					newGameFlag = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Thank you for plaing!");
			Console.Read();
		}

		private static void HighScores(List<Score> score)
		{
			Console.WriteLine("\nScore:");
			if (score.Count > 0)
			{
				for (int i = 0; i < score.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} blocks",
						i + 1, score[i].Name, score[i].Score);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("High scores are empty!\n");
			}
		}

		private static void PlayerTurn(char[,] field,
			char[,] mines, int row, int col)
		{
			char numberOfMines = CountMines(mines, row, col);
			mines[row, col] = numberOfMines;
			field[row, col] = numberOfMines;
		}

		private static void DrawField(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < cols; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreatePlayField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceBombs()
		{
			int rows = 5;
			int cols = 10;
			char[,] playField = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					playField[i, j] = '-';
				}
			}

			List<int> mines = new List<int>();
			while (mines.Count < 15)
			{
				Random random = new Random();
				int mine = random.Next(50);
				if (!mines.Contains(mine))
				{
					mines.Add(mine);
				}
			}

			foreach (int mine in mines)
			{
				int col = (mine / cols);
				int row = (mine % cols);
				if (row == 0 && mine != 0)
				{
					col--;
					row = cols;
				}
				else
				{
					row++;
				}
				playField[col, row - 1] = '*';
			}

			return playField;
		}

		private static void Calculations(char[,] field)
		{
			int col = field.GetLength(0);
			int rol = field.GetLength(1);

			for (int i = 0; i < col; i++)
			{
				for (int j = 0; j < rol; j++)
				{
					if (field[i, j] != '*')
					{
						char count = CountMines(field, i, j);
						field[i, j] = count;
					}
				}
			}
		}

		private static char CountMines(char[,] mines, int row, int col)
		{
			int count = 0;
			int rows = mines.GetLength(0);
			int cols = mines.GetLength(1);

			if (row - 1 >= 0)
			{
				if (mines[row - 1, col] == '*')
				{ 
					count++; 
				}
			}
			if (row + 1 < rows)
			{
				if (mines[row + 1, col] == '*')
				{ 
					count++; 
				}
			}
			if (col - 1 >= 0)
			{
				if (mines[row, col - 1] == '*')
				{ 
					count++;
				}
			}
			if (col + 1 < cols)
			{
				if (mines[row, col + 1] == '*')
				{ 
					count++;
				}
			}
			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (mines[row - 1, col - 1] == '*')
				{ 
					count++; 
				}
			}
			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (mines[row - 1, col + 1] == '*')
				{ 
					count++; 
				}
			}
			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (mines[row + 1, col - 1] == '*')
				{ 
					count++; 
				}
			}
			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (mines[row + 1, col + 1] == '*')
				{ 
					count++; 
				}
			}
			return char.Parse(count.ToString());
		}
	}
}
