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

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    void Init()
    {
        // 向かう座標を取得する
        _centerPoint = WayPoints.GetCenterPointRandom();
        _escapePoint = WayPoints.GetEscapePointRandom();

        // 画面中央に向けて移動する
        // 画面中央にしばらく漂う
        // 画面外に逃げる
    }
}
