using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// ���̊e�R���|�[�l���g�𐧌䂷��
/// </summary>
public class FishUnit : MonoBehaviour , IFloatHitable
{
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] FishMove _fishMove;

    struct Status
    {
        // �ڕW���W
        public Transform center;
        public Transform escape;
        // ���ʃf�[�^��SO
        public FishDataSO so;
    }

    static WayPoints _wayPoints;
    static SODataBase _dataBase;

    IEnumerator Start()
    {
        // �������Y����̂ŋ��ʂŎg���t�B�[���h���Z�b�g���邾���ŏ���
        // TODO:���ʂ���������
        if (_wayPoints == null || _dataBase == null)
        {
            yield return SetStaticFieldCoroutine();
        }
        else
        {
            Status status = Init();

            // ��ʒ����Ɍ����Ĉړ�����
            yield return _fishMove.MoveTo(status.center, status.so.Speed);
            // �Y��
            yield return new WaitForSeconds(status.so.WaitTime);
            // ��ʊO�ɓ�����
            yield return _fishMove.MoveTo(status.escape, status.so.Speed);
        }

        // TODO:��\���ɂ��ăI�u�W�F�N�g�v�[���ɗ��p�ł���悤�ɂ��Ă���
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    /// <summary>���ʂŎg���t�B�[���h�𐶐��A����������</summary>
    IEnumerator SetStaticFieldCoroutine()
    {
        _wayPoints = new WayPoints();
        _dataBase = new SODataBase();

        yield return _dataBase.Init();
    }

    Status Init()
    {
        Status status = new Status();
        status.center = _wayPoints.GetCenterPointRandom();
        status.escape = _wayPoints.GetEscapePointRandom();

        // randamu 
        FishDataSO.AddressTag tag = (FishDataSO.AddressTag)Random.Range(0, FishDataSO.GetAddressTagCount());
        status.so = _dataBase.GetSO(tag);

        _sr.sprite = status.so.Sprite;

        return status;
    }

    public void HitReceived()
    {
        Debug.Log("�q�b�g���܂���");
        StartCoroutine(_fishMove.Captured());
        // �q�b�g�����ۂ̏���������
        // �L�������ނ�o�g������ۂ̃A�j���[�V�����݂����Ȃ�
    }
}
