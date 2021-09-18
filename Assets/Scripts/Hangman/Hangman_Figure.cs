using UnityEngine;
using UnityEngine.UI;

public class Hangman_Figure : MonoBehaviour
{
    [Header ("Scene References")]
    [SerializeField] private Image hangManImage;

    [Header ("Textures")]
    [SerializeField] private Sprite state0;
    [SerializeField] private Sprite state1;
    [SerializeField] private Sprite state2;
    [SerializeField] private Sprite state3;
    [SerializeField] private Sprite state4;
    [SerializeField] private Sprite state5;
    [SerializeField] private Sprite state6;

    // vars
    private int currentState;


    // public void initialize() => currentState = 0;

    public void progress() {
        switch(currentState) {
            case 0: hangManImage.sprite = state0; break;
            case 1: hangManImage.sprite = state1; break;
            case 2: hangManImage.sprite = state2; break;
            case 3: hangManImage.sprite = state3; break;
            case 4: hangManImage.sprite = state4; break;
            case 5: hangManImage.sprite = state5; break;
            default: 
                hangManImage.sprite = state6; 
                Debug.Log("game over");
                break;
        }
        currentState++;
    }   
}
