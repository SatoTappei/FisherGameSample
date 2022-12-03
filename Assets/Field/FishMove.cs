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

    /// <summary>�ނ肠����ꂽ�ۂɋ����A�j���[�V�����ňړ�����ʒu</summary>
    static Transform _pivot;

    void Start()
    {
        // ���ʂ��d�������Ȃ̂�null�`�F�b�N����
        if (_pivot == null)
            _pivot = GameObject.FindGameObjectWithTag("FishedPivot").transform;
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
        yield return TweenCoroutine(transform.DOShakePosition(99, 1, 10).SetLoops(-1));
    }

    /// <summary>������</summary>
    public IEnumerator Escape()
    {
        yield return TweenCoroutine(transform.DOPunchScale(Vector3.zero, 0.5f));
    }

    /// <summary>�ނ肠������</summary>
    public IEnumerator Fished()
    {
        yield return TweenCoroutine(transform.DOMove(_pivot.position, 0.5f));
    }

    public IEnumerator TweenCoroutine(Tween tween)
    {
        if (_tween != null) _tween.Kill();

        _tween = tween;

        // ��̊g���ɑΉ��ł���悤��1�t���[���̑ҋ@���s��
        yield return null;
    }
}
