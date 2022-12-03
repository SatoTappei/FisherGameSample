using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// 魚の各コンポーネントを制御する
/// </summary>
public class FishUnit : MonoBehaviour , IFloatHitable
{
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] FishMove _fishMove;

    struct Status
    {
        // 目標座標
        public Transform center;
        public Transform escape;
        // 共通データのSO
        public FishDataSO so;
    }

    static WayPoints _wayPoints;
    static SODataBase _dataBase;

    IEnumerator Start()
    {
        // 周期がズレるので共通で使うフィールドをセットするだけで消す
        // TODO:無駄が多い処理
        if (_wayPoints == null || _dataBase == null)
        {
            yield return SetStaticFieldCoroutine();
        }
        else
        {
            Status status = Init();

            // 画面中央に向けて移動する
            yield return _fishMove.MoveTo(status.center, status.so.Speed);
            // 漂う
            yield return new WaitForSeconds(status.so.WaitTime);
            // 画面外に逃げる
            yield return _fishMove.MoveTo(status.escape, status.so.Speed);
        }

        // TODO:非表示にしてオブジェクトプールに流用できるようにしておく
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    /// <summary>共通で使うフィールドを生成、初期化する</summary>
    IEnumerator SetStaticFieldCoroutine()
    {
        _wayPoints = new WayPoints();
        _dataBase = new SODataBase();

        yield return _dataBase.Init();
    }

    Status Init()
    {
        Status status = new Status();
        status.center = _wayPoints.GetCenterPointRandom();
        status.escape = _wayPoints.GetEscapePointRandom();

        // randamu 
        FishDataSO.AddressTag tag = (FishDataSO.AddressTag)Random.Range(0, FishDataSO.GetAddressTagCount());
        status.so = _dataBase.GetSO(tag);

        _sr.sprite = status.so.Sprite;

        return status;
    }

    public void HitReceived()
    {
        Debug.Log("ヒットしました");
        StartCoroutine(_fishMove.Captured());
        // ヒットした際の処理を書く
        // キャラが釣りバトルする際のアニメーションみたいなの
    }
}
