using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    private Vector3 firstPos;
    private Vector3 lastPos;

    public GameObject spawnPoints;
    public GameObject player;
    public GameObject boss;
    public GameObject endPanel;
    public GameObject restartButton;
    public GameObject nextButton;
    public TextMeshProUGUI endText;
    public GameObject[] players;
    public static float Health;

    public bool[] spawnBools;

    public bool startBool;

    public int counter;
    public TextMeshProUGUI countertext;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(counterIE());
        
    }

    // Update is called once per frame
    void Update()
    {
        int a = 0;
        for (int i = 0; i < 5; i++)
        {
            if (players[i].activeInHierarchy)
            {
                a++;
            }
        }
        if (a == 0)
        {
            endPanel.SetActive(true);
            endText.text="Try Again!";
            nextButton.SetActive(false);
        }

        if (boss.activeInHierarchy==false)
        {
            for (int i = 0; i < 5; i++)
            {
                if (players[i].activeInHierarchy)
                {
                    players[i].GetComponent<Player>().firebool = false;
                }
            }
            endPanel.SetActive(true);
            endText.text = "Good Job!";
        }
        
        if (Input.touchCount > 0 && startBool)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstPos = touch.position;
                lastPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {

                lastPos = touch.position;
                if ((lastPos.x - firstPos.x) > 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (players[i].activeInHierarchy)
                        {
                            players[i].transform.position = Vector3.Lerp(players[i].transform.position, new Vector3(players[i].transform.position.x + (90f * Time.deltaTime), players[i].transform.position.y, players[i].transform.position.z), 5 * Time.deltaTime);

                        }
                    }
                    spawnPoints.transform.position = Vector3.Lerp(spawnPoints.transform.position, new Vector3(spawnPoints.transform.position.x + (90f * Time.deltaTime), spawnPoints.transform.position.y, spawnPoints.transform.position.z), 5 * Time.deltaTime);

                }
                if ((lastPos.x - firstPos.x) < -1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (players[i].activeInHierarchy)
                        {
                            players[i].transform.position = Vector3.Lerp(players[i].transform.position, new Vector3(players[i].transform.position.x - (90f * Time.deltaTime), players[i].transform.position.y, players[i].transform.position.z), 5 * Time.deltaTime);
                        }
                    }
                    spawnPoints.transform.position = Vector3.Lerp(spawnPoints.transform.position, new Vector3(spawnPoints.transform.position.x - (90f * Time.deltaTime), spawnPoints.transform.position.y, spawnPoints.transform.position.z), 5 * Time.deltaTime);
                }
            }
        }
    }

    IEnumerator counterIE()
    {
        while (counter>0 )
        {
            countertext.text = counter.ToString();

            yield return new WaitForSeconds(1f);

            counter--;
        }

        countertext.text = "GO!";
        player.GetComponent<Animator>().SetBool("PlayerBool", false);
        player.GetComponent<Player>().startbool = true;
        startBool = true;
        yield return new WaitForSeconds(1f);
        countertext.text = "";
    }
    

   
    
}
