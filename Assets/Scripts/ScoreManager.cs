using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int currentScore;

    GameObject player;
    void Start()
    {
        player  = GameObject.FindGameObjectWithTag("Player");
        currentScore = player.GetComponent<PlayerController>().score;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = player.GetComponent<PlayerController>().score;
        scoreText.text = "Score: " + currentScore.ToString();

        if(player == null)
        {
            Debug.Log("Has muerto");
        }
    }
}
