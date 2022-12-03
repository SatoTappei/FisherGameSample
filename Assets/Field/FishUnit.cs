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
    static bool _isInited;

    /// <summary>���ݒނ肠�����Ă��邩�̃t���O</summary>
    public bool IsCapture { get; private set; }

    IEnumerator Start()
    {
        // �������Y����̂ŋ��ʂŎg���t�B�[���h���Z�b�g���邾���ŏ���
        // TODO:���ʂ���������
        if (_wayPoints == null || _dataBase == null)
        {
            yield return SetStaticFieldCoroutine();
            _isInited = true;
            gameObject.SetActive(false);
        }
        else
        {
            // SODataBase�̏����Z�b�g�A�b�v���o���Ă��Ȃ���Ύ��g���폜����
            // TODO:���ʂȏ����A����������
            if (!_isInited)
            {
                Destroy(gameObject);
                yield break;
            }

            // ���g��o�^����
            FieldManager fm = new FieldManager();
            fm.Add(this);

            Status status = Init();

            // ��ʒ����Ɍ����Ĉړ�����
            yield return _fishMove.MoveTo(status.center, status.so.Speed);
            // �Y��
            yield return new WaitForSeconds(status.so.WaitTime);
            // ��ʊO�ɓ�����
            yield return _fishMove.MoveTo(status.escape, status.so.Speed);
        }
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

    /// <summary>�ނ肠����ꂽ�ۂɌĂ΂�鏈��</summary>
    public void Fished()
    {
        StartCoroutine(_fishMove.Fished());
        IsCapture = false;
    }

    /// <summary>������ꂽ�ۂɌĂ΂�鏈��</summary>
    public void Escape()
    {
        StartCoroutine(_fishMove.Escape());
        IsCapture = false;
    }

    public void HitReceived()
    {
        // �q�b�g�����ۂɂ҂��҂�������
        StartCoroutine(_fishMove.Captured());
        IsCapture = true;
    }
}
