using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �^�C�g����ʂ𐧌䂷��R���|�[�l���g
/// </summary>
public class TitleStream : MonoBehaviour
{

    public IEnumerator Stream()
    {
        // �^�C�g����ʂ̏���
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }
}
