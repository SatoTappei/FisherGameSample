using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �����ւ��q�b�g������Ă΂�鏈���̃C���^�[�t�F�[�X
/// </summary>
interface IFloatHitable : IEventSystemHandler
{
    void HitReceived();
}
