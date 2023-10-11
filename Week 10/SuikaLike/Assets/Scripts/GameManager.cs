using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dongle lastDongle;
    public GameObject donglePrefab;
    public Transform dongleGroup;
    public GameObject effectPrefab;
    public Transform effectGroup;

    public int score;
    public int maxLevel;
    public bool isOver;


    void Awake()
    {
       Application.targetFrameRate = 60;
    }


    void Start()
    {
        NextDongle();
    }

    
    Dongle GetDongle()
    {
        // ����Ʈ ����
        GameObject instantEffectObj = Instantiate(effectPrefab, effectGroup);
        ParticleSystem instantEffect = instantEffectObj.GetComponent<ParticleSystem>();

        // ���� ����
        GameObject instantDongleObj = Instantiate(donglePrefab, dongleGroup);
        Dongle instantDongle = instantDongleObj.GetComponent<Dongle>();
        instantDongle.effect = instantEffect;
        return instantDongle;
    }


    void NextDongle()
    {
        if(isOver)
        {
            return;
        }

        Dongle newDongle = GetDongle();
        lastDongle = newDongle;
        lastDongle.manager = this;
        lastDongle.level = Random.Range(0, maxLevel);
        lastDongle.gameObject.SetActive(true);

        StartCoroutine("WaitNext");
    }


    IEnumerator WaitNext()
    {
        while (lastDongle != null) 
        {
            yield return null;
        }

        yield return new WaitForSeconds(2.5f);

        NextDongle();
    }


    public void TouchDown()
    {
        if (lastDongle == null)
            return;

        lastDongle.Drag();
    }


    public void TouchUp()
    {
        if (lastDongle == null)
            return;

        lastDongle.Drop();
        lastDongle = null;
    }


    public void GameOver()
    {
        if(isOver)
        {
            return;
        }

        isOver = true;

        StartCoroutine("GameOverRoutine");
    }


    IEnumerator GameOverRoutine()
    {
        // 1. ���ȿ� Ȱ��ȭ�� ��� ���� ��������
        Dongle[] dongles = FindObjectsOfType<Dongle>();

        // 2. ����� ���� ��� ���� ����ȿ�� ��ȿȭ
        for (int index = 0; index < dongles.Length; index++)
            dongles[index].rigid.simulated = false;

        // 3. 1���� ����Ʈ�� �ϳ��� ������ �����
        for (int index = 0; index < dongles.Length; index++)
        {
            dongles[index].Hide(Vector3.up * 100);

            yield return new WaitForSeconds(0.1f);
        }
    }
}