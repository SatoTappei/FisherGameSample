using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

/// <summary>
/// 浮き輪の制御を行うコンポーネント
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
        // テスト用
        //if (Input.GetKeyDown(KeyCode.D)) Destroy(gameObject);
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
        });
    }

    void OnDestroy()
    {
        _tween.Kill();
    }
}
