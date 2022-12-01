using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトル画面を制御するコンポーネント
/// </summary>
public class TitleStream : MonoBehaviour
{
    public void Init()
    {
        // 初期化処理を必要に応じて書く
    }

    public IEnumerator StreamCoroutine()
    {
        // TODO:タイトル画面の処理
        //      処理を返す時がタイトル画面を抜けるとき
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }
}
