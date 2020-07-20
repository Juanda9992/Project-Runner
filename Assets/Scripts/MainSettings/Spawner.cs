using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint = new Transform[7];
    public GameObject[] blocks = new GameObject[2];
    [HideInInspector] public float maxTime;
    int randomIndex;
    float currentTime = 1;
    int randomObject;
    int lastNumber;



    void Start() //Este metodo obtiene la variable de tiempo de otro script, ademas define el primer bloque con su respectiva pocision
    {
        maxTime = GameObject.FindGameObjectWithTag("Main").GetComponent<DificultSetter>().maxTime;
        randomIndex = Random.Range(0,spawnPoint.Length);
        randomObject = Random.Range(0,blocks.Length);
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
        Transform position = spawnPoint[randomIndex].transform; //Se obtiene la posicion del punto de spawn

        Instantiate(blocks[randomObject],position.position,Quaternion.identity); //Instancia un bloque aleatorio
        randomIndex = Random.Range(0,spawnPoint.Length); //
        randomObject = Random.Range(0,blocks.Length);//Se selecciona un bloque al azar
        maxTime = GameObject.FindGameObjectWithTag("Main").GetComponent<DificultSetter>().maxTime; //Establece el nuevo tiempo

        lastNumber = randomObject;
        

    }
}
