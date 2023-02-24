using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 playerForward;
    public bool attackBool = false;
    float timer = 0.0f;
    public float bulletHealth;

    private ParticleSystem.EmissionModule deadParticleEmission;
    public ParticleSystem deadParticle;

    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(playerForward.x + 0.01f, playerForward.x - 0.01f);
        float randomZ = Random.Range(playerForward.z +0.01f, playerForward.z - 0.01f);
        playerForward.x = randomX;
        playerForward.z = randomZ;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2 || bulletHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {

        if (attackBool == true)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = (playerForward) * 80f;
        }

    }
    void OnCollisionEnter(Collision collisionInfo)
    {
      
        
        if (collisionInfo.collider.tag == "Box" || collisionInfo.collider.tag == "Boss")
        {
            ParticleSystem deadParticleClone = Instantiate(deadParticle, collisionInfo.gameObject.transform.position, deadParticle.transform.rotation);
            deadParticleEmission = deadParticleClone.emission;
            deadParticleClone.transform.position = collisionInfo.gameObject.transform.position;
            deadParticleEmission.enabled = true;
            deadParticleClone.Play(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Box" || other.tag == "Boss" )
        {
            ParticleSystem deadParticleClone = Instantiate(deadParticle, other.transform.position, deadParticle.transform.rotation);
            deadParticleEmission = deadParticleClone.emission;
            deadParticleClone.transform.position = other.transform.position;
            deadParticleEmission.enabled = true;
            deadParticleClone.Play(true);
            Destroy(gameObject);
        }

        if (other.tag == "Zombie")
        {
            other.GetComponent<ZombieScript>().zombieHealth -= 3;
           /* ParticleSystem deadParticleClone = Instantiate(deadParticle, other.transform.position, deadParticle.transform.rotation);
            deadParticleEmission = deadParticleClone.emission;
            deadParticleClone.transform.position = other.transform.position;
            deadParticleEmission.enabled = true;
            deadParticleClone.Play(true);*/
            Destroy(gameObject);
        }
    }


}
