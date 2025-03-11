using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance; //클래스 내에서 단 하나의 변수만 있도록 관리하는 변수.

    public static CharacterManager Instance //외부에서 이 클래스에 접근할 때 사용하는 property
    {
        get //외부에서 접근하는 property는 Instance 변수이기 때문에 거기에 받은 값을 _instance에 반환
        {
            if (_instance == null)
            {
                _instance = new GameObject("CharacerManager").AddComponent<CharacterManager>();
                //만약 인스턴스가 존재하지 않으면 인게임 내에 새로 생성
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
            DontDestroyOnLoad(gameObject); //씬 전환시에도 계속 유지
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject); //인스턴스 중복 방지
            }
        }
    }
}