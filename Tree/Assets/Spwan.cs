using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using Random = UnityEngine.Random;

public class Spwan : MonoBehaviour
{

    public GameObject player;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //when the key m is pressed call pressToSpawn
        if (Input.GetKeyDown(KeyCode.M))
        {
            pressToSpawn();
        }
    }

    public void pressToSpawn()
    {
        Vector3 position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(player.name, position, Quaternion.identity); 
    }
}
