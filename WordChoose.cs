using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordChoose : MonoBehaviour {
    public Text myText;
    public Text myScore;
    public Text clock;
    private int playlistNumber;
    private int score;
    private int wordsTyped;
    private float wpm;
    private bool gameActive;
    private bool checkingText;
    //private bool lerpingText;
    //private float lerpvalue;
    public float initialTime;
    private float timer;
    public AudioClip correct;
    private AudioSource source;
    private InputField myInput;
    public Button myButton;
    public Dropdown myDropdown;
    private List<string> playlist;
    private List<List<string>> listOfLists = new List<List<string>>{
            new List<string> {"Animals", "ant", "buffalo", "cat", "dog", "elephant", "fish", "giraffe", "horse", "iguana", "jackalope", "kangaroo", "lion", "monkey", "narwhal", "octopus", "pig", "quail", "rat", "snake", "turtle", "urial", "vulture", "wolf", "yak", "zebra",},
            new List<string> {"Elements", "hydrogen", "helium", "lithium", "beryllium", "boron", "carbon", "nitrogen", "oxygen", "fluorine", "neon", "sodium", "magnesium", "aluminium", "silicon", "phosphorus", "sulfur", "chlorine", "argon", "potassium", "calcium", "scandium", "titanium", "vanadium", "chromium", "manganese"},
            new List<string> {"Pokemon", "bulbasaur", "ivysaur", "venusaur", "charmander", "charmeleon", "charizard", "squirtle", "wartortle", "blastoise", "caterpie", "metapod", "butterfree", "weedle", "kakuna", "beedrill", "pidgey", "pidgeotto", "pidgeot", "rattata", "ratticate", "spearow", "fearow", "ekans", "arbok", "pikachu" },
            new List<string> {"NATO", "alpha", "bravo", "Charlie", "delta", "echo", "foxtrot", "golf", "hotel", "India", "Juliet", "kilo", "Lima", "Mike", "November", "Oscar", "papa", "Quebec", "Romeo", "sierra", "tango", "uniform", "victor", "whiskey", "x-ray", "yankee", "zulu" },
            new List<string> {"Countries", "America", "Brazil", "Canada", "Denmark", "England", "Finland", "Germany", "Holland", "India", "Japan", "Korea", "Lithunia", "Mongolia", "Nigeria", "Oman", "Portugal", "Qatar", "Russia", "Sweden", "Thailand", "Ukraine", "Vietnam", "Wales", "Yemen", "Zimbabwe"},
            new List<string> {"UK Tube Stations", "Angel", "Baker Street", "Borough", "Charing Cross", "Victoria", "Earl's Court", "Edgware", "Embankment", "Euston", "Green Park", "Hammersmith", "Heathrow Terminals", "Hyde Park Corner", "South Kensington", "King's Cross St.Pancras", "Knightsbridge", "Leicester Square", "London Bridge", "Oxford Circus", "Paddington", "Piccadilly Circus", "Russell Square", "St. Paul's", "Tottenham Court Road", "Waterloo", "Mornington Crescent","Uxbridge","Cockfosters", "Bank","Blackfriars","Bond Street","Barons Court","Farringdon","Holborn","Gloucester Road", "Lancaster Gate","Oval","Arsenal","Liverpool Street","Regent's Park","Old Street","St. James's Park","Sloane Square","Temple","Tower Hill","Warren Street","Westminster"},
            new List<string> {"Names", "Alice", "Bob", "Charlie", "Dave", "Eve", "Frank", "Gerald", "Holly", "Ingrid", "Janice", "Klaus", "Lindsay", "Mallory", "Nicholas", "Olivia", "Peggy", "Quentin", "Russell", "Sybil", "Trudy", "Ulysses", "Victor", "Walter", "Xanthe", "Yvonne", "Zachary"},
            new List<string> {"BEMANI", "dopamine", "flower", "anemone", "cosine", "standalone", "aggressor", "garuda", "evans", "albida", "jomanda", "lisa-riccia", "vallisneria", "rice metal", "lucky", "overcomplexification","starter","air raid","red zone", "macuilxochitl", "lindwurm", "happy", "true blue", "creation", "giga break", "sludge", "stulti", "sinistra", "broken", "icicles", "plum", "adrenaline", "nature", "goose", "dance","relinquish","sand","samurai","hedgehog", "New York","London","Tohoku","Osaka","Tokyo","possession","period","endymion","black roses","medusa","exclamation","sola","max","fascination","gold","Vanessa","endorphin","serotonin"},
            new List<string> {"Programming", "unity","coding","integer","float","double","var","enumerator","method","function","exception","nullpointer","runtime","throughput","array","try-catch","while(true)","compile","javascript","java","python","crash","error report","downtime","server","internet","computer","Netcentric Architecture","programming"},
            new List<string> {"Space", "sun","mercury","venus","earth","mars","jupiter","saturn","uranus","neptune","pluto","milky way","asteroid belt","star","deimos","phobos","moon","ganymede","black hole","vaccuum","dark matter","aliens","europa","andromeda","galaxy","constellation","orion","aries","taurus","gemini","cancer","leo minor","leo major","virgo","libra","scorpius","sagittaurus","capricorn","aquarius","pisces","pleiades","crux","ursa minor","ursa major","canos minor","canis major","lepus","triangulum","lupus", "horologium", "bootes", "asterism"},
            new List<string> {"Music", "accordion","bass","guitar","piano","trumpet","keyboard","synthesizer","violin","harp","organ","tuba","trombone","oboe","saxophone","flute","harpsicord","bagpipe","crwth","cello","viola","recorder","bassoon","piccolo","triangle"},
            new List<string> {"Cities", "Venice","Vienna","Geneva","Bangkok","Rome","Milan","Apulia","Sicily","Tuscany","Ruhr","Berlin","Munich","Stravopol","London","Liverpool","Clyde","Edinburgh","Glasgow","Dublin","Dundee", "Belfast", "Ullapool","Brest","Picardy","Burgundy","Paris","Stockholm","Bordeaux","Seville","Reykjavik","Nuuk","Gascony","Marseilles","Lisbon","Madrid","Naples","Athens","Sparta","Budapest","Oslo","Helsinki","St. Petersburg","Moscow","Vladivostok","Perm","Warsaw","Rumia","Ankara","Constantinople","Spokane","New York","Chicago","Boston","Detroit","Kansas City","Memphis","Philadelphea", "St. Louis","Houston","Winnipeg","Calgary","Quebec","Ontario","Anchorage","Auckland","Canberra","Sydney","Bristol","Brisbane","Tasmania","Adelaide","Alice Springs","Melbourne","Shanghai","Guangzhou","Xi'an","Chengdu","Beijing","York","Durham","Croydon","Brussels","Amsterdam","Bogota","Sao Paulo","Brasilia","Rio de Janeiro","Fortaleza","Johannesburg","Cape Town","Kinshasa","Cairo","Amman","Dakar","Lagos","Luanda","Zanzibar","Khartoum","Barcelona","Copenhagen","Kiev","Istanbul","Baghdad","Dubai","Riyadh","Nairobi","Santiago","Punta Arenas","Buenos Aires","Arequipa","Salvador","San Juan","Miami","Havana","Mexico City","Honolulu","Los Angeles","Vancouver","Denver","Montreal","Edmonton","Minneapolis","Mumbai","Bombay","New Delhi","Kolkata","Bangalore","Mumbai","Karachi","Volgograd","Novosibirsk","Harbin","Shenyang","Tokyo","Nagasaki","Sendai","Kyoto","Sapporo","Osaka","Seoul","Pyongyang","Manila","Jakarta","Hanoi","Ho Chi Minh City","Darwin","Cairns","Christchurch","Auckland","Perth","Adelaide","Aberdeen","Hong Kong","Urumqi","Ulan Bator"},
            new List<string> {"Difficult", "cry", "cwm", "crwth", "farce", "fjord", "glyph", "ixora", "ataxia","awkward","axolotl", "fallacy", "flaccid", "jocular", "aardvark", "Brooklyn", "cemetery", "Djibouti", "dopamine", "Arrabiata", "dziggetai", "endorphin", "fettucini", "Kamchatka", "manifesto", "necessary", "necessity", "adrenaline", "Alprazolam", "Kazakhstan", "Kyrgyzstan", "Afghanistan", "Alburquerque", "champaign", "Oklahoma", "orangutan", "orientation", "oriental", "Peninsula", "Pensylvania", "pizza", "proximity", "qadi", "qaid", "qanat", "qat", "rhythm", "scarce", "serotonin", "Skagerrak", "swatch", "Tajikistan", "tranq", "trinity", "umiaq", "Uzbekistan", "xanadu", "xenon", "Xerox", "xylophone", "Majapahit", "Quetzalcoatl", "handkerchief", "Macuilxochitl", "pharmaceutical", "complexification", "antidisestablishmentarianism", "floccinaucinihilipilification", "dhole", "bharal" },
            new List<string> {"Testing", "aaa","bbb","ccc","ddd","eee"},
        };

    // Use this for initialization
    void Start () {
        myInput = gameObject.GetComponent<InputField>();
        myText.text = "Welcome to Typist!";
        source = GetComponent<AudioSource>();
        myScore.text = "Your Score = 0\nWords Typed = 0";
        myButton.GetComponentInChildren<Text>().text = "Start Game";
        score = 0;
        wordsTyped = 0;
        gameActive = false;
        checkingText = false;
        timer = initialTime;
        playlist = new List<string>();
        updateTime();
        populateDropdown();
        myButton.onClick.AddListener(() => StartCoroutine(startGame()));
        myInput.onValueChanged.AddListener(delegate { StartCoroutine(checkWord()); });
        //lerpvalue = 0;
        //lerpingText = false;
    }

    void Update() {
        if (gameActive){
            updateTime();
            timer -= Time.deltaTime;
            updateScore();
            if (Mathf.RoundToInt(timer) < 0) {
                StopCoroutine(checkWord());
                StartCoroutine(endGame());
            }
        }
    }

    IEnumerator startGame() {
        myButton.GetComponentInChildren<Text>().text = "Stop";
        timer = initialTime;
        playlist.Clear();
        playlist.AddRange(chooseWordList());
        playlist.RemoveAt(0);
        score = 0;
        wordsTyped = 0;
        myText.text = "3";
        yield return new WaitForSeconds(1);
        myText.text = "2";
        yield return new WaitForSeconds(1);
        myText.text = "1";
        yield return new WaitForSeconds(1);
        myText.text = "GO!";
        yield return new WaitForSeconds(1);
        myText.text = textRandom(playlist);
        myInput.interactable = true;
        myInput.ActivateInputField();
        gameActive = true;
        myInput.text = "";
        myButton.onClick.RemoveAllListeners();
        myButton.onClick.AddListener(() => StartCoroutine(endGame()));
    }

    IEnumerator checkWord() {
        if (myText.text.Equals(myInput.text) && gameActive) {
            checkingText = true;
            source.PlayOneShot(correct);
            score += myText.text.Length;
            wordsTyped++;
            myInput.text = "";
            myInput.interactable = false;
            myText.color = Color.green;
            yield return new WaitForSeconds(0.25f);
            myText.color = Color.black;
            myText.text = textRandom(playlist);
            myInput.interactable = true;
            myInput.ActivateInputField();
            checkingText = false;
        }

    }

    IEnumerator endGame() {
        while (checkingText) {
            yield return new WaitForSeconds(0.1f);
        }
        myInput.interactable = false;
        if (timer < 0) {
            timer = 0;
        }
        wpm = (wordsTyped) / ((initialTime - timer)/60)   ;
        myText.text = ("Game Over!\nYour WPM: " + wpm);
        myButton.GetComponentInChildren<Text>().text = "Play Again";
        gameActive = false;
        myButton.onClick.RemoveAllListeners();
        myButton.onClick.AddListener(() => StartCoroutine(startGame()));
    }

    /*IEnumerator textLerp(Color start, Color finish, float duration) {
        lerpvalue = 0;
        while (lerpvalue < 1){
            myText.color = Color.Lerp(start, finish, lerpvalue);
            lerpvalue += Time.deltaTime / duration;
            Debug.Log("lerpvalue = " + lerpvalue + ", color = " + myText.color);
        }
        yield return null;
    }*/

    string textRandom(List<string> wordList){
        string myWord;
        if (wordList.Count == 0) {
            wordList.AddRange(chooseWordList());
            wordList.RemoveAt(0);
            Debug.Log("List Refilled");
        }
        myWord = wordList[Random.Range(0, wordList.Count)];
        wordList.Remove(myWord);
        wordList.RemoveAll(item => item == null);
        return myWord;
    }

    List<string> chooseWordList() {
        playlistNumber = myDropdown.value;
        if (playlistNumber <= listOfLists.Count - 1) {
            return (listOfLists[playlistNumber]);
        } else if(playlistNumber == listOfLists.Count) {
            return listOfLists[Random.Range(0, listOfLists.Count)];
        } else {
            return allWords();
        }
    }

    void updateScore() {
        myScore.text = ("Your Score = " + score + "\nWords Typed = " + wordsTyped);
    }

    void updateTime() {
        clock.text = ("Time: " + Mathf.RoundToInt(timer));
    }
    void populateDropdown() {
        List<string> catList = new List<string>();
        for(int i = 0; i<listOfLists.Count; i++) {
            catList.Add(listOfLists[i][0]);
        }
        catList.Add("Choose for me!");
        catList.Add("Everything");
        myDropdown.AddOptions(catList);
    }
    List<string> allWords() {
        List<string> biglist = new List<string>();
        List<string> temp = new List<string>();
        for (int i = 0; i<listOfLists.Count; i++) {
            temp = listOfLists[i];
            temp.RemoveAt(0);
            biglist.AddRange(temp);
        }
        return biglist;
    }
}
