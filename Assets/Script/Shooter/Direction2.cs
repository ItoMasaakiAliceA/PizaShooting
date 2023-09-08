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
        // �i�e�N�j�b�N�j�u�^�[�Q�b�g�̍����v�Ɓu��ԃw�b�h�̍����v�𑵂���B
        // ����Ńw�b�h�������u�^���ɐ���v����悤�ɂȂ�B
        acz.targetPos.y = transform.position.y;

        targetPosition = acz.targetPos;

        step = speed * Time.deltaTime;

        Vector3 targetDir = targetPosition - transform.position;

        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);

        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
