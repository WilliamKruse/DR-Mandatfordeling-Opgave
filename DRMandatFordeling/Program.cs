using DRMandatFordeling.Models;

//Test-data fra opgavebeskrivelsen.
List<Parti> OpstilledePartier = new List<Parti>()
{
	new Parti("A", 405),
	new Parti("B",925),
	new Parti("C", 612),
	new Parti("D", 310)
};

//Laver en ny liste, med beregnede mandat antal tilføjet.
List<Parti> ValgResultat = FordelMandater(OpstilledePartier, 5);

//Udskriver i consol hvor mange mandater hvert opstillet parti har opnået.
Console.WriteLine("Hej DR! Her er mandatfordelingen fra eksemplet i opgavebesrkivelsen: " + Environment.NewLine);

for (int i = 0; i < ValgResultat.Count; i++)
{
	Console.WriteLine(ValgResultat[i].Navn + " har fået: " + ValgResultat[i].Stemmer + " stemmer og dermed opnået: " + ValgResultat[i].Mandater + " mandater");
}
Console.WriteLine("");






// Consol dialog med bruger, der giver mulighed for at teste programmet med custom data.
List<Parti> BrugerData = new List<Parti>();
Console.WriteLine("Test programmet ved at indsætte din egen data!" + Environment.NewLine);
Console.WriteLine("Hvor mange mandater skal der i alt fordeles?");

int BrugerAntalMandater = int.Parse(Console.ReadLine());
Console.WriteLine("Hvor mange partier har stillet op til valget?");
int BrugerAntalPartier = int.Parse(Console.ReadLine());


for (int i = 0; i < BrugerAntalPartier; i++)
{
	Console.WriteLine("Indtast navn på parti nummer " + (i + 1) + ":");
	string tempNavn = Console.ReadLine();
	Console.WriteLine("Hvor mange stemmer har " + tempNavn + " fået til dette valg?");
	int tempStemmer = int.Parse(Console.ReadLine());
	BrugerData.Add(new Parti(tempNavn, tempStemmer));
}
//Fordeler mandater og udskriver resultat i console
List<Parti> BrugerResultat = FordelMandater(BrugerData, BrugerAntalMandater);
Console.WriteLine("Her er fordeling af mandater:" + Environment.NewLine);
for (int i = 0; i < BrugerResultat.Count; i++)
{
	Console.WriteLine(BrugerResultat[i].Navn + " har fået: " + BrugerResultat[i].Stemmer + " stemmer og dermed opnået: " + BrugerResultat[i].Mandater + " mandater");
}






//Metode der tager udgangspunkt i D'Hondts metode, til mandatfordeling i danske kommuner.
//Tager en liste af partier og deres respektive stemmer som input og returnere en ny liste med fordelte mandater tilføjet.
List<Parti> FordelMandater(List<Parti> StemmeData, int AntalMandaterTilFordeling)
{
	//Midlertidig liste, der til slut returneres med nye værdier tilføjet.
	List<Parti> Resultat = StemmeData;

	//Ydre for-loop der kører for hver mandat der skal placeres.
    for (int i = 0; i < AntalMandaterTilFordeling; i++)
	{
		int Index = 0;
		double Kvotient = 0;
		
		//Indre for-loop der sammeligner antal stemmer divideret med 1,2,3 osv., alt efter hvor mange mandater partiet har fået tildelt.
		for (int j = 0; j < Resultat.Count; j++)
		{
			double tempKvotient = Resultat[j].Stemmer / (Resultat[j].Mandater + 1);
			//Her burde trækkes lod i tilfælde af indentiske kvotienter, men det tager vi ikke hensyn til endnu
			if (tempKvotient>=Kvotient)
			{
				Kvotient = tempKvotient;
				Index = j;
			}
		}
		//tilføjer en mandat til "Resultat"
		Resultat[Index].Mandater++;
	}
	return Resultat;
};