using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public TMPro.TextMeshPro GoldText, OrbsText, SoulsText;
    public TMPro.TextMeshPro GoldGainText, OrbsGainText, SoulsGainText;
    public TMPro.TextMeshPro GoldP1Text, OrbsP1Text, SoulsP1Text;
    public TMPro.TextMeshProUGUI StageNameText, StageText;
    public SpriteRenderer BGFront, BGBack;
    public Player Player;
    public Server Server;
    public Stages Stages;
    public Tavern Tavern;
    public bool heroWindowOpen;
    public GameObject UnitTemplate;
    public SpriteRenderer UnitTemplateRarity;
    public List<GameObject> lastPulledVisuals;

    void Start () {
        UpdateResourceText ();
        UpdateP1 ();
        UpdateP1Text ();
        UpdateStageInfo ();
    }

    void FixedUpdate () {
        UpdateCollectionInfo ();
    }

    public void ShowPulls () {
        FlushLastPulledVisuals ();
        int offset = -800;
        int i = 0;
        foreach (Hero hero in Tavern.lastPulls) {
            offset += 150;
            i++;
            ChangeUnitTemplateRarityVisuals (hero);
            GameObject unit = Instantiate (UnitTemplate, new Vector3 (offset, 100, 0), Quaternion.identity);
            unit.transform.SetParent (GameObject.Find ("4_Tavern").GetComponent<Transform> (), false);
            unit.GetComponent<SpriteRenderer> ().sprite = hero.avatar;
            Debug.Log (hero.name + i);
            lastPulledVisuals.Add (unit);
        }
    }

    public void FlushLastPulledVisuals () {
        foreach (GameObject go in lastPulledVisuals) {
            Destroy (go);
        }
    }

    private void ChangeUnitTemplateRarityVisuals (Hero hero) {
        if (Equals (hero.rarity, "B")) {
            UnitTemplateRarity.sprite = Resources.Load<Sprite> ("GFX/UI/rB");
        } else if (Equals (hero.rarity, "A")) {
            UnitTemplateRarity.sprite = Resources.Load<Sprite> ("GFX/UI/rA");
        } else if (Equals (hero.rarity, "S")) {
            UnitTemplateRarity.sprite = Resources.Load<Sprite> ("GFX/UI/rS");
        }
    }

    public void UpdateCollectionInfo () {
        if (gameObject.activeSelf) {
            GoldGainText.text = Server.GetGoldGains ().ToString ();
            OrbsGainText.text = Server.GetOrbsGains ().ToString ();
            SoulsGainText.text = Server.GetSoulsGains ().ToString ();
        }
    }

    /**
     * Called whenever player beats a stage's level.
     */
    public void UpdateCollectionPerSecondInfo () {
        AdvanceStage ();
        UpdateStageInfo ();
        UpdateP1 ();
        UpdateP1Text ();
    }

    public void UpdatePlayerResources () {
        Player.gold = Player.gold + Server.GetGoldGains ();
        Player.orbs = Player.orbs + Server.GetOrbsGains ();
        Player.souls = Player.souls + Server.GetSoulsGains ();
        UpdateResourceText ();
    }

    private void AdvanceStage () {
        if (Player.stageLevel == Stages.stages[Player.stage]) {
            Player.stage++;
            Player.stageLevel = 1;
        } else {
            Player.stageLevel++;
        }
    }

    /*
     * Re-calculates P1 for the player.
     */
    private void UpdateP1 () {
        Player.goldP1 = Server.GetGoldP1 ();
        Player.orbsP1 = Server.GetOrbsP1 ();
        Player.soulsP1 = Server.GetSoulsP1 ();
    }

    /*
     * Updates UI's current resource info
     */
    private void UpdateResourceText () {
        GoldText.text = Player.gold.ToString ();
        OrbsText.text = Player.orbs.ToString ();
        SoulsText.text = Player.souls.ToString ();
    }
    /*
     * Updates UI's current resource per second info
     */
    private void UpdateP1Text () {
        GoldP1Text.text = "(" + Server.GetGoldP1 ().ToString () + "/s)";
        OrbsP1Text.text = "(" + Server.GetOrbsP1 ().ToString () + "/s)";
        SoulsP1Text.text = "(" + Server.GetSoulsP1 ().ToString () + "/s)";
    }

    private void UpdateStageInfo () {
        StageNameText.text = Stages.stageNames[Player.stage];
        StageText.text = Player.stage + " - " + Player.stageLevel;
        BGFront.sprite = Stages.BGFronts[Player.stage];
        BGBack.sprite = Stages.BGBacks[Player.stage];
    }

    public void toggleHeroWindowOpen () {
        if (heroWindowOpen) {
            heroWindowOpen = false;
        } else {
            heroWindowOpen = true;
        }
    }
}