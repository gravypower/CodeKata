// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameInverterTestFixture.cs" company="bah">
//   bah
// </copyright>
// <summary>
//   The class 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TDDNameInverter.Date20130612
{
    using NUnit.Framework;

    /// <summary>
    /// The class 1.
    /// </summary>
    [TestFixture]
    public class NameInverterTestFixture
    {

        /// <summary>
        /// The invert name_ given null input_ returns empty string.
        /// </summary>
        [Test]
        public void InvertName_GivenNullInput_ReturnsEmptyString()
        {
            // Arrange
            string name = null;

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void InvertName_GivenSimpleName_ReturnsSimpleName()
        {
            // Arrange
            var name = "name";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual(name, result);
        }

        [Test]
        public void InvertName_GivenName_InvertedName()
        {
            // Arrange
            var name = "First Last";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Last, First", result);
        }

        [Test]
        public void InvertName_GiveNameWithLeadingSpaces_InvertedName()
        {
            // Arrange
            var name = "  First Last";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Last, First", result);
        }

        [Test]
        public void InvertName_GivenTrailingSpaces_InvertedName()
        {
            // Arrange
            var name = "First Last  ";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Last, First", result);
        }

        [Test]
        public void InvertName_GivenManySplitingSpaces_InvertedName()
        {
            // Arrange
            var name = "First  Last";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Last, First", result);
        }

        [TestCase("Mr.")]
        [TestCase("Miss.")]
        [TestCase("Ms.")]
        [TestCase("Mrs.")]
        public void InvertName_GivenMsHonorific_InvertedNameWithHonorific(string honorific)
        {
            // Arrange
            var name = honorific + " First  Last";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual(honorific + " Last, First", result);
        }

        [Test]
        public void InvertName_GivenOnePostNominal_InvertedNameWithPostNominal()
        {
            // Arrange
            var name = "First  Last MD.";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Last, First MD.", result);
        }

        [Test]
        public void InvertName_GivenManeyPostNominals_InvertedNameWithPostNominals()
        {
            // Arrange
            var name = "First  Last MD. PHD.";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Last, First MD. PHD.", result);
        }

        [Test]
        public void InvertName_GivenOnePostNominalAndHonorific_InvertName_GivenOnePostNominal_InvertedNameWithPostNominalAndHonorific()
        {
            // Arrange
            var name = "Mr. First  Last MD.";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Mr. Last, First MD.", result);
        }

        [Test]
        public void InvertName_GivenOnePostNominalAndHonorific_InvertedNameWithPostNominalsAndHonorific()
        {
            // Arrange
            var name = "Mr. First  Last MD. PHD.";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Mr. Last, First MD. PHD.", result);
        }

        [Test]
        public void InvertName_GivenHonorificAndSimpleName_SimpleInvertedNameWithHonorific()
        {
            // Arrange
            var name = "Mr. First";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Mr. First", result);
        }

        [Test]
        public void InvertName_GivenOnePostNominalAndHonorificAndSimpleName_SimpleInvertedNameWithPostNominalsAndHonorific()
        {
            // Arrange
            var name = "Mr. First MD. PHD.";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Mr. First MD. PHD.", result);
        }

        [Test]
        public void InvertName_IncludeMiddelName_InvertedNameWithMiddelName()
        {
            // Arrange
            var name = "First Middel Last";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Last, First Middel", result);
        }

        [Test]
        public void InvertName_IncludeManyMiddelName_InvertedNameWithManyMiddelName()
        {
            // Arrange
            var name = "First Middel Middel1 Last";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Last, First Middel Middel1", result);
        }

        [Test]
        public void InvertName_IncludeHonorificAndMiddelName_InvertedNameWithHonorificAndMiddelName()
        {
            // Arrange
            var name = "Mr. First Middel Last";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Mr. Last, First Middel", result);
        }

        [Test]
        public void InvertName_IncludePostNominalsAndMiddelName_InvertedNameWithPostNominalsAndMiddelName()
        {
            // Arrange
            var name = "First Middel Last PHD.";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Last, First Middel PHD.", result);
        }

        [Test]
        public void InvertName_IncludeHonorificAndPostNominalsAndMiddelName_InvertedNameWithHonorificAndPostNominalsAndMiddelName()
        {
            // Arrange
            var name = "Mr. First Middel Last PHD.";

            // Act
            var result = NameInverter.InvertName(name);

            // Assert
            Assert.AreEqual("Mr. Last, First Middel PHD.", result);
        }
    }
}
