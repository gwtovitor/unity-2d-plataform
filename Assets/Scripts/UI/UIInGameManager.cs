using Ebac.Core.Singleton;
using TMPro;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TMP_Text uiTextCoins;
    public TMP_Text uiTextLifes;

    public static void UpdateTextCoins(string s)
    {
        Instance.uiTextCoins.text = s;
    }
    public static void UpdateTextLifes(string s)
    {
        Instance.uiTextLifes.text = s;
    }
}
