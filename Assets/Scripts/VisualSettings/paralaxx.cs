using UnityEngine;
using System.Collections;

public class paralaxx : MonoBehaviour 
{
    public float speed;
    MeshRenderer render;

    private void Start() 
    {
        render = GetComponent<MeshRenderer>();  
    }
    private void Update() 
    {
        render.material.mainTextureOffset = new Vector2(Time.time * speed, 0); //Se aplica elmefecto parallax al fondo
    }
}