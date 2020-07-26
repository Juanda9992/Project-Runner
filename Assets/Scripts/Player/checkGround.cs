using UnityEngine;

public class checkGround : MonoBehaviour 
{
    public Transform groundPosition;
    public LayerMask whatIsGround;
    public float circleRadius;
    bool Jump;    

    private void Update() 
    {
        Jump = Physics2D.OverlapCircle(groundPosition.position,circleRadius,whatIsGround);

        if(Input.GetKeyDown(KeyCode.Space) && Jump == true)
        {
            audioPlayer.PlaySound("jump");
            GetComponent<PlayerController>().Jump();
            Debug.Log(Jump);
        }

    }
}