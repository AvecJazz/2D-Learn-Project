using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [System.Serializable]
    public class DropItem 
    {
        public string name;
        public GameObject item;
        public float itemDropChance;
    }

    public float dropChance;
    public List<DropItem> Items = new List<DropItem>();


    public void CalculateAndDropItem() 
    {
        float calcDropChance = Random.Range(0f, 1.01f);

        if (calcDropChance > dropChance) 
        {
            Debug.Log("Ничего не выпало");
            return;
        }

        if (calcDropChance <= dropChance) 
        {
            float itemChanceSum = 0;

            for (int i = 0; i < Items.Count; i++) 
            {
                itemChanceSum += Items[i].itemDropChance;
            }

            float randomValue = Random.Range(0f, itemChanceSum);

            for (int i = 0; i < Items.Count; i++) 
            {
                if (randomValue <= Items[i].itemDropChance) 
                {
                    Instantiate(Items[i].item, transform.position, Quaternion.identity);
                    return;
                }

                randomValue -= Items[i].itemDropChance;
            }
        }
    }

}
