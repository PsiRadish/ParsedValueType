# Parsed\<T\> Structure #

Encapsulation of value-type parsing that mirrors the Nullable\<T\> "interface".

## Usage

Directly assign a [[|T:System.String]] value to a Parsed\<T\> to initiate parsing of the string. If successful, Parsed\<T\>.HasValue will be true and [[|P:Gardiant.CaseManagement.Util.Parsed\<T\>.Value]] will return the parsed [[|!:T]] value. 

## Type Parameters

|Name | Description |
|-----|------|
|T: |Value type to parse to.|

## Properties

### Parsed\<T\>.Input

 Gets or sets the [[|T:System.String]] to be parsed into a \<T\> value. 



---
### Parsed\<T\>.HasValue

 Gets a boolean indicating whether the current Parsed\<T\> object has a valid value of its underlying type. 



---
### Parsed\<T\>.Value

Gets the value of the current Parsed\<T\> object if it has been assigned a valid underlying value or parsable string.

WARNING: Read-only property; using the setter will cause an exception.

[[T:System.InvalidOperationException|T:System.InvalidOperationException]]: The HasValue property is false.

[[T:System.NotSupportedException|T:System.NotSupportedException]]: The property is written to.



---


