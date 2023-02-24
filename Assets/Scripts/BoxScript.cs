using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour
{
    public float powerPlus;
    public float healthPlus;
    public float bulletPlus;

    public float boxHealth;

    public AudioSource deadSound;
    public AudioSource punchSound;
    private ParticleSystem.EmissionModule deadParticleEmission;
    public ParticleSystem deadParticle;

    public GameObject plusObject;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        text.text = boxHealth.ToString();
        if (boxHealth <= 0)
        {
            deadSound.Play();
            deadParticleEmission = deadParticle.emission;
            deadParticle.transform.position = transform.position;
            deadParticleEmission.enabled = true;
            deadParticle.Play(true);

            GameObject plusObjectClone = Instantiate(plusObject, transform.position, new Quaternion(0, 0, 0, 0));
            plusObjectClone.name = "plusObjectClone";
            plusObjectClone.transform.position = transform.position;
            plusObjectClone.GetComponent<PlusObjectScript>().powerPlus = powerPlus;
            plusObjectClone.SetActive(true);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            punchSound.Play();
            boxHealth -= 5;
        }
        if (other.tag == "Player")
        {
            print(transform.name+" "+other.name);
            other.GetComponent<Player>().health = 0;
        }
    }
}
