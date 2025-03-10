using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt extraLife;

    // public TMP_Text text;
    public TextMeshProUGUI uiTextCoins;

    private void Reset()
    {
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    public void AddLife(int amount = 1)
    {
        extraLife.value += amount;
        UpdateUI();
    }

    public void AddItem(string id, int amount)
    {
        if (id == "coin")
        {
            AddCoins(amount);
        }
        if (id == "life")
        {
            AddLife(amount);
        }
    }

    private void UpdateUI()
    {
        UIInGameManager.UpdateTextCoins(coins.value.ToString());
        UIInGameManager.UpdateTextLifes(coins.value.ToString());
    }
}
