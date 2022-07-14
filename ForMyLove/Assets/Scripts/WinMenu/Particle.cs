using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] salut;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < salut.Length; i++)
        {
            salut[i].GetComponent<ParticleSystem>();
            salut[i].Play();
        }
    }
}
