using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public GameObject zombieClones;
    public GameObject zombie;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(generateZombie());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator generateZombie()
    {
        while (3>2)
        {
            
                GameObject zombieClone = Instantiate(zombie, zombie.transform.position, zombie.transform.rotation);
                zombieClone.name = "zombieClone";
                zombieClone.tag = "Zombie";
                zombieClone.transform.position = new Vector3(spawnPoint.transform.position.x+ Random.Range(-10.0f, 10.0f), zombie.transform.position.y, spawnPoint.transform.position.z + Random.Range(100.0f, 200.0f));
                zombieClone.transform.SetParent(zombieClones.transform);
                zombieClone.GetComponent<ZombieScript>().zombieHealth = 50;
                 zombieClone.SetActive(true);
            
            yield return new WaitForSeconds(2f);
        }
    }
}
