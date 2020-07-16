using UnityEngine;
using System.Collections;
public class destructible : MonoBehaviour 
{
    [Range(0.1f,2.5f)] public float time; //Timpo a destruir el objeto

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.CompareTag("Player")) //Si toca al jugaodr, este iniciara el proceso de destruccion
        {
            StartCoroutine(destroy(time));
        }    
    }
    public IEnumerator destroy(float time) //Se destruye en el tiempo establecido por el objeto mismo
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
    
}