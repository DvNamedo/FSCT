using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ChattingSystem : MonoBehaviour
{
    

    [Header("Environment Settings")]
    public GameObject Panel;
    public TMP_Text Message;
    public TMP_Text Name;
    public Image Charactor;
    public Image MassageWindow;
    public Image NameWindow;
    public GameObject AnswerInput;
    public GameObject ChoiceTabsPrefab;

    [Header("CharactorImages")]
    public Sprite defaultCharactorSprite;
    public List<string> charactorImageNames;
    public List<Sprite> charactorImageSprites;

    [Header("offsets")]
    public float optionsInverval;

    Dictionary<string, Sprite> charactorImages = new Dictionary<string, Sprite>();
    List<GameObject> Options = new List<GameObject>();

    int correctNumber = 0;
    int pageCurrent = 0;

    private void Awake()
    {
        for(int i = 0; i < charactorImageNames.Capacity; i++)
        {
            if(charactorImageNames[i] == null)
            {
                charactorImageNames[i] = "�̸����� ���� ��";
            }

            if (charactorImageSprites[i] == null)
            {
                charactorImageSprites[i] = defaultCharactorSprite;
            }

            charactorImages.Add(charactorImageNames[i], charactorImageSprites[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pageCurrent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("����");
        }
    }
    
    
    public void startChatting(string JSONname)
    {
        // �г� Ȱ��ȭ �� �ʱ�ȭ
        if (!Panel.activeSelf)
        {
            Panel.SetActive(true);
            Debug.Log("�г� Ȱ��ȭ ��");

            // json ���� �ҷ�����
            var jsonTextFile = Resources.Load<TextAsset>("Chattings/" + JSONname);

            //FileStream stream = new FileStream(Application.dataPath + "/Resources/Chattings/" + JSONname + ".json", FileMode.Open);
            //byte[] data = new byte[stream.Length];
            //stream.Read(data, 0, data.Length);
            //stream.Close();
            string jsonData = jsonTextFile.ToString();/*Encoding.UTF8.GetString(data);*/
            
            ChattingManager cm = JsonConvert.DeserializeObject<ChattingManager>(jsonData);

            Debug.Log("json ���� ó����");
            //������ ����
            StartCoroutine(pageManager(cm));

        }


    }

    public IEnumerator pageManager(ChattingManager source)
    {
        pageCurrent = 0;

        //source �� ������ �¿��� chatSet�� Length �� �����Ͽ� ���� var chatLength�� ����.
        var chatLength = source.chatSet.Count;

        Debug.Log($"ä�� ��: {chatLength}");

        

        while (pageCurrent < chatLength)
        {
            // �гΰ� �Բ� MessageWindow, NameWindow�� ���� �� / AnswerInput , ChoiceTabPrefab �� ������ active �ض�
            
            switch(source.chatSet[pageCurrent].type)
            {
                case "general":
                    AnswerInput.SetActive(false);
                    ChoiceTabsPrefab.SetActive(false);

                    break;
                case "choice":
                    AnswerInput.SetActive(false);
                    ChoiceTabsPrefab.SetActive(false);

                    //generate
                    for (int i = 0; i < source.chatSet[pageCurrent].ChoiceQizer.options.Count; i++)
                    {
                        Options.Add(Instantiate(ChoiceTabsPrefab, parent: Panel.transform));
                        Options[i].GetComponent<RectTransform>().position = ChoiceTabsPrefab.GetComponent<RectTransform>().position + new Vector3(0,optionsInverval * i);
                        Options[i].SetActive(true);

                        if(source.chatSet[pageCurrent].ChoiceQizer.options[i] == source.chatSet[pageCurrent].ChoiceQizer.correctAnswer)
                        {
                            correctNumber = i;
                        }
                    }


                    break;
                case "answer":
                    AnswerInput.SetActive(true);
                    ChoiceTabsPrefab.SetActive(false);

                    break;
                default:
                    break;
            }

            Debug.Log("Ȱ��ȭ ���� �Ϸ�");


            // Name �� ���� NameWindow, Name, Charactor, ChoiceTabs ��ġ ����
            // ĳ���� ��������Ʈ �ҷ�����
            Charactor.sprite = charactorImages[source.chatSet[pageCurrent].speaker];


            switch (source.chatSet[pageCurrent].speaker)
            {
                case "player": //ex
                    Charactor.GetComponent<RectTransform>().anchoredPosition = new Vector3(-595f, -286f, 0f);
                    NameWindow.GetComponent<RectTransform>().anchoredPosition = new Vector3(-583.29f, -450.24f, 0f);

                    break;
                case "object1": //ex
                    break;
                case "object2": //ex
                    break;
                default:
                    break;
            }

            Debug.Log("��ġ ���� �Ϸ�");

            // source �� ������ �¿��� pageCurrent ��° ���� ����(���� source���� ...)

            // source ���� �޽��� ���� �ؼ� Message �� ����
            Message.text = source.chatSet[pageCurrent].message;

            // source ���� speaker �����ؼ� Name�� ����
            Name.text = source.chatSet[pageCurrent].speaker;

            // source �� type�� ���� ������ ��츶�� ��ҵ��� ������ �迭,

            switch (source.chatSet[pageCurrent].type)
            {
                case "general":


                    break;
                case "choice":
                    for(int i = 0; i < source.chatSet[pageCurrent].ChoiceQizer.options.Count; i++)
                    {
                        
                        Options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = source.chatSet[pageCurrent].ChoiceQizer.options[i];
                    }

                    break;
                case "answer":

                    Debug.Log(source.chatSet[pageCurrent].AnswerQizer.Question);
                    AnswerInput.transform.Find("Question_Text").GetComponent<TMP_Text>().text = source.chatSet[pageCurrent].AnswerQizer.Question;

                    break;
                default:
                    break;
            }

            Debug.Log("�������� ���� �޽��� �غ� �Ϸ�");


            yield return new WaitForSeconds(0.1f); // Ȯ��
            Debug.Log("��ٸ�");
            //yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); //���� �ʿ�

            // ���������� ���� ��ٸ���
            switch (source.chatSet[pageCurrent].type)
            {
                case "general":
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

                    break;
                case "choice":

                    yield return new WaitWhile(() =>
                    {
                        bool isClicked = false;
                        for (int i = 0; i < Options.Count; i++)
                        {
                            isClicked = isClicked || Options[i].GetComponent<clicked>().isClick;
                            Debug.Log($"{i}번쨰 버튼 확인됨");
                            if (isClicked)
                            {
                                if (source.chatSet[pageCurrent].ChoiceQizer.options[i] == source.chatSet[pageCurrent].ChoiceQizer.correctAnswer)
                                {
                                    Debug.Log("맞음");
                                    Center.instance.isCorrectOnQuestion = true;
                                    break;
                                }
                                else
                                {
                                    Debug.Log("틀림");
                                    Center.instance.isCorrectOnQuestion = false;
                                    break;
                                }
                            }
                            

                        }
                        return !isClicked;
                    });

                    for (int i = 0; i < source.chatSet[pageCurrent].ChoiceQizer.options.Count; i++)
                    {
                        Destroy(Options[0]);
                        Options.RemoveAt(0);
                    }


                    break;
                case "answer":

                    yield return new WaitWhile(() =>
                    {
                        bool isCliked = false;
                        isCliked = isCliked || AnswerInput.transform.Find("Confirm").GetComponent<clicked>().isClick;
                        if (AnswerInput.GetComponent<InputField>().text != "")
                        {
                            if(isCliked)
                                Center.instance.isCorrectOnQuestion = source.chatSet[pageCurrent].AnswerQizer.correctAnswer == AnswerInput.GetComponent<InputField>().text;
                        }
                        else
                        {
                            AnswerInput.transform.Find("PlaceHolder").GetComponent<Text>().text = "입력을 확인하세요.";
                            isCliked = false;
                            AnswerInput.transform.Find("Confirm").GetComponent<clicked>().isClick = false;
                        }

                        Debug.Log($"눌림?:{isCliked}");
                        return !isCliked;

                    });
                    Debug.Log("end Answer");
                    AnswerInput.transform.Find("Confirm").GetComponent<clicked>().isClick = false;
                    
                    break;
                default:
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    break;
            }

            Debug.Log($"���� ������: {pageCurrent}");

            if (Center.instance.isCorrectOnQuestion)
                pageCurrent++;
            else
                pageCurrent = chatLength;

            Debug.Log("������ �ѱ�");
        }

        //�г� ��Ȱ��ȭ
        Panel.SetActive(false);

        CurserController.cursorSetActive(false);

        Debug.Log("�г� ��Ȱ��ȭ ��");

        
    }


    public class ChattingManager
    {
        public List<Chat> chatSet { get; set; }
    }

    public class Chat
    {
        public string speaker { get; set; }
        public string message { get; set; }
        public string type { get; set; }
        public ChoiceQuizer ChoiceQizer { get; set; }
        public AnswerQuizer AnswerQizer { get; set; }

        public class ChoiceQuizer
        {
            public List<string> options { get; set; }
            public string correctAnswer { get; set; }
        }

        public class AnswerQuizer
        {
            public string Question { get; set; }
            public string correctAnswer { get; set; }
        }
    }

    /*
    public enum ChattingType
    {
        GeneralChat,
        JuGwanSigChat,
        GaegGwanSigChat
    }
    */
}
