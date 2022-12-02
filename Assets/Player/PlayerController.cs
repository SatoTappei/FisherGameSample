using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// プレイヤーの各コンポーネントを制御する
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _floatPrefab;
    [SerializeField] Transform _floatPivot;

    Camera _camera;

    IEnumerator Start()
    {
        Init();

        // 予め生成しておく
        GameObject go = Instantiate(_floatPrefab, _floatPivot.position, Quaternion.identity);

        // マウスの位置に浮きを投げる
        yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
        Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        // クリックされたらその位置に飛ばす
        go.transform.DOMove(pos, 0.5f);

        // 浮きの感知範囲に魚が入ったら釣りバトル開始
        // スペースキー連打でバトルする
        // 毎フレームカウントが下がり続け、0になったら敗北
        // 勝てば魚ゲット、カウントアップ
        // 負けたら魚逃げる
    }

    void Update()
    {
        
    }

    void Init()
    {
        _camera = Camera.main;
    }
}
