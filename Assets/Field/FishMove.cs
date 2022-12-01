using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 魚を移動させるコンポーネント
/// </summary>
public class FishMove : MonoBehaviour
{
    Sequence _seq;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>DotWeenで目標まで移動させる</summary>
    public IEnumerator MoveTo(Transform target, float speed)
    {
        // ターゲットの方を向かせる
        Vector3 dir = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        Vector3 rot = transform.eulerAngles;
        transform.eulerAngles = new Vector3(rot.x, rot.y, rot.z - 90);

        yield return transform.DOMove(target.position, speed).WaitForCompletion();
    }
}
