using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour {
    public float time;
    public Player Player;

    void FixedUpdate () {
        time = Time.time;
    }

    public float GetGoldGains () {
        float goldGains = (time - Player.collectionDeltaTime) * Player.goldP1;

        return goldGains;
    }
    public float GetOrbsGains () {
        float orbsGains = (time - Player.collectionDeltaTime) * Player.orbsP1;

        return orbsGains;
    }
    public float GetSoulsGains () {
        float soulsGains = (time - Player.collectionDeltaTime) * Player.soulsP1;

        return soulsGains;
    }

    public float GetGoldP1 () {
        float goldP1 = Player.stage * Player.stage * 100 + Player.stageLevel * 1;

        return goldP1;
    }

    public float GetOrbsP1 () {
        float orbsP1 = Player.stage * Player.stage * 100 + Player.stageLevel * 1;

        return orbsP1;
    }

    public float GetSoulsP1 () {
        float soulsP1 = Player.stage * Player.stage * 100 + Player.stageLevel * 1;

        return soulsP1;
    }

}