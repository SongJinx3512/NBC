using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject donglePrefab;
    public Transform dongleGroup;
    public List<Dongle> donglePool;
    public GameObject effectPrefab;
    public Transform effectGroup;
    public List<ParticleSystem> effectPool;
    [Range(1, 30)]
    public int poolSize;
    public int poolCursor;
    public Dongle lastDongle;

    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum sfx { LevelUp, Next, Attach, Button, Over };
    int sfxCursor;

    public int score;
    public int maxLevel;
    public bool isOver;


    void Awake()
    {
       Application.targetFrameRate = 60;

        donglePool = new List<Dongle>();
        effectPool = new List<ParticleSystem>();

        for(int index = 0; index < poolSize; index++)
        {
            MakeDongle();
        }
    }


    void Start()
    {
        bgmPlayer.Play();
        NextDongle();
    }


    Dongle MakeDongle()
    {
        // ����Ʈ ����
        GameObject instantEffectObj = Instantiate(effectPrefab, effectGroup);
        instantEffectObj.name = "Effect " + effectPool.Count;
        ParticleSystem instantEffect = instantEffectObj.GetComponent<ParticleSystem>();
        effectPool.Add(instantEffect);

        // ���� ����
        GameObject instantDongleObj = Instantiate(donglePrefab, dongleGroup);
        instantDongleObj.name = "Dongle " + donglePool.Count;
        Dongle instantDongle = instantDongleObj.GetComponent<Dongle>();
        instantDongle.manager = this;
        instantDongle.effect = instantEffect;
        donglePool.Add(instantDongle);

        return instantDongle;
    }

    
    Dongle GetDongle()
    {
        for(int index = 0; index < donglePool.Count; index++)
        {
            poolCursor = (poolCursor + 1) % donglePool.Count;

            if (!donglePool[poolCursor].gameObject.activeSelf)
            {
                return donglePool[poolCursor];
            }
        }

        return MakeDongle();
    }


    void NextDongle()
    {
        if(isOver)
        {
            return;
        }

        lastDongle = GetDongle();
        lastDongle.level = Random.Range(0, maxLevel);
        lastDongle.gameObject.SetActive(true);

        sfxPlay(sfx.Next);
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

        yield return new WaitForSeconds(1f);

        sfxPlay(sfx.Over);
    }


    public void sfxPlay(sfx type)
    {
        switch (type)
        {
            case sfx.LevelUp:
                sfxPlayer[sfxCursor].clip = sfxClip[Random.Range(0, 3)];
                break;
            case sfx.Next:
                sfxPlayer[sfxCursor].clip = sfxClip[3];
                break;
            case sfx.Attach:
                sfxPlayer[sfxCursor].clip = sfxClip[4];
                break;
            case sfx.Button:
                sfxPlayer[sfxCursor].clip = sfxClip[5];
                break;
            case sfx.Over:
                sfxPlayer[sfxCursor].clip = sfxClip[6];
                break;
        }
    }
}