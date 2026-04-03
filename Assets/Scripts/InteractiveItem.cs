
using UnityEngine;
using UnityEngine.UIElements;

public class InteractiveItem : MonoBehaviour
{
    // --- SCRIPTABLE OBJECT METHOD ---
    [SerializeField]
    private ItemDataObject itemData;

    public SpriteRenderer ItemIconRenderer;

    private void Awake()
    {
        ItemIconRenderer = GetComponent<SpriteRenderer>();
    }

    public void Configure(ItemDataObject data)
    {
        itemData = data;
        ItemIconRenderer.sprite = itemData.icon;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffect();
        }
    }

    void ApplyEffect()
    {
        // --- NEW METHOD USING SCRIPTABLE OBJECT ---
        if (itemData == null)
        {
            Debug.LogWarning("ItemDataObject is not assigned!");
            return;
        }

        switch (itemData.type)
        {
            case InteractType.Heal:
                Debug.Log($"Healed for {itemData.effectValue}");
                break;

            case InteractType.Buah:
                Debug.Log($"Got Score for {itemData.effectValue} points!");
                break;

            case InteractType.Trap:
                Debug.Log($"Damage taken: {itemData.effectValue}");
                break;
        }

        // Destroy object (kecuali Trap)
        if (itemData.type != InteractType.Trap)
        {
            Destroy(gameObject);
        }
    }
}
