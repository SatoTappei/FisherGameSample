using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

/// <summary>
/// �����ւ̐�����s���R���|�[�l���g
/// </summary>
public class FloatPrefab : MonoBehaviour
{
    [SerializeField] Collider2D _col;

    Tween _tween;

    void Start()
    {
        Move();
    }

    void Update()
    {
        // �e�X�g�p
        //if (Input.GetKeyDown(KeyCode.D)) Destroy(gameObject);
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
        });
    }

    void OnDestroy()
    {
        _tween.Kill();
    }
}
