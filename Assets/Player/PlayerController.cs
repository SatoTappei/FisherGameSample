using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// プレイヤーの各コンポーネントを制御する
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] Gauge _gauge;
    [SerializeField] GameObject _floatPrefab;
    [SerializeField] Transform _floatPivot;

    Camera _camera;

    IEnumerator Start()
    {
        Init();

        // 浮き輪を生成して非表示にしておく
        GameObject go = Instantiate(_floatPrefab, _floatPivot.position, Quaternion.identity);
        go.SetActive(false);
        // 浮き輪が魚に当たった時に呼ばれる追加の処理としてゲージの表示を追加する
        go.GetComponent<FloatPrefab>().OnHited += () => _gauge.gameObject.SetActive(true);

        _gauge.OnWin += () => Debug.Log("かちました");
        _gauge.OnLose += () => Debug.Log("まけました");

        while (true)
        {
            // マウスクリックされたら浮き輪を表示させる
            // 表示されると浮き輪はマウスの位置に動くようになっている
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            go.SetActive(true);

            //Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            //pos.z = 0;

            // クリックされたらその位置に飛ばす
            //Tween t = go.transform.DOMove(pos, 0.5f);
            // 指定位置まで来たらコライダーをオンにする

            // バトルの決着がついたタイミングで浮きが消えるのでここで待つ
            yield return new WaitUntil(() => !go.activeInHierarchy);

            // ゲージ作成
            // 0になったときのコールバックと1になったときのコールバックを登録する
            // UnityEvent…ボタンのやつとか使えないか検討

            // TODO:バトルの流れ
            // 魚にヒットしたらゲージを表示したい
            // バトルが終わったらゲージを非表示にしたい

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
