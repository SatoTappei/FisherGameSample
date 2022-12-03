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
    static bool _isInited;

    /// <summary>現在釣りあげられているかのフラグ</summary>
    public bool IsCapture { get; private set; }

    IEnumerator Start()
    {
        // 周期がズレるので共通で使うフィールドをセットするだけで消す
        // TODO:無駄が多い処理
        if (_wayPoints == null || _dataBase == null)
        {
            yield return SetStaticFieldCoroutine();
            _isInited = true;
            gameObject.SetActive(false);
        }
        else
        {
            // SODataBaseの初期セットアップが出来ていなければ自身を削除する
            // TODO:無駄な処理、やり方が悪い
            if (!_isInited)
            {
                Destroy(gameObject);
                yield break;
            }

            // 自身を登録する
            FieldManager fm = new FieldManager();
            fm.Add(this);

            Status status = Init();

            // 画面中央に向けて移動する
            yield return _fishMove.MoveTo(status.center, status.so.Speed);
            // 漂う
            yield return new WaitForSeconds(status.so.WaitTime);
            // 画面外に逃げる
            yield return _fishMove.MoveTo(status.escape, status.so.Speed);
        }
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

    /// <summary>釣りあげられた際に呼ばれる処理</summary>
    public void Fished()
    {
        StartCoroutine(_fishMove.Fished());
        IsCapture = false;
    }

    /// <summary>逃げられた際に呼ばれる処理</summary>
    public void Escape()
    {
        StartCoroutine(_fishMove.Escape());
        IsCapture = false;
    }

    public void HitReceived()
    {
        // ヒットした際にぴちぴちさせる
        StartCoroutine(_fishMove.Captured());
        IsCapture = true;
    }
}
