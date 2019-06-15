using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgEnemyPopperData {

    public StgEnemyPopperData() {
        popType = StgEnemyPopperConstant.PopType.kTime;
        popTime = 0;
    }

    public StgEnemyPopperData(StgEnemyPopperConstant.PopType popType, int popTime) {
        this.popType = popType;
        this.popTime = popTime;
    }

    private StgEnemyPopperConstant.PopType popType; // 出現タイプ
    private int popTime; // 出現時間(出現タイプが時間のときに使用)
}
