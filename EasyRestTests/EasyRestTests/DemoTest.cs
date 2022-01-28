using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;

namespace Tests
{
    //Автор та опис
    [TestFixture(Author = "unickq", Description = "Examples")]
    //Обов'язково
    [AllureNUnit]
    //Звичайна лінка
    [AllureLink("https://github.com/unickq/allure-nunit")]
    public class DemoTest
    {
        //Метод очістки папки результатів перед черговим запуском тестів
        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        //Allure.Steps required
        [AllureStep("This method is just saying hello")]
        private void SayHello()
        {
            Console.WriteLine("Hello!");
        }

        [Test]
        //Теги
        [AllureTag("NUnit", "Debug")]
        //Лінка на проблему?, 
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        //Важливість
        [AllureSeverity(SeverityLevel.critical)]
        //Назва фічі
        [AllureFeature("Core")]
        public void EvenTest([Range(0, 5)] int value)
        {
            SayHello();

            //Wrapping Step
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.IsTrue(value % 2 == 0, $"Oh no :( {value} % 2 = {value % 2}"); },
                "Validate calculations");
        }
    }
}
