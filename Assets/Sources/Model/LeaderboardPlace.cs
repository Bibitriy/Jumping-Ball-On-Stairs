using UnityEngine;

public struct LeaderboardPlace
{
    private string _name;
    private int _score;

    public string Name => _name;
    public int Score => _score;

    public LeaderboardPlace(string name, int score)
    {
        _name = name;
        _score = score;
    }

    public void SetName(string name)
    {
        if (name == "" || name == null)
            _name = "Player";
        else
            _name = name;
    }

    public void SaveScore(int placesAmount)
    {
        int placeToInsert = FindScorePlace(placesAmount);

        for (int i = placesAmount-1; i >= placeToInsert; i--)
        {
            PlayerPrefs.SetString((i + 1).ToString() + "name", PlayerPrefs.GetString((i).ToString()));
            PlayerPrefs.SetInt((i + 1).ToString(), PlayerPrefs.GetInt((i).ToString()));
        }

        if (placeToInsert <= placesAmount)
        {
            PlayerPrefs.SetString(placeToInsert.ToString() + "name", _name);
            PlayerPrefs.SetInt(placeToInsert.ToString(), _score);
        }
    }

    private int FindScorePlace(int placesAmount)
    {
        for (int i = 1; i <= placesAmount; i++)
        {
            if (PlayerPrefs.GetInt(i.ToString()) < _score)
            {
                return i;
            }
        }
        return placesAmount + 1;
    }
}
