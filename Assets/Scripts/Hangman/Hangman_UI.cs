using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Hangman_UI : MonoBehaviour
{
    [Header ("Master")]
    [SerializeField] private Hangman_Master master;

    [Header ("Prefabs")]
    [SerializeField] private GameObject prefabLetter;

    [Header ("Menus")]
    [SerializeField] private GameObject resultMenu;

    [Header ("Custom UI Objects")]
    [SerializeField] private Hangman_Figure hangmanFigure;
    [SerializeField] private InputField inputField;
    [SerializeField] private Transform letterParent;

    // private variables
    private List<char> letters;
    private float currentLetterDistanceX;
    private float additionalLetterDistanceX;
    private string guess;


    public void initialize() {
        // initialize variables
        currentLetterDistanceX = 0;
        additionalLetterDistanceX = master.getDefaultLetterDistance();
        guess = "";
        resultMenu.SetActive(false);
        progressHangmanFigure();
    }

    // splits given <hangmanWord> into char list and generates UI objects from it
    // @param STRING hangmanWord: the word to split into letters
    public void loadHangmanLetters(string hangmanWord) {
        letters = new List<char>(hangmanWord.ToCharArray());
        letters.ForEach(letter => generateLetterObject(letter));
    }

    public void progressHangmanFigure() => hangmanFigure.progress();

    public void terminate() {
        inputField.gameObject.SetActive(false);
        resultMenu.SetActive(true);
    }


    // instantiates a clone of the letter prefab and sets its properties
    // @param CHAR letter: letter to set within the object settings
    private void generateLetterObject(char letterChar) {
        GameObject letterObj = Instantiate(prefabLetter, letterParent);

        letterObj.transform.localPosition = new Vector3(currentLetterDistanceX,0,0);
        currentLetterDistanceX += additionalLetterDistanceX;

        Hangman_Letter letter = letterObj.GetComponent<Hangman_Letter>();
        letter.prepareLetter(letterChar);

        master.addLetterToLetterList(letter);
    }


    #region UI Element Event functions
    // checks inputField for illegal inputs and them if found
    public void validateInput() {
        Regex illegalInputs = new Regex("[^A-Za-z]+");
        MatchCollection illegalMatches = illegalInputs.Matches(inputField.text);

        if (illegalMatches.Count == 1) inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
    }

    // determine if inputfield input is a letter or a word and act accordingly
    public void submitGuess() {
        guess = inputField.text.ToUpper();

        switch (guess.Length) {
            case 1: master.checkLetterGuess(guess[0]); break;
            default: master.checkWordGuess(guess); break;
        }
        inputField.text = "";
    }

    public void playAgain() => master.reloadScene();
    #endregion
}
