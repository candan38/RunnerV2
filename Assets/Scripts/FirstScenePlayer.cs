using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstScenePlayer : MonoBehaviour
{
    public GameObject bulletClones;
    public GameObject gun;
    public float power;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attackGunMachine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator attackGunMachine()
    {
      
        while (3>2)
        {
            GameObject bullet = gun.transform.Find("Bullet").gameObject;
            GameObject bulletPositionObject = gun.transform.Find("BulletPosObject").gameObject;
            AudioSource gunAudio = gun.transform.Find("GunSound").GetComponent<AudioSource>();
            ParticleSystem projectileParticle = gun.transform.Find("Projectile").GetComponent<ParticleSystem>();
            ParticleSystem.EmissionModule projectileParticleEmission;
            projectileParticleEmission = projectileParticle.emission;


            //gunAudio.Play();
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
    
}
