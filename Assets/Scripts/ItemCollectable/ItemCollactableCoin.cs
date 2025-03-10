using UnityEngine;

public class ItemCollactableCoin : ItemCollectableBase
{
    public SOString id;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddItem(id.value, 1);
    }
}
