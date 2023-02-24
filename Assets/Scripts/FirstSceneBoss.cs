using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneBoss : MonoBehaviour
{
    private ParticleSystem.EmissionModule deadParticleEmission;
    public ParticleSystem deadParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.tag=="Bullet")
        {
            ParticleSystem deadParticleClone = Instantiate(deadParticle, other.transform.position, deadParticle.transform.rotation);
            deadParticleEmission = deadParticleClone.emission;
            deadParticleClone.transform.position = other.transform.position;
            deadParticleEmission.enabled = true;
            deadParticleClone.Play(true);
        }
    }
}
