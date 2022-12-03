using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���S�̗̂���𐧌䂷��R���|�[�l���g
/// </summary>
public class InGameStream : MonoBehaviour
{
    [SerializeField] TitleStream _titleStream;
    [SerializeField] GameStartEffect _gameStartEffect;
    [SerializeField] GameOverEffect _gameOverEffect;
    [SerializeField] Generator[] _generators;

    IEnumerator Start()
    {
        // �^�C�g�����
        _titleStream.Init();
        yield return _titleStream.StreamCoroutine();
        // �Q�[���X�^�[�g�I
        _gameStartEffect.Init();
        yield return _gameStartEffect.StreamCoroutine();
        // �W�F�l���[�^���ғ�������
        foreach (Generator gen in _generators)
        {
            gen.IsActive = true;
        }

        // �Q�[����

        // �W�F�l���[�^���~������
        //foreach (Generator gen in _generators)
        //{
        //    gen.IsActive = false;
        //}
        // �Q�[���I�[�o�[
        _gameOverEffect.Init();
        yield return _gameOverEffect.StreamCoroutine();
    }

    void Update()
    {
        
    }
}
