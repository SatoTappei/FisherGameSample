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
    public enum AddressTag
    {
        Purple,
        Red,
        Yellow,
        // 新しく敵を作ったらここに識別用のタグを追加する
    }

    // AddressTagの個数、新しく敵を作ったら増やす
    const int MaxAddressTag = 3;

    [SerializeField] Sprite _sprite;
    [Header("このSOを取得するために使う識別用のタグ")]
    [SerializeField] AddressTag _tag;
    [Header("座標間の移動速度")]
    [SerializeField] float _speed;
    [Header("次の座標に向かうまでの待機時間")]
    [SerializeField] float _waitTime;

    public Sprite Sprite { get => _sprite; }
    public float Speed { get => _speed; }
    public float WaitTime { get => _waitTime; }
    public AddressTag Tag { get => _tag; }

    public static int GetAddressTagCount() => MaxAddressTag;
}
