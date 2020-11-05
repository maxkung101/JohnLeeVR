using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToYou : MonoBehaviour
{
    private AudioSource[] sources;
    private AudioSource tickSource;
    private int id;

    // Start is called before the first frame update
    private void Start()
    {
        id = PlayerPrefs.GetInt("Player Id", 0);
        sources = GetComponents<AudioSource>();
        tickSource = sources[id];
        tickSource.Play();
    }
}
