﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Business.Managers.Configurations;
using ZTestExtractor.Core.Models.Configurations;

namespace ZTestExtractor.Business.Test.Managers.Configurations
{
    [TestFixture]
    public class DatabaseConfigurationManagerTest
    {
        [TearDown]
        public void RemoveSavedConfigurationFile()
        {
            if (File.Exists(DatabaseConfigurationModel.FileName))
            {
                File.Delete(DatabaseConfigurationModel.FileName);
            }
        }

        [Test]
        public void SaveThrowsOnNullModel()
        {
            var manager = new DatabaseConfigurationManager();

            Assert.Throws<ArgumentNullException>(() => manager.Save(null));
        }

        [Test]
        public void SaveReturnFalseResultOnNullServerName()
        {
            var manager = new DatabaseConfigurationManager();

            var result = manager.Save(new DatabaseConfigurationModel());

            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void SaveReturnFalseResultOnNullDatabaseName()
        {
            var manager = new DatabaseConfigurationManager();

            var model = new DatabaseConfigurationModel
            {
                ServerName = "Foo"
            };

            var result = manager.Save(model);

            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void SaveReturnFalseResultOnNullUsername()
        {
            var manager = new DatabaseConfigurationManager();

            var model = new DatabaseConfigurationModel
            {
                ServerName = "Foo",
                DatabaseName = "Bar"
            };

            var result = manager.Save(model);

            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void SaveReturnFalseResultOnUnknownDatabase()
        {
            var manager = new DatabaseConfigurationManager();

            var model = new DatabaseConfigurationModel
            {
                ServerName = "Foo",
                DatabaseName = "Bar",
                Username = "Biz",
                Password = "Hemligt"
            };

            var result = manager.Save(model);

            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void SaveReturnSuccessfullySavesDatabaseFile()
        {
            var manager = new DatabaseConfigurationManager();

            var model = new DatabaseConfigurationModel
            {
                ServerName = "Foo",
                DatabaseName = "Bar",
                Username = "Biz",
                Password = "Hemligt",
                DatabaseSystem = DatabaseSystems.MySql
            };

            var result = manager.Save(model);

            Assert.That(result.IsSuccess, Is.True);
        }

        [Test]
        public void LoadNonExistantFileDoesNotReturnNull()
        {
            var manager = new DatabaseConfigurationManager();

            var model = manager.Load();

            Assert.That(model, Is.Not.Null);
        }

        [Test]
        public void LoadExistingFileReturnsCorrectModel()
        {
            var manager = new DatabaseConfigurationManager();

            var model = new DatabaseConfigurationModel
            {
                ServerName = "Foo",
                DatabaseName = "Bar",
                Username = "Biz",
                Password = "Hemligt",
                DatabaseSystem = DatabaseSystems.MySql
            };

            manager.Save(model);

            var fetchedModel = manager.Load();

            Assert.That(fetchedModel, Is.Not.Null);
            Assert.That(fetchedModel, Is.EqualTo(model));
        }
    }
}
