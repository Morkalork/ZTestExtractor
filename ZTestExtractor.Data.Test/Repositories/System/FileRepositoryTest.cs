using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Repositories.System;

namespace ZTestExtractor.Data.Test.Repositories.System
{
    [TestFixture]
    public class FileRepositoryTest
    {
        internal class TestModel
        {
            public string Property1 { get; set; }

            public int Property2 { get; set; }
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

            Assert.That(File.Exists(fileName), Is.True);

            File.Delete(fileName);
        }
    }
}
