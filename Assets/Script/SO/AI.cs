using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bubble
{
    [CreateAssetMenu (menuName = "Generator/Player/Create AI")]
    public class AI : ScriptableObject
    {
        [Header("AI Stats")]
        public string AIName;
        //public Side choose;
        private char[,] board = {
			{' ', ' ', ' '},
			{' ', ' ', ' '},
			{' ', ' ', ' '}
        };


        private char side;

        public class Move 
        {
            public int row, col, value;
        }

        private bool hasMoveLeft() 
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int evaluateBoard(char myside, char myenemy) 
        {
		
            // evaluates each row one by one
            for (int i = 0; i < 3; i++) {
                if(board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) {
                    if(board[i, 0] == myside) {
                        return 10;
                    } else if(board[i, 0] == myenemy) {
                        return -10;
                    }
                }
            }
            
            // evaluates each column one by one
            for (int i = 0; i < 3; i++) {
                if(board[0, i] == board[1, i] && board[1, i] == board[2, i]) {
                    if(board[0, i] == myside) {
                        return 10;
                    } else if(board[0, i] == myenemy) {
                        return -10;
                    }
                }
            }
            
            // evaluates diagonal line from top left to bottom right
            if(board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) {
                if(board[0, 0] == myside) {
                    return 10;
                } else if(board[0, 0] == myenemy) {
                    return -10;
                }
            }
            
            // evaluates diagonal line from top right to bottom left
            if(board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) {
                if(board[0, 2] == myside) {
                    return 10;
                } else if(board[0, 2] == myenemy) {
                    return -10;
                }
            }
            
            // tied
            return 0;
        }

        private int minimax(bool isPlayerOne, int depth, int alpha, int beta, char myside, char myenemy)
        {
            int score = evaluateBoard(myside, myenemy);
            
            if(score == 10){
                //maximizer wins
                
                return score - depth;
            }
            
            if(score == -10){
                //maximizer wins
                
                return score + depth;
            }
            
            if(hasMoveLeft() == false) {
                //tied
                
                return 0;
            }
            
            int best;
            char turn;
            
            if(isPlayerOne) {
                // maximizer
                best = -9999;
                turn = myside; 
            } else {
                // minimizer
                best = 9999;
                turn = myenemy; 
            }
            
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++){
                    if(board[i, j] == ' '){
                        board[i, j] = turn;
                        
                        int moveVal = minimax(!isPlayerOne, depth + 1, alpha, beta, myside, myenemy);
                        board[i, j] = ' ';
                        
                        if(isPlayerOne) {
                            //maximizer
                            if (moveVal > best)
                            {
                                best = moveVal;
                            }
                            if (best > alpha)
                            {
                                alpha = best;
                            }
                        } else {
                            //minimizer
                            if (moveVal < best)
                            {
                                best = moveVal;
                            }
                            if (best > beta)
                            {
                                beta = best;
                            }
                        }
                        
                        if(beta <= alpha) {
                            return best;
                        }
                    }
                }
            }
            
            return best;
        }

        
        private Move findBestMove(char myside, char myenemy) 
        {
            Move bestMove = new Move();
            char turn;
            bool isPlayerOne = true;
            
            if(isPlayerOne) {
                // maximizer
                
                turn = myside; // O
                bestMove.value = -9999;
            } else {
                // minimizer
                
                turn = myenemy; // X
                bestMove.value = 9999;
            }
            
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j <3; j++) {
                    if (board[i, j] == ' ') {
                        board[i, j] = turn;
                        
                        // recursive -> minimax
                        int moveVal = minimax(!isPlayerOne, 0, -9999, 9999, myside, myenemy);
                        
                        board[i, j] = ' ';
                        
                        if(isPlayerOne) {
                            //maximizer
                            if(moveVal > bestMove.value) {
                                bestMove.value = moveVal;
                                bestMove.row = i;
                                bestMove.col = j;
                            }
                        }
                        else {
                            //minimizer
                            if(moveVal < bestMove.value) {
                                bestMove.value = moveVal;
                                bestMove.row = i;
                                bestMove.col = j;
                            }
                        }
                    }
                }
            }
            
            return bestMove;
        }

        public Move AlphaBetaPruning(char me) 
        {
            char myside = me;
            char myenemy;
            if (myside == 'O')
            {
                myenemy = 'X';
            }
            else
            {
                myenemy = 'O';
            }
            
            Move nextMove = findBestMove(myside, myenemy);
            return nextMove;
        }

        public int GoAI(char side, char[,] grid)
        {
            board = grid;
            Move nextMove = AlphaBetaPruning(side);
            board[nextMove.row, nextMove.col] = side; 
            int pos = (nextMove.row*3) + nextMove.col;
            Debug.Log("AI choose" + nextMove.row + "and" + nextMove.col);
            return pos;
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
