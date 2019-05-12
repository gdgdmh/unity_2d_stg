using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // HPゲージ取得
       CanvasImageGauge gauge = GameObject.Find("Gauge").GetComponent<CanvasImageGauge>();
        // 0.2にテストで設定
        gauge.SetGaugeRaw(0.2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
