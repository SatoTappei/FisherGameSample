using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Linq;

/// <summary>�t�B�[���h���Ǘ�����R���|�[�l���g</summary>
class FieldManager
{
    static List<FishUnit> _fishList = new List<FishUnit>();

    public void Add(FishUnit unit) => _fishList.Add(unit);

    public void Remove(FishUnit unit) => _fishList.Remove(unit);

    /// <summary>�ނ��Ă���t���O�������Ă��鋛��Ԃ��Anull�`�F�b�N���邱��</summary>
    public FishUnit GetCapture() => _fishList.Where(f => f.IsCapture).FirstOrDefault();
}
