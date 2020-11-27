using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using CSharpFunctionalExtensions;

namespace FinestSolutions.DomainDrivenDesign.Abstractions.Identifiers.Guid
{
    public abstract class Identifier : ValueObject, IComparable
    {
        public System.Guid Value { get; private set; }

        protected Identifier(System.Guid value) => Value = value;

        public static implicit operator System.Guid(Identifier id) => id.Value;

        public override string ToString() => Value.ToString();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public new int CompareTo(object obj)
        {
            if (!(obj is Identifier identifier))
            {
                throw new ArgumentException($"{obj.GetType()} is not type {GetType()}");
            }

            return Value.CompareTo(identifier.Value);
        }

        public static TIdentifier New<TIdentifier>(System.Guid value) where TIdentifier : Identifier =>
            Activator.CreateInstance(
                type: typeof(TIdentifier),
                bindingAttr: BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                binder: null,
                args: new object[] {value},
                culture: CultureInfo.InvariantCulture,
                activationAttributes: null) as TIdentifier;
    }
}