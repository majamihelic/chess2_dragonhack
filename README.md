# chess2_dragonhack
Chess game with slightly modified rules, randomized starting positions and various added quick time events.

1) PIECES
pieces are almost the same as in the standard chess game:
-king: moves one space at a time in any direction
-queen: moves any number of squares diagonally, horizontally, or vertically
-bishop: moves any number of squares diagonally
-dragon: moves in an ‘L-shape,’ two squares in a straight direction, and then one square perpendicular to that. Can jump over other pieces
-rook: moves any number of squares horizontally or vertically
-pawn: moves one square forward, captures diagonally one square forward
  
2) START OF GAME
Positions on the chessboard are not predetermined, except for the kings. Other pieces are randomly assigned to the tiles of the first two and last two rows of the chessboard.
The starting player is chosen at random.

3) SPECIAL EVENTS
There are three types of special events:
-extra move: catching this quick time event allows you to make one extra move.
-swap pieces: you may pick any two of your pieces and switch their positions (click on the respective pieces you might want to switch).
-explode: this event makes all the pieces on the 3*3 grid, at the center of which is the moved piece that triggered this event, explode, save for the two kings.

4) KNOWN BUGS
-miscounting remaining pieces on the board
-certain pieces not exploding even when in range
-swap qte might cause pieces to behave abnormally. if you encounter this issue, you may need to swap a piece or avoid clicking on the moving piece at all.

5) END OF GAME
As the modified rules and extra events make a traditional checkmate a move that no longer guarantee of the elimination of the king piece, we have decided that the game ends when one of the kings is eliminated.
