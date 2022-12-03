using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// �v���C���[�̊e�R���|�[�l���g�𐧌䂷��
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] Gauge _gauge;
    [SerializeField] GameObject _floatPrefab;
    [SerializeField] Transform _floatPivot;

    Camera _camera;

    IEnumerator Start()
    {
        Init();

        // �����ւ𐶐����Ĕ�\���ɂ��Ă���
        GameObject go = Instantiate(_floatPrefab, _floatPivot.position, Quaternion.identity);
        go.SetActive(false);
        // �����ւ����ɓ����������ɌĂ΂��ǉ��̏����Ƃ��ăQ�[�W�̕\����ǉ�����
        go.GetComponent<FloatPrefab>().OnHited += () => _gauge.gameObject.SetActive(true);

        _gauge.OnWin += () => Debug.Log("�����܂���");
        _gauge.OnLose += () => Debug.Log("�܂��܂���");

        while (true)
        {
            // �}�E�X�N���b�N���ꂽ�畂���ւ�\��������
            // �\�������ƕ����ւ̓}�E�X�̈ʒu�ɓ����悤�ɂȂ��Ă���
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            go.SetActive(true);

            //Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            //pos.z = 0;

            // �N���b�N���ꂽ�炻�̈ʒu�ɔ�΂�
            //Tween t = go.transform.DOMove(pos, 0.5f);
            // �w��ʒu�܂ŗ�����R���C�_�[���I���ɂ���

            // �o�g���̌����������^�C�~���O�ŕ�����������̂ł����ő҂�
            yield return new WaitUntil(() => !go.activeInHierarchy);

            // �Q�[�W�쐬
            // 0�ɂȂ����Ƃ��̃R�[���o�b�N��1�ɂȂ����Ƃ��̃R�[���o�b�N��o�^����
            // UnityEvent�c�{�^���̂�Ƃ��g���Ȃ�������

            // TODO:�o�g���̗���
            // ���Ƀq�b�g������Q�[�W��\��������
            // �o�g�����I�������Q�[�W���\���ɂ�����

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
