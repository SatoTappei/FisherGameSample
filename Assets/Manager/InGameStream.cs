using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体の流れを制御するコンポーネント
/// </summary>
public class InGameStream : MonoBehaviour
{
    [SerializeField] TitleStream _titleStream;

    IEnumerator Start()
    {
        yield return _titleStream.Stream();

    }

    void Update()
    {
        
    }
}
