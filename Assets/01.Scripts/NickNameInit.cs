using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NickNameInit : MonoBehaviour
{
    public InputField userId; //사용자 이름 입력 받음

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        userId.text = GetUserId();
    }

    // Update is called once per frame
    public string GetUserId()
    {
        string userId = PlayerPrefs.GetString("USER_ID");//로컬에 키값으로 저장되어 있는 USER_ID를 반환
        if (string.IsNullOrEmpty(userId))
        {
            userId = "USER_" + Random.Range(0, 999).ToString("000");
        }
        return userId;
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("02.MainScene");
        PlayerPrefs.SetString("USER_ID", userId.text);
    }
}
