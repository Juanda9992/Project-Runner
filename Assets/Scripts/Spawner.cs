using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint = new Transform[7];
    public GameObject[] blocks = new GameObject[2];
    public float maxTime;

    int randomIndex;
    float currentTime;
    int randomObject;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        randomIndex = Random.Range(0,spawnPoint.Length);
        randomObject = Random.Range(0,blocks.Length);
    }

    // Update is called once per frame
    void Update()
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
