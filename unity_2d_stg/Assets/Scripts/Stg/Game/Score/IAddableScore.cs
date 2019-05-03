using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAddableScore {

    /// <summary>
    /// スコアの加算
    /// </summary>
    /// <param name="score">加算するスコア</param>
    void AdditionalScore(int score);
}
