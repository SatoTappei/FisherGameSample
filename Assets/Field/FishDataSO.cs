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
    [SerializeField] Sprite _sprite;
    [Header("���W�Ԃ̈ړ����x")]
    [SerializeField] float _speed;
    [Header("���̍��W�Ɍ������܂ł̑ҋ@����")]
    [SerializeField] float _waitTime;

    public Sprite Sprite { get => _sprite; }
    public float Speed { get => _speed; }
    public float WaitTime { get => _waitTime; }
}
