# TagScanner - A Code Overview {#Contents}

This document presents brief desciptions of the most important classes and other design elements of the TagScanner application.

## Contents

- <a href="#Model">Model</a>
  - <a href="#Library">Library</a>
  - <a href="#Filter">Filter</a>
  - <a href="#Tags">Tags</a>
  -  <a href="IWork">IWork _(interface)_</a>
      - <a href="#Work">Work</a>
      - <a href="#Selection">Selection</a>
- <a href="#Term">_Term (abstract)_</a>
  - <a href="#Constant">Constant</a>
  - <a href="#Field">Field</a>
  - <a href="#Parameter">Parameter</a>
  - <a href="#Umptad">_Umptad (abstract)_</a>
  - <a href="#Cast">Cast</a>
  - <a href="#Function">Function</a>
  - <a href="#Operation">Operation</a>
      - <a href="#MonadicOperation">Monadic Operation _+, -, !_</a>
      - <a href="#DyadicOperation">Dyadic Operation _+, -, *, /, &amp;, |, \^, =, !=, &lt;, &lt;=, &gt;=, &gt;_</a>
      - <a href="#TriadicOperation">Triadic Operation _? :_</a>
- <a href="#Grammar">Grammar</a>
  - <a href="#Tokens">Tokens</a>
  - <a href="#Parser">Parser</a>
- <a href="#DevCheatSheet">Development Cheat Sheet</a>
  - <a href="#CheatSheetTags">Tags</a>
  - <a href="#CheatSheetFields">Fields</a>
  - <a href="#CheatSheetFunctions">Functions</a>
  - <a href="#CheatSheetOperations">Operations</a>

## Model {#Model}

The __Model__ class represents the collection of _data items_ (also known as _business objects_) used by the application.

Two important properties of the __Model__ are its __Library__ and __Filter__.

<a href="#Contents">\^Contents</a>

## Library {#Library}

<a href="#Contents">\^Contents</a>

## Filter {#Filter}

The **Filter** class is the receptacle for a collection of **Term** objects, any _one_ of which may be selected to apply to the data. The _ResultType_ of a __Term__ in a __Filter__ must be _bool_.

At runtime, the selected __Term__ is converted to a _Predicate_ and applied to the list of data in the __Model__. If the selected __Term__ returns _true_ for any given item, then the item is displayed normally in the set presented to the user. If it returns _false_, then depending on the currently chosen _Filter Action_, that item will either be grayed out, or entirely hidden.

<a href="#Contents">\^Contents</a>

## Tags {#Tags}

<a href="#Contents">\^Contents</a>

## IWork {#IWork}

<a href="#Contents">\^Contents</a>

## Work {#Work}

<a href="#Contents">\^Contents</a>

## Selection {#Selection}

<a href="#Contents">\^Contents</a>

## Term {#Term}

The __Term__ class is the abstract base of the following hierarchy:

- ___Term__ (abstract)_
  - <a href="#Constant">__Constant__</a>
  - <a href="#Field">__Field__</a>
  - <a href="#Parameter">__Parameter__</a>
  - <a href="#Umptad">___Umptad__ (abstract)_</a>
    - <a href="#Cast">__Cast__</a>
    - <a href="#Function">__Function__</a>
    - <a href="#Operation">__Operation__</a>

These and several other related classes and types are grouped together under the _TagScanner.Terms_ namespace, distinct from the _TagScanner.Models_ namespace in general use up to this point in the document.

<a href="#Contents">\^Contents</a>

## Constant {#Constant}

The __Constant__ class represents fixed values in expressions. Supported value types are _bool_, _char_, _string_, various numerical integer (_int_, _uint_, _long_, _ulong_) and floating point (_float_, _double_, _decimal_) formats, together with _TimeSpan_ and _DateTime_.

<a href="#Contents">\^Contents</a> <a href="#Term">\^Term</a>

## Field {#Field}

The __Field__ class represents domain item properties. This system was developed primarily to maintain the ID3 tags of a collection of audiovisual media, chiefly MP3 music files, so examples of fields are _Title_, _Duration_, _Album Title_, etc., or file properties such as _File Attributes_, or _File Created_.

Notice that field denotations are permitted to contain spaces and other non-alphanumeric characters.

At runtime, the full list of accessible fields, together with their various metadata, will be assembled from the attributes attached to properties in the _Selection_ class. This is so for historical reasons; the first UI developed for the application used the Winforms PropertyGrid control, which binds to these attributes. The next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#Contents">\^Contents</a> <a href="#Term">\^Term</a>

## Parameter {#Parameter}

The __Parameter__ class is used internally, to provide the default parameter values needed while building expressions manually.

<a href="#Contents">\^Contents</a> <a href="#Term">\^Term</a>

## Umptad {#Umptad}

The oddly named __Umptad__ class is another abstract base, this time for multiterm collections. The name derives from the classification of operators into monadic, dyadic, triadic, tetradic etc. types, based on their number of operands. With some violence to terminology, we might refer to these as Monads, Dyads, Triads, Tetrads, etc.

An operator accepting an indeterminate number of operands can then be said to accept _umpty_ or _umpteen_ of them; hence, an _umptadic_ operator, or _umptad_.

- ___Umptad__ (abstract)_
  - <a href="#Cast">__Cast__</a>
  - <a href="#Function">__Function__</a>
  - <a href="#Operation">__Operation__</a>

<a href="#Contents">\^Contents</a> <a href="#Term">\^Term</a> <a href="#Umptad">\^Umptad</a>

## Cast {#Cast}

The __Cast__ class is the first and simplest __Umptad__ descendant. Taking a single operand, it recasts its ResultType to be some other, compatible new type. For example, the expression

    # Album Artists.Cast(long)

converts the _# Album Artists_ property from a normal integer (System.Int32) to a long one (System.Int64).

<a href="#Contents">\^Contents</a> <a href="#Term">\^Term</a> <a href="#Umptad">\^Umptad</a>

## Function {#Function}

The __Function__ rclass epresents a C# method call, taking one __Term__ per required function argument, and returning a new __Term__ whose ResultType matches that method's return type.

Syntactically there are two varieties of __Function__, _static_ and _member_. An example of a _static_ __Function__ is _Compare_:

    Compare(1st Album Artist, "N")

This compares the value of an item's _1st Album Artist_ property to the fixed value _"M"_, and returns a __Constant Term__ representing the usual result of performing a static _Compare_ method between two strings - in this case, indicating whether the artist would appear in the first or second half of a dictionary.

By contrast, an example of a _member_ __Function__ might be

    Album Artists (joined).Contains("Beat")

which, in the case of a Beatles song, would return a __Constant Term__ with a _ResultType_ of _bool_, and a _Value_ of _true_.

The available roster of __Function__s is currently found in the _Methods.cs_ file, though the next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#Contents">\^Contents</a> <a href="#Term">\^Term</a> <a href="#Umptad">\^Umptad</a>

## Operation {#Operation}

The __Operation__ class represents a C# operator call, taking one or more __Term__s, applying an __Operator__ to them, and yielding a result __Term__. The currently available set includes monadic and dyadic operators, and one triadic sample. Although several subclasses are provided for various (not all) of the available operations, there are no specific base classes for monadic, dyadic, and triadic types.

The available __Operator__ set is currently found in the _Operators.cs_ file, though the next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#Contents">\^Contents</a> <a href="#Term">\^Term</a> <a href="#Umptad">\^Umptad</a>

## Monadic Operation {#MonadicOperation}

The available __Monadic Operator__ set includes _unary plus (+)_, _negative (-)_, and _logical negation (!)_.

- __Operation__
  - __Positive__
  - __Negative__
  - __Negation__

Each of these has its own specialized __Operation__ subclass, (__Positive__, __Negative__ and __Negation__ respectively, although they can equally be instantiated using just the __Operation__ base class, supplying the appropriate __Operator__ symbol.

<a href="#Contents">\^Contents</a> <a href="#Term">\^Term</a> <a href="#Umptad">\^Umptad</a> <a href="#Operation">\^Operation</a>

## Dyadic Operation {#DyadicOperation}

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

<a href="#Contents">\^Contents</a> <a href="#Term">\^Term</a> <a href="#Umptad">\^Umptad</a> <a href="#Operation">\^Operation</a>

## Triadic Operation {#TriadicOperation}

The single provided triadic operation is of course the __Conditional__, the expression equivalent of a coding _if-then-else__ construct. Here is an example of its use, first in a coding context, then in a scripting, context:

    var foo = new Conditional(Album Title.Contains("Pepper"), 10, 2); // Returns 10 for "Sgt. Pepper's", or else 2 for any pepperless title.

    Album Title.Contains("Pepper") ? 10 : 2

<a href="#Contents">\^Contents</a> <a href="#Term">\^Term</a> <a href="#Umptad">\^Umptad</a> <a href="#Operation">\^Operation</a>

## Grammar {#Grammar}

<details><summary>The grammar of the TagScanner application's scripting language looks a little bit like this <i>(<u>click here</u> to expand / collapse):</i></summary>

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
  - '([\^']|'')'

- __String:__
  - "([\^\"]|\.)*"

- __Field:__
  - Album | Album Artists | # Album Artists | ... | Year

- __Function:__
  - StaticFunction ( TermList? )
  - Term . MemberFunction ( TermList? )

- __MemberFunction:__
  - Contains | EndsWith | ... | Uppercase

- __StaticFunction:__
  - Compare | Format | ... | Replace$ | ... | Truncate

- __TermList:__
  - Term
  - Term , TermList

- __Operation:__
  - Operator1 Term
  - Term Operator2 Term
  - Term ? Term : Term

- __Operator1:__ _one of_ + - !

- __Operator2:__ _one of_ &amp; | \^ = != &lt; &lt;= &gt; &gt;= + - * /

</details>
<a href="#Contents">\^Contents</a>

## Tokens {#Tokens}

The __Tokens__ class performs the first stage of expression parsing, separating the input character stream into its various recognisable language tokens.

<a href="#Contents">\^Contents</a>

## Parser {#Parser}

The __Parser__ class, leaning heavily on the resources of the __Tokens__ class, performs the difficult part of the process of converting the input character stream into an executable expression.

<a href="#Contents">\^Contents</a>

## Development Cheat Sheet {#DevCheatSheet}

__Tags__ {#CheatSheetTags}

- This application uses the _TagLib#_ library to access (both read and write) metadata in media files, including video, audio, and photo formats.
- In the _TagLib#_ library source code and API, the term _Tag_ refers to a structure containing most of the metadata for the given media.
- By contrast, the term _Tag_ in this application means any single item of metadata from that structure, e.g. work title, performer, duration, etc.
- These _Tags_ have in turn their own metadata, indicating for example their runtime type, category, and so on.
- Such _meta-metadata_ can be found in the _TagScanner.Models.TagInfo_ class _(TagInfo.cs)_.
- In the application source code, __Tag__ values are introduced in the _TagScanner.Models.Tag_ enumeration _(Tags.cs)_.
- __Tag__ data types and read/write permissions are best summarised in the _TagScanner.Models.IWork_ interface _(IWork.cs)_.
- The set of possible __Tag__ data type names is supplied by the static _TagScanner.Models.TagType_ class _(TagType.cs)_.
- This interface is implemented by two classes in the _TagScanner.Models_ namespace: _Work (Work.cs)_ and _Selection (Selection.cs)_.
- The code level name of a __Tag__ is not exposed in the app UI, nor in the scripting interface. Instead, its _DisplayText_ value is used throughout.
- For historical reasons, these values appear as attributes on corresponding properties of the _TagScanner.Models.Selection_ class _(Selection.cs)_.
- To see all __Tag__ _DisplayText_ values: (1) run the app, (2) right-click _Select Columns_ or _Select Tags_, then (3) choose _List | Names only_.

<a href="#Contents">\^Contents</a>

__Fields__ {#CheatSheetFields}

- Available __Field__ instances are defined by a _Dictionary<Tag, TagInfo>_ called _TagDictionary_ in the static class _TagScanner.Terms.Tags_.
- The dictionary exposes two arrays as properties of this static class: _Tag[] Keys_, and _TagInfo[] Values_.
- You may use the extension method _TagInfo(this Tag tag)_ toaccess the __Field__ metadata for a given _tag_:

      var tagInfo = tag.TagInfo();

- However, further extension methods are provided to access any other TagInfo member, given just the _tag_:

      var category = tag.Category();
      var column = tag.Column(); // Width, Alignment & editor type (Text or CheckBox).
      var displayName = tag.DisplayName();

<a href="#Contents">\^Contents</a>

__Functions__ {#CheatSheetFunctions}

- Available __Function__ instances are defined by a _Dictionary<string, MethodInfo>_ called _MethodDictionary_ in the static class _TagScanner.Terms.Methods_.
- The dictionary exposes two arrays as properties of this static class: _string[] Keys_, and _MethodInfo[] Values_.
- You may use the extension method _Methods.MethodInfo(this string key)_ to access the __Function__ metadata for a given _key_:

      var methodInfo = key.MethodInfo();

- If the _key_ contains an underscore, e.g. _Concat\_2_, _Concat\_3_, _Concat\_4_, the associated __Function__ is not displayed in the application UI.
- If the _key_ ends in a dollar sign, e.g. _Match$_, _Replace$_, the underlying method is a member of static class _Regex_.

<a href="#Contents">\^Contents</a>

__Operations__ {#CheatSheetOperations}

- Available __Operation__ instances are defined by a _Dictionary<Op, OpInfo>_ called _OperatorDictionary_ in the static class _TagScanner.Terms.Operators_.
- The dictionary exposes two arrays as properties of this static class: _Op[] Keys_, and _OpInfo[] Values_.
- You may use the extension method _Operators.OpInfo(this string key)_ to access the __Operation__ metadata for a given operator _op_:

      var opInfo = op.OpInfo();

<a href="#Contents">\^Contents</a>
