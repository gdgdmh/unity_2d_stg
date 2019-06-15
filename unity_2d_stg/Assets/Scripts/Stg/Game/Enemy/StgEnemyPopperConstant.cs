using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgEnemyPopperConstant {
	// 敵がPopするタイプ
    public enum PopType : int {
        kTime, // 時間による
        kNobody, // 敵がいないとき
        kBoss,  // ボス用
    };

}
