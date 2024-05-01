using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class Createandjoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField JoinName;
    public TMP_InputField CreateName;

    public GameObject c;
    public GameObject j;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateName.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinName.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        //desactive les input fileds
        c.SetActive(false);
        j.SetActive(false);
    }
}
