using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerHealth : MonoBehaviour, IStgPlayerHealthObserver {

    // Start is called before the first frame update
    void Start() {
        // HPゲージ取得
       gauge = GameObject.Find("Gauge").GetComponent<CanvasImageGauge>();
       gauge.SetGaugeRaw(1.0f);

        MhCommon.Assert(player != null, "StgPlayerHealth::Start() player null");
        playerScript = this.player.GetComponent<StgPlayer>();
        MhCommon.Assert(playerScript != null, "StgPlayerHealth::Start() playerScript null");
        playerScript.SetHealthObserver(this);
    }

    // Update is called once per frame
    void Update() {        
    }

    public void UpdateHealth(int maxHealth, int currentHealth, int diffHealth) {
        // 更新
        MhCommon.Print("StgPlayerHealth::UpdateHealth() called max=" + maxHealth + " cur=" + currentHealth + " diff=" + diffHealth);
        gauge.SetGaugePercent(CalcPercent.Get((float)maxHealth, (float)currentHealth));
    }

    //public void SetPlayer(ref GameObject player) {
    //}

    //public void SetStgPlayer(ref GameObject player) {
    //}

	public GameObject player;
    private StgPlayer playerScript;
    private CanvasImageGauge gauge;
}
