using UnityEngine;

public class ItemCollactableCoin : ItemCollectableBase
{
  
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
    }
}
