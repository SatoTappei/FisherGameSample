using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

/// <summary>
/// 魚を移動させるコンポーネント
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

    /// <summary>DotWeenで目標まで移動させる</summary>
    public IEnumerator MoveTo(Transform target, float speed, UnityAction action = null)
    {
        if (_tween != null && _tween.active) yield break;

        // ターゲットの方を向かせる
        Vector3 dir = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        Vector3 rot = transform.eulerAngles;
        transform.eulerAngles = new Vector3(rot.x, rot.y, rot.z - 90);

        _tween = transform.DOMove(target.position, speed);

        yield return _tween.WaitForCompletion();

        // TODO:コールバックの仕組みが付け焼刃
        if (action != null) action.Invoke();
    }

    /// <summary>ぴちぴちさせる</summary>
    public IEnumerator Captured()
    {
        // トゥウィーン中ならKillする
        if (_tween != null) _tween.Kill();

        _tween = transform.DOShakePosition(99, 1, 10).SetLoops(-1);

        // 後の拡張に対応できるように1フレームの待機を行う
        yield return null;
    }
}
