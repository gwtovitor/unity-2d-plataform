using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ebac.Core.Singleton;

public class UIInGameManager : Singleton<ItemManager>
{
    public TMP_Text uiTextCoins;

    public static void UpdateTextCoins(string s){
        Instance.uiTextCoins.text = s;
    }
}
