using System;
using UnityEngine;

public class SoundController : MonoBehaviour
{
  public static SoundController Instance;
  [Header("[Lobby SoundClip]")]
  public AudioClip lobbyClip;
  [Header("[ButtonClick SoundClip]")]
  public AudioClip buttonClickClip;
  public AudioSource AudioSource{get{return audioSource;}set{audioSource = value;}}


  [SerializeField]
  private AudioSource audioSource;
  private void Awake()
  {
    Init();
  }
    private void Start()
    {
       audioSource.clip = lobbyClip;
       audioSource.loop =true;
        
    }
    private void Init()
  {
    DontDestroyOnLoad(this.gameObject);
    Instance = this;
    audioSource.clip = lobbyClip;
    audioSource.loop = true;
    audioSource.volume = 1f;
    audioSource.Play();
  }

  public void OnPlayClickSound()
  {
     audioSource.PlayOneShot(buttonClickClip);
  }
    
}
