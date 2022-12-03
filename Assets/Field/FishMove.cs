using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

/// <summary>
/// �����ړ�������R���|�[�l���g
/// </summary>
public class FishMove : MonoBehaviour
{
    Tween _tween;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>DotWeen�ŖڕW�܂ňړ�������</summary>
    public IEnumerator MoveTo(Transform target, float speed, UnityAction action = null)
    {
        if (_tween != null && _tween.active) yield break;

        // �^�[�Q�b�g�̕�����������
        Vector3 dir = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        Vector3 rot = transform.eulerAngles;
        transform.eulerAngles = new Vector3(rot.x, rot.y, rot.z - 90);

        _tween = transform.DOMove(target.position, speed);

        yield return _tween.WaitForCompletion();

        // TODO:�R�[���o�b�N�̎d�g�݂��t���Đn
        if (action != null) action.Invoke();
    }

    /// <summary>�҂��҂�������</summary>
    public IEnumerator Captured()
    {
        // �g�D�E�B�[�����Ȃ�Kill����
        if (_tween != null) _tween.Kill();

        _tween = transform.DOShakePosition(99, 1, 10).SetLoops(-1);

        // ��̊g���ɑΉ��ł���悤��1�t���[���̑ҋ@���s��
        yield return null;
    }
}
