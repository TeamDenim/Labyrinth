#"Escape from Labyrinth" Game

###High Quality Code teamwork project

Your task is to write an interactive console-based game in which the player should escape from a labyrinth of size *7 x 7 cells*. Each cell is either free ('-') or occupied ('X'). The labyrinth should consist of randomly generated free and occupied cells and the player's position is initially in its center. 

The player is shown as '\*'. In the randomly generated labyrinth at least one exit should always be reachable by a sequence of moves in the standard 4 directions: left, right, up, down. At each turn, the player enters a single letter – the direction to follow (**L** - left, **R** - right, **U** - up, **D** - down). *Directions can be given by small or capital letters.* As a response, the computer either moves the player position to the specified empty cell or indicates that the cell is occupied and the requested move is illegal. If the player's position reaches some of the labyrinth's walls, the game is considered finished. When the game is finished, the number of moves is printed along with congratulations message and a new game automatically starts.
The player can request starting a new game in a new labyrinth by entering the command **'restart'**. 

Your program should implement a local top scoreboard, which keeps the best results and the names of their authors. Initially, at the program start, the scoreboard is empty. It keeps the top 5 results sorted in *ascending* order by the number of *valid* moves performed. When a game is finished by exiting from the labyrinth, the player's result can enter in the top scoreboard if his or her number of moves is *less* than some of the other achievements staying in the top scoreboard. When the player's result enters the scoreboard, the player should enter his or her name or nickname. The player can request printing the top scoreboard during the game by entering the command **'top'**. The player can request stopping the game and exiting from the program the command **'exit'**.
