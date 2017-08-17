# Parsed\<T\> Structure #

Encapsulation of value-type parsing that mirrors the [Nullable\<T\>](https://msdn.microsoft.com/en-us/library/b3h38hb0.aspx) "interface".  
  
Directly assign a [System.String](https://msdn.microsoft.com/en-us/library/system.string.aspx) value to a Parsed\<T\> to initiate parsing of the string. If successful, Parsed\<T\>.HasValue will be `true` and Parsed\<T\>.Value will return the parsed T value. 


## Syntax
```cs
[Serializable]
public struct Parsed<T> : IComparable<Parsed<T>>
where T: struct
```
#### Type Parameters
<dl>
  <dt>T</dt>
  <dd>The underlying value type to parse to.</dd>
</dl>


## Properties

### Parsed\<T\>.Input
Type: [System.String](https://msdn.microsoft.com/en-us/library/system.string.aspx)  
Gets or sets the string to be parsed into a \<T\> value.

### Parsed\<T\>.HasValue
Type: [System.Boolean](https://msdn.microsoft.com/en-us/library/system.boolean.aspx)  
Gets a value indicating whether the current Parsed\<T\> object has a valid value of its underlying type.

### Parsed\<T\>.Value
Type: T  
Gets the value of the current Parsed\<T\> object if it has been assigned a valid underlying value or parsable string.
#### Exceptions
| Name | Condition |
| --- | --- |
| [InvalidOperationException](https://msdn.microsoft.com/en-us/library/system.invalidoperationexception.aspx) | The HasValue property is false. |
