using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム終了時の演出を行う
/// </summary>
public class GameOverEffect : MonoBehaviour
{
    public void Init()
    {
        // 初期化処理を必要に応じて書く
    }

    public IEnumerator StreamCoroutine()
    {
        // TODO:ゲームスタートの演出の処理
        //      この処理を抜けたタイミングがゲームスタート
        yield return null;
    }
}
