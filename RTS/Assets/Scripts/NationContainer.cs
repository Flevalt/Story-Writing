using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NationContainer : MonoBehaviour {

    string ruler;
    int governmentForm;
    int economyForm;
    int religionForm;
    int currencyForm;
    TerritoryContainer[] ownedProvinces;
    bool[] enactedLaws;
    int currentCurrency;
    int currencyGrowth;
    int currentPopulation;
    int populationGrowth;
}
