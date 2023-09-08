using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction2 : MonoBehaviour
{
    public AimController_Z acz;
    private Vector3 targetPosition;

    public float speed;
    private float step;

    void Update()
    {
        // （テクニック）「ターゲットの高さ」と「戦車ヘッドの高さ」を揃える。
        // これでヘッド部分が「真横に旋回」するようになる。
        acz.targetPos.y = transform.position.y;

        targetPosition = acz.targetPos;

        step = speed * Time.deltaTime;

        Vector3 targetDir = targetPosition - transform.position;

        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);

        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
