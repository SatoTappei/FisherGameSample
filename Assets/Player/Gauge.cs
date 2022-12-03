using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 魚との駆け引きを行うゲージを制御する
/// </summary>
public class Gauge : MonoBehaviour
{
    [SerializeField] Transform _damage;

    float _currentValue;

    // 釣りバトルの決着が着いたタイミングで呼ばれるコールバック
    public UnityAction OnWin;
    public UnityAction OnLose;

    void Awake()
    {
        // 任意のタイミングで表示させ、コルーチンを開始したいので生成時は非表示にしておく
        gameObject.SetActive(false);
    }

    IEnumerator Start()
    {
        while (true)
        {
            // 初期値を設定
            _currentValue = 0.5f;

            // ゲージが0もしくは1になるまで待つ
            // この間のゲージの増減はUpdateで行う
            yield return new WaitUntil(() => Check01());

            // 結果によって呼ぶコールバックを変える
            if (_currentValue <= 0)
            {
                OnLose.Invoke();
            }
            else if (_currentValue >= 1)
            {
                OnWin.Invoke();
            }

            // 次のバトル時にリセットする
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.R));
            Debug.Log("リセットシマス");
        }
    }

    void Update()
    {
        // ゲージが0もしくは1の場合は増減を行わない
        if (Check01()) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentValue += 0.05f;
        }
        else
        {
            _currentValue -= 0.001f;
        }

        _currentValue = Mathf.Clamp01(_currentValue);
        _damage.localScale = new Vector3(1 - _currentValue, 1, 1);
    }

    /// <summary>ゲージのScale.xが0もしくは1になっているかを返す</summary>
    bool Check01() => _currentValue <= 0 || _currentValue >= 1;
}
