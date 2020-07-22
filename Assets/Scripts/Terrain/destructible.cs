using UnityEngine;
using System.Collections;
public class destructible : MonoBehaviour 
{
    [Range(0.1f,2.5f)] public float time; //Timpo a destruir el objeto
    Animator animator;

    private void Start() 
    {
        animator = GetComponent<Animator>();    
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.CompareTag("Player")) //Si toca al jugaodr, este iniciara el proceso de destruccion
        {
            animator.SetBool("hasCollider", true);
        }    
    }

    public void AutoDestroy()
    {
        Destroy(this.gameObject);
    }

}