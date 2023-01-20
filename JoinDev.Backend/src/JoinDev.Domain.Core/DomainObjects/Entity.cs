﻿using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Domain.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; }
        public DateTime Timestamp { get; }

        private List<Event> _events;
        public IReadOnlyCollection<Event> Events => _events?.AsReadOnly();

        public Entity()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;
        }

        public void AddEvent(Event eventItem)
        {
            _events = _events ?? new List<Event>();
            _events.Add(eventItem);
        }

        public void RemoveEvent(Event eventItem)
        {
            _events?.Remove(eventItem);
        }

        public void ClearEvents()
        {
            _events?.Clear();
        }

        public override bool Equals(object obj)
        {
            var compare = obj as Entity;

            if (ReferenceEquals(this, compare)) return true;
            if (ReferenceEquals(null, compare)) return false;

            return Id.Equals(compare.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 437 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id = {Id}]";
        }
    }
}
