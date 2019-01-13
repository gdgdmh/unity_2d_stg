using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem {

    public InputSystem() {
        unitySingleTouchAction = new UnitySingleTouchAction();
        unitySingleTouchDragAction = new UnitySingleTouchDragAction();
    }

    public void Initialize() {
        unitySingleTouchAction.Initialize();
        unitySingleTouchDragAction.Initialize();
    }

    public void SetDisplaySize(int width, int height) {
        unitySingleTouchAction.SetDisplaySize(width, height);
        unitySingleTouchDragAction.SetDisplaySize(width, height);
    }

    public UnitySingleTouchAction GetSingleTouchAction() {
        return unitySingleTouchAction;
    }

    public UnitySingleTouchDragAction GetSingleTouchDragAction() {
        return unitySingleTouchDragAction;
    }

    private UnitySingleTouchAction unitySingleTouchAction;
    private UnitySingleTouchDragAction unitySingleTouchDragAction;
}
