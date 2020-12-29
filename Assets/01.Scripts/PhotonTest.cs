using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonTest : MonoBehaviour
{

    public Text playerList;
    int length =1;
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
        }
       

    }
}
