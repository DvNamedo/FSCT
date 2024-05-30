using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;  

public class ChattingSystem : MonoBehaviour
{
    public GameObject Panel;
    public Text Message;
    public Text Name;
    public Image Charactor;
    public Image MassageWindow;
    public Image NameWindow;
    public InputField AnswerInput;
    public List<Button> ChoiceTabs;

    int pageSup = 0;
    int pageCurrent = 0;

    // Start is called before the first frame update
    void Start()
    {
        pageSup = 0;
        pageCurrent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pageSup++;
        }
    }

    public void startChatting(string JSONname)
    {
        // 패널 활성화 및 초기화

        FileStream stream = new FileStream(Application.dataPath + "/Chattings" + "/" + JSONname + ".json", FileMode.Open);
        byte[] data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
        stream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        ChattingManager cm = JsonConvert.DeserializeObject<ChattingManager>(jsonData);


        StartCoroutine(pageManager(cm));

        //패널 비활성화

    }

    public IEnumerator pageManager(ChattingManager source)
    {
        var chatLength = source.chatSet.Count;

        //source 의 데이터 셋에서 chatSet의 Length 를 추출하여 변수 var chatLength에 기입.

        // 패널과 함꼐 MessageWindow, NameWindow는 같이 뜸
        // source 의 데이터 셋에서 pageCurrent 번째 개입 시작(이하 source에서 ...)

        // source 에서 메시지 추출 해서 Message 에 기입
        // source 에서 speaker 추출해서 Name에 기입
        // Name 에 따라서 NameWindow, Name, Charactor, ChoiceTabs 위치 변경
        // source 의 type에 따라서 세가지 경우마다 요소들을 적절히 배열, 마우스 포인터도 같이 조작.

        yield return new WaitUntil(() => pageCurrent < pageSup);
        pageCurrent++;

        if (pageCurrent > chatLength)
        {
            yield return null;
        }
        

        
    }

    
    public class ChattingManager
    {
        public List<Chat> chatSet; 
    }

    public class Chat
    {
        public string speaker;
        public string message;
        public string type;

        public class ChoiceQuizer
        {
            public List<string> options;
            public string correctAnswer;
        }

        public class AnswerQuizer
        {
            public string Question;
            public string correctAnswer;
        }

    }

    public enum ChattingType
    {
        GeneralChat,
        JuGwanSigChat,
        GaegGwanSigChat
    }
}
