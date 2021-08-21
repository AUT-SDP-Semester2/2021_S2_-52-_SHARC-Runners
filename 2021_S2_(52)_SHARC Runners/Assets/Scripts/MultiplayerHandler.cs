using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

/*
 *This class deals with handling the lobby and room functionality
 *
 */

public class MultiplayerHandler : MonoBehaviourPunCallbacks
{

    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text roomNameText;

    private void Start()
    {
        Debug.Log("Connected to Master");

        //automatically load scene for all the clients in room when hosts switches scene
       // PhotonNetwork.AutomaticallySyncScene = true;

        //Establishes Connection set out in the Photon Settings in Resource Folder
        PhotonNetwork.ConnectUsingSettings();

    }

    //Once connected to the master server
    public override void OnConnectedToMaster()
    {
        //connecting to a lobby
        PhotonNetwork.JoinLobby();
    }

    //Once the lobby is joined
    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("Title");
        Debug.Log("Joined Lobby");
        PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");
    }

    //Create Room
    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MenuManager.Instance.OpenMenu("Loading");
    }

    //if create room was successful, OnJoinedRoom will be called
    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("Room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;


        //Player[] players = PhotonNetwork.PlayerList;

        ////destroy all the players that existed before joining the room
        //foreach (Transform child in PlayerListContent)
        //{
        //    Destroy(child.gameObject);
        //}

        ////create the players
        //for (int i = 0; i < players.Length; i++)
        //{

        //    Instantiate(PlayerListItemPrefab, PlayerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        //}

        ////if it is the host, set the button to active
        //startGameBtn.SetActive(PhotonNetwork.IsMasterClient);
    }

    //if create room was unsuccessful, OnCreateRoomFailed will be called
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        //errorText.text = "Room Creation Failed" + message;
        MenuManager.Instance.OpenMenu("error");
    }


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();

        MenuManager.Instance.OpenMenu("Loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("Title2");
    }

}
