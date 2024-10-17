using TMPro; //utilisier librairie
using UnityEngine; // règle d'import : dans ce script on utilise tout ce qui est ici; si ce n'st pas là ca note erreur ; faire click droit ; actions rapides et etc

public class GuesstheNumber : MonoBehaviour // "public" new fonctionnalité utilisable ds tout le projet ; "class" groupe auquel affecter (genre class de perso ; modèle de fonctionnalités) ":monobehaviour" ; truc de base pour créer des fonctionnalités (voir sur internet) 
{// définit la "class" créée juse au dessus

    public TMP_Text messageText; //nv variable public donc peut être vue dans l'inspector (menu à gauche sur unity) ; pouvoir dire plus grand ou plus petit
    public TMP_InputField numberInput; //lire le numéro et savoir si plus grand ou plus petit

    private int randomNumber; //stocker le nombre random qui aura été généré dans la variable "randomNumber" ; "int" faite pour contnir un nb entier (positif ou négatif)

    private void Start() //"private" parce que pas de raison de donner pubic ; "void" pas de retour à donner puisque ici juste un test ; "start" uniquement qd l'objet est activé pour la première fois
    {
        ResetGame(); //exécuter dès le start la fonction ResetGame qui a été définie en bas    
    }
    
       // randomNumber = Random.Range(1,101); //101 car exclusif le max   ; définir la variable de manière random dans un intervale
      //  Debug.Log("Generated number : " + randomNumber); //afficher dans la console pour nous le contenu de la variable (donc le chiffre random) 
       // messageText.text = "Guess the number..."; //on sait que ç amodifie le texte de la boite de texte genre de base celle au milieu car on a drag and drop le code avec "add coponent" plus tôt (pour expliquer se ref notes juste en dessous)
        //messageText.text = "yo bitches"; //donne ce text au démarrage  =>> on va chercher le "text" dans "messageText"
   

    public void Try()
    {
        //if (numberInput.text == "")  //ici dans le cas où le contenu est vide ; "==" permet de comparer   ; mais couvre pas les cas où qqn met que des espaces etc donc : 
        if (string.IsNullOrWhiteSpace(numberInput.text)==true) //si valeur nulle (genre espace) ou pas valide ; "== true" pour dire "si la condition est réelle (donc si c'est nul ou pas valide) => Pas nécessaire obligatoirement
        {
            messageText.text = "Frere t'abuses entre un nombre valide"; //afficher ça sur la boite de text en haut
            numberInput.text = ""; //vider le champs de text d'entrée (genre le truc où le joueur entre un nb)
            return; //arrête (équivalent "end if")

        }

        if(int.TryParse(numberInput.text, out int playerNumber)) //"tryParse" : lis les caractères et trasforme en qq chose d'autre ; vu que le hamps "text " a été rempli il est pas considéré comme nombre ; comme ça on pourra comparer au random number et permet de le mettre dans player number si c'est good (si ça écrt un texte et pas un nombre)
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
