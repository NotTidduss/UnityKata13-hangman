using UnityEngine;
using UnityEngine.UI;

public class Hangman_Letter : MonoBehaviour
{
    [Header ("Prefab References")]
    [SerializeField] private Text letterText;

    public bool isVisible {get; private set;}
    private char letterChar;


    public bool equals(char guess) => letterChar == guess;


    public void prepareLetter(char letter) {
        letterText.text = "";
        isVisible = false;
        letterChar = letter;
    }

    public void show() {
        letterText.text = letterChar.ToString();
        isVisible = true;
    }
}
