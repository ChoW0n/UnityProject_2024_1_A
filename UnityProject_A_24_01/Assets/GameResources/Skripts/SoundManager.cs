using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;        //Audio ���� ����� ����ϱ� ���� �߰�

[System.Serializable]       //����ȭ �����ش�. (����Ƽ �ȿ��� �����͸� �ν�����â���� ��Ÿ���� �����ִ� ���)

public class Sound  //Ŀ���� ���� Ŭ����
{
    public string name; //������ �̸�
    public AudioClip clip;  //���� Ŭ��

    [Range(0f, 1f)]         //�ν����� ȭ�鿡�� 0 ~ 1 ���� ���� ������ �� �ִ� �����̴��� ��ȯ
    public float volume = 1.0f;
    [Range(0.1f, 3f)]       //�ν����� ȭ�鿡�� 0 ~ 1 ���� ���� ������ �� �ִ� �����̴��� ��ȯ
    public float pitch = 1.0f;  //���� ��ġ
    public bool loop;           //�ݺ� ��� ����
    public AudioMixerGroup mixerGroup;      //����� �ͼ� �׷�

    [HideInInspector]       //�ͽ����� â���� �Ⱥ��̰� ���ִ� ���
    public AudioSource sources;     //����� �ҽ�
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;        //�̱��� �ν��Ͻ� (static�� ���� ������ �÷��� ��𼭵� ������ �� �ְ� ���ش�.)
    public List<Sound> sounds = new List<Sound>();  //���� ����Ʈ ���� (List �ڷᱸ���� ����)
    public AudioMixer audioMixer;       //����� �ͼ� ����

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);      //Scene�� ����Ǿ (�� ������Ʈ)�� �ı����� �ʴ´�.
        }
        else
        {
            Destroy(gameObject);        //�̹� �ٸ� ������Ʈ�� ������� �ı��Ѵ�. Ŭ������ �������� 1���� ������ų�� �ִ�.
        }
        
        //���带 �ʱ�ȭ
        foreach (Sound sound in sounds)
        {
            sound.sources = gameObject.AddComponent<AudioSource>();
            sound.sources.clip = sound.clip;
            sound.sources.volume = sound.volume;
            sound.sources.pitch = sound.pitch;
            sound.sources.loop = sound.loop;
            sound.sources.outputAudioMixerGroup = sound.mixerGroup;
        }
    }

    //���带 ����ϴ� �Լ�
    public void PlaySound(string name)
    {
        Sound soundToPlay = sounds.Find(sound => sound.name == name);

        if (soundToPlay != null)
        {
            soundToPlay.sources.Play();
        }
        else
        {
            Debug.LogWarning("���� " +  name + " ã�� �� ����.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
