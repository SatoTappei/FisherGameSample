using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���S�̗̂���𐧌䂷��R���|�[�l���g
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
