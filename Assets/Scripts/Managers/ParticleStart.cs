using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStart : MonoBehaviour
{

    [SerializeField] ParticleSystem Boom;

    void Awake()
    {
        Boom.Play();
    }

}
