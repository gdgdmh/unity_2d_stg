using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2dFloatPosition : I2dFloatPositionable {

    public Vector2 Position {
        set { Position = value; }
        get { return Position; }
    }

    void I2dFloatPositionable.SetX(float x) {
        //Position
    }

    void I2dFloatPositionable.SetY(float y) {
        //Position.y = y;
    }

    float I2dFloatPositionable.GetX() {
        return 0;
        //return Position.x;
    }

    float I2dFloatPositionable.GetY() {
        return 0;
        //return Position.y;
    }


}
