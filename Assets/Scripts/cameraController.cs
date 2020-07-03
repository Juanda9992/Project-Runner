using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Camera cam;
    public float maxRange;
    public float minRange;

    public float defaultRange;

    float zoom;
    float cameraSize;
    // Start is called before the first frame update
    void Start()
    {
        cam = cam.GetComponent<Camera>();
        zoom = 5;
        cam.orthographicSize = zoom;
        cameraSize = zoom;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            zoom -= Time.deltaTime;
            cameraSize = Mathf.Clamp(zoom,minRange,maxRange);
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            zoom += Time.deltaTime;
            cameraSize = Mathf.Clamp(zoom,minRange,maxRange);
        }  
        if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A))
        {
            cameraSize = Mathf.Clamp(zoom,4,6);
            if(zoom < 5)
            {
                zoom += Time.deltaTime;
            }
            else if(zoom > 5)
            {
                zoom -= Time.deltaTime;
            }
        }        
        cam.orthographicSize = cameraSize;
        Debug.Log(cameraSize);
    }
}
