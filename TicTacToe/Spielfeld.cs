using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TicTacToe
{
    class Spielfeld
    {
        private readonly FieldState[,] board;
        private bool currentPlayerID;
        private byte turnCounter;

        public bool GetCurrentPlayer()
        {
            return currentPlayerID;
        }
        public FieldState[,] GetBoard()
        {
            return board;
        }
        public Spielfeld()
        {
            board = new FieldState[3, 3];
            Reset();
        }

        public void Reset()
        {
            Array.Clear(board, 0, board.Length);
            currentPlayerID = DateTime.Now.Millisecond % 2 == 0;
            turnCounter = 0;
        }

        public TurnResult Turn(Point Coordinates)
        {
            if (board[Coordinates.Y, Coordinates.X] == FieldState.O || board[Coordinates.Y, Coordinates.X] == FieldState.X)// wenn an mitgelieferten koordinaten bereits X oder O steht
                return TurnResult.Invalid;//      Methodenende und rückgabe von Invalid
            turnCounter++;// zugzähler um 1 erhöhen

            // wenn aktueller spieler true
            //      an koordinaten ein X schreiben
            // andernfalls
            //      an koordinaten ein O schreiben
            board[Coordinates.Y, Coordinates.X] = (currentPlayerID ? FieldState.X : FieldState.O);

            // wenn in einer der spalten 3 gleiche oder in einer der zeilen 3 gleiche oder in einer der beiden diagonalen 3 gleiche
            if (// horizontale tests
                (board[0, 0] != FieldState.Empty && board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2]) ||
                (board[1, 0] != FieldState.Empty && board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2]) ||
                (board[2, 0] != FieldState.Empty && board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2]) ||
                // vertikale tests           
                (board[0, 0] != FieldState.Empty && board[1, 0] == board[0, 0] && board[2, 0] == board[0, 0]) ||
                (board[0, 1] != FieldState.Empty && board[1, 1] == board[0, 1] && board[2, 1] == board[0, 1]) ||
                (board[0, 2] != FieldState.Empty && board[1, 2] == board[0, 2] && board[2, 2] == board[0, 2]) ||
                // diagonale tests              
                (board[0, 0] != FieldState.Empty && board[1, 1] == board[0, 0] && board[2, 2] == board[0, 0]) ||
                (board[0, 2] != FieldState.Empty && board[1, 1] == board[0, 2] && board[2, 0] == board[0, 2]))
            {
                return TurnResult.Win; //      Methodenende und rückgabe von Win
            }

            if (turnCounter == 9) // wenn zuganzahl gleich  9
                return TurnResult.Tie;//      Methodenende und rückgabe von Tie
            currentPlayerID = !currentPlayerID;
            return TurnResult.Valid;// rückgabe von valid
        }


    }
}
