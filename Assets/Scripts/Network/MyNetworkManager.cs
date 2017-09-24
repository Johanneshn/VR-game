using System;
using UnityEngine;

public class MyNetworkManager : Photon.PunBehaviour
{
    private const string NetworkVersion = "0.0.1";

    private void OnEnable()
    {
        PhotonNetwork.ConnectUsingSettings(NetworkVersion);
    }

    public override void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("test", roomOptions, TypedLobby.Default);
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom("Test Room");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Pilot", new Vector3(0,0,0), Quaternion.identity, 0);
    }
}
