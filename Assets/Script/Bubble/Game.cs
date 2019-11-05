using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bubble
{
    public class Game : MonoBehaviour
    {
        public Side sidex;
        public Side sideo;
        int turn;
        int wait;
        int score;
        Side onturn;
       
        public Text textComponent;
        public Text textComponent2;
        public SceneSwitcher button;
        public BoardController Board;

        // Start is called before the first frame update
        void Start()
        {
            TurnOff(this.textComponent.gameObject);
            TurnOff(this.textComponent2.gameObject);
            TurnOff(button.gameObject);
            StartCoroutine(Play());
        }

        public void TurnOff(GameObject myText)
        {
            myText.gameObject.SetActive(false);
        }

        public void TurnOn(GameObject myText)
        {
            myText.gameObject.SetActive(true);
        }

        IEnumerator Play()
        {
            score = 50;
            turn = 1;
            wait = 0;
            for (int i = 0; i < 10; i++)
            {
                onturn = sidex;
                if (onturn.gamer.Player != null)
                {
                    yield return StartCoroutine(Xturn());
                }
                else
                {
                    runAI('X');
                }
                score = Board.evaluateBoard();

                if (score != 50)
                {
                    break;
                }

                onturn = sideo;
                if (onturn.gamer.Player != null)
                {
                    yield return StartCoroutine(Oturn());
                }
                else
                {
                    runAI('O');
                }
                score = Board.evaluateBoard();
                if (score != 50)
                {
                    break;
                }
                turn++;
            }
            UpdateText(score);
        }

        public void runAI(char side)
        {
            Board.RunAI(onturn, side);
        }

        IEnumerator Xturn()
        {
            Debug.Log("Xturn started");
            yield return StartCoroutine(WaitForAction());
            Debug.Log("Xturn started");
            this.wait = 0;
        }

        IEnumerator Oturn()
        {
            Debug.Log("Oturn started");
            yield return StartCoroutine(WaitForAction());
            Debug.Log("Oturn started");
            this.wait = 0;
        }

        IEnumerator WaitForAction() 
        {
            Debug.Log("wait started");
            while (this.wait == 0)
            {
                yield return 0;
            }
            Debug.Log("wait is done");
        }

        public void FinishChoose()
        {
            this.wait = 1;
        }

        public Side whichside()
        {
            return onturn;
        }

        public void UpdateText(int Score) {
            TurnOn(this.textComponent.gameObject);
            TurnOn(this.textComponent2.gameObject);
            //Update the text shown in the text component by setting the `text` variable
            if (Score > 0 && Score < 50)
            {
                textComponent.text = "X wins";
            }
            else 
            {
                if (Score < 0)
                {
                    textComponent.text = "O wins";
                }
                else
                {
                    textComponent.text = "Tie";
                }
            }
            textComponent2.text = "Press anywhere to back to tittle scene";
            TurnOn(button.gameObject);
        }


        // Update is called once per frame
        void Update()
        {
            
        }
    }
    
}
