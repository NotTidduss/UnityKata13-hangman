using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hangman_System : MonoBehaviour
{
    [Header ("Scene Names")]
    public string hangmanSceneName = "1_Hangman";

    [Header ("UI Settings")]
    public float uiDefaultLetterDistance = 200;

    // List of Hangman words to be randomly chosen from
    public List<string> hangmanWords = new List<string>(){"hangman"};

    public void loadHangmanScene() => SceneManager.LoadScene(hangmanSceneName);
    public string getHangmanWord() => hangmanWords[Random.Range(0, hangmanWords.Count)];
}
