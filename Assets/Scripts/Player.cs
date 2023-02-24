using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject[] players;
    public GameObject bulletClones;
    public GameObject gun;
    public GameObject spawnpoint;
    public float health;
    public float power;


    

    public TextMeshProUGUI powerText;

    public bool firebool;
    public bool startbool;
    public bool walkbool;
    public bool corotinebool;
    public bool failBool;

    public AudioSource deadSound;
    public ParticleSystem deadParticle;
    private ParticleSystem.EmissionModule deadParticleEmission;

    // Start is called before the first frame update
    void Start()
    {
        walkbool = true;
        firebool = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startbool==true && walkbool==true)
        {
            if (corotinebool==false)
            {
                StartCoroutine(attackGunMachine());
            }
            powerText.text = power.ToString();
            transform.Translate(0, 0, Time.deltaTime * 12f);
            spawnpoint.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y,transform.position.z) ;
            
            
        }
        if (health <= 0)
        {
            deadSound.Play();
            ParticleSystem deadParticleClone = Instantiate(deadParticle, gameObject.transform.position, gameObject.transform.rotation);
            deadParticleEmission = deadParticleClone.emission;
            deadParticleClone.transform.position = transform.position;
            deadParticleEmission.enabled = true;
            deadParticleClone.Play(true);
            int a=0;
            for (int i = 0; i < 5; i++)
            {
                if (players[i].activeInHierarchy)
                {
                    a++;
                }                
            }
            if (a==0)
            {
                failBool = true;
            }
            gameObject.SetActive(false);
        }
        if (failBool==true)
        {
            Time.timeScale = 0;
        }
       
    }
    IEnumerator attackGunMachine()
    {
        corotinebool = true;
        while (firebool)
        {
            GameObject bullet = gun.transform.Find("Bullet").gameObject;
            GameObject bulletPositionObject = gun.transform.Find("BulletPosObject").gameObject;
            AudioSource gunAudio = gun.transform.Find("GunSound").GetComponent<AudioSource>();
            ParticleSystem projectileParticle = gun.transform.Find("Projectile").GetComponent<ParticleSystem>();
            ParticleSystem.EmissionModule projectileParticleEmission;
            projectileParticleEmission = projectileParticle.emission;


            gunAudio.Play();
            projectileParticleEmission.enabled = true;
            projectileParticle.Play(true);

            GameObject bulletClone = Instantiate(bullet, bulletPositionObject.transform.position, new Quaternion(0, 0, 0, 0));
            bulletClone.name = "bulletClone";
            bulletClone.tag = "Bullet";
            bulletClone.transform.position = bulletPositionObject.transform.position;
            bulletClone.transform.SetParent(bulletClones.transform);
            bulletClone.GetComponent<BulletScript>().attackBool = true;
            bulletClone.GetComponent<BulletScript>().playerForward = transform.forward;
            bulletClone.GetComponent<BulletScript>().bulletHealth = power;

            bulletClone.SetActive(true);

            yield return new WaitForSeconds(1/power);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name=="DownCollider" || collision.transform.name == "Circle" || collision.transform.name == "BossAttack")
        {
           health = 0;
        }

    }
}
