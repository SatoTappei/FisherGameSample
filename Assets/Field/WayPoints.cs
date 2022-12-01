using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// �����ڎw���|�C���g��ێ�����N���X
/// ��ʒ����̍��W�ɂ̓I�u�W�F�N�g��CenterPoint�^�O��t����
/// ��ʊO�̍��W�ɂ̓I�u�W�F�N�g��EscapePoint�^�O��t����
/// </summary>
class WayPoints
{
    /// <summary>��ʒ����̍��W�̃��X�g</summary>
    List<Transform> _cpList;
    /// <summary>��ʊO�̍��W�̃��X�g</summary>
    List<Transform> _epList;

    public WayPoints()
    {
        _cpList = GameObject.FindGameObjectsWithTag("CenterPoint").Select(g => g.transform).ToList();
        _epList = GameObject.FindGameObjectsWithTag("EscapePoint").Select(g => g.transform).ToList();
    }

    // �w�肵�����X�g�̒����烉���_���Ɏ擾���Ă���
    public Transform GetCenterPointRandom() => _cpList[Random.Range(0, _cpList.Count)];
    public Transform GetEscapePointRandom() => _epList[Random.Range(0, _epList.Count)];
}
