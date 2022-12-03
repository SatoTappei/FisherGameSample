using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// ���Ƃ̋삯�������s���Q�[�W�𐧌䂷��
/// </summary>
public class Gauge : MonoBehaviour
{
    [SerializeField] Transform _damage;

    float _currentValue;

    // �ނ�o�g���̌������������^�C�~���O�ŌĂ΂��R�[���o�b�N
    public UnityAction OnWin;
    public UnityAction OnLose;

    void Awake()
    {
        // �C�ӂ̃^�C�~���O�ŕ\�������A�R���[�`�����J�n�������̂Ő������͔�\���ɂ��Ă���
        gameObject.SetActive(false);
    }

    IEnumerator Start()
    {
        while (true)
        {
            // �����l��ݒ�
            _currentValue = 0.5f;

            // �Q�[�W��0��������1�ɂȂ�܂ő҂�
            // ���̊Ԃ̃Q�[�W�̑�����Update�ōs��
            yield return new WaitUntil(() => Check01());

            // ���ʂɂ���ČĂԃR�[���o�b�N��ς���
            if (_currentValue <= 0)
            {
                OnLose.Invoke();
            }
            else if (_currentValue >= 1)
            {
                OnWin.Invoke();
            }

            // ���̃o�g�����Ƀ��Z�b�g����
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.R));
            Debug.Log("���Z�b�g�V�}�X");
        }
    }

    void Update()
    {
        // �Q�[�W��0��������1�̏ꍇ�͑������s��Ȃ�
        if (Check01()) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentValue += 0.05f;
        }
        else
        {
            _currentValue -= 0.001f;
        }

        _currentValue = Mathf.Clamp01(_currentValue);
        _damage.localScale = new Vector3(1 - _currentValue, 1, 1);
    }

    /// <summary>�Q�[�W��Scale.x��0��������1�ɂȂ��Ă��邩��Ԃ�</summary>
    bool Check01() => _currentValue <= 0 || _currentValue >= 1;
}
