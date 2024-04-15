# TagScanner - A Code Overview {#contents}

TagScanner gathers ID3 tags and other available metadata from suitable files, e.g. MP3s, and stores them in a library file. Loaded metadata are editable, and when the library file is re-saved, these edits can optionally be applied to the relevant media files.

There is a query builder allowing the construction of complex filters based on all metadata properties, and a Find/Replace function which operates across multiple tags and optionally uses Regex. The app is WinForms based, but uses embedded WPF grids to take advantage of their (free!) filtering, sorting & grouping operations.

This document presents brief desciptions of the most important classes and other design elements of the TagScanner application.

    When an edit is made to one or more Work items in the PropertyGrid editor, its Edit event is invoked:-
     \
      Work.Set<T>() -> Work.OnEdit() -> Work.Edit.Invoke() -> Model.Work_Edit() -> Model.WorkEdit.Invoke()

    Work.Edit was assigned a delegate in one of two ways, either of which will call Model.WorkEdit():
    1. StatusController adds a delegate when loading from a live directory scan.
    2. MruLibraryController adds a delegate when loading from a saved file.

    This WorkEdit event is heard by LFC (the LibraryFormController), which calls its own WorkEdit() method:
     \
      LFC.WorkEdit() -> CP.Run(... spoof: true) -> CP.Redo(command, spoof);

    The "spoof: true"" parameter tells CP (the CommandProcessor) that this edit has already occurred,
    so there's no need to run the Command payload; just update the stacks & menus.

    When a command is undone by selecting it on the Edit|Undo menu, the CommandProcessor does this:
     \
      CP.EditUndo_Click() -> CP.Undo() -> CP.CanUndo && CP.Undo(UndoStack.Pop()) ? CP.Undo(Command)
       \
        WorkPropertyCommand.Do() -> WorkPropertyCommand.Run()
         \
          Work.SetPropertyValue() -> Work.GetPropertyInfo().SetValue();

    This takes us back into the Work property setter, which will call the Set method at the start of this section.
    Clearly we don't want another spoof command generated!

## Contents

- <a href="#model">Model</a>
  - <a href="#library">Library</a>
  - <a href="#filter">Filter</a>
  - <a href="#tags">Tags</a>
  -  <a href="#iwork">_IWork (interface)_</a>
      - <a href="#work">Work</a>
      - <a href="#selection">Selection</a>
- <a href="#term">_Term (abstract)_</a>
  - <a href="#constant">Constant</a>
  - <a href="#field">Field</a>
  - <a href="#param">Parameter</a>
  - <a href="#termlist">TermList</a>
    - <a href="#cast">Cast</a>
    - <a href="#function">Function</a>
    - <a href="#operation">Operation</a>
      - <a href="#monad">Monadic Operation ( + - !</a> )
      - <a href="#dyad">Dyadic Operation ( + - * / &amp; | \^ = != &lt; &lt;= &gt;= &gt; )</a>
      - <a href="#triad">Triadic Operation ( ? : )</a>
- <a href="#grammar">Grammar</a>
  - <a href="#tokenizer">Tokenizer</a>
  - <a href="#parser">Parser</a>
  - <a href="#parserstate">ParserState</a>
- <a href="#dcs">Development Cheat Sheet</a>
  - <a href="#cstags">Tags</a>
  - <a href="#csfields">Fields</a>
  - <a href="#csfuncs">Functions</a>
  - <a href="#csops">Operations</a>

## Model {#model}

The __Model__ class represents the collection of _data items_ (also known as _business objects_) used by the application.

The most important property of the __Model__ is its <a href="#library">Library</a>.

<a href="#contents">\^Contents</a>

## Library {#library}

In the __Library__ class, the _Works_ property is the receptacle for a list of <a href="#work">Work</a> objects. These hold the ID3 Tag information and other metadata about your media files (music, pictures, videos). _Library_ also retains, in its _Folders__ property, a list of the filesystem folders from which these works were scanned.

Finally, the Library has a property named <a href="#filter">Filter</a>, holding the current set of Term Filters for the media collection.

The _Library_ class is the basis of persistence in the application. It can save its contents to file in various formats. Its native, _Binary_ format is the most space-efficient, but there are also _XML_ and _Json_ alternatives, provided for more human readable (or _data interchange friendly_) options.

The Json implementation uses the Newtonsoft library, which tends to deserialize all integer types as _long_. This causes problems with the application's filter builder, which generally uses normal sized integers for media properties such as the number of artists on a recording, etc., with the only exception being filesystem-related metadata which use _long_ types.

<a href="#contents">\^Contents</a>

## Filter {#filter}

The __Filter__ class is the receptacle for a collection of __Term__ objects, any _one_ of which may be selected to apply to the data. The _ResultType_ of a __Term__ in a __Filter__ must be _bool_.

At runtime, the selected __Term__ is converted to a _Predicate_ and applied to the list of data in the __Model__. If the selected __Term__ returns _true_ for any given item, then the item is displayed normally in the set presented to the user. If it returns _false_, then depending on the currently chosen _Filter Action_, that item will either be grayed out, or entirely hidden.

<a href="#contents">\^Contents</a>

## Tags {#tags}

<a href="#contents">\^Contents</a>

## IWork (interface) {#iwork}

<a href="#contents">\^Contents</a>

## Work {#work}

<a href="#contents">\^Contents</a>

## Selection {#selection}

<a href="#contents">\^Contents</a>

## Term (abstract) {#term}

The __Term__ class is the abstract base of the following hierarchy:

- ___Term__ (abstract)_
  - <a href="#constant">__Constant__</a>
  - <a href="#field">__Field__</a>
  - <a href="#param">__Parameter__</a>
  - <a href="#termlist">__TermList__</a>
    - <a href="#cast">__Cast__</a>
    - <a href="#function">__Function__</a>
    - <a href="#operation">__Operation__</a>

These and several other related classes and types are grouped together under the _TagScanner.Terms_ namespace, distinct from the _TagScanner.Models_ namespace in general use up to this point in the document.

<a href="#contents">\^Contents</a>

## Constant {#constant}

The __Constant__ class represents fixed values in expressions. Supported value types are _bool_, _char_, _string_, various numerical integer (_int_, _uint_, _long_, _ulong_) and floating point (_float_, _double_, _decimal_) formats, together with _TimeSpan_ and _DateTime_.

<a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Field {#field}

The __Field__ class represents domain item properties. This system was developed primarily to maintain the ID3 tags of a collection of audiovisual media, chiefly MP3 music files, so examples of fields are _Title_, _Duration_, _Album Title_, etc., or file properties such as _File Attributes_, or _File Created_.

Notice that field denotations are permitted to contain spaces and other non-alphanumeric characters.

At runtime, the full list of accessible fields, together with their various metadata, will be assembled from the attributes attached to properties in the _Selection_ class. This is so for historical reasons; the first UI developed for the application used the Winforms PropertyGrid control, which binds to these attributes. The next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Parameter {#param}

The __Parameter__ class is used internally, to provide the default parameter values needed while building expressions manually.

<a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## TermList {#termlist}

The __TermList__ class is represents multiterm collections.

- __TermList__
  - <a href="#cast">__Cast__</a>
  - <a href="#function">__Function__</a>
  - <a href="#operation">__Operation__</a>

<a href="#termlist">\^TermList</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Cast {#cast}

The __Cast__ class is the simplest __TermList__ descendant. Taking a single operand, it recasts its ResultType to be some other, compatible new type. For example, the expression

    # Album Artists.Cast(long)

converts the _# Album Artists_ property from a normal integer (System.Int32) to a long one (System.Int64).

<a href="#termlist">\^TermList</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Function {#function}

The __Function__ rclass epresents a C# method call, taking one __Term__ per required function argument, and returning a new __Term__ whose ResultType matches that method's return type.

Syntactically there are two varieties of __Function__, _static_ and _member_. An example of a _static_ __Function__ is _Compare_:

    Compare(1st Album Artist, "N")

This compares the value of an item's _1st Album Artist_ property to the fixed value _"N"_, and returns a __Constant Term__ representing the usual result of performing a static _Compare_ method between two strings - in this case, indicating whether the artist would appear in the first or second half of a dictionary.

By contrast, an example of a _member_ __Function__ might be

    Album Artists (joined).Contains("Beat")

which, in the case of a Beatles song, would return a __Constant Term__ with a _ResultType_ of _bool_, and a _Value_ of _true_.

The available roster of __Function__s is currently found in the _Methods.cs_ file, though the next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#contents">\^Contents</a> <a href="#term">\^Term</a> <a href="#termlist">\^TermList</a>

## Operation {#operation}

The __Operation__ class represents a C# operator call, taking one or more __Term__s, applying an __Operator__ to them, and yielding a result __Term__. The currently available set includes monadic and dyadic operators, and one triadic sample. Although several subclasses are provided for various (not all) of the available operations, there are no specific base classes for monadic, dyadic, and triadic types.

The available __Operator__ set is currently found in the _Operators.cs_ file, though the next stage of development will include moving these into readily available storage, free of recompilation requirements.

<a href="#termlist">\^TermLiat</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Monadic Operation ( + - ! ) {#monad}

The available __Monadic Operator__ set includes _unary plus (+)_, _negative (-)_, and _logical negation (!)_.

- __Operation__
  - __Positive__
  - __Negative__
  - __Negation__

Each of these has its own specialized __Operation__ subclass, __Positive__, __Negative__ and __Negation__ respectively, although they can equally be instantiated using just the __Operation__ base class and supplying the appropriate __Operator__ symbol.

<a href="#operation">\^Operation</a> <a href="#termlist">\^TermList</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Dyadic Operation ( + - * / &amp; | \^ = != &lt; &lt;= &gt;= &gt; ) {#dyad}

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

<a href="#operation">\^Operation</a> <a href="#termlist">\^TermList</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Triadic Operation ( ? : ) {#triad}

The single provided triadic operation is of course the __Conditional__, the expression equivalent of a coding _if-then-else__ construct. Here is an example of its use, first in a coding context, then in a scripting, context:

    var foo = new Conditional(Album Title.Contains("Pepper"), 10, 2); // Returns 10 for "Sgt. Pepper's", or else 2 for any pepperless title.

    Album Title.Contains("Pepper") ? 10 : 2

<a href="#operation">\^Operation</a> <a href="#termlist">\^TermList</a> <a href="#term">\^Term</a> <a href="#contents">\^Contents</a>

## Grammar {#grammar}

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

<a href="#contents">\^Contents</a>

## Tokenizer {#tokenizer}

The __Tokenizer__ class performs the first stage of expression parsing, separating the input character stream into its various recognisable language tokens.

<a href="#contents">\^Contents</a>

## Parser {#parser}

The __Parser__ class, leaning heavily on the resources of the __Tokenizer__ class, implements a <a href="https://en.wikipedia.org/wiki/Recursive_descent_parser">recursive descent parser</a> to convert the input character stream into an executable expression.

<a href="#contents">\^Contents</a>

## ParserState {#parserstate}

Class ParserState isolates the steps of the parsing process from the messy details of its mechanical implementation, allowing its major steps to be targeted with special debugging tools, and so followed much more easily.

The essential operation of Recursive Descent Parsing is beautiful to watch. This class allows the capture of each Push, Pop, Enqueue and Dequeue action, and the display of the contents of the three chief dynamic data structures in play: the _Tokens_ queue, and the _Terms_ and _Operators_ stacks.

In Visual Studio's _Output_ window, choose _Show output from: Debug_, then right-click in the window and deselect all _Messages_ except _Program Output_. Annoyingly, this has to be done for each available Message type individually!

To get these internal state data dumps to appear at runtime, define the conditional compilation symbol _DEBUG_PARSER_.

<a href="#contents">\^Contents</a>

## Development Cheat Sheet {#dcs}

### __Tags__ {#cstags}

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

<a href="#contents">\^Contents</a>

### __Fields__ {#csfields}

- Available __Field__ instances are defined by a _Dictionary<Tag, TagInfo>_ called _TagDictionary_ in the static class _TagScanner.Terms.Tags_.
- The dictionary exposes two arrays as properties of this static class: _Tag[] Keys_, and _TagInfo[] Values_.
- You may use the extension method _TagInfo(this Tag tag)_ toaccess the __Field__ metadata for a given _tag_:

      var tagInfo = tag.TagInfo();

- However, further extension methods are provided to access any other TagInfo member durectly, given just the _tag_:

      var category = tag.Category();
      var column = tag.Column(); // Width, Alignment & editor type (Text or CheckBox).
      var displayName = tag.DisplayName();

<a href="#contents">\^Contents</a>

### __Functions__ {#csfuncs}

- Available __Function__ instances are defined by a _Dictionary<string, MethodInfo>_ called _MethodDictionary_ in the static class _TagScanner.Terms.Methods_.
- The dictionary exposes two arrays as properties of this static class: _string[] Keys_, and _MethodInfo[] Values_.
- You may use the extension method _Methods.MethodInfo(this string key)_ to access the __Function__ metadata for a given _key_:

      var methodInfo = key.MethodInfo();

- If the _key_ contains an underscore, e.g. _Concat\_2_, _Concat\_3_, _Concat\_4_, the associated __Function__ is not displayed in the application UI.
- If the _key_ ends in a dollar sign, e.g. _Match$_, _Replace$_, the underlying method is a member of static class _Regex_.

<a href="#contents">\^Contents</a>

### __Operations__ {#csops}

- Available __Operation__ instances are defined by a _Dictionary<Op, OpInfo>_ called _OperatorDictionary_ in the static class _TagScanner.Terms.Operators_.
- The dictionary exposes two arrays as properties of this static class: _Op[] Keys_, and _OpInfo[] Values_.
- You may use the extension method _Operators.OpInfo(this string key)_ to access the __Operation__ metadata for a given operator _op_:

      var opInfo = op.OpInfo();

<a href="#contents">\^Contents</a>
