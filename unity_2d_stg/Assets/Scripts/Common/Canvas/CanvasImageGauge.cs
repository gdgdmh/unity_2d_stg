using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャンバスに設定されたイメージに対してゲージとしての機能を制御する
/// ImageのImageTypeはFilledを選択すること
/// </summary>
public class CanvasImageGauge : MonoBehaviour {

    public CanvasImageGauge() {
        // デフォルト値
        gaugeName = kDefaultGaugeName;
    }

    private void Awake() {        
        InitializeGaugeObject();
    }

    // Start is called before the first frame update
    void Start() {
    }

    /// <summary>
    /// ゲージの値に生データを設定する(0.0f - 1.0f)
    /// </summary>
    /// <param name="value">設定する生データ</param>
    public void SetGaugeRaw(float value) {
        MhCommon.Assert(gauge != null, "CanvasImageGauge::SetGaugeRaw() gauge null");
        MhCommon.Assert((value >= 0.0f) && (value <= 1.0f), "CanvasImageGauge::SetGaugeRaw() value invalid(0.0f - 1.0f) over range");
        gauge.fillAmount = value;
    }

    /// <summary>
    /// ゲージの値にパーセンテージで設定する
    /// </summary>
    /// <param name="percent">ゲージのパーセンテージ</param>
    public void SetGaugePercent(float percent) {
        MhCommon.Assert(gauge != null, "CanvasImageGauge::SetGaugeRaw() gauge null");
        MhCommon.Assert((percent >= 0.0f) && (percent <= 100.0f), "CanvasImageGauge::SetGaugeRaw() value invalid(0.0f - 100.0f) over range");
        float gaugeValue = CalcPercentToValue.Get(percent, 1.0f);
        gauge.fillAmount = gaugeValue;
    }

    /// <summary>
    /// ゲージオブエジェクトの初期化(取得)
    /// </summary>
    private void InitializeGaugeObject() {
        gauge = GameObject.Find(gaugeName).GetComponent<UnityEngine.UI.Image>();
        MhCommon.Assert(gauge != null, "CanvasImageGauge::InitializeGaugeObject() gauge find failure");
    }

    public static readonly string kDefaultGaugeName = "Gauge"; // findするゲージのデフォルト名
    public string gaugeName; // findするゲージの名前
    private UnityEngine.UI.Image gauge; // ゲージ用のイメージ
}
