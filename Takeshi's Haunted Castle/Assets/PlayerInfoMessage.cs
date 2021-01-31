using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public enum PlayerClass { camera, player };
public class PlayerInfoMessage : NetworkBehaviour
{
    //public static short msgType = MsgType.Highest + 1;
    public PlayerClass playerClass;

    public PlayerInfoMessage(PlayerClass playerClass)
    {
        this.playerClass = playerClass;
    }

    public PlayerInfoMessage() { }
}
