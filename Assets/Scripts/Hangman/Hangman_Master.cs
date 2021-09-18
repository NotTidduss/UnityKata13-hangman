using System.Collections.Generic;
using UnityEngine;

public class Hangman_Master : MonoBehaviour
{
    [Header ("Scene References")]
    [SerializeField] private Hangman_System sys;
    [SerializeField] private Hangman_UI ui;

    // private variables
    private List<Hangman_Letter> letterList;
    private string hangmanWord;


    void Start() {
        // initialize variables
        letterList = new List<Hangman_Letter>();
        hangmanWord = sys.getHangmanWord();

        // initialize Game Components
        ui.initialize();

        // prepare game
        ui.loadHangmanLetters(hangmanWord.ToUpper());
    }

    
    public float getDefaultLetterDistance() => sys.uiDefaultLetterDistance;
    public void addLetterToLetterList(Hangman_Letter letter) => letterList.Add(letter);
    public void reloadScene() => sys.loadHangmanScene();

    public void checkLetterGuess(char guessLetter) {
        bool isLetterCorrect = isInLetterList(guessLetter);

        switch (isLetterCorrect) {
            case true: if (isGameOver()) ui.terminate(); break;
            case false: ui.progressHangmanFigure(); break;
        }
    }

    public void checkWordGuess(string guessWord) {
        Debug.Log("Word guess :D");
    }


    // iterate through the letter list and check if <guessLetter> is included there (also show if so)
    // @param CHAR guessLetter: the letter to be checked for.
    // @return BOOL isInList: true if <guessLetter> is in list, false if not.
    private bool isInLetterList(char guessLetter) {
        bool isInList = false;

        letterList.ForEach(letter => {
            if (!letter.isVisible && letter.equals(guessLetter)) {
                isInList = true;
                letter.show();
            }
        });
        return isInList;
    }

    private bool isGameOver() {
        bool isGameOver = true;
        letterList.ForEach(letter => {
            if (!letter.isVisible) isGameOver = false;
        });
        return isGameOver;
    }
}
