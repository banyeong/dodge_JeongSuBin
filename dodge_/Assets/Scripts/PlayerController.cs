using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    public int hp = 100;
    public HPBar hpBar;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidbody.velocity = newVelocity;
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        hpBar.SetHP(hp);
        if (hp <= 0)
        {
            Die();
        }
    }

    public void GetHeal(int heal)
    {
        hp += heal;
        if (hp > 100)
        {
            hp = 100;
        }
        hpBar.SetHP(hp);
    }

    void Die()
    {
        gameObject.SetActive(false);

        //씬에 존재하는 GameManager 타입의 오브젝트를 찾아 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        //가져온 GameManager 오브젝트의 EndGame() 실행
        gameManager.EndGame();
    }
}
