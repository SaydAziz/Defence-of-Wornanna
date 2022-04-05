using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set;}

    [SerializeField] private AudioSource[] sounds;

    void Awake()
    {
        if (Instance !=null && Instance != this)
        {
            Destroy(this);          //basic singleton pattern
        }
        else
        {
            Instance = this;
        }
    }


    public void PlaySound(int i)
    {
        sounds[i].Play();   
    }
}
