using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public float bossHealth;

    public AudioSource deadSound;
    public AudioSource punchSound;
    private ParticleSystem.EmissionModule deadParticleEmission;
    public ParticleSystem deadParticle;
    public Image healthBar;
    private float startHealth;

    public GameObject[] players;
    public bool bossWalk; 
    // Start is called before the first frame update
    void Start()
    {
        startHealth = bossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = bossHealth / startHealth;
        if (bossHealth <= 0)
        {
            deadSound.Play();
            deadParticleEmission = deadParticle.emission;
            deadParticle.transform.position = transform.position;
            deadParticleEmission.enabled = true;
            deadParticle.Play(true);

           gameObject.SetActive(false);
        }
        if (bossWalk) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z-3), 5 * Time.deltaTime);
        }
       /* if (players[0].activeInHierarchy && Vector3.Distance(players[0].transform.position, transform.position)<=60f)
        {
            bossWalk = false;
            GetComponent<Animator>().SetBool("BossAttack",true);
            for (int i = 0; i < 5; i++)
            {
                players[i].GetComponent<Player>().firebool= false;
            }
        }*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            punchSound.Play();
            bossHealth -= 5;
        }
    }
}
