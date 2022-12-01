using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// �����ړ�������R���|�[�l���g
/// </summary>
public class FishMove : MonoBehaviour
{
    Sequence _seq;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>DotWeen�ŖڕW�܂ňړ�������</summary>
    public IEnumerator MoveTo(Transform target, float speed)
    {
        // �^�[�Q�b�g�̕�����������
        Vector3 dir = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        Vector3 rot = transform.eulerAngles;
        transform.eulerAngles = new Vector3(rot.x, rot.y, rot.z - 90);

        yield return transform.DOMove(target.position, speed).WaitForCompletion();
    }
}
