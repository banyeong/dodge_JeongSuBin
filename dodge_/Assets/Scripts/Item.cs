using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    int healAmount = 20;
    void Update()
    {
        // Item 효과를 주기 위해서 회전을 시킴
        transform.Rotate(0f, 15f * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.GetHeal(healAmount);
            }

            Destroy(gameObject);
        }
    }
}
