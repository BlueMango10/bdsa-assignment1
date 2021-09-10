Answers
===
Generics
---
* The first method has no constraints on `U`, but `T` has to implement `IComparable<T>`.
* The second methods needs `U` to implement `IComparable<U>` and `T` needs to derive from *or* be the same type as `T`.
