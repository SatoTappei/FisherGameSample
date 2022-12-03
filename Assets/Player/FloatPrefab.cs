using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

/// <summary>
/// �����ւ̐�����s���R���|�[�l���g
/// </summary>
public class FloatPrefab : MonoBehaviour
{
    [SerializeField] Collider2D _col;

    Sequence _sequence;
    /// <summary>
    /// �\����\���Ŏg���܂킷�̂Ő������ꂽ�ʒu���f�t�H���g�̈ʒu�Ƃ��ĕێ����Ă���
    /// </summary>
    Vector3 _defaultPos;

    /// <summary>���ɓ��������ۂɂ͕����������Ȃ��悤�ɂ���</summary>
    bool _isHit;

    /// <summary>�����ւ����ɓ��������Ƃ��ɌĂ΂��ǉ��̏���</summary>
    public UnityAction OnHited;

    void Awake()
    {
        _defaultPos = transform.position;
    }

    void OnEnable()
    {
        Move();
    }

    void OnDisable()
    {
        _sequence.Kill();
        transform.position = _defaultPos;
        _isHit = false;
    }

    void Update()
    {
        // �E�N���b�N�ŏ������Ƃ��o����
        if (Input.GetMouseButtonDown(1) && !_isHit)
            gameObject.SetActive(false);
    }

    /// <summary>�}�E�X�J�[�\���̈ʒu�Ɉړ�������</summary>
    void Move()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        _sequence = DOTween.Sequence()
                    .Append(transform.DOMove(pos, 0.5f))
                    .AppendCallback(() => _col.enabled = true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isHit) return;

        // 2�C�ȏ�q�b�g���Ȃ��悤�ɔ��������
        _col.enabled = false;
        Debug.Log("�q�b�g");
        _isHit = true;

        ExecuteEvents.Execute<IFloatHitable>(collision.gameObject, null, (reciever, _) =>
        {
            reciever.HitReceived();
            OnHited.Invoke();
        });
    }

    void OnDestroy()
    {
        _sequence.Kill();
    }
}
