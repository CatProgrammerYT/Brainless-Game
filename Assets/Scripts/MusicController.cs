using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] musicClips = new AudioClip[3];
    public AudioSource ass;

    public static MusicController mc;

    public float volume = 1f;

    private void Start()
    {

        DontDestroyOnLoad(this.gameObject);
        if(mc == null)
        {
            mc = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        Player();
    }

    private void Player()
    {
        ass.Stop();
        for (int i = 0; i < musicClips.Length; i++)
        {
            ass.volume = volume;
            ass.PlayOneShot(musicClips[i]);
        }
    }
}
