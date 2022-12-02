using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 浮き輪の制御を行うコンポーネント
/// </summary>
public class FloatPrefab : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ExecuteEvents.Execute<IFloatHitable>(collision.gameObject, null, (reciever, _) =>
        {
            reciever.HitReceived();
        });
    }
}
