using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2dFloatPosition : I2dFloatPositionable {

	public Object2dFloatPosition() {
	}

	public Object2dFloatPosition(float x, float y) {
		Position = new Vector2(x, y);
		//Position.Set(x, y);
	}

	/*
    public Vector2 Position {
        set { Position = value; }
        get { return Position; }
    }
	*/

	public Vector2 Position;

    public void SetX(float x) {
    //void I2dFloatPositionable.SetX(float x) {
		Position = new Vector2(x, Position.y);
    }

    public void SetY(float y) {
		Position = new Vector2(Position.x, y);
        //Position.y = y;
    }

    public float GetX() {
		return Position.x;
        //return 0;
        //return Position.x;
    }

    public float GetY() {
		return Position.y;
        //return 0;
        //return Position.y;
    }


}
