using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 魚の各コンポーネントを制御する
/// </summary>
public class FishUnit : MonoBehaviour
{
    [SerializeField] FishMove _fishMove;

    Transform _centerPoint;
    Transform _escapePoint;

    IEnumerator Start()
    {
        Init();

        // 画面中央に向けて移動する
        yield return _fishMove.MoveTo(_centerPoint, 0.5f);
        // 画面外に逃げる
        yield return _fishMove.MoveTo(_escapePoint, 0.5f);
    }

    void Update()
    {
        
    }

    void Init()
    {
        // 向かう座標を取得する
        _centerPoint = WayPoints.GetCenterPointRandom();
        _escapePoint = WayPoints.GetEscapePointRandom();

        // TODO
        // SOを取得してくる
        // 画像をSO内の魚の画像に差し替え
        // SOへの参照をパラメータとして保持
    }
}
