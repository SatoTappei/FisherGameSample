using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの各コンポーネントを制御する
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _floatPrefab;
    [SerializeField] Transform _floatCursor;

    void Start()
    {
        // マウスの位置に浮きを投げる
        // 浮きの感知範囲に魚が入ったら釣りバトル開始
        // スペースキー連打でバトルする
        // 毎フレームカウントが下がり続け、0になったら敗北
        // 勝てば魚ゲット、カウントアップ
        // 負けたら魚逃げる
    }

    void Update()
    {
        
    }
}
