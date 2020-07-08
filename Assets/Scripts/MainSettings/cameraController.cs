using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Camera cam;
    public float maxRange;
    public float minRange;

    public float defaultRange;

    float zoom;
    float cameraSize;
    Transform offset;

    void Start() //Aqui se obtiene la camara y se ajusta el nivel del zoom
    {
        cam = cam.GetComponent<Camera>();
        zoom = 5;
        cam.orthographicSize = zoom;
        cameraSize = zoom;
        offset = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        cameraSize = Mathf.Clamp(zoom,minRange,maxRange);
        //Si se oprime el eje x negativo, camara hara un efecto zoom in
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            zoom -= Time.deltaTime;
            
        }
        //Si se oprime el eje x positivo, camara hara un efecto zoom out
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            zoom += Time.deltaTime;
        }  
        //Si no se oprime ninguna tecla, el zoom volvera a la normalidad
        if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A) && zoom !=5)
        {
            if(zoom < 5)
            {
                zoom +=  Time.deltaTime;
            }
            if(zoom > 5)
            {
                zoom -=  Time.deltaTime;
            }
        }        
        cam.orthographicSize = cameraSize;

    }
}
