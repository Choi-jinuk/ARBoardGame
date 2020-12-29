using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotonInit : MonoBehaviourPunCallbacks
{

    public Text userId;
    public GameObject joinrandom;
        public GameObject roommake;
    public GameObject findRoom;
    
    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        userId.text = PlayerPrefs.GetString("USER_ID");
    }
    public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby(); //서버 접속시 JoinLobby 호출
    public override void OnJoinedLobby() //로비에 접속 시 호출되는 콜백함수
    {
        base.OnJoinedLobby();
        Debug.Log("Entered Lobby!!");
        userId.text = GetUserId();
        joinrandom.SetActive(true);
        roommake.SetActive(true);
        findRoom.SetActive(true);
    }

    string GetUserId() //로컬에 저장된 플레이어 이름을 반환하거나 생성함
    {
        string userId = PlayerPrefs.GetString("USER_ID");//로컬에 키값으로 저장되어 있는 USER_ID를 반환
        if (string.IsNullOrEmpty(userId))
        {
            userId = "USER_" + Random.Range(0, 999).ToString("000");
        }
        return userId;
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    { //방 접속에 실패하면 새로운 방 생성
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("No rooms!");
        PhotonNetwork.CreateRoom("My Room", new RoomOptions { MaxPlayers = 4 });//총 4명이 참가 가능한 방
    }

    public override void OnJoinedRoom()
    { //방에 접속이 되면 탱크 생성
        base.OnJoinedRoom();
        Debug.Log("Entered Room");
        SceneManager.LoadScene("03.InGameScene");
        //CreateTank();
        //메인 씬으로 이동하는 코루틴 함수 호출
        //인게임씬으로넘어가게
    }
  
    public void OnClickJoinRandomRoom() //  JoinRandomRoom 버튼 누르면 호출되는 함수
    {
        PhotonNetwork.NickName = PlayerPrefs.GetString("USER_ID"); //로컬 플레이어의 이름을 설정
        PhotonNetwork.JoinRandomRoom(); //무작위로 방에 입장
    }
 /*   public void OnClickCreateRoom() //MaKe Room 버튼 클릭 시 호출될 함수
    {
        string _roomName = roomName.text;
        if (string.IsNullOrEmpty(roomName.text)) //룸 이름이 없거나 Null일 경우 룸 이름 지정
        {
            _roomName = "ROOM_" + Random.Range(0, 999).ToString("000");
        }
        PhotonNetwork.NickName = userId.text; //로컬 플레이어의 이름을 설정
        PlayerPrefs.SetString("USER_ID", userId.text); //플레이어의 이름을 저장

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.CreateRoom(_roomName, roomOptions, TypedLobby.Default);

    }*/
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("CreateRoom Failed = " + message);
    }
  
    //RoomItem이 클릭되면 호출된 이벤트 연결 함수
  
    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

}
