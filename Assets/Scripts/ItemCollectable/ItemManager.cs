using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;

    // public TMP_Text text;
    public TextMeshProUGUI uiTextCoins;

    private void Reset()
    {
        coins = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        UIInGameManager.UpdateTextCoins(coins.ToString());
    }
}
