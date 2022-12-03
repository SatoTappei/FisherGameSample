using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

/// <summary>
/// 浮き輪の制御を行うコンポーネント
/// </summary>
public class FloatPrefab : MonoBehaviour
{
    [SerializeField] Collider2D _col;

    Sequence _sequence;
    /// <summary>
    /// 表示非表示で使いまわすので生成された位置をデフォルトの位置として保持しておく
    /// </summary>
    Vector3 _defaultPos;

    /// <summary>魚に当たった際には浮きを消せないようにする</summary>
    bool _isHit;

    /// <summary>浮き輪が魚に当たったときに呼ばれる追加の処理</summary>
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
        // 右クリックで消すことが出来る
        if (Input.GetMouseButtonDown(1) && !_isHit)
            gameObject.SetActive(false);
    }

    /// <summary>マウスカーソルの位置に移動させる</summary>
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

        // 2匹以上ヒットしないように判定を消す
        _col.enabled = false;
        Debug.Log("ヒット");
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
