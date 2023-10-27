using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClientSoawn : MonoBehaviour
{
    public GameObject cliente;
    public GameObject objective;
    private GameObject _newCliente;
    private GameObject _newObjective;
    public GameObject player;
    [SerializeField] private Rigidbody rb;
    public List<Vector3> positions;
    public List<Vector3> objectives;
    public bool clienteObtenido = false;
    public Text tiempoCliente;
    public float tiempotimer;
    public bool startTimer;
    

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        SpawnClient();
        


    }

    private void Update()
    {
        if (startTimer)
        {
            
            tiempotimer -= Time.deltaTime;
            tiempoCliente.text = tiempotimer.ToString();
        }
        
        if (!clienteObtenido)
        {
            if (Vector3.Distance(player.transform.position, _newCliente.transform.position) <= 1) 
            {
                  
                //Debug.Log("FRENA");
                _newCliente.transform.parent = player.transform;
                SpawnObjective();
                clienteObtenido = true;
                startTimer = true;
                tiempotimer = 10f;
            } 
        }
        else
        {
            LeaveClient();
        }
    }


    private void SpawnClient()
    {
       
        int indexC = Random.Range(0, positions.Count);
        _newCliente = Instantiate(cliente, positions[indexC], Quaternion.identity);
        clienteObtenido = false;
        
        
    }

    private void SpawnObjective()
    {
        int indexO = Random.Range(0, objectives.Count);
        _newObjective = Instantiate(objective, positions[indexO], Quaternion.identity);
    }

    private void LeaveClient()
    {
        if ((Vector3.Distance(player.transform.position, _newObjective.transform.position) <= 5))
        {
            tiempotimer = 10;
            startTimer = false;
            //Debug.Log("A");
            Destroy(_newCliente );
            Destroy(_newObjective);
            SpawnClient();
        }
    }
    
}
