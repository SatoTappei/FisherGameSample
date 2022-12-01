using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 魚毎に共通したデータのSO
/// FishUnitクラスがFactoryクラス経由で取得する
/// </summary>
[CreateAssetMenu]
public class FishDataSO : ScriptableObject
{
    [SerializeField] Sprite _sprite;
    [Header("座標間の移動速度")]
    [SerializeField] float _speed;
    [Header("次の座標に向かうまでの待機時間")]
    [SerializeField] float _waitTime;

    public Sprite Sprite { get => _sprite; }
    public float Speed { get => _speed; }
    public float WaitTime { get => _waitTime; }
}
