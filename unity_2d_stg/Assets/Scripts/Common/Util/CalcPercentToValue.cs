using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalcPercentToValue {
    public static float Get(float percent, float maxValue) {
        MhCommon.Assert(percent >= 0.0f, "CalcPercentToValue::Get() percent minus (invalidvalue)");
        return ((maxValue * percent) / 100.0f);
    }
}
