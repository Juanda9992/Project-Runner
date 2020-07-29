using UnityEngine;

public class particles : MonoBehaviour 
{

    private void Start() 
    {
        ParticleSystem.MainModule settings = this.GetComponent<ParticleSystem>().main;

        settings.startColor = new Color(255,0,0); 
    }    
}