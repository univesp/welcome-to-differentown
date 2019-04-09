using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackScoreController : MonoBehaviour {

    private int airportScore = 100;
    private int hotelScore = 100;
    private int parkScore = 100;
    private int museumScore = 100;
    private int shoppingScore = 100;
    private int restaurantScore = 100;

    public void DecreaseAirportScore(int penalty)
    {
        airportScore -= penalty;
    }

    public void DecreaseHotelScore(int penalty)
    {
        hotelScore -= penalty;
    }

    public void DecreaseParkScore(int penalty)
    {
        parkScore -= penalty;
    }

    public void DecreaseMuseumScore(int penalty)
    {
        museumScore -= penalty;
    }

    public void DecreaseShoppingScore(int penalty)
    {
        shoppingScore -= penalty;
    }

    public void DecreaseRestaurantScore(int penalty)
    {
        restaurantScore -= penalty;
    }

    #region Get Methods
    public int GetAirportScore()
    {
        return airportScore;
    }

    public int GetHotelScore()
    {
        return hotelScore;
    }

    public int GetParkScore()
    {
        return parkScore;
    }

    public int GetMuseumScore()
    {
        return museumScore;
    }

    public int GetShoppingScore()
    {
        return shoppingScore;
    }

    public int GetRestaurantScore()
    {
        return restaurantScore;
    }
    #endregion
}