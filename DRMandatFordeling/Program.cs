using DRMandatFordeling.Models;

List<Parti> OpstilledePartier = new List<Parti>()
{
	new Parti("A", 405),
	new Parti("B",925),
	new Parti("C", 612),
	new Parti("D", 310)
};

List<Parti> ValgResultat = FordelMandater(OpstilledePartier, 5);

for (int i = 0; i < ValgResultat.Count; i++)
{
	Console.WriteLine(ValgResultat[i].Navn + " har fået: " + ValgResultat[i].Stemmer + " og dermed opnået: " + ValgResultat[i].Mandater); ;
}


List<Parti> FordelMandater(List<Parti> StemmeData, int AntalMandaterTilFordeling)
{
	List<Parti> Resultat = StemmeData;

	List<int> TempMandatFordeling = new List<int>();
    int antalPartier = StemmeData.Count;

	for (int i = 0; i < antalPartier; i++)
	{
		TempMandatFordeling.Add(0);
	}

    for (int i = 0; i < AntalMandaterTilFordeling; i++)
	{
		int Index = 0;
		double Kvotient = 0;
		
		for (int j = 0; j < antalPartier; j++)
		{
			double tempKvotient = StemmeData[j].Stemmer / (TempMandatFordeling[j] + 1);
			if (tempKvotient>Kvotient)
			{
				Kvotient = tempKvotient;
				Index = j;
			}
		}
		TempMandatFordeling[Index]++;
		Resultat[Index].Mandater++;
	}
	return Resultat;
};



