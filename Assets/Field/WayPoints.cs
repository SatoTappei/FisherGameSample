using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 魚が目指すポイントを保持するクラス
/// 画面中央の座標にはオブジェクトにCenterPointタグを付ける
/// 画面外の座標にはオブジェクトにEscapePointタグを付ける
/// </summary>
class WayPoints
{
    /// <summary>画面中央の座標のリスト</summary>
    List<Transform> _cpList;
    /// <summary>画面外の座標のリスト</summary>
    List<Transform> _epList;

    public WayPoints()
    {
        _cpList = GameObject.FindGameObjectsWithTag("CenterPoint").Select(g => g.transform).ToList();
        _epList = GameObject.FindGameObjectsWithTag("EscapePoint").Select(g => g.transform).ToList();
    }

    // 指定したリストの中からランダムに取得してくる
    public Transform GetCenterPointRandom() => _cpList[Random.Range(0, _cpList.Count)];
    public Transform GetEscapePointRandom() => _epList[Random.Range(0, _epList.Count)];
}
