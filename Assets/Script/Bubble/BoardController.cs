using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubble
{
    public class BoardController : MonoBehaviour
    {
        public Game main;

        public List<GridSpace> Grid = new List<GridSpace>();

        char[,] board = {
			{' ', ' ', ' '},
			{' ', ' ', ' '},
			{' ', ' ', ' '}
        };

        public void Choose(int x, int y, char symbol)
        {
            board[x, y] = symbol;
            main.FinishChoose();
        }

        public void AIChoose(int x, int y, char symbol)
        {
            board[x, y] = symbol;
        }

        public int evaluateBoard() 
        {
		
            // evaluates each row one by one
            for (int i = 0; i < 3; i++) {
                if(board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) {
                    if(board[i, 0] == 'X') {
                        return 10;
                    } else if(board[i, 0] == 'O') {
                        return -10;
                    }
                }
            }
            
            // evaluates each column one by one
            for (int i = 0; i < 3; i++) {
                if(board[0, i] == board[1, i] && board[1, i] == board[2, i]) {
                    if(board[0, i] == 'X') {
                        return 10;
                    } else if(board[0, i] == 'O') {
                        return -10;
                    }
                }
            }
            
            // evaluates diagonal line from top left to bottom right
            if(board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) {
                if(board[0, 0] == 'X') {
                    return 10;
                } else if(board[0, 0] == 'O') {
                    return -10;
                }
            }
            
            // evaluates diagonal line from top right to bottom left
            if(board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) {
                if(board[0, 2] == 'X') {
                    return 10;
                } else if(board[0, 2] == 'O') {
                    return -10;
                }
            }
            int empty = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        empty++;
                    }
                }
            }

            if (empty == 0)
            {
                return 0;
            }
            
            // tied
            return 50;
        }

        public char[,] getboard()
        {
            return this.board;
        }

        public void updateboard(char[,] Board)
        {
            this.board = Board;
        }

        public void RunAI(Side onturn, char side)
        {
            int pos = onturn.gamer.Comp.GoAI(side, board);

            foreach (GridSpace Button in Grid)
            {
                if (Button.getpos() == pos)
                {
                    Button.AIClick();
                    break;
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
    
}
