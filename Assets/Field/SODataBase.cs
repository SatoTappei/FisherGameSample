using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// ������SO�𓮓I�ɓǂݍ���Ńf�[�^�x�[�X�Ƃ��Ďg���N���X
/// �eSO�̓f�t�H���g�O���[�v�ɓo�^������A�A�h���X��simplify�ŕύX���Ă����B
/// </summary>
class SODataBase
{
    /// <summary>�ǂݍ���SO�̎����^</summary>
    Dictionary<FishDataSO.AddressTag, FishDataSO> _dic;

    /// <summary>
    /// �R���X�g���N�^�ŃR���[�`�����g���Ȃ��̂Ő�p�̃��\�b�h�ŏ��������s���B<br></br>
    /// LoadAssetAsync�ő҂������Ă���A������await�����΃R���X�g���N�^�ōs�����͉\�����A
    /// �ꉞ�񓯊��ōs�����\�b�h�Ȃ̂ł������Ă���
    /// </summary>
    public IEnumerator Init()
    {
        _dic = new Dictionary<FishDataSO.AddressTag, FishDataSO>();

        // ���I�Ɏ擾���Ă��Ď����^�Ɋi�[����
        AddressableAssetGroup group = AddressableAssetSettingsDefaultObject.Settings.DefaultGroup;
        foreach (AddressableAssetEntry entry in group.entries)
        {
            AsyncOperationHandle<FishDataSO> handle = Addressables.LoadAssetAsync<FishDataSO>(entry.address);
            yield return handle;
            _dic.Add(handle.Result.Tag, handle.Result);
        }
    }

    /// <summary>�^�O�ɑΉ�����SO��Ԃ�</summary>
    public FishDataSO GetSO(FishDataSO.AddressTag tag) => _dic[tag];
}
