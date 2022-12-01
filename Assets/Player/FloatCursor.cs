using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �}�E�X�ɒǏ]����J�[�\��
/// </summary>
public class FloatCursor : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [Header("�C���X�y�N�^�[���Transform�̒l�Őݒ肷��")]
    [SerializeField] Vector2 _leftUp;
    [SerializeField] Vector2 _rightBottom;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        pos.x = Mathf.Clamp(pos.x, _leftUp.x, _rightBottom.x);
        pos.y = Mathf.Clamp(pos.y, _rightBottom.y, _leftUp.y);
        transform.position = pos;
    }
}
