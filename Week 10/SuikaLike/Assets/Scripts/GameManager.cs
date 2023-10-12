using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("---------------[ Core ]")]
    public bool isOver;
    public int score;
    public int maxLevel;

    [Header("---------------[ Object Pooling ]")]
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

    [Header("---------------[ Audio ]")]
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum sfx { LevelUp, Next, Attach, Button, Over };
    int sfxCursor;

    [Header("---------------[ UI ]")]
    public GameObject startGroup;
    public GameObject endGroup;
    public Text scoreText;
    public Text maxScoreText;
    public Text subScoreText;

    [Header("---------------[ ETC ]")]
    public GameObject line;
    public GameObject bottom;


    void Awake()
    {
       Application.targetFrameRate = 60;

        donglePool = new List<Dongle>();
        effectPool = new List<ParticleSystem>();

        for(int index = 0; index < poolSize; index++)
        {
            MakeDongle();
        }

        if(!PlayerPrefs.HasKey("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", 0);
        }

        maxScoreText.text = PlayerPrefs.GetInt("MaxScore").ToString();
    }


    public void GameStart()
    {
        // ������Ʈ �ߵ�
        line.SetActive(true);
        bottom.SetActive(true);
        scoreText.gameObject.SetActive(true);
        maxScoreText.gameObject.SetActive(true);
        startGroup.SetActive(false);

        // ���� �÷���
        bgmPlayer.Play();
        sfxPlay(sfx.Button);

        // ���� ���� (���ۻ���)
        Invoke("NextDongle", 1.5f);
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

        // �ְ� ���� ����
        int maxScore = Mathf.Max(score, PlayerPrefs.GetInt("MaxScore"));
        PlayerPrefs.SetInt("MaxScore", maxScore);
        // ���ӿ��� UI ǥ��
        subScoreText.text = "���� : " + scoreText.text;
        endGroup.SetActive(true);

        bgmPlayer.Stop();
        sfxPlay(sfx.Over);
    }


    public void Reset()
    {
        sfxPlay(sfx.Button);
        StartCoroutine("ResetCoroutine");
    }


    IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");
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

        sfxPlayer[sfxCursor].Play();
        sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
    }


    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }


    void LateUpdate()
    {
        scoreText.text = score.ToString();
    }
}