using UnityEngine;

public class audioPlayer : MonoBehaviour 
{
    public static  AudioClip JumpsSound,CoinSound,DeathSound, CrackSound;

    static AudioSource audioSource;

    private void Start() 
    {
        JumpsSound = Resources.Load<AudioClip>("jump");
        CoinSound = Resources.Load<AudioClip>("coin");
        DeathSound = Resources.Load<AudioClip>("death");
        CrackSound = Resources.Load<AudioClip>("crack");

        audioSource = GetComponent<AudioSource>();   
    }
    public static void PlaySound(string sound)
    {
        switch(sound)
        {
            case "jump":
                audioSource.PlayOneShot(JumpsSound);
                break;
            case "coin":
                audioSource.PlayOneShot(CoinSound);
                break;
            
            case "crack":
                audioSource.PlayOneShot(CrackSound);
                break;

            case "death":
                audioSource.PlayOneShot(DeathSound);
                break;
                

        }
    } 
}