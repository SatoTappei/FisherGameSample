using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �^�C�g����ʂ𐧌䂷��R���|�[�l���g
/// </summary>
public class TitleStream : MonoBehaviour
{
    public void Init()
    {
        // ������������K�v�ɉ����ď���
    }

    public IEnumerator StreamCoroutine()
    {
        // TODO:�^�C�g����ʂ̏���
        //      ������Ԃ������^�C�g����ʂ𔲂���Ƃ�
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }
}
