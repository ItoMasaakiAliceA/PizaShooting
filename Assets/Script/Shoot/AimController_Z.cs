using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController_Z : MonoBehaviour
{
    public Vector3 targetPos;
    public Image aimImage;

    void Update()
    {
        // 「マウスの位置」と「照準器の位置」を同期させる。
        transform.position = Input.mousePosition;

        RaycastHit hit;

        // MainCameraからマウスの位置にRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit))
        {
            // RayがColliderと衝突した地点の座標を取得
            targetPos = hit.point;

        }
    }
}