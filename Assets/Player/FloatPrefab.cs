using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �����ւ̐�����s���R���|�[�l���g
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
