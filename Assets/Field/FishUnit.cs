using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ‹›’P‘Ì‚ğ§Œä‚·‚é
/// </summary>
public class FishUnit : MonoBehaviour
{
    Transform _centerPoint;
    Transform _escapePoint;

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    void Init()
    {
        // Œü‚©‚¤À•W‚ğæ“¾‚·‚é
        _centerPoint = WayPoints.GetCenterPointRandom();
        _escapePoint = WayPoints.GetEscapePointRandom();

        // ‰æ–Ê’†‰›‚ÉŒü‚¯‚ÄˆÚ“®‚·‚é
        // ‰æ–Ê’†‰›‚É‚µ‚Î‚ç‚­•Y‚¤
        // ‰æ–ÊŠO‚É“¦‚°‚é
    }
}
