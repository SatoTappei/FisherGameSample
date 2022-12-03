using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>フィールドを管理するコンポーネント</summary>
class FieldManager
{
    static List<FishUnit> _fishList = new List<FishUnit>();

    /// <summary>現在釣りあげている魚</summary>
    static FishUnit _captured;
    public FishUnit Captured { get => _captured; set => _captured = value; }

    public void Add(FishUnit unit) => _fishList.Add(unit);

    public void Remove(FishUnit unit) => _fishList.Remove(unit);
}
