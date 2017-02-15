using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace FluentAssertions.Json.Tests
{
    [TestFixture]
    public class ObjectAssertionsExtensionsTests
    {
        [Test]
        public void SerializableClass_ShouldBeJsonSerializable()
        {
            var obj = new SerializableClass();

            obj.Should().BeJsonSerializable<SerializableClass>();
        }

        [Test]
        public void NotSerializableClass_ShouldNotBeJsonSerializable()
        {
            var notJsonSerializable = new NotJsonSerializable(11);

            Action action = () => notJsonSerializable.Should().BeJsonSerializable<NotJsonSerializable>();

            action.ShouldThrow<AssertionException>()
                .Where(e=>e.Message.Contains(" to be JSON serializable, but serialization failed with:"));
        }

        public class SerializableClass
        {
            public string Name { get; set; }
        }

        public class NotJsonSerializable
        {
            public NotJsonSerializable(int param)
            {
                
            }
        }
    }
}
