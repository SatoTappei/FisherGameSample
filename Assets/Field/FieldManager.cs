using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Linq;

/// <summary>フィールドを管理するコンポーネント</summary>
class FieldManager
{
    static List<FishUnit> _fishList = new List<FishUnit>();

    public void Add(FishUnit unit) => _fishList.Add(unit);

    public void Remove(FishUnit unit) => _fishList.Remove(unit);

    /// <summary>釣られているフラグが立っている魚を返す、nullチェックすること</summary>
    public FishUnit GetCapture() => _fishList.Where(f => f.IsCapture).FirstOrDefault();
}
