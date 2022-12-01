using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���𐶐�����R���|�[�l���g
/// </summary>
public class Generator : MonoBehaviour
{
    [SerializeField] GameObject _prefabs;
    [SerializeField] float _distance;

    [Header("�W�F�l���[�^�̉ғ��ƒ�~��؂�ւ���")]
    public bool IsActive = false;

    IEnumerator Start()
    {
        // �O������ғ������܂ő҂�
        yield return new WaitUntil(() => IsActive);

        while (IsActive)
        {
            Instantiate(_prefabs, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_distance);
        }
        Debug.Log("�W�F�l���[�^��~");
    }

    void Update()
    {
        
    }
}
