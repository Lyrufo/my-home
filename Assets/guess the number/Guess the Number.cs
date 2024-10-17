using TMPro; //utilisier librairie
using UnityEngine; // r�gle d'import : dans ce script on utilise tout ce qui est ici; si ce n'st pas l� ca note erreur ; faire click droit ; actions rapides et etc

public class GuesstheNumber : MonoBehaviour // "public" new fonctionnalit� utilisable ds tout le projet ; "class" groupe auquel affecter (genre class de perso ; mod�le de fonctionnalit�s) ":monobehaviour" ; truc de base pour cr�er des fonctionnalit�s (voir sur internet) 
{// d�finit la "class" cr��e juse au dessus

    public TMP_Text messageText; //nv variable public donc peut �tre vue dans l'inspector (menu � gauche sur unity) ; pouvoir dire plus grand ou plus petit
    public TMP_InputField numberInput; //lire le num�ro et savoir si plus grand ou plus petit

    private int randomNumber; //stocker le nombre random qui aura �t� g�n�r� dans la variable "randomNumber" ; "int" faite pour contnir un nb entier (positif ou n�gatif)

    private void Start() //"private" parce que pas de raison de donner pubic ; "void" pas de retour � donner puisque ici juste un test ; "start" uniquement qd l'objet est activ� pour la premi�re fois
    {
        ResetGame(); //ex�cuter d�s le start la fonction ResetGame qui a �t� d�finie en bas    
    }
    
       // randomNumber = Random.Range(1,101); //101 car exclusif le max   ; d�finir la variable de mani�re random dans un intervale
      //  Debug.Log("Generated number : " + randomNumber); //afficher dans la console pour nous le contenu de la variable (donc le chiffre random) 
       // messageText.text = "Guess the number..."; //on sait que � amodifie le texte de la boite de texte genre de base celle au milieu car on a drag and drop le code avec "add coponent" plus t�t (pour expliquer se ref notes juste en dessous)
        //messageText.text = "yo bitches"; //donne ce text au d�marrage  =>> on va chercher le "text" dans "messageText"
   

    public void Try()
    {
        //if (numberInput.text == "")  //ici dans le cas o� le contenu est vide ; "==" permet de comparer   ; mais couvre pas les cas o� qqn met que des espaces etc donc : 
        if (string.IsNullOrWhiteSpace(numberInput.text)==true) //si valeur nulle (genre espace) ou pas valide ; "== true" pour dire "si la condition est r�elle (donc si c'est nul ou pas valide) => Pas n�cessaire obligatoirement
        {
            messageText.text = "Frere t'abuses entre un nombre valide"; //afficher �a sur la boite de text en haut
            numberInput.text = ""; //vider le champs de text d'entr�e (genre le truc o� le joueur entre un nb)
            return; //arr�te (�quivalent "end if")

        }

        if(int.TryParse(numberInput.text, out int playerNumber)) //"tryParse" : lis les caract�res et trasforme en qq chose d'autre ; vu que le hamps "text " a �t� rempli il est pas consid�r� comme nombre ; comme �a on pourra comparer au random number et permet de le mettre dans player number si c'est good (si �a �crt un texte et pas un nombre)
        {
            if(playerNumber == randomNumber)
            {
                messageText.text = "victory";
            }
            else if (playerNumber > randomNumber)
            {
                messageText.text = "Less";
            }
            else if (playerNumber < randomNumber)
            {
                messageText.text = "Greater";
            }

        }
        else
        {
            messageText.text = "entre un nb frero";
        }
        numberInput.text = ""; //ds tous les autres cas, reset le champ
    }

    public void ResetGame() //pour reset le jeu
    {
        randomNumber = Random.Range(1, 101); 
        Debug.Log("Generated number : " + randomNumber);  
        messageText.text = "Guess the number...";
    }

}
