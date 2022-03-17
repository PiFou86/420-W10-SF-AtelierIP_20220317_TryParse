
public class Program
{
    public static void Main(string[] p_args)
    {
        // Utilisation de nos fonctions
        bool estValeurEntiere = false;
        int valeurEntiereSaisie = 0;
        do
        {
            Console.Out.WriteLine("Entrez une valeur entière positive SVP : ");
            string lectureChaine = Console.In.ReadLine();

            estValeurEntiere = EstChaineChiffresSeulement(lectureChaine);
            if (!estValeurEntiere)
            {
                Console.Error.WriteLine("La valeur saisie n'est pas un entier positif reconnu !");
            } 
            else
            {
                valeurEntiereSaisie = ConvertirChaineEntierPositifEnEntier(lectureChaine);
            }
        } while (!estValeurEntiere);

        Console.Out.WriteLine($"Voici la valeur entière que vous avez saisie : {valeurEntiereSaisie}");
    }


    /// <summary>
    /// Fonction qui convertit une chaine de caractère contenant un entier positif en un entier positif
    /// </summary>
    public static int ConvertirChaineEntierPositifEnEntier(string p_chaine)
    {
        /// On valide si le paramètre d'entrée respecte les hypothèses pour lesquelles notre algorithme a été pensé :
        /// On ne sait traiter que des chaines de caractères qui ont au moins un chiffre et seulement des chiffres. 
        /// On ne peut donc traduire que des entiers positifs.
        if (string.IsNullOrEmpty(p_chaine) || !EstChaineChiffresSeulement(p_chaine))
        {
            /// Si nous n'avons pas les bonnes données en entrée, on lève une erreur (ce sera vu un peu plus loin dans votre session)
            throw new ArgumentOutOfRangeException(nameof(p_chaine));
        }

        /// Ici, nous sommes assurés d'avoir une chaine contenant au moins un chiffre et ne contenant que des chiffres.
        int valeurEntier = 0;
        for (int numeroCaractere = 0; numeroCaractere < p_chaine.Length; numeroCaractere++)
        {
            int chiffre = ConvertirCaractereChiffreEnEntier(p_chaine[numeroCaractere]);

            /// On décale la valeur vers la gauche d'une position en multipliant par 10 et on positionne notre chiffre
            valeurEntier = valeurEntier * 10 + chiffre;
        }

        return valeurEntier;
    }

    /// <summary>
    /// Permet de convertir un caractère représentant un chiffre en entier
    /// </summary>
    /// <params name="p_chiffre">Caractère à convertir</params>
    /// <returns>L'entier correspondant au chiffre passé en paramètres</returns>
    public static int ConvertirCaractereChiffreEnEntier(char p_chiffre)
    {
        /// On valide ici que nous avons un paramètre qui respecte les hypothèses dans lesquelles notre algorithme peut fonctionner
        if (p_chiffre < '0' || p_chiffre > '9')
        {
            throw new ArgumentOutOfRangeException(nameof(p_chiffre));
        }

        /// On utilise ici les propriétés de la table ASCII :
        ///  - les différents caractères sont codés avec des entiers de 0 à 127
        ///  - les caractères représentants les chiffres sont classés par ordre croissant de 0 à 9
        ///  - ces chiffres sont placés de manière contigue (C'est la même chose pour les lettres de l'alphabet
        /// aussi  bien en minuscule qu'en majuscule)
        /// 
        /// Nous pourrions aussi faire une suite de if (p_chiffre == '0') { valeur = 0; } else if (p_chiffre == '0') {... 
        /// ou un swith (p_chiffre) { case '0' : valeur = 0; break; case '1' : ...}
        return p_chiffre - '0';
    }

    /// <summary>
    /// Si un des caractères n'est pas un chiffre, alors nous renvoyons faux, sinon on renvoie vrai
    /// </summary>
    /// <param name="p_chaine">Chaine de caractères non nulle à valider</param>
    /// <returns>Renvoie vrai si la chaine est constituée seulement de chiffre</returns>
    public static bool EstChaineChiffresSeulement(string p_chaine)
    {
        /// Notre algorithme de validation doit s'assurer que nous 
        if (p_chaine is null)
        {
            throw new ArgumentNullException(nameof(p_chaine));
        }

        /// Au départ, on considère que la chaine est valide pour notre algorithme.
        /// On va parcourir la chaine de caractères et valider que chaque caractère est un chiffre.
        /// Si on trouve un cas où un caractère n'est pas un chiffre, on change notre booléen.
        /// On profite de l'initialisation pour valider que la chaine contient bien au moins un caractère.
        bool estChaineChiffresSeulement = p_chaine != "";
        /// Notez le "&& estChaineChiffresSeulement" dans la condition de la boucle pour sortir dès 
        /// qu'un caractère autre qu'un chiffre est détecté.
        for (int numeroCaractere = 0; numeroCaractere < p_chaine.Length && estChaineChiffresSeulement; numeroCaractere++)
        {
            /// ici nous pourrions écrire estChaineChiffresSeulement = EstChiffre(p_chaine[numeroCaractere]) car
            /// nous sortons de la boucle dès qu'autre chose qu'un chiffre est détecté.
            /// Si la condition ne permettait pas de sortir, l'affectation et le if ne seraient pas équivalent.
            /// Dans ce contexte, je vous conseille d'utiliser un if pour lever toute ambiguité.
            if (!EstChiffre(p_chaine[numeroCaractere]))
            {
                estChaineChiffresSeulement = false;
            }
        }

        return estChaineChiffresSeulement;
    }

    /// <summary>
    /// Valide si un caractère est un chiffre ou non
    /// </summary>
    /// <param name="p_caractere">Caractère à valider comme étant ou non un chiffre</param>
    /// <returns>Renvoie vrai si c'est bien un chiffre, faux sinon</returns>
    public static bool EstChiffre(char p_caractere)
    {
        /// pas besoin de faire de if ici, l'expression est déjà booléenne.
        return (p_caractere >= '0' && p_caractere <= '9');
    }

}