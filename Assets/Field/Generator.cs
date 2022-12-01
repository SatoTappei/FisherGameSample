using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 魚を生成するコンポーネント
/// </summary>
public class Generator : MonoBehaviour
{
    [SerializeField] GameObject _prefabs;
    [SerializeField] float _distance;

    [Header("ジェネレータの稼働と停止を切り替える")]
    public bool IsActive = false;

    IEnumerator Start()
    {
        // 外部から稼働されるまで待つ
        yield return new WaitUntil(() => IsActive);

        while (IsActive)
        {
            Instantiate(_prefabs, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_distance);
        }
        Debug.Log("ジェネレータ停止");
    }

    void Update()
    {
        
    }
}
