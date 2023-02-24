using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusObjectScript : MonoBehaviour
{
    public float healthPlus;
    public float powerPlus;
    public float bulletPlus;
    //public GameObject player;
    public GameObject[] players;
    public GameObject[] spawnPoints;
    public bool[] spawnBools;
    public GameObject cameraMain;
    public GameObject scriptMain;

    private GameObject activePlayer;
    // Start is called before the first frame update
    void Start()
    {
       activePlayer = cameraMain.GetComponent<MainCamera>().activePlayer;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        activePlayer = cameraMain.GetComponent<MainCamera>().activePlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (powerPlus > 0)
            {
                other.GetComponent<Player>().power += powerPlus;
            }
            else
            {
                float dim = 1000f;
                GameObject activeSpawnPoint=null;
                int spwanIndex = 0;
                print(activePlayer.name);
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].activeInHierarchy == false && players[i].GetComponent<Player>().health==100 )
                    {
                        print(activePlayer.transform.name);
                        for (int j=0;j<5;j++)
                        {
                            print(Vector3.Distance(activePlayer.transform.position, spawnPoints[j].transform.position));
                            print(spawnBools[j]);
                            if (scriptMain.GetComponent<MainScript>().spawnBools[j] ==false && Vector3.Distance(activePlayer.transform.position, spawnPoints[j].transform.position)<dim)
                            {
                                dim = Vector3.Distance(activePlayer.transform.position, spawnPoints[j].transform.position);
                                activeSpawnPoint = spawnPoints[j];
                                spwanIndex = j;
                            }                            
                        }
                        print(activeSpawnPoint.transform.name);
                        if (activeSpawnPoint != null)
                        {
                            players[i].transform.position = new Vector3(activeSpawnPoint.transform.position.x, players[i].transform.position.y, activeSpawnPoint.transform.position.z);
                            players[i].GetComponent<Player>().startbool = true;
                            players[i].SetActive(true);
                            players[i].GetComponent<Animator>().SetBool("PlayerBool", false);
                            scriptMain.GetComponent<MainScript>().spawnBools[spwanIndex] = true;
                        }
                        break;
                    }
                }
            }

            gameObject.SetActive(false);
        }
    }
}
