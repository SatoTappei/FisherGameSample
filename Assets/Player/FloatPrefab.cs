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

    Tween _tween;
    /// <summary>
    /// �\����\���Ŏg���܂킷�̂Ő������ꂽ�ʒu���f�t�H���g�̈ʒu�Ƃ��ĕێ����Ă���
    /// </summary>
    Vector3 _defaultPos;

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
        _tween.Kill();
        transform.position = _defaultPos;
    }

    void Update()
    {
        // �e�X�g�p
        if (Input.GetKeyDown(KeyCode.D)) gameObject.SetActive(false);
    }

    /// <summary>�}�E�X�J�[�\���̈ʒu�Ɉړ�������</summary>
    void Move()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        _tween = transform.DOMove(pos, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 2�C�ȏ�q�b�g���Ȃ��悤�ɔ��������
        _col.enabled = false;

        ExecuteEvents.Execute<IFloatHitable>(collision.gameObject, null, (reciever, _) =>
        {
            reciever.HitReceived();
            OnHited.Invoke();
        });
    }

    void OnDestroy()
    {
        _tween.Kill();
    }
}
