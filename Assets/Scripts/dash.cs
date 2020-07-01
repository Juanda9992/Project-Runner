using UnityEngine;

public class dash : MonoBehaviour 
{
    public float dashTime;
    private string direction = "Right";
    float speed = 30;
    float currentDash;

    private void Start() 
    {
        currentDash  = dashTime;   
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = "Left";
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = "Right";
        }    
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
        currentDash -= Time.deltaTime;
    }    

    private void Dash()
    {
        if(direction == "Left" && currentDash < 0)
            {
                transform.position = new Vector2(transform.position.x - 3, transform.position.y);
                currentDash = dashTime;
            }
           if(direction == "Right" && currentDash < 0)
            {
                transform.position = new Vector2(transform.position.x + 3, transform.position.y);
                currentDash = dashTime;
            }
    }

}