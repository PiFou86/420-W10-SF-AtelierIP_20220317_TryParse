using Xunit;
using AtelierIP_20220317_TryParse;
using System;

namespace AtelierIP_20220317_TryParse.Tests
{
    public class ProgramTests
    {
        #region "Tests de EstChiffre"
        [Theory]
        [InlineData('0', true)]
        [InlineData('1', true)]
        [InlineData('2', true)]
        [InlineData('3', true)]
        [InlineData('8', true)]
        [InlineData('9', true)]
        [InlineData('a', false)]
        [InlineData(' ', false)]
        public void EstChiffre_CaracteresVaries_ResOk(char p_caractereATester, bool p_estChiffreAttendu)
        {
            // Arrange

            // Act
            bool estChiffre = Program.EstChiffre(p_caractereATester);

            // Assert
            Assert.Equal(p_estChiffreAttendu, estChiffre);
        }
        #endregion

        #region "Tests de EstChaineChiffresSeulement"
        [Fact]
        public void EstChaineChiffresSeulement_ChaineNulle_Erreur()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => Program.EstChaineChiffresSeulement(null));
        }

        [Theory]
        [InlineData("0", true)]
        [InlineData("1", true)]
        [InlineData("123", true)]
        [InlineData("-1", false)]
        [InlineData("", false)]
        [InlineData(" 1", false)]
        [InlineData("1 ", false)]
        [InlineData("1.0", false)]
        [InlineData("1a", false)]
        public void EstChaineChiffresSeulement_CaracteresVaries_ResOk(string p_chaineAAnalyser, bool p_estChaineCorrect)
        {
            // Arrange

            // Act
            bool estChaineChiffresSeulement = Program.EstChaineChiffresSeulement(p_chaineAAnalyser);

            // Assert
            Assert.Equal(p_estChaineCorrect, estChaineChiffresSeulement);
        }
        #endregion

        #region "Tests de ConvertirChaineEntierPositifEnEntier"
        [Fact]
        public void ConvertirChaineEntierPositifEnEntier_ChaineNulle_Erreur()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Program.ConvertirChaineEntierPositifEnEntier(null));
        }

        [Theory]
        [InlineData(" 0")]
        [InlineData("0 ")]
        [InlineData("abc")]
        [InlineData("")]
        public void ConvertirChaineEntierPositifEnEntier_ChaineNonEntierPositif_Erreur(string p_mauvaiseChaine)
        {
            // Arrange

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Program.ConvertirChaineEntierPositifEnEntier(p_mauvaiseChaine));
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("123", 123)]
        public void ConvertirChaineEntierPositifEnEntier_ChainesNombresVaries_ResOk(string p_chaineAAnalyser, int p_nombreAttendu)
        {
            // Arrange

            // Act
            int nombreCalcule = Program.ConvertirChaineEntierPositifEnEntier(p_chaineAAnalyser);

            // Assert
            Assert.Equal(p_nombreAttendu, nombreCalcule);
        }
        #endregion

        #region "Tests de ConvertirCaractereChiffreEnEntier"
        [Fact]
        public void ConvertirCaractereChiffreEnEntier_CaractereNonChiffre_Erreur()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Program.ConvertirCaractereChiffreEnEntier('a'));
        }

        [Theory]
        [InlineData('0', 0)]
        [InlineData('1', 1)]
        [InlineData('9', 9)]
        public void ConvertirCaractereChiffreEnEntier_CaracteresVaries_ResOk(char p_caractereAConvertir, int p_nombreAttendu)
        {
            // Arrange

            // Act
            int nombreCalcule = Program.ConvertirCaractereChiffreEnEntier(p_caractereAConvertir);

            // Assert
            Assert.Equal(p_nombreAttendu, nombreCalcule);
        }
        #endregion

    }
}