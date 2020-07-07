using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int currentScore;

    GameObject player;
    void Start() //Se asigna el personaje y al texto del puntaje
    {
        player  = GameObject.FindGameObjectWithTag("Player");
        currentScore = player.GetComponent<PlayerController>().score;
    }

    // Update is called once per frame
    void Update() //Cambia el texto al valor del puintaje del personaje
    { 
        currentScore = player.GetComponent<PlayerController>().score;
        scoreText.text = "Score: " + currentScore.ToString();

        if(player == null)
        {
            Debug.Log("Has muerto");
        }
    }
}
