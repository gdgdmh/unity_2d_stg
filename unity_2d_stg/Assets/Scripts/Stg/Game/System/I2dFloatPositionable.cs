using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I2dFloatPositionable {

    //Vector2 Position { set; get; }
    void SetX(float x);
    void SetY(float y);
    float GetX();
    float GetY();
}
