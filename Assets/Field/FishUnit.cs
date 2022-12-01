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

    IEnumerator Start()
    {
        Init();

        // ��ʒ����Ɍ����Ĉړ�����
        yield return _fishMove.MoveTo(_centerPoint, 0.5f);
        // ��ʊO�ɓ�����
        yield return _fishMove.MoveTo(_escapePoint, 0.5f);
    }

    void Update()
    {
        
    }

    void Init()
    {
        // ���������W���擾����
        _centerPoint = WayPoints.GetCenterPointRandom();
        _escapePoint = WayPoints.GetEscapePointRandom();

        // TODO
        // SO���擾���Ă���
        // �摜��SO���̋��̉摜�ɍ����ւ�
        // SO�ւ̎Q�Ƃ��p�����[�^�Ƃ��ĕێ�
    }
}
