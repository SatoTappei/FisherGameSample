using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトル画面を制御するコンポーネント
/// </summary>
public class TitleStream : MonoBehaviour
{

    public IEnumerator Stream()
    {
        // タイトル画面の処理
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }
}
