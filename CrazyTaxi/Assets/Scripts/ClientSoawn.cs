using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClientSoawn : MonoBehaviour
{
    public ArrowPoint arrow;
    public GameObject client;
    public GameObject objective;
    private GameObject _newClient;
    private GameObject _newObjective;
    public GameObject player;
    public List<Vector3> positions;
    public List<Vector3> objectives;
    public bool clientOb = false;
    public Text timeClient;
    public float timer;
    public bool startTimer;
    public int score=0;
    public Text scoreText;
    

    private void Start()
    {
        SpawnClient();
    }

    private void Update()
    {
        arrow.target = _newClient;
        scoreText.text = "score:" + score;
        if (startTimer)
        {
            timer -= Time.deltaTime;
            timeClient.text = timer.ToString();
        }
        
        
        if (!clientOb)
        {
            if (Vector3.Distance(player.transform.position, _newClient.transform.position) <= 3)
            {
                _newClient.transform.parent = player.transform;
                SpawnObjective();
                clientOb = true;
                startTimer = true;
                timer = 30f;
            } 
        }
        else
        {
            arrow.target = _newObjective;
            if (timer <= 0)
            {
                Destroy(_newClient);
                Destroy(_newObjective);
                timeClient.text = "0";
                startTimer = false;
                SpawnClient();
            }
            LeaveClient();
        }
    }


    private void SpawnClient()
    {
        int indexC = Random.Range(0, positions.Count);
        _newClient = Instantiate(client, positions[indexC], Quaternion.identity);
        clientOb = false;
    }

    private void SpawnObjective()
    {
        int indexO = Random.Range(0, objectives.Count);
        _newObjective = Instantiate(objective, objectives[indexO], Quaternion.identity);
    }

    private void LeaveClient()
    {
        if ((Vector3.Distance(player.transform.position, _newObjective.transform.position) <= 5))
        {
            timeClient.text = "0";
            score += 100;
            startTimer = false;
            Destroy(_newClient );
            Destroy(_newObjective);
            SpawnClient();
        }
    }
    
}
