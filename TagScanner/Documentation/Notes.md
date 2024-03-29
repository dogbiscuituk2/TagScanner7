# TagScanner Classes - An Overview {#Contents}

## Contents

- <a href="#Model">Model</a>
  - <a href="#Library">Library</a>
  - <a href="#Filter">Filter</a>
- <a href="#Term">_Term (abstract)_</a>
  - <a href="#Constant">Constant</a>
  - <a href="#Field">___Field___</a>
  - <a href="#Parameter">Parameter</a>
  - <a href="#Umptad">_Umptad (abstract)_</a>
  - <a href="#Cast">Cast</a>
  - <a href="#Function">___Function___</a>
  - <a href="#Operation">___Operation___</a>
      - <a href="#MonadicOperation">Monadic Operations _+, -, !_</a>
      - <a href="#DyadicOperation">Dyadic Operations _+, -, *, /, &amp;, |, ^, =, !=, &lt;, &lt;=, &gt;=, &gt;_</a>
      - <a href="#TriadicOperation">Triadic Operation _? :_</a>
- <a href="#Grammar">Grammar</a>
  - <a href="#Tokens">Tokens</a>
  - <a href="#Parser">Parser</a>

## Model {#Model}

The __Model__ class represents the collection of _data items_ (also known as _business objects_) used by the application.

Two important properties of the __Model__ are its __Library__ and __Filter__.

<a href="#Contents">^ Contents</a>

## Library {#Library}

<a href="#Contents">^ Contents</a>

## Filter {#Filter}

The **Filter** class is the receptacle for a collection of **Term** objects, any _one_ of which may be selected to apply to the data. The _ResultType_ of a __Term__ in a __Filter__ must be _bool_.

At runtime, the selected __Term__ is converted to a _Predicate_ and applied to the list of data in the __Model__. If the selected __Term__ returns _true_ for any given item, then the item is displayed normally in the set presented to the user. If it returns _false_, then depending on the currently chosen _Filter Action_, that item will either be grayed out, or entirely hidden.

<a href="#Contents">^ Contents</a>

## Term {#Term}

The __Term__ class is the abstract base of the following hierarchy:

- ___Term__ (abstract)_
  - __Constant__
  - __Field__
  - __Parameter__
  - ___Umptad__ (abstract)_
    - __Cast__
    - __Function__
    - __Operation__

<a href="#Contents">^ Contents</a>

## Constant {#Constant}

The __Constant__ class represents fixed values in expressions. Supported value types are _bool_, _char_, _string_, various numerical integer (_int_, _uint_, _long_, _ulong_) and floating point (_float_, _double_, _decimal_) formats, together with _TimeSpan_ and _DateTime_.

<a href="#Contents">^ Contents</a>

## Field {#Field}

The __Field__ class represents domain item properties. This system was developed primarily to maintain the ID3 tags of a collection of audiovisual media, chiefly MP3 music files, so examples of fields are _Title_, _Duration_, _Album Title_, etc., or file properties such as _File Attributes_, or _File Created_.

Notice that field denotations are permitted to contain spaces and other non-alphanumeric characters.

At runtime, the full list of accessible fields, together with their various metadata, will be assembled from the attributes attached to properties in the _Selection_ class. This is so for historical reasons; the first UI developed for the application used the Winforms PropertyGrid control, which binds to these attributes. The next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#Contents">^ Contents</a>

## Parameter {#Parameter}

The __Parameter__ class is used internally, to provide the default parameter values needed while building expressions manually.

<a href="#Contents">^ Contents</a>

## Umptad {#Umptad}

The oddly named __Umptad__ class is another abstract base, this time for multiterm collections. The name derives from the classification of operators into monadic, dyadic, triadic, tetradic etc. types, based on their number of operands. With some violence to terminology, we might refer to these as Monads, Dyads, Triads, Tetrads, etc.

An operator accepting an indeterminate number of operands can then be said to accept _umpty_ or _umpteen_ of them; hence, an _umptadic_ operator, or _umptad_.

- ___Umptad__ (abstract)_
  - __Cast__
  - __Function__
  - __Operation__

<a href="#Contents">^ Contents</a>

## Cast {#Cast}

The __Cast__ class is the first and simplest __Umptad__ descendant. Taking a single operand, it recasts its ResultType to be some other, compatible new type. For example, the expression

    # Album Artists.Cast(long)

converts the _# Album Artists_ property from a normal integer (System.Int32) to a long one (System.Int64).

<a href="#Contents">^ Contents</a>

## Function {#Function}

The __Function__ rclass epresents a C# method call, taking one __Term__ per required function argument, and returning a new __Term__ whose ResultType matches that method's return type.

Syntactically there are two varieties of __Function__, _static_ and _member_. An example of a _static_ __Function__ is _Compare_:

    Compare(1st Album Artist, "N")

This compares the value of an item's _1st Album Artist_ property to the fixed value _"M"_, and returns a __Constant Term__ representing the usual result of performing a static _Compare_ method between two strings - in this case, indicating whether the artist would appear in the first or second half of a dictionary.

By contrast, an example of a _member_ __Function__ might be

    Album Artists (joined).Contains("Beat")

which, in the case of a Beatles song, would return a __Constant Term__ with a _ResultType_ of _bool_, and a _Value_ of _true_.

The available roster of __Function__s is currently found in the _Methods.cs_ file, though the next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#Contents">^ Contents</a>

## Operation {#Operation}

The __Operation__ class represents a C# operator call, taking one or more __Term__s, applying an __Operator__ to them, and yielding a result __Term__. The currently available set includes monadic and dyadic operators, and one triadic sample. Although several subclasses are provided for various (not all) of the available operations, there are no specific base classes for monadic, dyadic, and triadic types.

The available __Operator__ set is currently found in the _Operators.cs_ file, though the next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#Contents">^ Contents</a>

## Monadic Operations {#MonadicOperation}

The available __Monadic Operator__ set includes _unary plus (+)_, _negative (-)_, and _logical negation (!)_.

- __Operation__
  - __Positive__
  - __Negative__
  - __Negation__

Each of these has its own specialized __Operation__ subclass, (__Positive__, __Negative__ and __Negation__ respectively, although they can equally be instantiated using just the __Operation__ base class, supplying the appropriate __Operator__ symbol.

<a href="#Contents">^ Contents</a>

## Dyadic Operations {#DyadicOperation}

The classes in this category are labelled dyadic, not because they take exactly two operands, but rather because their underlying C# operators are themselves strictly dyadic. However, many of these __Operation__ subclasses can accept any number of operands. This freedom should be used carefully, and only when the precedence & associativity context is clear.

The following is not a complete dyadic __Operation__ list, since several of them, such as the equalities ('=', '!=') and the relationals ('<', '<=', '>=', '>'), don't have their own dedicated subclasses.

- __Operation__
  - __Sum__
  - __Difference__
  - __Product__
  - __Quotient__
  - __Conjunction__
  - __Disjunction__
  - __Concatenation__

For example, the sum of 1+2+3 can be coded as any of the following (click to expand):

    new Sum(new Sum(1, 2), 3) // Nested dyads.

    new Sum(1, new Sum(2, 3)) // Nested dyads.

    new Sum(1, 2, 3) // Effectively triadic or n-adic.

    new Operation('+', 1, 2, 3) // Operation subclasses like Sum are just a coding convenience.

    new Operation(1, '+', 2, 3) // Infix operators can be moved to 2nd position in the parameter list.

Note that implicit type conversion operators are invoked behind the scenes in these examples, to convert the supplied numerical values into the __Constant__ instances expected by an __Operation__, as well as in the last example, converting the '+' character to the required _enum_ value __Op.Add__.

As another example, the removal of the 2-term restriction on these operators makes implementation of a "between" operator easy:

    new Operation('<', 1, 2, 3) // Returns true, since 1 < 2 < 3.

Under the hood, this is implemented as a __Conjunction__ of _1 &lt; 2_ and _2 &lt; 3_.

<a href="#Contents">^ Contents</a>

## Triadic Operation {#TriadicOperation}

The single provided triadic operation is of course the __Conditional__, the expression equivalent of a coding _if-then-else__ construct. Here is an example of its use, first in a coding context, then in a scripting, context:

    var foo = new Conditional(Album Title.Contains("Pepper"), 10, 2); // Returns 10 for "Sgt. Pepper's", or else 2 for any pepperless title.

    Album Title.Contains("Pepper") ? 10 : 2

<a href="#Contents">^ Contents</a>

## Grammar {#Grammar}

<details><summary>The grammar of the TagScanner application's scripting language looks a little bit like this (click <u>here</u> to expand / collapse):</summary>

- __Term:__
  - Cast | Constant | Field | Function | Operation
  - ( Term )

- __Cast:__
  - ( Type ) Term

- __Type:__
  - bool | byte | char | DateTime | decimal | double | float | int | long | object | sbyte | short | string | TimeSpan | uint | ulong | ushort

- __Constant:__
  - Number | Char | String

- __Number:__
  - [-+]?[0-9]+

- __Char:__
  - '([^']|'')'

- __String:__
  - "([^\"]|\.)*"

- __Field:__
  - Album | Album Artists | # Album Artists | ... | Year

- __Function:__
  - StaticFn ( Operands? )
  - Term . MemberFn ( Operands? )

- __MemberFn:__
  - Contains | EndsWith | ... | Uppercase

- __StaticFn:__
  - Compare | Format | ... | Replace$ | ... | Truncate

- __Operands:__
  - Term
  - Term, Operands

- __Operation:__
  - Operator1 Term
  - Term Operator2 Term
  - Term ? Term : Term

- __Operator1:__ _one of_ + - !

- __Operator2:__ _one of_ &amp; | ^ = != &lt; &lt;= &gt; &gt;= + - * /

</details>
<a href="#Contents">^ Contents</a>

## Tokens {#Tokens}

The __Tokens__ class performs the first stage of expression parsing, separating the input character stream into its various recognisable language tokens.

<a href="#Contents">^ Contents</a>

## Parser {#Parser}

The __Parser__ class, leaning heavily on the resources of the __Tokens__ class, performs the difficult part of the process of converting the input character stream into an executable expression.

<a href="#Contents">^ Contents</a>
