using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonTest : MonoBehaviourPunCallbacks
{

    public Text playerList;

    public Transform[] spots;
    public GameObject pig;
    public Transform target;
    public DefaultTrackableEventHandler trackable;
    int length = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerList.text = PhotonNetwork.PlayerList.GetValue(0) + "\n";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PhotonNetwork.PlayerList.GetValue(0));

        if (length == PhotonNetwork.PlayerList.Length)
        { 
        
        }
        else 
        {
            playerList.text = "";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                playerList.text += PhotonNetwork.PlayerList.GetValue(i) + "\n";
              
            }
            length = PhotonNetwork.PlayerList.Length;

            if (spots.Length >= length)
            {
                Debug.Log("create Player");
                GameObject player = Instantiate(pig, spots[length-1]);
                player.GetComponent<MeshRenderer>().enabled = trackable.isTrackingFound;
                
                player.transform.parent = target.transform;
                player.GetComponent<PlayerNickName>().NickName.text = PhotonNetwork.PlayerList.GetValue(length - 1) + "";
            }
        }
       

    }
}
