using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ɋ��ʂ����f�[�^��SO
/// FishUnit�N���X��Factory�N���X�o�R�Ŏ擾����
/// </summary>
[CreateAssetMenu]
public class FishDataSO : ScriptableObject
{
    public enum AddressTag
    {
        Purple,
        Red,
        Yellow,
        // �V�����G��������炱���Ɏ��ʗp�̃^�O��ǉ�����
    }

    // AddressTag�̌��A�V�����G��������瑝�₷
    const int MaxAddressTag = 3;

    [SerializeField] Sprite _sprite;
    [Header("����SO���擾���邽�߂Ɏg�����ʗp�̃^�O")]
    [SerializeField] AddressTag _tag;
    [Header("���W�Ԃ̈ړ����x")]
    [SerializeField] float _speed;
    [Header("���̍��W�Ɍ������܂ł̑ҋ@����")]
    [SerializeField] float _waitTime;

    public Sprite Sprite { get => _sprite; }
    public float Speed { get => _speed; }
    public float WaitTime { get => _waitTime; }
    public AddressTag Tag { get => _tag; }

    public static int GetAddressTagCount() => MaxAddressTag;
}
