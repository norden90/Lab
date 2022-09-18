//Lab1 – Hitta tal i sträng med tecken

//Skapa en konsollapplikation som tar en textsträng (string) som argument till Main eller uppmanar användaren mata in en sträng i konsollen.
//Textsträngen ska sedan sökas igenom efter alla delsträngar som är tal som börjar
//och slutar på samma siffra, utan att start/slutsiffran, eller något annat tecken än
//siffror förekommer där emellan.
//ex. 3463 är ett korrekt sådant tal, men 34363 är det inte eftersom det finns
//ytterligare en 3:a i talet, förutom start och slutsiffran. Strängar med bokstäver i
//t.ex 95a9 är inte heller ett korrekt tal.

//Skriv ut och markera varje korrekt delsträng
//För varje sådan delsträng som matchar kriteriet ovan ska programmet skriva ut en
//rad med hela strängen, men där delsträngen är markerad i en annan färg.
//Exempel output för input ”29535123p48723487597645723645”:

//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645
//29535123p48723487597645723645

//Ni kan välja vilka färger ni skriver ut med så länge man ser skillnad på dem. Ni
//byter färg genom att ändra värde på Console.ForegroundColor.

//Addera ihop alla tal och skriv ut totalen
//Programmet ska också addera ihop alla tal den hittat enligt ovan och skriva ut det
//sist i programmet. Gör gärna en tom rad emellan för att skilja från output ovan.
//Exempel output för input ”29535123p48723487597645723645”:
//Total = 5836428677242

//Redovisning
//Uppgiften ska lösas individuellt.
//Lämna in uppgiften på ithsdistans med en kommentar med github-länken.

//Betygskriterier
//För godkänt:
//Räcker att lösa en av uppgifterna, d.v.s. antingen skriva ut alla delsträngar som i exemplet ovan, eller räkna ut och skriva ut totalen.
//Om man matar in strängen i exemplet ska man få samma output som ovan.
//Det ska även fungera generellt, oavsett vilken sträng man matar in.
//För väl godkänt krävs även:
//Båda uppgifterna ska vara lösta, d.v.s. programmet ska först skriva ut alla delsträngar som i exemplet ovan och därefter räkna ut och skriva ut total.
//Koden ska vara väl strukturerad och lätt att förstå.
//Inlämning sker före deadline.

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

class lab1
{
    static void Main(string[] args)
    {
        string input = string.Empty; //Deklarera en tom input sträng.
        long sum = 0; //En tom varibel som kan användas senare. 

        Console.WriteLine("Ange ett stort tal blandat med siffror och bokstäver.");
        input = Console.ReadLine(); //Den inmatade strängen som användaren skirver in. 
        //input = "29535123p48723487597645723645"; //Exempel text i lab, med förväntat resultat 5836428677242

          
        for (int i = 0; i < input.Length; i++)  //Två for loopar som där den andra[j] alltid kommer att jämföra med [i].
                                                //för att kunna hitta de tecken vi letar efter.
        {

            for (int j = i + 1; j < input.Length; j++)
            {          
                
                if (input[i] == input[j]) //Olika vilkor när vi ska trigga en händelse. 
                                          //Om båda input index är samma, triggas koden nedanför. 
                {
                    //SubString tar ut en del av en sträng, du deklarerar var du börjar och avslutar den.
                    //Inom () deklarera var vi ska klippa ur strängen. 

                    string start = input.Substring(0, i);//Startar på index 0 och avslutar på input[i]
                    string mid = input.Substring(i, j - i + 1);//Börjar på input [i] och klipper till input[j]-input[i] + 1.
                    string end = input.Substring(start.Length + mid.Length); //Startar på längen av delsträngen start + mid.
                                                                             //Och klipper resterande sträng.

                    long num = long.Parse(mid); //Omvandla den text som har samma start och slutsiffra till en long(siffror).
                    sum += num; //För varje markerade sträng som vi hittar adderar vi till sum.
                                //Sum visar sedan summan av alla delsträngar mid. 


                    //Här skriver vi ut alla del strängar på en rad, och mid som innerhåller samma start och slutsiffra, den färgmarkeras.
                    Console.Write(start);
                    Console.ForegroundColor = ConsoleColor.DarkGreen; //Nästkommande sträng kommer färgläggas. 
                    Console.Write(mid);
                    Console.ForegroundColor = ConsoleColor.Gray; //Återgår till standard färgen. 
                    Console.WriteLine(end);                
                    break; //När alla delar har gjorts avbryter vi [j] loopen och återgår till loppen [i] och fortsätter leta efter 
                           //fler matchande strängar.
                }

                //Annars om Input[i] eller input[j], om char INTE är en siffra. Avbryt loopen. 
                //Avbryt loopen. Går även att använda Char.IsLetter för att hitta en bokstav.
                //Om det är en '!' agerar den som en bool. Sant eller falskt statement. 
                           
                else if (!char.IsDigit(input[i]) || !char.IsDigit(input[j])) 
                {                                                   
                    break;
                }
            }
        }
        Console.WriteLine($"\nSumman av alla färgmarkade siffror är: {sum}"); //Skirv ut varibel sum.
    }
}