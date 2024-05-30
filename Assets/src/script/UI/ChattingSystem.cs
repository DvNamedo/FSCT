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
        // �г� Ȱ��ȭ �� �ʱ�ȭ

        FileStream stream = new FileStream(Application.dataPath + "/Chattings" + "/" + JSONname + ".json", FileMode.Open);
        byte[] data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
        stream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        ChattingManager cm = JsonConvert.DeserializeObject<ChattingManager>(jsonData);


        StartCoroutine(pageManager(cm));

        //�г� ��Ȱ��ȭ

    }

    public IEnumerator pageManager(ChattingManager source)
    {
        var chatLength = source.chatSet.Count;

        //source �� ������ �¿��� chatSet�� Length �� �����Ͽ� ���� var chatLength�� ����.

        // �гΰ� �Բ� MessageWindow, NameWindow�� ���� ��
        // source �� ������ �¿��� pageCurrent ��° ���� ����(���� source���� ...)

        // source ���� �޽��� ���� �ؼ� Message �� ����
        // source ���� speaker �����ؼ� Name�� ����
        // Name �� ���� NameWindow, Name, Charactor, ChoiceTabs ��ġ ����
        // source �� type�� ���� ������ ��츶�� ��ҵ��� ������ �迭, ���콺 �����͵� ���� ����.

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
