using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>フィールドを管理するコンポーネント</summary>
public class FieldManager : MonoBehaviour
{
    [SerializeField] Generator[] _generators;

    //async Task<IEnumerator> StartAsync()
    //{
    //    // WayPointsコンポ…Staticを外す
    //    // SODataBaseコンポ…これもStaticを外す
    //    // Generatorの上にFieldを管理するクラスを作る
    //    // Generatorで魚を生成して返すようにする
    //    // 返ってきた魚に対してWayPointsとSODataBaseで諸々を割り当てるようにする
    //    WayPoints wayPoints = new WayPoints();
    //    SODataBase dataBase = new SODataBase();

    //    await dataBase.Init();
    //}

    void Update()
    {
        
    }
}
