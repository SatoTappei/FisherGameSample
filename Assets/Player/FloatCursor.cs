using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �}�E�X�ɒǏ]����J�[�\���̃R���|�[�l���g
/// </summary>
public class FloatCursor : MonoBehaviour
{
    [Header("�C���X�y�N�^�[���Transform�̒l�Őݒ肷��")]
    [SerializeField] Vector2 _leftUp;
    [SerializeField] Vector2 _rightBottom;

    Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Set();
    }

    /// <summary>�}�E�X�J�[�\���̈ʒu�ɃZ�b�g����</summary>
    void Set()
    {
        Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        pos.x = Mathf.Clamp(pos.x, _leftUp.x, _rightBottom.x);
        pos.y = Mathf.Clamp(pos.y, _rightBottom.y, _leftUp.y);
        transform.position = pos;
    }
}
