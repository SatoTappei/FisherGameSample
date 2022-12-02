using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マウスに追従するカーソルのコンポーネント
/// </summary>
public class FloatCursor : MonoBehaviour
{
    [Header("インスペクター上のTransformの値で設定する")]
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

    /// <summary>マウスカーソルの位置にセットする</summary>
    void Set()
    {
        Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        pos.x = Mathf.Clamp(pos.x, _leftUp.x, _rightBottom.x);
        pos.y = Mathf.Clamp(pos.y, _rightBottom.y, _leftUp.y);
        transform.position = pos;
    }
}
