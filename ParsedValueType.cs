using System;
using System.ComponentModel;

namespace ParsedValueType
{
    /// <summary>
    /// <para>Encapsulation of value-type parsing that mirrors the <see cref="Nullable{T}"/> "interface".</para>
    /// <para>
    /// Directly assign a <see cref="string"/> value to a <see cref="Parsed{T}"/> to initiate parsing of the string.
    /// If successful, <see cref="HasValue"/> will be true and <see cref="Value"/> will return the parsed <see cref="T"/> value.
    /// </para>
    /// </summary>
    /// <typeparam name="T">Value type to parse to.</typeparam>
    [Serializable]
    public struct Parsed<T> : IComparable<Parsed<T>> where T: struct // constrain to value type
    {
        private static TypeConverter _converter = TypeDescriptor.GetConverter(typeof(T));
        
        public Parsed(string input) : this()
        {
            this.Input = input;
        }
        public Parsed(T value) : this()
        {
            _nullable = value;
            _input = null;
        }
        public Parsed(T? nullableValue) : this()
        {
            _nullable = nullableValue;
            _input = null;
        }
        
        // Don't work in LINQ to Entities, alas...
        public static implicit operator Parsed<T>(string input)
        {
            return new Parsed<T>(input);
        }
        public static implicit operator Parsed<T>(T value)
        {
            return new Parsed<T>(value);
        }
        public static implicit operator Parsed<T>(T? nullableValue)
        {
            return new Parsed<T>(nullableValue);
        }
        public static implicit operator T?(Parsed<T> parsed)
        {
            return parsed._nullable;
        }
        
        public static bool operator ==(Parsed<T> a, Parsed<T> b)
        {
            return a._nullable.Equals(b._nullable);
        }
        public static bool operator !=(Parsed<T> a, Parsed<T> b)
        {
            return !a._nullable.Equals(b._nullable);
        }
        public static bool operator ==(Parsed<T> a, T? b)
        {
            return a._nullable.Equals(b);
        }
        public static bool operator !=(Parsed<T> a, T? b)
        {
            return !a._nullable.Equals(b);
        }
        public static bool operator ==(T? a, Parsed<T> b)
        {
            return a.Equals(b._nullable);
        }
        public static bool operator !=(T? a, Parsed<T> b)
        {
            return !a.Equals(b._nullable);
        }
        // warnings if these aren't overridden; just pass the buck to Nullable<T>
        public override bool Equals(object obj)
        {
            return _nullable.Equals(obj);
        }
        public override int GetHashCode()
        {
            return _nullable.GetHashCode();
        }
        
        // Implement the CompareTo method for IComparable
        public int CompareTo(Parsed<T> other)
        {
            return Nullable.Compare(this._nullable, other._nullable);
        }
        
        
        private T? _nullable;
        
        /// <summary>
        /// Gets the value of the current <see cref="Parsed{T}"/> object if it has been assigned a valid underlying value or parsable string.
        /// </summary>
        /// <exception cref="InvalidOperationException">The HasValue property is false.</exception>
        public T Value
        {
            get
            {
                return _nullable.Value;
            }
        }
        
        /// <summary>
        /// Gets a boolean indicating whether the current <see cref="Parsed{T}"/> object has a valid value of its underlying type.
        /// </summary>
        public bool HasValue
        {
            get
            {
                return _nullable.HasValue;
            }
        }
        
        
        private string _input;
        
        /// <summary>
        /// Gets or sets the <see cref="string"/> to be parsed into a <see cref="{T}"/> value.
        /// </summary>
        public string Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
                
                if (value == null)
                {
                    _nullable = null;
                    return;
                }
                
                if (_converter.IsValid(value))
                {
                    _nullable = (T)_converter.ConvertFromString(value);
                }
                else
                    _nullable = null;
            }
        }
        
        public override string ToString()
        {
            if (_nullable.HasValue)
            {
                return _nullable.ToString();
            }
            else if (_input != null)
            {
                return String.Format(_QuoteString, _input);
            }
            else
                return _StrNull;
        }
        
        private static string _QuoteString = "\"{0}\"";
        private static string _StrNull = "<null>";
    }
}
