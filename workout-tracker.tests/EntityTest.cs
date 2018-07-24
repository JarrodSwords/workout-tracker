using System;
using Xunit;
using workout_tracker.domain;
using FluentAssertions;
using Moq;

namespace workout_tracker.tests
{
    public class EntityTest
    {
        private Entity CreateEntity()
        {
            var mock = new Mock<Entity> { CallBase = true };

            return mock.Object;
        }

        private void SetId(ref Entity entity, long id) {
            (entity.GetType())
            .GetProperty("Id")
            .SetValue(entity, id);
        }

        [Fact]
        public void Equals_WithSameReference_ReturnsTrue()
        {
            var entity = CreateEntity();
            var compareToEntity = entity;

            var result = entity.Equals(compareToEntity);

            result.Should().BeTrue();
        }

        public class Subclass : Entity {}

        [Fact]
        public void Equals_WithDifferentSubclass_ReturnsFalse()
        {
            var entity = CreateEntity();
            var mock = new Mock<Subclass> { CallBase = true };
            var compareToEntity = mock.Object;

            var result = entity.Equals(compareToEntity);

            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WithNonEntity_ReturnsFalse()
        {
            var entity = CreateEntity();
            var compareToEntity = new Object();

            var result = entity.Equals(compareToEntity);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(1)]
        public void Equals_WithSameId_ReturnsTrue(long id)
        {
            var entity = CreateEntity();
            SetId(ref entity, id);
            var compareToEntity = CreateEntity();
            SetId(ref compareToEntity, id);

            var result = entity.Equals(compareToEntity);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        public void Equals_WithDifferentId_ReturnsTrue(long entityId, long compareToEntityId)
        {
            var entity = CreateEntity();
            SetId(ref entity, entityId);
            var compareToEntity = CreateEntity();
            SetId(ref compareToEntity, compareToEntityId);

            var result = entity.Equals(compareToEntity);

            result.Should().BeFalse();
        }

        [Fact]
        public void EqualOperator_WithOneNull_ReturnsFalse()
        {
            var entity = CreateEntity();

            var result = entity == (Entity)null;
            var result2 = (Entity)null == entity;

            result.Should().BeFalse();
            result2.Should().BeFalse();
        }

        [Fact]
        public void EqualOperator_WithBothNull_ReturnsTrue()
        {
            var entity = CreateEntity();

            var result = (Entity)null == (Entity)null;

            result.Should().BeTrue();
        }
    }
}
