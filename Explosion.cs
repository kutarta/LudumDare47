using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Explosion : MonoBehaviour
{

    public ParticleSystem DeathParticles;
    private void Start()
    {
        Invoke("Death", 6f);
    }

    void Death()
    {
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
