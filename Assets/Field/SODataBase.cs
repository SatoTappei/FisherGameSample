using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// 魚毎のSOを動的に読み込んでデータベースとして使うクラス
/// 各SOはデフォルトグループに登録した後、アドレスをsimplifyで変更しておく。
/// </summary>
class SODataBase
{
    /// <summary>読み込んだSOの辞書型</summary>
    Dictionary<FishDataSO.AddressTag, FishDataSO> _dic;

    /// <summary>
    /// コンストラクタでコルーチンが使えないので専用のメソッドで初期化を行う。<br></br>
    /// LoadAssetAsyncで待ちをしており、ここのawaitを取ればコンストラクタで行う事は可能だが、
    /// 一応非同期で行うメソッドなのでこうしておく
    /// </summary>
    public IEnumerator Init()
    {
        _dic = new Dictionary<FishDataSO.AddressTag, FishDataSO>();

        // 動的に取得してきて辞書型に格納する
        AddressableAssetGroup group = AddressableAssetSettingsDefaultObject.Settings.DefaultGroup;
        foreach (AddressableAssetEntry entry in group.entries)
        {
            AsyncOperationHandle<FishDataSO> handle = Addressables.LoadAssetAsync<FishDataSO>(entry.address);
            yield return handle;
            _dic.Add(handle.Result.Tag, handle.Result);
        }
    }

    /// <summary>タグに対応したSOを返す</summary>
    public FishDataSO GetSO(FishDataSO.AddressTag tag) => _dic[tag];
}
