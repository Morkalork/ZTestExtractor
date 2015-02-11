using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Repositories.System;

namespace ZTestExtractor.Data.Test.Repositories.System
{
    [TestFixture]
    public class FileRepositoryTest
    {
        internal class TestModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public override bool Equals(object obj)
            {
                TestModel model = obj as TestModel;
                if(model == null)
                {
                    return false;
                }

                return this.Id.Equals(model.Id);
            }

            public override int GetHashCode()
            {
                return this.Id.GetHashCode();
            }
        }

        private IList<string> filesSaved = new List<string>();

        [TearDown]
        public void RemoveAllCreatedFiles()
        {
            foreach (var file in filesSaved)
            {
                File.Delete(file);
            }
        }

        [Test]
        public void SaveToFileThrowsOnInvalidFileName()
        {
            var repository = new FileRepository();

            Assert.Throws<ArgumentNullException>(() => repository.SaveModelToFile(new TestModel(), null));
        }

        [Test]
        public void SaveToFileWritesFile()
        {
            var repository = new FileRepository();

            var model = new TestModel();
            string fileName = "TestModelStorage.test";

            repository.SaveModelToFile(model, fileName);
            filesSaved.Add(fileName);

            Assert.That(File.Exists(fileName), Is.True);
        }

        [Test]
        public void LoadModelFromFileThrowsOnInvalidFileName()
        {
            var repository = new FileRepository();

            Assert.Throws<ArgumentNullException>(() => repository.LoadModelFromFile<TestModel>(null));
        }

        [Test]
        public void LoadModelWithNoFileReturnsNull()
        {
            var repository = new FileRepository();

            string fileName = "TestModelStorage.test";

            var storedModel = repository.LoadModelFromFile<TestModel>(fileName);

            Assert.That(storedModel, Is.Null);
        }

        [Test]
        public void LoadModelReturnsCorrectModel()
        {
            var repository = new FileRepository();

            var model = new TestModel();
            string fileName = "TestModelStorage.test";

            repository.SaveModelToFile(model, fileName);
            filesSaved.Add(fileName);

            var storedModel = repository.LoadModelFromFile<TestModel>(fileName);

            Assert.That(storedModel, Is.Not.Null);
            Assert.That(storedModel, Is.EqualTo(model));
        }
    }
}
