using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���P�̂𐧌䂷��
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
        // ���������W���擾����
        _centerPoint = WayPoints.GetCenterPointRandom();
        _escapePoint = WayPoints.GetEscapePointRandom();

        // ��ʒ����Ɍ����Ĉړ�����
        // ��ʒ����ɂ��΂炭�Y��
        // ��ʊO�ɓ�����
    }
}
