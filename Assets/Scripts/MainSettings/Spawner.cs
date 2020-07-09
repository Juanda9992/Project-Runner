using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint = new Transform[7];
    public GameObject[] blocks = new GameObject[2];
    [HideInInspector] public float maxTime;

    int randomIndex;
    float currentTime = 0;
    int randomObject;



    void Start() //Este metodo obtiene la variable de tiempo de otro script, ademas define el primer bloque con su respectiva pocision
    {
        maxTime = GameObject.FindGameObjectWithTag("Main").GetComponent<DificultSetter>().maxTime;
        randomIndex = Random.Range(0,spawnPoint.Length);
        randomObject = Random.Range(0,blocks.Length);
    }

    void Update() //Crea un bloque en un lugar aleatorio cada cierto tiempo
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            Create();
        }
    }
    public void Create()
    {
        Vector2 position = spawnPoint[randomIndex].GetComponent<Transform>().position; //Se obtiene la posicion del puntio de spawneo elegido

        Instantiate(blocks[randomObject],position,Quaternion.identity); 
        //Se instancia un bloque al azar de la lista de bloques en una pocision al azar de una lista de posiciones

        //Se reinicia el tiempo y se vuelve a elegiur un bloque al azar y una posicion al azar
        currentTime = maxTime;
        currentTime = maxTime;
        randomIndex = Random.Range(0,spawnPoint.Length);
        randomObject = Random.Range(0,blocks.Length);

    }
}
