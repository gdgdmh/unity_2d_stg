using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalcPercent {
    public static float Get(float maxValue, float currentValue) {
        MhCommon.Assert(maxValue != 0.0f, "CalcPercent::Get() maxValue 0.0f");
        MhCommon.Assert(maxValue > 0.0f, "CalcPercent::Get() maxValue=" + maxValue + " (invalid value)");
        //MhCommon.Assert(currentValue > 0.0f, "CalcPercent::Get() currentValue " + currentValue + " minus(invalid value)");
        return ((currentValue * 100.0f) / maxValue);
    }
}
