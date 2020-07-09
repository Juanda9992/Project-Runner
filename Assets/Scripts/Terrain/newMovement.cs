using UnityEngine;

public class newMovement : MonoBehaviour 
{
   [HideInInspector] public float speed;

    private void Update() 
    {
        speed = GameObject.FindGameObjectWithTag("Main").GetComponent<DificultSetter>().currentSpeed;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }    
}