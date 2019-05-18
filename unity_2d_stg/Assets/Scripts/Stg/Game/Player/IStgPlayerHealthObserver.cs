using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのイベントリスナー
/// </summary>
public interface IStgPlayerHealthObserver {
    void UpdateHealth(int maxHealth, int currentHealth, int diffHealth);
}
