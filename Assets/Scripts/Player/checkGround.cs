using UnityEngine;

public class checkGround : MonoBehaviour 
{
    public Transform groundPosition;
    public LayerMask whatIsGround;

    public LayerMask whatIsSpike;
    public float circleRadius;
    bool Jump;    
    bool isSpike;

    private void Update() 
    {
        Jump = Physics2D.OverlapCircle(groundPosition.position,circleRadius,whatIsGround);

        if(Input.GetKeyDown(KeyCode.Space) && Jump == true)
        {
            audioPlayer.PlaySound("jump");
            GetComponent<PlayerController>().Jump();
            Debug.Log(Jump);
        }

        if(Jump == false)
        {
            isSpike = Physics2D.OverlapCircle(groundPosition.position,circleRadius,whatIsSpike);
            if(isSpike)
            {
                GetComponent<PlayerController>().Death();
            }
        }

    }
}