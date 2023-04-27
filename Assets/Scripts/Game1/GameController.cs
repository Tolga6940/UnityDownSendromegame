using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite arkayuz;
    public Sprite[] onyuz;
    public List<Sprite> gameimages = new List<Sprite>();

    public GameObject oyunsonu;

    public GameObject[] stars;

    public List<Button> btns = new List<Button>();

    public bool firstg;
    public bool secondg;
    public int countg;
    public int councorretg;
    public int gameg;

    private int firstgindex;
    private int secondgindex;

    public string ilktahminp;
    public string ikincitahminp;
    void Awake()
    {
        onyuz = Resources.LoadAll<Sprite>("Graphics/Animals");
    }
    void Start()
    {
        GetButtons();
        AddListeners();
        addgameimages();
        shuffle(gameimages);
        gameg = gameimages.Count / 2;
        
 
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag ("Pbutton");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = arkayuz;
        }
    }
    void addgameimages()
    {
        int looper = btns.Count;
        int index = 0;
        for (int i = 0; i < looper; i++)
        {
            if (index==looper/2)
            {
                index = 0;
            }

            gameimages.Add(onyuz[index]);
            index++;
        }
    }
    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PicMemory());
        }
    }
    public void PicMemory()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstg)
        {
            firstg = true;

            firstgindex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);


            ilktahminp = gameimages[firstgindex].name;

            btns[firstgindex].image.sprite = gameimages[firstgindex];
            
        }
        else if (!secondg)
        {
            secondg = true;

            secondgindex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            ikincitahminp = gameimages[secondgindex].name;

            btns[secondgindex].image.sprite = gameimages[secondgindex];

            countg++;

            StartCoroutine(checkifmatched());

    

        }
    }
    IEnumerator checkifmatched()
    {
        yield return new WaitForSeconds(1f);

        if (ilktahminp == ikincitahminp)
        {
            yield return new WaitForSeconds(.5f);

            btns[firstgindex].interactable = false;
            btns[secondgindex].interactable = false;


            btns[firstgindex].image.color= new Color(0,0,0,0);
            btns[secondgindex].image.color = new Color(0, 0, 0, 0);


            oyunbittimi();
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            btns[firstgindex].image.sprite = arkayuz;
            btns[secondgindex].image.sprite = arkayuz;
        }

        yield return new WaitForSeconds(.5f);

        firstg = secondg = false;
    }
    void oyunbittimi()
    {
        councorretg++;
        if (councorretg == gameg)
        {
            Debug.Log("oyun bitti");
            Debug.Log("Oyunu bitirmen "+countg+"kadar sürdü.");
            oyunsonu.SetActive(true);
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
            GetComponent<GameController>().StarCheck();

        }
    }
    void shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int rndind = Random.Range(i, list.Count);
            list[i] = list[rndind];
            list[rndind] = temp;
        }
    }


    public void StarCheck()
    {

        if (countg > (gameg + 2))
        {
            stars[0].SetActive(true);
            Debug.Log("1yýldýz geldi");
        }
        else if (countg > gameg && countg <= (gameg + 2))
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            Debug.Log("1ve 2yýldýz geldi");
        }
        else if (countg == gameg)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            Debug.Log("1,2,3 yýldýz geldi");
        }
    }
}
