using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTestSceneTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        SceneShare.Instance.Initialize();
        
    }

    // Update is called once per frame
    void Update() {
        UnitySingleTouchAction touchAction = SceneShare.Instance.GetInput().GetSingleTouchAction();
        UnitySingleTouchDragAction dragAction = SceneShare.Instance.GetInput().GetSingleTouchDragAction();
        touchAction.Update();
        dragAction.Update();

        dragAction.PrintDifference();

        //if (dragAction.IsDragging()) {
        //    MhCommon.Print("dragging");
        //}
        //if (dragAction.IsDragBegan()) {
        //    MhCommon.Print("dragBegan");
        //}
        //if (touchAction.IsDragging()) {
            //MhCommon.Print("dragging");
            //Vector3 sp = touchAction.GetDragEndPosition();
            //Vector3 sp = touchAction.GetDragCurrentPosition();

            //MhCommon.Print("x = " + sp.x + " y = " + sp.y + " z = " + sp.z);

        //}

    }
}
