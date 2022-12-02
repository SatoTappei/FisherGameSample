using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 浮き輪がヒットしたら呼ばれる処理のインターフェース
/// </summary>
interface IFloatHitable : IEventSystemHandler
{
    void HitReceived();
}
