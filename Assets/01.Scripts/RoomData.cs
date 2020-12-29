using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomData : MonoBehaviour
{
    [HideInInspector] // 외부 접근을 위해 public으로 선언했지만 Inspector에 노출하지 않음
    public string roomName = "";
    [HideInInspector]
    public int connectPlayer = 0;
    [HideInInspector]
    public int maxPlayer = 0;

    public Text textRoomName; // 룸 이름을 표시할 Text UI항목
    public Text textConnectInfo; // 룸 접속자 수와 최대 접속자 수를 표시할 Text UI 항목

    public void DispRoomData() //룸 정보를 전달한 후 Text UI 항목에 표시하는 함수
    {
        textRoomName.text = roomName;
        textConnectInfo.text = "(" + connectPlayer.ToString() + "/" + maxPlayer.ToString() + ")";
    }

}
