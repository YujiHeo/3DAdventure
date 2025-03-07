using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance; //Ŭ���� ������ �� �ϳ��� ������ �ֵ��� �����ϴ� ����.

    public static CharacterManager Instance //�ܺο��� �� Ŭ������ ������ �� ����ϴ� property
    {
        get //�ܺο��� �����ϴ� property�� Instance �����̱� ������ �ű⿡ ���� ���� _instance�� ��ȯ
        {
            if (_instance == null)
            {
                _instance = new GameObject("CharacerManager").AddComponent<CharacterManager>();
                //���� �ν��Ͻ��� �������� ������ �ΰ��� ���� ���� ����
            }
            return _instance;
        }
    }

    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private Player _player;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); //�� ��ȯ�ÿ��� ��� ����
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject); //�ν��Ͻ� �ߺ� ����
            }
        }
    }
}