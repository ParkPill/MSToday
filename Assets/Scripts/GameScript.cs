using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject Msprefab;
    public GameObject CoinPrefab;
    public GameObject CoinSilverPrefab;
    public float CoolTime = 0.5f;
    private float _coolTime;
    public float CoinCoolTime = 0.5f;
    private float _CoinCoolTime;
    public float _gameTime;
    public Text LblTime;
    public Text LblCoin;
    public Text LblTotalCoin;
    public int CoinCount = 0;
    public GameObject BtnBuy0;
    public GameObject BtnBuy1;
    public GameObject BtnBuy2;
    public GameObject BtnBuy3;
    public GameObject BtnBuy4;
    public GameObject BtnBuy5;
    public GameObject PnlGameOver;
    public GameObject Title;
    public GameObject PnlShop;
    public GameObject BtnShop;
    public Text LblResult;
    public bool IsGameOver;
    public bool IsStarted = false;
    public GameObject[] Cubes;
    public string CoinKey = "CoinKey";
    public string AirPlaneKey = "AirPlaneKey{0}";
    public string SelectedAirplane = "SelectedAirplane";
    public GameObject[] AirPlanes;

    // Start is called before the first frame update
    void Start()

    {
        int index = PlayerPrefs.GetInt(SelectedAirplane, 0);
        SelectAirplane(index);
        LblTotalCoin.text = PlayerPrefs.GetInt(CoinKey).ToString() + "€";
        StartCoroutine(Difficulty());
        UpdateUi();
    }
    public void CloseShop()
    {
        PnlShop.SetActive(false);

    }
    public void OnShopClick()
    {
        PnlShop.SetActive(true);
    }
    public void SelectAirplane(int index)
    {
        for (int i = 0; i < AirPlanes.Length; i++)
        {
            if (i == index)
            {
                AirPlanes[i].SetActive(true);
            }
            else
            {
                AirPlanes[i].SetActive(false);
            }

            //AirPlanes[i].SetActive(i == index);
        }
         PlayerPrefs.SetInt(SelectedAirplane, index);
    }
    public IEnumerator Difficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (IsGameOver || !IsStarted)
            {
                continue;
            }
            CoolTime -= 0.05f;
        }

    }
    public void StartGame()
    {
        IsStarted = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (IsGameOver || !IsStarted)
        {
            return;
        }
        Title.SetActive(false);
        _gameTime += Time.deltaTime;
        LblTime.text = string.Format("{0:0.0}", _gameTime);
        _coolTime += Time.deltaTime;
        if (_coolTime >= CoolTime)
        {
            GameObject obj = Instantiate(Msprefab);
            obj.GetComponent<missile>().TheGameScript = this;
            obj.GetComponent<missile>().RightTop = new Vector2(Cubes[3].transform.position.x, Cubes[3].transform.position.y);
            obj.GetComponent<missile>().LeftBottom = new Vector2(Cubes[0].transform.position.x, Cubes[0].transform.position.y);
            _coolTime = 0;

        }

        _CoinCoolTime += Time.deltaTime;
        if (_CoinCoolTime >= CoinCoolTime)
        {
            GameObject obj;
            int rate = UnityEngine.Random.Range(0, 100);
            Debug.Log("rate " + rate);
            if (rate < 15) 
            {
                obj = Instantiate(CoinPrefab);
            }
            else
            {
                obj = Instantiate(CoinSilverPrefab);
            }
            obj.GetComponent<missile>().TheGameScript = this;
            obj.GetComponent<missile>().RightTop = new Vector2(Cubes[3].transform.position.x, Cubes[3].transform.position.y);
            obj.GetComponent<missile>().LeftBottom = new Vector2(Cubes[0].transform.position.x, Cubes[0].transform.position.y);
            _CoinCoolTime = 0;

        }

    }
    public void BuyAirplane(GameObject lbl)
    {
        int price = int.Parse(lbl.GetComponent<Text>().text);
        int coin = PlayerPrefs.GetInt(CoinKey);
        if (price <= coin)
        {
            AddSavedCoin(-price);
            int index = int.Parse(lbl.name.Substring(9));
            PlayerPrefs.SetInt(string.Format(AirPlaneKey, index), 1);
            UpdateUi();
            //string str = string.Format("Airplane {0} {1}", index, "abgf");
            // 스트링 포멧 형식은 0번에 콤마 뒤에 첫 번째 값이 들어간 문자열을 반환한다.
        }
    }
    public void ReStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GameOver()
    {
        PnlGameOver.SetActive(true);
        IsGameOver = true;
        LblResult.text = _gameTime.ToString("0.0");
        int coin = PlayerPrefs.GetInt(CoinKey);
        coin += CoinCount;
        PlayerPrefs.SetInt(CoinKey, coin);
    }
    public void AddInGameCoin(int count)
    {
        Debug.Log("Coin " + count);
        CoinCount += count;
        UpdateUi();


    }

    
    public void AddSavedCoin(int count)
    {
        int coin = PlayerPrefs.GetInt(CoinKey);
        coin += count;
        PlayerPrefs.SetInt(CoinKey, coin);
    }
    public void UpdateUi()
    {
        LblCoin.text = CoinCount.ToString();
        int coin = PlayerPrefs.GetInt(CoinKey);
        LblTotalCoin.text = coin.ToString();
        int didBuy = PlayerPrefs.GetInt(string.Format(AirPlaneKey, 0), 0);
        if (didBuy == 1)
        {
            BtnBuy0.SetActive(false);
        }
        didBuy = PlayerPrefs.GetInt(string.Format(AirPlaneKey, 1), 0);
        if (didBuy == 1)
        {
            BtnBuy1.SetActive(false);
        }
        didBuy = PlayerPrefs.GetInt(string.Format(AirPlaneKey, 2), 0);
        if (didBuy == 1)
        {
            BtnBuy2.SetActive(false);
        }
        didBuy = PlayerPrefs.GetInt(string.Format(AirPlaneKey, 3), 0);
        if (didBuy == 1)
        {
            BtnBuy3.SetActive(false);
        }
        didBuy = PlayerPrefs.GetInt(string.Format(AirPlaneKey, 4), 0);
        if (didBuy == 1)
        {
            BtnBuy4.SetActive(false);
        }
        didBuy = PlayerPrefs.GetInt(string.Format(AirPlaneKey, 5), 0);
        if (didBuy == 1)
        {
            BtnBuy5.SetActive(false);
            Debug.Log("sfsdf");
        }
        Debug.Log("sfsdf");

    }
}
