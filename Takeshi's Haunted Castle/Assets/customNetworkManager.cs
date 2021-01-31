using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class customNetworkManager : NetworkBehaviour
{
    public GameObject playerPrefab, cameraPrefab;
    public Vector3 myvectr;
    /*
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessagereader)
    {
        PlayerInfoMessage msg = extraMessagereader.ReadMessage<PlayerInfoMessage>();
        Debug.Log(msg.playerClass);
        GameObject playerPrefab = spawnPlayerFromClass(msg.playerClass);
        NetworkServer.AddPlayerForConnection(conn, playerPrefab, playerControllerId);
    }
    */
    public GameObject spawnPlayerFromClass(PlayerClass playerClass)
    {
        GameObject playerPrefab = null;
        switch (playerClass)
        {
            case PlayerClass.player:
                playerPrefab = playerPrefab;
                break;
            case PlayerClass.camera:
                playerPrefab = cameraPrefab;
                break;
        }
        return GameObject.Instantiate(playerPrefab, myvectr, Quaternion.identity);
    }
}
