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
        // �u�}�E�X�̈ʒu�v�Ɓu�Ə���̈ʒu�v�𓯊�������B
        transform.position = Input.mousePosition;

        RaycastHit hit;

        // MainCamera����}�E�X�̈ʒu��Ray���΂�
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit))
        {
            // Ray��Collider�ƏՓ˂����n�_�̍��W���擾
            targetPos = hit.point;

        }
    }
}