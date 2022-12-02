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

        while (true)
        {
            // マウスの位置に浮きを投げる
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            // 生成
            GameObject go = Instantiate(_floatPrefab, _floatPivot.position, Quaternion.identity);

            //Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            //pos.z = 0;

            // クリックされたらその位置に飛ばす
            //Tween t = go.transform.DOMove(pos, 0.5f);
            // 指定位置まで来たらコライダーをオンにする

            yield return new WaitUntil(() => go == null);

            // ゲージ作成
            // 0になったときのコールバックと1になったときのコールバックを登録する
            // UnityEvent…ボタンのやつとか使えないか検討

            //t.Kill();
            Debug.Log("浮きが消えました");
        }
        // 浮きの感知範囲に魚が入ったら釣りバトル開始
        // インターフェースで実装

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
