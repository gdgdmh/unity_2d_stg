using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalcPercent {
    public static float Get(float maxValue, float currentValue) {
        MhCommon.Assert(maxValue == 0.0f, "CalcPercent::Get() maxValue 0.0f");
        MhCommon.Assert((maxValue < 0.0f) || (currentValue < 0.0f), "CalcPercent::Get() parameter minus(invalid value)");
        return ((currentValue * 100.0f) / maxValue);
    }
}
