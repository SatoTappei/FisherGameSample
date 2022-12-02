using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// �v���C���[�̊e�R���|�[�l���g�𐧌䂷��
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _floatPrefab;
    [SerializeField] Transform _floatPivot;

    Camera _camera;

    IEnumerator Start()
    {
        Init();

        while (true)
        {
            // �}�E�X�̈ʒu�ɕ����𓊂���
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            // ����
            GameObject go = Instantiate(_floatPrefab, _floatPivot.position, Quaternion.identity);

            //Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            //pos.z = 0;

            // �N���b�N���ꂽ�炻�̈ʒu�ɔ�΂�
            //Tween t = go.transform.DOMove(pos, 0.5f);
            // �w��ʒu�܂ŗ�����R���C�_�[���I���ɂ���

            yield return new WaitUntil(() => go == null);

            //t.Kill();
            Debug.Log("�����������܂���");
        }
        // �����̊��m�͈͂ɋ�����������ނ�o�g���J�n
        // �C���^�[�t�F�[�X�Ŏ���

        // �X�y�[�X�L�[�A�łŃo�g������
        // ���t���[���J�E���g�������葱���A0�ɂȂ�����s�k
        // ���Ă΋��Q�b�g�A�J�E���g�A�b�v
        // �������狛������
    }

    void Update()
    {
        
    }

    void Init()
    {
        _camera = Camera.main;
    }
}
