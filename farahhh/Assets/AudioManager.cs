using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance;
   public  AudioSource musicSource;
  public AudioSource sfxSource;
  public AudioClip overWorldMusic; 
  public AudioClip caveMusic;
  public AudioClip[] variousSFX;
  void Awake()
{
    //make sure the entire game only has one Audio Manager throughout
    if (Instance == null) {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    } else Destroy(gameObject);
}

//Public in case another object needs to call for a specific sound effect to begin playing
public void PlayMusicSFX(AudioClip clip)
{
    sfxSource.clip = clip;
    sfxSource.Play();
}

//Public in case another object needs to call for a specific soundtrack to begin playing
public void PlayMusic(AudioClip clip)
{
    musicSource.clip = clip;
    musicSource.Play();
}


//Function takes a bunch of sound clips as parameters
public void PlayRandomSFX(params AudioClip[] clips)
{
    //assign the incoming array of items to our local arraylist variable called 'variousSFX'
    variousSFX = clips;

    //randomly select a sound clip from the arraylist, then play that clip
    int index = Random.Range(0, variousSFX.Length);
    sfxSource.PlayOneShot(variousSFX[index]);
}
    // Start is called before the first frame update

    void Start()
    {
        musicSource.clip = overWorldMusic;

    musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
