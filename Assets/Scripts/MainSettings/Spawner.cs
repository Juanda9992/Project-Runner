using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint = new Transform[7]; [Header("Posicion donde se generara el Prefab")]
    public GameObject[] blocks = new GameObject[2]; [Header("Array de los prefabs a generar")]
    [HideInInspector] public float maxTime;
    int randomIndex;
    float currentTime = 1;
    int randomObject;
    int lastNumber;

    public bool isRandom;



    void Start() //Este metodo obtiene la variable de tiempo de otro script, ademas define el primer bloque con su respectiva pocision
    {
        maxTime = GameObject.FindGameObjectWithTag("Main").GetComponent<DificultSetter>().maxTime;
        if(isRandom)
        {
            randomIndex = Random.Range(0,spawnPoint.Length);
            randomObject = Random.Range(0,blocks.Length);
        }
        else
        {
            randomObject = 0;
        }
        
    }

    void Update() //Crea un bloque en un lugar aleatorio cada cierto tiempo
    {
        if(currentTime <= 0)
        {
            Create();
        }
        currentTime -= Time.deltaTime;    
    }

    private void Create()
    {
        currentTime = maxTime; //Se reinicia el contador
        maxTime = GameObject.FindGameObjectWithTag("Main").GetComponent<DificultSetter>().maxTime; //Establece el nuevo tiempo        

        if(isRandom)
        {
            Transform position = spawnPoint[randomIndex].transform; //Se obtiene la posicion del punto de spawn

            Instantiate(blocks[randomObject],position.position,Quaternion.identity); //Instancia un bloque aleatorio
            randomIndex = Random.Range(0,spawnPoint.Length); //
            randomObject = Random.Range(0,blocks.Length);//Se selecciona un bloque al azar
        }
        else
        {
            Transform position = spawnPoint[randomIndex].transform; //Se obtiene la posicion del punto de spawn

            Instantiate(blocks[randomObject],position.position,Quaternion.identity); //Instancia un bloque aleatorio
            randomIndex = Random.Range(0,spawnPoint.Length); 
            randomObject++;
            if(randomObject >= blocks.Length)
            {
                randomObject = 0;
            }
        }

        
    }
}
