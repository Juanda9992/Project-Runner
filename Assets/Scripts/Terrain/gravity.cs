using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour 
{
    public float time;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            StartCoroutine(fallOff(time));
        }    
    }
    public IEnumerator fallOff(float time)
    {
        yield return new WaitForSeconds(time);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.localScale = new Vector2(0.96f,0.94f);
        
    }    
}