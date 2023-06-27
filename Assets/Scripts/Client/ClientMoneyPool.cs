using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMoneyPool : MonoBehaviour
{
    int moneyCount;
    int moneyFlow, arrivingFlow;

    int tam, kusurat, sayac;
    public Animator anim;
    int totalMoneyAmount;

    [SerializeField] GameObject moneyImg;

    public Queue<GameObject> moneyList = new Queue<GameObject>();

    public static ClientMoneyPool clientMoneyPool;

    [SerializeField] MoneyManager moneyManager;

    Coroutine coroutine;

    private void Awake()
    {
        if (clientMoneyPool == null)
        {
            clientMoneyPool = this;
        }
    }

    void GenerateMoney(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject money = Instantiate(moneyImg, transform.position, Quaternion.identity, transform);
            money.SetActive(false);
            moneyList.Enqueue(money);
        }
    }

    public void ShowMoney(int amount, Vector3 pos)
    {
        totalMoneyAmount = amount;
        MoneyDivider();
        if (amount % 10 == 0)
            amount /= 10;

        else
        {
            amount /= 10;
            amount++;
        }



        if (amount > moneyCount)
        {
            GenerateMoney(amount - moneyCount);
            moneyCount = amount;
        }

        coroutine = StartCoroutine(Money(amount, pos));
    }

    IEnumerator Money(int amount, Vector3 pos)
    {
        while (true)
        {
            if (moneyFlow < amount)
            {
                yield return new WaitForSeconds(0.1f);
                GameObject money = moneyList.Dequeue();
                money.SetActive(true);
                money.transform.position = pos + (Vector3.up * 200f);
                moneyFlow++;
            }

            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Money"))
        {
            anim.Play("BGMoney");
            GameObject money = other.gameObject;
            money.SetActive(false);
            moneyList.Enqueue(money);
            arrivingFlow++;

            if (sayac < tam)
            {
                moneyManager.moneyCount += 10f;
                sayac++;
            }

            else
            {
                moneyManager.moneyCount += (float)kusurat;
            }

            if (arrivingFlow == moneyFlow)
            {
                StopCoroutine(coroutine);
                arrivingFlow = 0;
                moneyFlow = 0;
                sayac = 0;
            }
        }
    }


    void MoneyDivider()
    {

        tam = totalMoneyAmount / 10;
        kusurat = totalMoneyAmount % 10;
    }
}
