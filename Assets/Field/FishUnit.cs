using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���̊e�R���|�[�l���g�𐧌䂷��
/// </summary>
public class FishUnit : MonoBehaviour
{
    [SerializeField] FishMove _fishMove;

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
