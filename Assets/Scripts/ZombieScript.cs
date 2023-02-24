using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZombieScript : MonoBehaviour
{
    public float zombieHealth;

    public AudioSource deadSound;

    public ParticleSystem deadParticle;
    private ParticleSystem.EmissionModule deadParticleEmission;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(0, 0, Time.deltaTime * 3f);
        if (zombieHealth <= 0)
        {
            deadSound.Play();
            ParticleSystem deadParticleClone = Instantiate(deadParticle, gameObject.transform.position, gameObject.transform.rotation);
            deadParticleEmission = deadParticleClone.emission;
            deadParticleClone.transform.position = transform.position;
            deadParticleEmission.enabled = true;
            deadParticleClone.Play(true);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.gameObject.GetComponent<Player>().health = 0;
            zombieHealth = 0;
        }
    }





}
