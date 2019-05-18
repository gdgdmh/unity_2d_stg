using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerHealth : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        // HPゲージ取得
       CanvasImageGauge gauge = GameObject.Find("Gauge").GetComponent<CanvasImageGauge>();
        // 0.2にテストで設定
        //gauge.SetGaugeRaw(0.2f);
        gauge.SetGaugeRaw(1.0f);

        MhCommon.Assert(player != null, "StgPlayerHealth::Start() player null");
        playerScript = this.player.GetComponent<StgPlayer>();
        MhCommon.Assert(playerScript != null, "StgPlayerHealth::Start() playerScript null");
    }

    // Update is called once per frame
    void Update() {        
    }

    //public void SetPlayer(ref GameObject player) {
    //}

    //public void SetStgPlayer(ref GameObject player) {
    //}

	public GameObject player;
    private StgPlayer playerScript;
}
