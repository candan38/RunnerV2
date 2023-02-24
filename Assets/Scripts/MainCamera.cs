using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject[] players;
    public GameObject activePlayer;

    // Start is called before the first frame update
    void Start()
    {
        activePlayer = players[0];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<5;i++)
        {
            if (players[i].activeInHierarchy)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(players[i].transform.position.x, transform.position.y, players[i].transform.position.z - 30f), 5 * Time.deltaTime);
                activePlayer = players[i];
                break;
            }
            else
            {
                activePlayer = null;
            }

        }
       

    }
}
