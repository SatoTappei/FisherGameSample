using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体の流れを制御するコンポーネント
/// </summary>
public class InGameStream : MonoBehaviour
{
    [SerializeField] TitleStream _titleStream;
    [SerializeField] GameStartEffect _gameStartEffect;
    [SerializeField] GameOverEffect _gameOverEffect;
    [SerializeField] Generator[] _generators;

    IEnumerator Start()
    {
        // タイトル画面
        _titleStream.Init();
        yield return _titleStream.StreamCoroutine();
        // ゲームスタート！
        _gameStartEffect.Init();
        yield return _gameStartEffect.StreamCoroutine();
        // ジェネレータを稼働させる
        foreach (Generator gen in _generators)
        {
            gen.IsActive = true;
        }

        // ゲーム中

        // ジェネレータを停止させる
        //foreach (Generator gen in _generators)
        //{
        //    gen.IsActive = false;
        //}
        // ゲームオーバー
        _gameOverEffect.Init();
        yield return _gameOverEffect.StreamCoroutine();
    }

    void Update()
    {
        
    }
}
