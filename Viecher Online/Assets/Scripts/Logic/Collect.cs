using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public Server Server;
    public Player Player;
    public GUIManager GuiManager;

    public void CollectGains() {
        GuiManager.UpdatePlayerResources();
        UpdatePlayerDeltaTime();
    }

    private void UpdatePlayerDeltaTime() {
        Player.SetCollectionDeltaTime(Server.time);
    }
}
