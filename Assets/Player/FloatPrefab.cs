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

    Tween _tween;
    /// <summary>
    /// 表示非表示で使いまわすので生成された位置をデフォルトの位置として保持しておく
    /// </summary>
    Vector3 _defaultPos;

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
        _tween.Kill();
        transform.position = _defaultPos;
    }

    void Update()
    {
        // テスト用
        if (Input.GetKeyDown(KeyCode.D)) gameObject.SetActive(false);
    }

    /// <summary>マウスカーソルの位置に移動させる</summary>
    void Move()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        _tween = transform.DOMove(pos, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 2匹以上ヒットしないように判定を消す
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
